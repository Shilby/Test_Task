using Test_Task.DTOs;
using Test_Task.Models;

namespace Test_Task.Services
{
    public interface ICandidateService
    {
        Task<CandidateResponseDto> AddOrUpdateCandidateAsync(CandidateDto candidateDto);
    }
}
