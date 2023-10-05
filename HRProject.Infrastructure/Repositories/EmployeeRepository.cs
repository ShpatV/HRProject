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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task AddAsync(Employee employee)
        {
            employee.CreatedAt = DateTime.Now;
            await _db.AddAsync(employee);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            var employees = await _db.Employees.ToListAsync();
            return employees;
        }

        public async Task DeleteAsync(Employee employee)
        {
            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();
        }



        public async Task<Employee> GetByIdAsync(Guid id)
        {
            return _db.Set<Employee>().FirstOrDefault(c => c.Id == id);
        }


        public async Task UpdateAsync(Employee employee)
        {
            var existingEmployee = await _db.Employees.FindAsync(employee.Id);

            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.UpdateAt = DateTime.Now;

                _db.Employees.Update(existingEmployee);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"Todo item with ID {employee.Id} not found.");
            }
        }
    }
}
