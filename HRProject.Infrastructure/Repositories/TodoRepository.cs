using HRProject.Domain.Entities;
using HRProject.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HRProject.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _db;
        public TodoRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task AddAsync(Todo todo)
        {
            todo.CreatedAt = DateTime.Now;
            await _db.AddAsync(todo);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            var todos = await _db.Todos.ToListAsync();
            return todos;
        }

        public async Task DeleteAsync(Todo todo)
        {
            _db.Todos.Remove(todo);
            await _db.SaveChangesAsync();
        }



        public async Task<Todo> GetByIdAsync(Guid id)
        {
            return _db.Set<Todo>().FirstOrDefault(c => c.Id == id);
        }


        public async Task UpdateAsync(Todo todo)
        {
            var existingTodo = await _db.Todos.FindAsync(todo.Id);

            if (existingTodo != null)
            {
                existingTodo.Name = todo.Name;
                existingTodo.UpdateAt = DateTime.Now;

                _db.Todos.Update(existingTodo);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"Todo item with ID {todo.Id} not found.");
            }
        }


    }
}
