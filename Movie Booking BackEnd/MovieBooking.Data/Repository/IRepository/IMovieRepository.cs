using MovieBooking.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.Data.Repository.IRepository
{
    public interface IMovieRepository: IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetMoviesByShowDateAsync(DateOnly givenDate);
    }
}
