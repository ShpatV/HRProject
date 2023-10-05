using HRProject.Domain.Entities;

namespace HRProject.Domain.Interfaces
{
    public interface ITodoRepository
    {
        Task AddAsync(Todo todo);
        Task DeleteAsync(Todo todo);
        Task UpdateAsync(Todo todo);
        Task<Todo> GetByIdAsync(Guid id);
        Task<List<Todo>> GetAllAsync();
    }
}
