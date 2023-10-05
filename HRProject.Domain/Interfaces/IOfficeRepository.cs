using HRProject.Domain.Entities;

namespace HRProject.Domain.Interfaces
{
    public interface IOfficeRepository
    {
        Task AddAsync(Office office);
        Task DeleteAsync(Office office);
        Task UpdateAsync(Office office);
        Task<Office> GetByIdAsync(Guid id);
        Task<List<Office>> GetAllAsync();
    }
}
