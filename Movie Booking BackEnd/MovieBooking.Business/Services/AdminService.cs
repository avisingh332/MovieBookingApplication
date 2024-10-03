using MovieBooking.Business.Dtos.RequestDtos;
using MovieBooking.Business.Dtos.ResponseDtos;
using MovieBooking.Business.Services.IServices;
using MovieBooking.Data.Models;
using MovieBooking.Data.Repository;
using MovieBooking.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.Business.Services
{
    public class AdminService : IAdminService
    {
        private IMovieRepository _movieRepo;
        private IShowRepository _showRepo;
        private readonly  IBookingRepository _bookingRepository;
        public AdminService(IMovieRepository movieRepo, IShowRepository showRepo, IBookingRepository bookingRepository)
        {
            _movieRepo = movieRepo;
            _showRepo = showRepo;
            _bookingRepository = bookingRepository;
        }
        public async Task<MovieCreateResponseDto> AddMovie(MovieCreateRequestDto request)
        {

            var id = Guid.NewGuid();
            Movie movie = new Movie
            {
                Id= id,
                Name= request.Name,
                Genre= request.Genre,
                Director= request.Director,
                Description= request.Description,
            };

            try
            {
                await _movieRepo.AddAsync(movie);
                Movie movieAdded = await _movieRepo.GetAsync(movie => movie.Id == id) ?? throw new ApplicationException("Product Not Created Successfully");
                MovieCreateResponseDto response = new MovieCreateResponseDto
                {
                    Id = movieAdded.Id,
                    Name = movieAdded.Name,
                    Genre = movieAdded.Genre,
                    Director = movieAdded.Director,
                    Description = movieAdded.Description,
                };
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ShowResponseDto> AddShow(ShowCreateRequestDto request)
        {
            

            var id = Guid.NewGuid();
            TimeSpan startTime;
            TimeSpan.TryParse(request.StartTime, out startTime);
            TimeSpan endTime;
            TimeSpan.TryParse(request.EndTime, out endTime);
            Show show = new Show
            {
                Id = id,
                StartDate =  request.StartDate.ToDateTime(TimeOnly.MinValue),
                EndDate = request.EndDate.ToDateTime(TimeOnly.MinValue),
                ScreenNo = request.ScreenNo,
                MovieId = request.MovieId,
                NoOfSeats = request.NoOfSeats,
                StartTime =startTime, 
                EndTime =endTime,
                Price  = request.Price,
            };
            try
            {
                await _showRepo.AddAsync(show);
                Show showAdded = await _showRepo.GetAsync(show => show.Id == id) ?? throw new ApplicationException("Show Was Not Added!!! ");
                ShowResponseDto response = new ShowResponseDto
                {
                    Id = showAdded.Id,
                    StartDate = DateOnly.FromDateTime(showAdded.StartDate),
                    EndDate = DateOnly.FromDateTime(showAdded.EndDate),
                    ScreenNo = showAdded.ScreenNo,
                    MovieId = showAdded.MovieId,
                    NoOfSeats = showAdded.NoOfSeats,
                    StartTime = showAdded.StartTime, 
                    EndTime = showAdded.EndTime,
                    Price = showAdded.Price,
                };
                return response;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<BookingResponseDto>> GetAllBookingsAsync()
        {
            IEnumerable<UserBooking> bookings = await _bookingRepository.GetAllAsync()
                    ?? throw new ApplicationException("Error Fetching Bookings");

            IEnumerable<BookingResponseDto> response = bookings.Select(b =>
            {
                return new BookingResponseDto
                {
                    Id = b.Id,
                    ShowId = b.ShowId,
                    UserId = b.UserId,
                };
            });

            return response;
        }

    }
}
