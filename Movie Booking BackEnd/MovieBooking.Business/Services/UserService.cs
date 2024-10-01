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

namespace MovieBooking.Business.Services
{
    public class UserService :IUserService
    {
        private readonly IMovieRepository _movieRepo;
        private readonly IShowRepository _showRepo;

        public UserService(IMovieRepository movieRepo, IShowRepository showRepo)
        {
            _movieRepo = movieRepo;
            _showRepo = showRepo;
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
            }).ToList();
        }
    }
}
