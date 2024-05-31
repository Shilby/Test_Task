using Microsoft.EntityFrameworkCore;
using Test_Task.Data;
using Test_Task.Models;

namespace Test_Task.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly CandidateContext _context;

        public CandidateRepository(CandidateContext context)
        {
            _context = context;
        }

        public async Task<Candidate> GetCandidateByEmailAsync(string email)
        {
            return await _context.Candidates.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task AddCandidateAsync(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCandidateAsync(Candidate candidate)
        {
            _context.Candidates.Update(candidate);
            await _context.SaveChangesAsync();
        }
    }
}
