using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TalentPortalAPI.Models.Domain;
using TalentPortalAPI.CustomAnnotations;

namespace TalentPortalAPI.Models.DTO
{
    public class JobApplicantDTO
    {   
        public int JobApplicantId { get; set; }

        public string ApplicationStatus { get; set; }

        //public Byte[]? UserResume { get; set; }

        public int JobId { get; set; }
        public Job? Job { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
