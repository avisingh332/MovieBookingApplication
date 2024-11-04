using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieBooking.Business.Dtos.RequestDtos;
using MovieBooking.Business.Dtos.ResponseDtos;
using MovieBooking.Business.Extensions;
using MovieBooking.Business.Services.IServices;
using MovieBooking.Data.Models;
using System.Security.Claims;

namespace MovieBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAdminService _adminService;
        public BookingController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Authorize(Roles ="User")]
        public async Task<ActionResult<ResponseDto>> CreateAsync([FromBody] BookingCreateRequestDto request)
        {
            var userId = User.GetUserId();
            if (string.IsNullOrEmpty(userId)) return ValidationProblem("Invalid User"); 
            var response = await _userService.CreateBookingAsync(request, userId);
            return Ok(new ResponseDto
            {
                IsSuccess = true,
                Message = "Booking Success",
                Result = new BookingResponseDto
                {
                    Id = response.Id,
                    ShowId = response.ShowId,
                    UserId = response.UserId,
                    MovieDetails = response.MovieDetails,
                    ShowDetails = response.ShowDetails,
                    BookingDate = response. BookingDate, 
                }
            });
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ResponseDto>> GetAllAsync()
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value; 
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;    

            if (userRole == "Admin")
            {
                // If user is Admin, return all bookings
                var allBookings = await _adminService.GetAllBookingsAsync();
                return Ok(new ResponseDto
                {
                    IsSuccess = true,
                    Message = "Fetched Successfully",
                    Result = allBookings
                });
            }
            else if (userRole == "User")
            {
                // If user is a regular user, return only their own bookings
                var userBookings = await _userService.GetAllBookingsAsync(userId);
                return Ok(new ResponseDto
                {
                    IsSuccess=true, 
                    Message ="Fetched Successfully",
                    Result = userBookings
                });
            }
            else
            {
                // Unauthorized access for unknown roles
                return Forbid();
            }
        }
               
    }
}
