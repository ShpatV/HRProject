using HRProject.Application.wrappers;
using Microsoft.AspNetCore.Mvc;

namespace HRProject.API.Controllers
{

    [ApiController]

    public class BaseApiController : ControllerBase
    {
       protected IActionResult ReturnResponse<T>(ApiResponse<T> response)
       {
            if(response is null)
            {
                return NotFound();
            }

            if(response.StatusCode == (int)Application.wrappers.StatusCodes.NotFound)
            {
                return NotFound(response);
            }

            if(response.StatusCode == (int)Application.wrappers.StatusCodes.BadRequest)
            {
                return BadRequest(response);
            }

            return Ok(response);
       }
    }
}