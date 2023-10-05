using HRProject.Application.Dtos.Office;
using HRProject.Application.wrappers;

namespace HRProject.Application.Services
{
    public interface IOfficeService
    {
        Task<ApiResponse<string>> AddAsync(OfficeReqDto officeDto);
        Task<ApiResponse<List<OfficeResDto>>> GetAllAsync();
        Task<ApiResponse<OfficeResDto>> GetByIdAsync(Guid id);
        Task<ApiResponse<string>> UpdateAsync(Guid id, OfficeReqDto officeDto);
        Task<ApiResponse<string>> DeleteAsync(Guid id);
    }
}
