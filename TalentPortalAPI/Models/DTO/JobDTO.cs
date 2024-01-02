using System.ComponentModel.DataAnnotations;

namespace TalentPortalAPI.Models.DTO
{
    public class JobDTO
    {
        
        public int JobId { get; set; }

        
        public string JobName { get; set; }

        
        public string Description { get; set; }

        
        public int Experience { get; set; }

       
        public string Location { get; set; }

        public int CountOfApplicants { get; set; }

        public int OpenApplicationCount { get; set; }
    }
}
