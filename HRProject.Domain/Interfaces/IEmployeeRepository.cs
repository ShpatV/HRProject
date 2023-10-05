using HRProject.Domain.Entities;

namespace HRProject.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Employee employee);
        Task DeleteAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task<Employee> GetByIdAsync(Guid id);
        Task<List<Employee>> GetAllAsync();
    }
}
