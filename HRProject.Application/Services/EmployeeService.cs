using HRProject.Application.Dtos.Employee;
using HRProject.Application.wrappers;
using HRProject.Domain.Entities;
using HRProject.Domain.Interfaces;

namespace HRProject.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }
        public async Task<ApiResponse<string>> AddAsync(EmployeeReqDto employeeDto)
        {
            var employee = new Employee
            {
                Name = employeeDto.Name
            };


            await _repo.AddAsync(employee);
            return ApiResponse<string>.Success("Employee is added successfully!");
        }

        public async Task<ApiResponse<string>> DeleteAsync(Guid id)
        {
            var employee = await _repo.GetByIdAsync(id);

            if (employee == null)
            {
                return ApiResponse<string>.NotFound("Employee not found!");
            }

            await _repo.DeleteAsync(employee);
            return ApiResponse<string>.Success("Employee is deleted successfuly");
        }

        public async Task<ApiResponse<List<EmployeeResDto>>> GetAllAsync()
        {
            var employees = await _repo.GetAllAsync();
            var response = new List<EmployeeResDto>();

            foreach (var employee in employees)
            {
                response.Add(new EmployeeResDto
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    CreatedAt = employee.CreatedAt
                });
            }

            return ApiResponse<List<EmployeeResDto>>.Success(response);
        }





        public async Task<ApiResponse<EmployeeResDto>> GetByIdAsync(Guid id)
        {
            var employee = await _repo.GetByIdAsync(id);
            if (employee == null)
            {
                return ApiResponse<EmployeeResDto>.NotFound("Employee not found!");
            }

            var response = new EmployeeResDto
            {
                Id = employee.Id,
                Name = employee.Name,
                CreatedAt = employee.CreatedAt
            };

            return ApiResponse<EmployeeResDto>.Success(response);
        }


        public async Task<ApiResponse<string>> UpdateAsync(Guid id, EmployeeReqDto employeeDto)
        {
            var employee = await _repo.GetByIdAsync(id);

            if (employee == null)
            {
                return ApiResponse<string>.NotFound("Employee not found!");
            }

            employee.Name = employeeDto.Name;

            await _repo.UpdateAsync(employee);

            var response = new EmployeeResDto
            {
                Id = employee.Id,
                Name = employee.Name,
                CreatedAt = employee.CreatedAt
            };

            return ApiResponse<string>.Success("Employee is updated successfully!");
        }
    }
}
