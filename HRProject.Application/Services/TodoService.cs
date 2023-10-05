using HRProject.Application.Dtos.Todo;
using HRProject.Application.wrappers;
using HRProject.Domain.Entities;
using HRProject.Domain.Interfaces;

namespace HRProject.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repo;
        public TodoService(ITodoRepository repo)
        {
            _repo = repo;
        }
        public async Task<ApiResponse<string>> AddAsync(TodoReqDto todoDto)
        {
            var todo = new Todo
            {
                Name = todoDto.Name
            };

            await _repo.AddAsync(todo);
            return ApiResponse<string>.Success("Todo is added successfully!");
        }
        
        public async Task<ApiResponse<string>> DeleteAsync(Guid id)
        {
            var todo = await _repo.GetByIdAsync(id);

            if (todo == null)
            {
                return ApiResponse<string>.NotFound("Todo not found!");
            }

            await _repo.DeleteAsync(todo);

            return ApiResponse<string>.Success("Todo is deleted successfuly");

        }

        public async Task<ApiResponse<List<TodoResDto>>> GetAllAsync()
        {
            var todos = await _repo.GetAllAsync();
            var response = new List<TodoResDto>();

            foreach(var todo in todos)
            {
                response.Add(new TodoResDto
                {
                    Id = todo.Id,
                    Name = todo.Name,
                    CreatedAt = todo.CreatedAt
                });
            }

            return ApiResponse<List<TodoResDto>>.Success(response);
        }





        public async Task<ApiResponse<TodoResDto>> GetByIdAsync(Guid id)
        {
            var todo = await _repo.GetByIdAsync(id);
            if (todo == null)
            {
                return ApiResponse<TodoResDto>.NotFound("Todo not found!");
            }

            var response = new TodoResDto
            {
                Id = todo.Id,
                Name = todo.Name,
                CreatedAt = todo.CreatedAt
            };

            return ApiResponse<TodoResDto>.Success(response);
        }


        public async Task<ApiResponse<string>> UpdateAsync(Guid id, TodoReqDto todoDto)
        {
            var todo = await _repo.GetByIdAsync(id);

            if (todo == null)
            {
                return ApiResponse<string>.NotFound("Todo not found!");
            }

            todo.Name = todoDto.Name;

            await _repo.UpdateAsync(todo);

            var response = new TodoResDto
            {
                Id = todo.Id,
                Name = todo.Name,
                CreatedAt = todo.CreatedAt
            };

            return ApiResponse<string>.Success("Todo is updated successfully!");
        }


    }
}
