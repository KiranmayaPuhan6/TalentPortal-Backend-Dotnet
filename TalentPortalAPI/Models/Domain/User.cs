using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TalentPortalAPI.Models.Domain;
using TalentPortalAPI.CustomAnnotations;
namespace TalentPortalAPI.Models.Domain
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserFirstName { get; set; }
        public string? UserMiddleName { get; set; }

        [Required]
        public string UserLastName { get; set; }

        [Required]
        public DateTime UserDOB { get; set; }

        [Required]
        [GenderValidation(ErrorMessage = "Please choose appropriate gender")]
        public string Gender { get; set; }

        [Required]
        //[Phone]
        public long UserPhoneNumber { get; set; }
        //public Byte[]? UserResume { get; set; }

        //public Byte[]? UserImg { get; set; }
        public string UserAddress { get; set; }

        [Required]
        // [Range(5,40)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailId { get; set; }

        [Required]
        //[DataType(DataType.Password)]
        //[Range(4, 20)]
        public string Password { get; set; }

        [ForeignKey("UserType")]
        public int UserTypeId { get; set; }
        public UserType? UserType { get; set; }
    }
}
