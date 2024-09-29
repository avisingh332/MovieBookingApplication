using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieBooking.Business.Dtos.RequestDtos;
using MovieBooking.Business.Dtos.ResponseDtos;
using MovieBooking.Business.Services;
using MovieBooking.Business.Services.IServices;
using MovieBooking.Data.Models;

namespace MovieBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;

        public ShowController(IAdminService adminService, IUserService userService)
        {
            _adminService = adminService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto>> CreateAsync([FromBody] ShowCreateRequestDto request)
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
                ShowCreateResponseDto response = await _adminService.AddShow(request);

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
        public async Task<ActionResult<ResponseDto>> GetAllAsync([FromQuery] Guid? movieId=null, [FromQuery]DateOnly? showDate=null)
        {
            IEnumerable<ShowGetResponseDto> shows =await  _userService.GetAllShowsAsync(showDate, movieId);
            return Ok(new ResponseDto
            {
                IsSuccess = true,
                Message = "Fetched Successfully",
                Result = shows
            });
        }
    }
}
