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
    public class PositionRepository : IPositionRepository
    {
        private readonly ApplicationDbContext _db;
        public PositionRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task AddAsync(Position position)
        {
            position.CreatedAt = DateTime.Now;
            await _db.AddAsync(position);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Position>> GetAllAsync()
        {
            var positions = await _db.Positions.ToListAsync();
            return positions;
        }

        public async Task DeleteAsync(Position position)
        {
            _db.Positions.Remove(position);
            await _db.SaveChangesAsync();
        }



        public async Task<Position> GetByIdAsync(Guid id)
        {
            return _db.Set<Position>().FirstOrDefault(c => c.Id == id);
        }


        public async Task UpdateAsync(Position position)
        {
            var existingPosition = await _db.Positions.FindAsync(position.Id);

            if (existingPosition != null)
            {
                existingPosition.Name = position.Name;
                existingPosition.UpdateAt = DateTime.Now;

                _db.Positions.Update(existingPosition);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"Position item with ID {position.Id} not found.");
            }
        }
    }
}
