using System.ComponentModel.DataAnnotations;

namespace TalentPortalAPI.Models.Domain
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }

        [Required]
        // New anmotation to only accept lowercase words
        public string SkillName { get; set; }
    }
}
