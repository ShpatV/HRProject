using HRProject.Application.Dtos.Position;
using HRProject.Application.wrappers;

namespace HRProject.Application.Services
{
    public interface IPositionService
    {
        Task<ApiResponse<string>> AddAsync(PositionReqDto positionDto);
        Task<ApiResponse<List<PositionResDto>>> GetAllAsync();
        Task<ApiResponse<PositionResDto>> GetByIdAsync(Guid id);
        Task<ApiResponse<string>> UpdateAsync(Guid id, PositionReqDto positionDto);
        Task<ApiResponse<string>> DeleteAsync(Guid id);
    }
}
