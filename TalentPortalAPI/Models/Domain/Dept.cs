using System.ComponentModel.DataAnnotations;

namespace TalentPortalAPI.Models.Domain
{
    public class Dept
    {
        [Key]
        public int DeptId { get; set; }

        [Required]
        public string DeptName { get; set; }
    }
}
