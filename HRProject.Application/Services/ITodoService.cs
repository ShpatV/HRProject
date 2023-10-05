using HRProject.Application.Dtos.Todo;
using HRProject.Application.wrappers;

namespace HRProject.Application.Services
{
    public interface ITodoService
    {
        Task<ApiResponse<string>> AddAsync(TodoReqDto todoDto);
        Task<ApiResponse<List<TodoResDto>>> GetAllAsync();
        Task<ApiResponse<TodoResDto>> GetByIdAsync(Guid id);
        Task<ApiResponse<string>> UpdateAsync(Guid id, TodoReqDto todoDto);
        Task<ApiResponse<string>> DeleteAsync(Guid id);
    }
}
