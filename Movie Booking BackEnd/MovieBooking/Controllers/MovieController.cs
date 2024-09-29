using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieBooking.Business.Dtos.RequestDtos;
using MovieBooking.Business.Dtos.ResponseDtos;
using MovieBooking.Business.Services;
using MovieBooking.Business.Services.IServices;

namespace MovieBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;
        public MovieController(IAdminService adminService, IUserService userService)
        {
            _adminService = adminService;
            _userService = userService;
        }
        [HttpPost]
        public async Task<ActionResult<ResponseDto>> CreateAsync([FromBody] MovieCreateRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                               .Select(e => e.ErrorMessage)
                                               .ToList();

                return BadRequest(new ResponseDto
                {
                    IsSuccess = false,
                    Message = "Validation failed",
                    Result = errors
                });
            }

            try
            {
                MovieCreateResponseDto response = await _adminService.AddMovie(request);

                return Created($"/api/Movie/{response.Id}", new ResponseDto
                {
                    IsSuccess = true,
                    Message = "Created Successfully",
                    Result = response,
                });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto
                {
                    IsSuccess = false,
                    Message = "An error occurred while creating the product",
                    Result = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetAllAsync([FromQuery] DateOnly? showDate =null) 
        {
            IEnumerable<MovieGetResponseDto> movies = await _userService.GetAllMoviesAsync(showDate);
            return Ok(new ResponseDto
            {
                IsSuccess = true,
                Message = "Fetched Successfully",
                Result = movies
            });
        }
    }
}
