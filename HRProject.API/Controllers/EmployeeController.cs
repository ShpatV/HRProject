using HRProject.Application.Dtos.Employee;
using HRProject.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseApiController
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(EmployeeReqDto dto)
        {
            var result = await _service.AddAsync(dto);
            return ReturnResponse(result);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return ReturnResponse(result);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return ReturnResponse(result);
        }


        [HttpDelete("Delete/{id}")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAsync(id);
            return ReturnResponse(result);
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(Guid id, EmployeeReqDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            return ReturnResponse(result);
        }
    }
}
