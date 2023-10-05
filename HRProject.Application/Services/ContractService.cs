using HRProject.Application.Dtos.Contract;
using HRProject.Application.wrappers;
using HRProject.Domain.Entities;
using HRProject.Domain.Interfaces;

namespace HRProject.Application.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _repo;
        public ContractService(IContractRepository repo)
        {
            _repo = repo;
        }
        public async Task<ApiResponse<string>> AddAsync(ContractReqDto contractDto)
        {
            var contract = new Contract
            {
                Status = contractDto.Status
            };

            await _repo.AddAsync(contract);
            return ApiResponse<string>.Success("Contract is added successfully!");
        }

        public async Task<ApiResponse<string>> DeleteAsync(Guid id)
        {
            var contract = await _repo.GetByIdAsync(id);

            if (contract == null)
            {
                return ApiResponse<string>.NotFound("Contract not found!");
            }

            await _repo.DeleteAsync(contract);

            return ApiResponse<string>.Success("Contract is deleted successfuly");


        }

        public async Task<ApiResponse<List<ContractResDto>>> GetAllAsync()
        {
            var contracts = await _repo.GetAllAsync();
            var response = new List<ContractResDto>();

            foreach (var contract in contracts)
            {
                response.Add(new ContractResDto
                {
                    Id = contract.Id,
                    Status = contract.Status,
                    CreatedAt = contract.CreatedAt
                });
            }

            return ApiResponse<List<ContractResDto>>.Success(response);
        }





        public async Task<ApiResponse<ContractResDto>> GetByIdAsync(Guid id)
        {
            var contract = await _repo.GetByIdAsync(id);
            if (contract == null)
            {
                return ApiResponse<ContractResDto>.NotFound("Contract not found!");
            }

            var response = new ContractResDto
            {
                Id = contract.Id,
                Status = contract.Status,
                CreatedAt = contract.CreatedAt
            };

            return ApiResponse<ContractResDto>.Success(response);
        }


        public async Task<ApiResponse<string>> UpdateAsync(Guid id, ContractReqDto contractDto)
        {
            var contract = await _repo.GetByIdAsync(id);

            if (contract == null)
            {
                return ApiResponse<string>.NotFound("Contract not found!");
            }

            contract.Status = contractDto.Status;

            await _repo.UpdateAsync(contract);

            var response = new ContractResDto
            {
                Id = contract.Id,
                Status = contract.Status,
                CreatedAt = contract.CreatedAt
            };

            return ApiResponse<string>.Success("Contract is updated successfully!");
        }
    }
}
