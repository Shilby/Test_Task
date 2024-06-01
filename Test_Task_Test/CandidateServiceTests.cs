using Microsoft.Extensions.Caching.Memory;
using Moq;
using Test_Task.DTOs;
using Test_Task.Models;
using Test_Task.Repository;
using Test_Task.Services;

namespace Test_Task_Test
{
    public class CandidateServiceTests
    {
        private readonly Mock<ICandidateRepository> _candidateRepositoryMock;
        private readonly CandidateService _candidateService;

        public CandidateServiceTests()
        {
            _candidateRepositoryMock = new Mock<ICandidateRepository>();
            _candidateService = new CandidateService(_candidateRepositoryMock.Object);
        }

        [Fact]
        public async Task AddOrUpdateCandidateAsync_ShouldAddCandidate_WhenNewCandidate()
        {
            // Arrange
            var candidateDto = new CandidateDto
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Comments = "Test comment"
            };

            _candidateRepositoryMock.Setup(repo => repo.GetCandidateByEmailAsync(candidateDto.Email)).ReturnsAsync((Candidate)null);

            // Act
            var result = await _candidateService.AddOrUpdateCandidateAsync(candidateDto);

            // Assert
            _candidateRepositoryMock.Verify(repo => repo.AddCandidateAsync(It.IsAny<Candidate>()), Times.Once);
            Assert.Equal(candidateDto.FirstName, result.FirstName);
        }

        [Fact]
        public async Task AddOrUpdateCandidateAsync_ShouldUpdateCandidate_WhenExistingCandidate()
        {
            // Arrange
            var existingCandidate = new Candidate
            {
                Id = 1,
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane.doe@example.com",
                Comments = "Existing comment"
            };

            var candidateDto = new CandidateDto
            {
                FirstName = "Jane Updated",
                LastName = "Doe",
                Email = "jane.doe@example.com",
                Comments = "Updated comment"
            };

            _candidateRepositoryMock.Setup(repo => repo.GetCandidateByEmailAsync(candidateDto.Email)).ReturnsAsync(existingCandidate);

            // Act
            var result = await _candidateService.AddOrUpdateCandidateAsync(candidateDto);

            // Assert
            _candidateRepositoryMock.Verify(repo => repo.UpdateCandidateAsync(It.IsAny<Candidate>()), Times.Once);
            Assert.Equal(candidateDto.FirstName, result.FirstName);
        }
    }
}

