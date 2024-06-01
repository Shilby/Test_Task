using Microsoft.AspNetCore.Mvc;
using Test_Task.DTOs;
using Test_Task.Services;

namespace Test_Task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : Controller
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
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
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
