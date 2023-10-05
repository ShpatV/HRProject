using HRProject.Domain.Entities;
using HRProject.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject.Infrastructure.Repositories
{
    public class AffiliateRepository : IAffiliateRepository
    {
        private readonly ApplicationDbContext _db;
        public AffiliateRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task AddAsync(Affiliate affiliate)
        {
            affiliate.CreatedAt = DateTime.Now;
            await _db.AddAsync(affiliate);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Affiliate>> GetAllAsync()
        {
            var affiliates = await _db.Affiliates.ToListAsync();
            return affiliates;
        }

        public async Task DeleteAsync(Affiliate affiliate)
        {
            _db.Affiliates.Remove(affiliate);
            await _db.SaveChangesAsync();
        }



        public async Task<Affiliate> GetByIdAsync(Guid id)
        {
            return _db.Set<Affiliate>().FirstOrDefault(c => c.Id == id);
        }


        public async Task UpdateAsync(Affiliate affiliate)
        {
            var existingAffiliate = await _db.Affiliates.FindAsync(affiliate.Id);

            if (existingAffiliate != null)
            {
                existingAffiliate.Name = affiliate.Name;
                existingAffiliate.UpdateAt = DateTime.Now;

                _db.Affiliates.Update(existingAffiliate);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"Todo item with ID {affiliate.Id} not found.");
            }
        }
    }
}
