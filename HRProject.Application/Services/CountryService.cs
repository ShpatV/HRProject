using HRProject.Application.Dtos.Country;
using HRProject.Application.wrappers;
using HRProject.Domain.Entities;
using HRProject.Domain.Interfaces;

namespace HRProject.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _repo;
        public CountryService(ICountryRepository repo)
        {
            _repo = repo;
        }
        public async Task<ApiResponse<string>> AddAsync(CountryReqDto countryDto)
        {
            var country = new Country
            {
                StateName = countryDto.StateName
            };


            await _repo.AddAsync(country);
            return ApiResponse<string>.Success("Country is added successfully!");
        }

        public async Task<ApiResponse<string>> DeleteAsync(Guid id)
        {
            var country = await _repo.GetByIdAsync(id);

            if (country == null)
            {
                return ApiResponse<string>.NotFound("Country not found!");
            }

            await _repo.DeleteAsync(country);
            return ApiResponse<string>.Success("Country is deleted successfuly");

        }

        public async Task<ApiResponse<List<CountryResDto>>> GetAllAsync()
        {
            var countries = await _repo.GetAllAsync();
            var response = new List<CountryResDto>();

            foreach (var country in countries)
            {
                response.Add(new CountryResDto
                {
                    Id = country.Id,
                    StateName = country.StateName
                });
            }

            return ApiResponse<List<CountryResDto>>.Success(response);
        }





        public async Task<ApiResponse<CountryResDto>> GetByIdAsync(Guid id)
        {
            var country = await _repo.GetByIdAsync(id);
            if (country == null)
            {
                return ApiResponse<CountryResDto>.NotFound("Country not found!");
            }

            var response = new CountryResDto
            {
                Id = country.Id,
                StateName = country.StateName
            };

            return ApiResponse<CountryResDto>.Success(response);
        }


        public async Task<ApiResponse<string>> UpdateAsync(Guid id, CountryReqDto countryDto)
        {
            var country = await _repo.GetByIdAsync(id);

            if (country == null)
            {
                return ApiResponse<string>.NotFound("Country not found!");
            }

            country.StateName = countryDto.StateName;

            await _repo.UpdateAsync(country);

            var response = new CountryResDto
            {
                Id = country.Id,
                StateName = country.StateName
            };

            return ApiResponse<string>.Success("Country is updated successfully!");
        }
    }
}
