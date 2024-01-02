using TalentPortalAPI.Models.Domain;

namespace TalentPortalAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<User> RegisterUser(User user);
        Task<User> ReturnUserInformation(int userid);
        Task<User> DeleteUser(int userid);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserByName(string username, string password);
        List<User> JustWorkPlease();
    }
}
