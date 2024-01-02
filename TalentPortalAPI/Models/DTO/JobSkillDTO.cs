using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TalentPortalAPI.Models.Domain;

namespace TalentPortalAPI.Models.DTO
{
    public class JobSkillDTO
    {
       
        public int JobSkillId { get; set; }

        public int JobId { get; set; }
        public Job? Job { get; set; }


        public int SkillId { get; set; }
        public Skill? Skill { get; set; }
    }
}
