using HRProject.Application.Dtos.Affiliate;
using HRProject.Application.wrappers;
using HRProject.Domain.Entities;
using HRProject.Domain.Interfaces;

namespace HRProject.Application.Services
{
    public class AffiliateService : IAffiliateService
    {
        private readonly IAffiliateRepository _repo;
        public AffiliateService(IAffiliateRepository repo)
        {
            _repo = repo;
        }
        public async Task<ApiResponse<string>> AddAsync(AffiliateReqDto affiliateDto)
        {
            var affiliate = new Affiliate
            {
                Name = affiliateDto.Name
            };

            await _repo.AddAsync(affiliate);

            return ApiResponse<string>.Success("Affiliate is added successfully!");
        }

        public async Task<ApiResponse<string>> DeleteAsync(Guid id)
        {
            var affiliate = await _repo.GetByIdAsync(id);

            if (affiliate == null)
            {
                return ApiResponse<string>.NotFound("Affiliate not found!");
            }

            await _repo.DeleteAsync(affiliate);
            return ApiResponse<string>.Success("Affiliate is deleted successfuly");
        }

        public async Task<ApiResponse<List<AffiliateResDto>>> GetAllAsync()
        {
            var affiliates = await _repo.GetAllAsync();
            var response = new List<AffiliateResDto>();

            foreach (var affiliate in affiliates)
            {
                response.Add(new AffiliateResDto
                {
                    Id = affiliate.Id,
                    Name = affiliate.Name,
                });
            }

            return ApiResponse<List<AffiliateResDto>>.Success(response);
        }

        public async Task<ApiResponse<AffiliateResDto>> GetByIdAsync(Guid id)
        {
            var affiliate = await _repo.GetByIdAsync(id);
            if (affiliate == null)
            {
                return ApiResponse<AffiliateResDto>.NotFound("Affiliate not found!");
            }

            var response = new AffiliateResDto
            {
                Id = affiliate.Id,
                Name = affiliate.Name,
            };

            return ApiResponse<AffiliateResDto>.Success(response);
        }


        public async Task<ApiResponse<string>> UpdateAsync(Guid id, AffiliateReqDto affiliateDto)
        {
            var affiliate = await _repo.GetByIdAsync(id);

            if (affiliate == null)
            {
                return ApiResponse<string>.NotFound("Affiliate not found!");
            }

            affiliate.Name = affiliateDto.Name;

            await _repo.UpdateAsync(affiliate);

            var response = new AffiliateResDto
            {
                Id = affiliate.Id,
                Name = affiliate.Name,
            };

            return ApiResponse<string>.Success("Affiliate is updated successfully!");
        }
    }
}
