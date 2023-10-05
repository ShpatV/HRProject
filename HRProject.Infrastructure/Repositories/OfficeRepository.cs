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
    public class OfficeRepository : IOfficeRepository
    {
        private readonly ApplicationDbContext _db;
        public OfficeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task AddAsync(Office office)
        {
            office.CreatedAt = DateTime.Now;
            await _db.AddAsync(office);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Office>> GetAllAsync()
        {
            var offices = await _db.Offices.ToListAsync();
            return offices;
        }

        public async Task DeleteAsync(Office office)
        {
            _db.Offices.Remove(office);
            await _db.SaveChangesAsync();
        }



        public async Task<Office> GetByIdAsync(Guid id)
        {
            return _db.Set<Office>().FirstOrDefault(c => c.Id == id);
        }


        public async Task UpdateAsync(Office office)
        {
            var existingOffice = await _db.Offices.FindAsync(office.Id);

            if (existingOffice != null)
            {
                existingOffice.Name = office.Name;
                existingOffice.UpdateAt = DateTime.Now;

                _db.Offices.Update(existingOffice);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"Office item with ID {office.Id} not found.");
            }
        }

    }
}
