using HRProject.Domain.Entities;

namespace HRProject.Domain.Interfaces
{
    public interface IContractRepository
    {
        Task AddAsync(Contract contract);
        Task DeleteAsync(Contract contract);
        Task UpdateAsync(Contract contract);
        Task<Contract> GetByIdAsync(Guid id);
        Task<List<Contract>> GetAllAsync();


    }
}
