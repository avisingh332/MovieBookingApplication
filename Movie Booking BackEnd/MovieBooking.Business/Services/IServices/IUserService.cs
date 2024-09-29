using MovieBooking.Business.Dtos.RequestDtos;
using MovieBooking.Business.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.Business.Services.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<MovieGetResponseDto>> GetAllMoviesAsync(DateOnly? showDate = null);
        Task<IEnumerable<ShowGetResponseDto>> GetAllShowsAsync(DateOnly? showDate = null, Guid? movieId = null);
    }
}
