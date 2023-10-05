using HRProject.Application.Dtos.Employee;
using HRProject.Application.wrappers;

namespace HRProject.Application.Services
{
    public interface IEmployeeService
    {
        Task<ApiResponse<string>> AddAsync(EmployeeReqDto employeeDto);
        Task<ApiResponse<List<EmployeeResDto>>> GetAllAsync();
        Task<ApiResponse<EmployeeResDto>> GetByIdAsync(Guid id);
        Task<ApiResponse<string>> UpdateAsync(Guid id, EmployeeReqDto countryDto);
        Task<ApiResponse<string>> DeleteAsync(Guid id);
    }
}
