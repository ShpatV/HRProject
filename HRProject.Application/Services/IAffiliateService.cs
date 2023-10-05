using HRProject.Application.Dtos.Affiliate;
using HRProject.Application.wrappers;

namespace HRProject.Application.Services
{
    public interface IAffiliateService
    {
        Task<ApiResponse<string>> AddAsync(AffiliateReqDto affiliateDto);
        Task<ApiResponse<List<AffiliateResDto>>> GetAllAsync();
        Task<ApiResponse<AffiliateResDto>> GetByIdAsync(Guid id);
        Task<ApiResponse<string>> UpdateAsync(Guid id, AffiliateReqDto affiliateDto);
        Task<ApiResponse<string>> DeleteAsync(Guid id);
    }
}
