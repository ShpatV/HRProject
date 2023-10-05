using HRProject.Application.Dtos.Office;
using HRProject.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : BaseApiController
    {

        private readonly IOfficeService _service;
        public OfficeController(IOfficeService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(OfficeReqDto dto)
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
        public async Task<IActionResult> Update(Guid id, OfficeReqDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            return ReturnResponse(result);
        }
    }
}
