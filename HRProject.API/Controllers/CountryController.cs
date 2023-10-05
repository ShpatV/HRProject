using HRProject.Application.Dtos.Country;
using HRProject.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController :  BaseApiController
    {
        private readonly ICountryService _service;
        public CountryController(ICountryService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CountryReqDto dto)
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
        public async Task<IActionResult> Update(Guid id, CountryReqDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            return ReturnResponse(result);
        }
    }
}
