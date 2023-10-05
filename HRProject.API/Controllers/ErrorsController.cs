using Microsoft.AspNetCore.Mvc;

namespace HRProject.API.Controllers
{
    public class ErrorsController : ControllerBase
    {
    

        public IActionResult Error()
        {
            return Problem();
        }
      
    }
}
