using Microsoft.EntityFrameworkCore;
using MovieBooking.Data.Models;
using MovieBooking.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.Data.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private readonly ApplicationDbContext _db;
        public MovieRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Movie>> GetMoviesByShowDateAsync(DateOnly givenDate)
        {
            var givenDateWithTime = givenDate.ToDateTime(TimeOnly.MinValue);
            var movieIds = await _db.Shows
              .Where(s => s.StartDate <= givenDateWithTime &&
                          s.EndDate >= givenDateWithTime)
              .Select(s => s.MovieId)
              .Distinct()
              .ToListAsync();

            // Now fetch the movies corresponding to those MovieIds
            var movies = await _db.Movies
                .Where(m => movieIds.Contains(m.Id))
                .ToListAsync();

            return movies;
        }
    }
}
