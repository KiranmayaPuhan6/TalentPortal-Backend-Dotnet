using System.ComponentModel.DataAnnotations;

namespace TalentPortalAPI.Models.Domain
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        [Required]
        public string JobName { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0, 30)]
        public int Experience { get; set; }

        [Required]
        public string Location { get; set; }

        public int CountOfApplicants { get; set; }

        public int OpenApplicationCount { get; set; }
    }
}
