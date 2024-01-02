using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TalentPortalAPI.Models.Domain;
using TalentPortalAPI.CustomAnnotations;

namespace TalentPortalAPI.Models.Domain
{
    public class JobApplicant
    {
        [Key]
        public int JobApplicantId { get; set; }
        
        [Required]
        [ApplicationStatusLimitationAttribute]
        public string ApplicationStatus { get; set; }

        //public Byte[]? UserResume { get; set; }

        [Required]
        [ForeignKey("Job")]
        public int JobId { get; set; }
        public Job? Job {get; set;}

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
