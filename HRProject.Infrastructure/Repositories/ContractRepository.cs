using HRProject.Domain.Entities;
using HRProject.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HRProject.Infrastructure.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly ApplicationDbContext _db;
        public ContractRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task AddAsync(Contract contract)
        {
            contract.CreatedAt = DateTime.Now;
            await _db.AddAsync(contract);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Contract>> GetAllAsync()
        {
            var contracts = await _db.Contracts.ToListAsync();
            return contracts;
        }

        public async Task DeleteAsync(Contract contract)
        {
            _db.Contracts.Remove(contract);
            await _db.SaveChangesAsync();
        }



        public async Task<Contract> GetByIdAsync(Guid id)
        {
            return _db.Set<Contract>().FirstOrDefault(c => c.Id == id);
        }


        public async Task UpdateAsync(Contract contract)
        {
            var existingContract = await _db.Contracts.FindAsync(contract.Id);

            if (existingContract != null)
            {
                existingContract.Status = contract.Status;
                existingContract.UpdateAt = DateTime.Now;

                _db.Contracts.Update(existingContract);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"Todo item with ID {contract.Id} not found.");
            }
        }
    }
}
