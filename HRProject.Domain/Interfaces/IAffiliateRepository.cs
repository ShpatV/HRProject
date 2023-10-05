using HRProject.Domain.Entities;

namespace HRProject.Domain.Interfaces
{
    public interface IAffiliateRepository
    {
        Task AddAsync(Affiliate employeeAffiliate);
        Task DeleteAsync(Affiliate affiliate);
        Task UpdateAsync(Affiliate employeeAffiliate);
        Task<Affiliate> GetByIdAsync(Guid id);
        Task<List<Affiliate>> GetAllAsync();
    }
}
