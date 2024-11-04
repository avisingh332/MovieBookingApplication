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
        Task<IEnumerable<ShowResponseDto>> GetAllShowsAsync(DateOnly? showDate = null, Guid? movieId = null);

        Task<ShowResponseDto> GetShowByIdAsync(Guid id);
        Task<MovieGetResponseDto> GetMovieByIdAsync(Guid id);

        Task<BookingResponseDto> CreateBookingAsync(BookingCreateRequestDto bookingCreateRequestDto, string userId);
        Task<IEnumerable<BookingResponseDto>> GetAllBookingsAsync(string userId);
    }
}
