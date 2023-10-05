using HRProject.Application.Dtos.Position;
using HRProject.Application.Dtos.Position;
using HRProject.Application.wrappers;
using HRProject.Domain.Entities;
using HRProject.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject.Application.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _repo;
        public PositionService(IPositionRepository repo)
        {
            _repo = repo;
        }
        public async Task<ApiResponse<string>> AddAsync(PositionReqDto positionDto)
        {
            var position = new Position
            {
                Name = positionDto.Name
            };


            await _repo.AddAsync(position);
            return ApiResponse<string>.Success("Position is added successfully!");
        }

        public async Task<ApiResponse<string>> DeleteAsync(Guid id)
        {
            var position = await _repo.GetByIdAsync(id);

            if (position == null)
            {
                return ApiResponse<string>.NotFound("Position not found!");
            }

            await _repo.DeleteAsync(position);

            return ApiResponse<string>.Success("Position is deleted successfuly");

        }

        public async Task<ApiResponse<List<PositionResDto>>> GetAllAsync()
        {
            var positions = await _repo.GetAllAsync();
            var response = new List<PositionResDto>();

            foreach (var position in positions)
            {
                response.Add(new PositionResDto
                {
                    Id = position.Id,
                    Name = position.Name,
                    CreatedAt = position.CreatedAt
                });
            }

            return ApiResponse<List<PositionResDto>>.Success(response);
        }

        public async Task<ApiResponse<PositionResDto>> GetByIdAsync(Guid id)
        {
            var position = await _repo.GetByIdAsync(id);
            if (position == null)
            {
                return ApiResponse<PositionResDto>.NotFound("Position not found!");
            }

            var response = new PositionResDto
            {
                Id = position.Id,
                Name = position.Name,
                CreatedAt = position.CreatedAt
            };

            return ApiResponse<PositionResDto>.Success(response);
        }


        public async Task<ApiResponse<string>> UpdateAsync(Guid id, PositionReqDto positionDto)
        {
            var position = await _repo.GetByIdAsync(id);

            if (position == null)
            {
                return ApiResponse<string>.NotFound("Position not found!");
            }

            position.Name = positionDto.Name;

            await _repo.UpdateAsync(position);

            var response = new PositionResDto
            {
                Id = position.Id,
                Name= position.Name,
                CreatedAt = position.CreatedAt
            };

            return ApiResponse<string>.Success("Position is updated successfully!");
        }
    }
}
