using HRProject.Domain.Entities;

namespace HRProject.Domain.Interfaces
{
    public interface ICountryRepository
    {
        Task AddAsync(Country country);
        Task DeleteAsync(Country country);
        Task UpdateAsync(Country country);
        Task<Country> GetByIdAsync(Guid id);
        Task<List<Country>> GetAllAsync();
    }
}
