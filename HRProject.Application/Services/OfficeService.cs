using HRProject.Application.Dtos.Office;
using HRProject.Application.wrappers;
using HRProject.Domain.Entities;
using HRProject.Domain.Interfaces;

namespace HRProject.Application.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository _repo;
        public OfficeService(IOfficeRepository repo)
        {
            _repo = repo;
        }
        public async Task<ApiResponse<string>> AddAsync(OfficeReqDto officeDto)
        {
            var office = new Office
            {
                Name = officeDto.Name
            };


            await _repo.AddAsync(office);
            return ApiResponse<string>.Success("Office is added successfully!");
        }

        public async Task<ApiResponse<string>> DeleteAsync(Guid id)
        {
            var office = await _repo.GetByIdAsync(id);

            if (office == null)
            {
                return ApiResponse<string>.NotFound("Office not found!");
            }

            await _repo.DeleteAsync(office);

            return ApiResponse<string>.Success("Office is deleted successfuly");


        }





        public async Task<ApiResponse<List<OfficeResDto>>> GetAllAsync()
        {
            var offices = await _repo.GetAllAsync();
            var response = new List<OfficeResDto>();

            foreach (var office in offices)
            {
                response.Add(new OfficeResDto
                {
                    Id = office.Id,
                    Name = office.Name
                });
            }

            return ApiResponse<List<OfficeResDto>>.Success(response);
        }





        public async Task<ApiResponse<OfficeResDto>> GetByIdAsync(Guid id)
        {
            var office = await _repo.GetByIdAsync(id);
            if (office == null)
            {
                return null; // or throw an exception or return a custom error response
            }

            var response = new OfficeResDto
            {
                Id = office.Id,
                Name = office.Name
            };

            return ApiResponse<OfficeResDto>.Success(response);
        }


        public async Task<ApiResponse<string>> UpdateAsync(Guid id, OfficeReqDto officeDto)
        {
            var office = await _repo.GetByIdAsync(id);

            if (office == null)
            {
                return ApiResponse<string>.NotFound("Office not found!");
            }

            office.Name = officeDto.Name;

            await _repo.UpdateAsync(office);

            var response = new OfficeResDto
            {
                Id = office.Id,
                Name = office.Name
            };

            return ApiResponse<string>.Success("Office is updated successfully!");
        }

    }
}
