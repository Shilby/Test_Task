using System.ComponentModel.DataAnnotations;

namespace Test_Task.Models
{
    public class Candidate
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string PreferredCallTime { get; set; }

        public string LinkedInUrl { get; set; }

        public string GitHubUrl { get; set; }

        [Required]
        public string Comments { get; set; }
    }
}
