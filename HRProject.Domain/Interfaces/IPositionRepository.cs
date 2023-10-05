using HRProject.Domain.Entities;

namespace HRProject.Domain.Interfaces
{
    public interface IPositionRepository
    {
        Task AddAsync(Position position);
        Task DeleteAsync(Position position);
        Task UpdateAsync(Position position);
        Task<Position> GetByIdAsync(Guid id);
        Task<List<Position>> GetAllAsync();
    }
}
