using HRProject.Application.Dtos.Affiliate;
using HRProject.Application.Dtos.Contract;
using HRProject.Application.wrappers;

namespace HRProject.Application.Services
{
    public interface IContractService
    {
        Task<ApiResponse<string>> AddAsync(ContractReqDto contractDto);
        Task<ApiResponse<List<ContractResDto>>> GetAllAsync();
        Task<ApiResponse<ContractResDto>> GetByIdAsync(Guid id);
        Task<ApiResponse<string>> UpdateAsync(Guid id, ContractReqDto contractDto);
        Task<ApiResponse<string>> DeleteAsync(Guid id);
    }
}
