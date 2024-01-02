using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TalentPortalAPI.Models.Domain;

namespace TalentPortalAPI.Models.DTO
{
    public class UserSkillDTO
    {
        
        public int UserSkillId { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public int SkillId { get; set; }    
        public Skill? Skill { get; set; }


    }
}
