using Microsoft.AspNetCore.Mvc;
using Test_Task.DTOs;
using Test_Task.Services;
using Microsoft.Extensions.Logging;

namespace Test_Task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : Controller
    {
        private readonly ICandidateService _candidateService;
        private readonly ILogger<CandidateController> _logger;

        public CandidateController(ICandidateService candidateService, ILogger<CandidateController> logger)
        {
            _candidateService = candidateService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateCandidate(CandidateDto candidateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _candidateService.AddOrUpdateCandidateAsync(candidateDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding or updating the candidate.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
