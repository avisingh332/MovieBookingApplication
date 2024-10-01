using MovieBooking.Business.Dtos.RequestDtos;
using MovieBooking.Business.Dtos.ResponseDtos;
using MovieBooking.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.Business.Services.IServices
{
    public interface IAdminService
    {
        Task<MovieCreateResponseDto> AddMovie(MovieCreateRequestDto request);
        Task<ShowResponseDto> AddShow(ShowCreateRequestDto request);
    }
}
