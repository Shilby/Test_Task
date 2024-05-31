using System.Threading.Tasks;
using Test_Task.DTOs;
using Test_Task.Models;
using Test_Task.Repository;

namespace Test_Task.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _repository;

        public CandidateService(ICandidateRepository repository)
        {
            _repository = repository;
        }

        public async Task<CandidateResponseDto> AddOrUpdateCandidateAsync(CandidateDto candidateDto)
        {
            var existingCandidate = await _repository.GetCandidateByEmailAsync(candidateDto.Email);

            if (existingCandidate != null)
            {
                existingCandidate.FirstName = candidateDto.FirstName;
                existingCandidate.LastName = candidateDto.LastName;
                existingCandidate.PhoneNumber = candidateDto.PhoneNumber;
                existingCandidate.PreferredCallTime = candidateDto.PreferredCallTime;
                existingCandidate.LinkedInUrl = candidateDto.LinkedInUrl;
                existingCandidate.GitHubUrl = candidateDto.GitHubUrl;
                existingCandidate.Comments = candidateDto.Comments;

                await _repository.UpdateCandidateAsync(existingCandidate);
                return MapToDto(existingCandidate);
            }
            else
            {
                var newCandidate = new Candidate
                {
                    FirstName = candidateDto.FirstName,
                    LastName = candidateDto.LastName,
                    PhoneNumber = candidateDto.PhoneNumber,
                    Email = candidateDto.Email,
                    PreferredCallTime = candidateDto.PreferredCallTime,
                    LinkedInUrl = candidateDto.LinkedInUrl,
                    GitHubUrl = candidateDto.GitHubUrl,
                    Comments = candidateDto.Comments
                };

                await _repository.AddCandidateAsync(newCandidate);
                return MapToDto(newCandidate);
            }
        }

        private CandidateResponseDto MapToDto(Candidate candidate)
        {
            return new CandidateResponseDto
            {
                Id = candidate.Id,
                FirstName = candidate.FirstName,
                LastName = candidate.LastName,
                PhoneNumber = candidate.PhoneNumber,
                Email = candidate.Email,
                PreferredCallTime = candidate.PreferredCallTime,
                LinkedInUrl = candidate.LinkedInUrl,
                GitHubUrl = candidate.GitHubUrl,
                Comments = candidate.Comments
            };
        }
    }
}
