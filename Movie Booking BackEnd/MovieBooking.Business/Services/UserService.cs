using Microsoft.AspNetCore.Mvc;
using MovieBooking.Business.Dtos.ResponseDtos;
using MovieBooking.Business.Dtos.RequestDtos;
using MovieBooking.Business.Dtos.ResponseDtos;
using MovieBooking.Business.Services.IServices;
using MovieBooking.Data.Models;
using MovieBooking.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Azure;
using MovieBooking.Data.Repository;

namespace MovieBooking.Business.Services
{
    public class UserService :IUserService
    {
        private readonly IMovieRepository _movieRepo;
        private readonly IShowRepository _showRepo;
        private readonly IBookingRepository _bookingRepository;

        public UserService(IMovieRepository movieRepo, IShowRepository showRepo, IBookingRepository bookingRepository)
        {
            _movieRepo = movieRepo;
            _showRepo = showRepo;
            this._bookingRepository = bookingRepository;
        }
        public async Task<MovieGetResponseDto> GetMovieByIdAsync(Guid id)
        {
            var movie = await _movieRepo.GetAsync(m => m.Id == id);
            return new MovieGetResponseDto
            {
                Id = movie.Id,
                Name = movie.Name,
                Genre = movie.Genre,
                Director = movie.Director,
                Description = movie.Description,
            };
        }
        public async Task<IEnumerable<MovieGetResponseDto>> GetAllMoviesAsync(DateOnly? showDate = null)
        {
            IEnumerable<Movie> movies;
            if (showDate != null)
            {
                movies =  await _movieRepo.GetMoviesByShowDateAsync(showDate.Value);
            }
            else
            {
                 movies = await _movieRepo.GetAllAsync();
            }

            return movies.Select(m => new MovieGetResponseDto
            {
                Id = m.Id,
                Name = m.Name,
                Genre = m.Genre,
                Director = m.Director,
                Description = m.Description,
            }).ToList();
        }

        public async Task<IEnumerable<ShowResponseDto>> GetAllShowsAsync(DateOnly? showDate = null, Guid? movieId = null)
        {
           
            Expression<Func<Show, bool>> filter = show =>
                (!showDate.HasValue || show.StartDate.Date == showDate.Value.ToDateTime(TimeOnly.MinValue).Date) &&
                (!movieId.HasValue || show.MovieId == movieId.Value);

            // Use GetAllAsync with the filter
            IEnumerable<Show> shows = await _showRepo.GetAllAsync(filter);

            return shows.Select(s => new ShowResponseDto
            {
                Id = s.Id,
                MovieId = s.MovieId,
                ScreenNo = s.ScreenNo,
                NoOfSeats = s.NoOfSeats,
                StartDate = DateOnly.FromDateTime(s.StartDate),
                EndDate = DateOnly.FromDateTime(s.EndDate),
                StartTime = s.StartTime, 
                EndTime = s.EndTime,
                Price = s.Price,
            }).ToList();
        }
        public async Task<ShowResponseDto> GetShowByIdAsync(Guid id)
        {
            var s = await _showRepo.GetAsync(s => s.Id == id);
            return new ShowResponseDto
            {
                Id = s.Id,
                MovieId = s.MovieId,
                ScreenNo = s.ScreenNo,
                NoOfSeats = s.NoOfSeats,
                StartDate = DateOnly.FromDateTime(s.StartDate),
                EndDate = DateOnly.FromDateTime(s.EndDate),
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                Price = s.Price,
            };
        }

        public async Task<BookingResponseDto> CreateBookingAsync( BookingCreateRequestDto request, string userId)
        {

            var show = await _showRepo.GetAsync(s => s.Id == request.ShowId)
                ?? throw new ApplicationException("Show not found.");


            if (show.NoOfSeats <  request.SeatsBooked)
            {
                throw new ApplicationException("Not enough available seats.");
            }

            Guid id = Guid.NewGuid();
            var userBooking = new UserBooking
            {
                Id = id,
                ShowId = request.ShowId,
                UserId = userId,
                SeatsBooked = request.SeatsBooked,
                BookingDate = request.BookingDate.ToDateTime(TimeOnly.MinValue)
            };
            await _bookingRepository.AddAsync(userBooking);

            show.NoOfSeats -= request.SeatsBooked;
            await _showRepo.UpdateAsync(show);
            var userBookingAdded = await _bookingRepository.GetAsync(ub => ub.Id == id) ?? throw new ApplicationException("Booking Was Not Successfully");
            ShowResponseDto showDetails =await  GetShowByIdAsync(userBookingAdded.ShowId);
            MovieGetResponseDto movieDetails = await GetMovieByIdAsync(showDetails.MovieId);

            return new BookingResponseDto
            {
                Id = userBookingAdded.Id,
                ShowId = userBookingAdded.ShowId,
                UserId = userBookingAdded.UserId,
                ShowDetails = showDetails,
                MovieDetails = movieDetails,
                BookingDate = DateOnly.FromDateTime(userBookingAdded.BookingDate)
            };
        }

        public async Task<IEnumerable<BookingResponseDto>> GetAllBookingsAsync(string userId)
        {
            IEnumerable<UserBooking> bookings = await _bookingRepository.GetAllAsync(b => b.UserId == userId)
                    ?? throw new ApplicationException("Error Fetching Bookings");

            var response = bookings.Select(  b =>
            {
                var showDetails = GetShowByIdAsync(b.ShowId).GetAwaiter().GetResult();
                var movieDetails = GetMovieByIdAsync(showDetails.MovieId).GetAwaiter().GetResult();
                return new BookingResponseDto
                {
                    Id = b.Id,
                    ShowId = b.ShowId,
                    UserId = b.UserId,
                    SeatsBooked = b.SeatsBooked,
                    ShowDetails = showDetails,
                    MovieDetails = movieDetails,
                    BookingDate = DateOnly.FromDateTime(b.BookingDate)
                };
            });

            return response;
        }
    }
}
