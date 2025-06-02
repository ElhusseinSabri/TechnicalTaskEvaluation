using DTOs.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Contoller.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewingController :ControllerBase
    {
        IReviewingService _reviewingService;

        public ReviewingController(IReviewingService reviewingService)
        {
            _reviewingService = reviewingService;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitRatings([FromBody] EmployeeRatingDto dto)
        {
            try
            {
                await _reviewingService.SubmitRatingsAsync(dto);
                return Ok(new { message = "Ratings submitted successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("reviews/{employeeName}")]
        public async Task<IActionResult> GetEmployeeEvaluations(string employeeName)
        {
            try
            {
                var result = await _reviewingService.GetEmployeeEvaluationsAsync(employeeName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });

            }
        }

    }
}
