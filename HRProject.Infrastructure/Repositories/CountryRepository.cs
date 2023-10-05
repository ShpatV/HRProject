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
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _db;
        public CountryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task AddAsync(Country country)
        {
            country.CreatedAt = DateTime.Now;
            await _db.AddAsync(country);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Country>> GetAllAsync()
        {
            var countries = await _db.Countries.ToListAsync();
            return countries;
        }

        public async Task DeleteAsync(Country country)
        {
            _db.Countries.Remove(country);
            await _db.SaveChangesAsync();
        }



        public async Task<Country> GetByIdAsync(Guid id)
        {
            return _db.Set<Country>().FirstOrDefault(c => c.Id == id);
        }


        public async Task UpdateAsync(Country country)
        {
            var existingCountry = await _db.Countries.FindAsync(country.Id);

            if (existingCountry != null)
            {
                existingCountry.StateName = country.StateName;
                existingCountry.UpdateAt = DateTime.Now;

                _db.Countries.Update(existingCountry);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"Country  with ID {country.Id} not found.");
            }
        }

    }
}
