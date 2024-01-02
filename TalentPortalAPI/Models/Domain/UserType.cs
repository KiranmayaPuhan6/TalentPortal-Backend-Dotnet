using System.ComponentModel.DataAnnotations;

namespace TalentPortalAPI.Models.Domain
{
    public class UserType
    {
        [Key]
        public int UserTypeId { get; set; }
        [Required]
        public string UserTypeName { get; set; }
    }
}
