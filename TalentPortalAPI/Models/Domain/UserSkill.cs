using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentPortalAPI.Models.Domain
{
    public class UserSkill
    {
        [Key]
        public int UserSkillId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey("Skill")]
        public int SkillId { get; set; }    
        public Skill? Skill { get; set; }


    }
}
