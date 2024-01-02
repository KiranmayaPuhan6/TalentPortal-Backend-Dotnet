using System.ComponentModel.DataAnnotations;

namespace TalentPortalAPI.Models.Domain
{
    public class UserLoginDetails
    {
        public string UserName { get; set; }
        public string Password { get; set; }    

    }
}
