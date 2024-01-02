using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TalentPortalAPI.Models.Domain;

namespace TalentPortalAPI.Models.Domain
{
    public class JobSkill
    {
        [Key]
        public int JobSkillId { get; set; }

        [ForeignKey("Job")]
        public int JobId { get; set; }
        public Job? Job { get; set; }


        [ForeignKey("Skill")]
        public int SkillId { get; set; }
        public Skill? Skill { get; set; }
    }
}
