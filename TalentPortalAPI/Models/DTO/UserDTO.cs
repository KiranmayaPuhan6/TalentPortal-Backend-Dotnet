using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TalentPortalAPI.Models.Domain;

namespace TalentPortalAPI.Models.DTO
{
    public class UserDTO
    {
       
        public int UserId { get; set; }

        public string UserFirstName { get; set; }
        public string UserMiddleName { get; set; }
        
        public string UserLastName { get; set; }
        
        public DateTime UserDOB { get; set; }
        
        public string Gender { get; set; }

        
        public long UserPhoneNumber { get; set; }
        //public Byte[] UserResume { get; set; }

        //public Byte[] UserImg { get; set; }
        public string UserAddress { get; set; }

        public int UserTypeId { get; set; }
        public UserType? UserType { get; set; }
    }
}
