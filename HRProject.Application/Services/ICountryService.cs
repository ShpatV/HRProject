using HRProject.Application.Dtos.Country;
using HRProject.Application.wrappers;

namespace HRProject.Application.Services
{
    public interface ICountryService
    {
        Task<ApiResponse<string>> AddAsync(CountryReqDto countryDto);
        Task<ApiResponse<List<CountryResDto>>> GetAllAsync();
        Task<ApiResponse<CountryResDto>> GetByIdAsync(Guid id);
        Task<ApiResponse<string>> UpdateAsync(Guid id, CountryReqDto countryDto);
        Task<ApiResponse<string>> DeleteAsync(Guid id);
    }
}
