using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using TalentPortalAPI.Data;
using TalentPortalAPI.Interfaces;
using TalentPortalAPI.Models.Domain;

namespace TalentPortalAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TalentPortalDbContext talentPortalDbContext;
        public UserRepository(TalentPortalDbContext _talentPortalDbContext)
        {
            talentPortalDbContext = _talentPortalDbContext;
        }

        public async Task<User> DeleteUser(int userid)
        {
            var user = await talentPortalDbContext.Users.FirstOrDefaultAsync(x => x.UserId == userid);
            if (user == null)
                return null;
            else
            {
                talentPortalDbContext.Users.Remove(user);
                await talentPortalDbContext.SaveChangesAsync();
            }
            return user;
        }

        public async Task<User> RegisterUser(User user)
        {
            await talentPortalDbContext.Users.AddAsync(user);
            await talentPortalDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> ReturnUserInformation(int userid)
        {
            var u = await talentPortalDbContext.Users.FirstOrDefaultAsync(x => x.UserId == userid);
            if (u == null) return null;
            if (u.UserMiddleName != null)
            {
                var user = new User()
                {
                    UserId = u.UserId,
                    UserFirstName = u.UserFirstName,
                    UserMiddleName = u.UserMiddleName,
                    UserLastName = u.UserLastName,
                    UserDOB = u.UserDOB,
                    Gender = u.Gender,
                    UserPhoneNumber = u.UserPhoneNumber,
                    //UserResume = u.UserResume,
                    //UserImg = u.UserImg,
                    UserAddress = u.UserAddress,
                    UserName = null,
                    EmailId = u.EmailId,
                    Password = null,
                };
                return user;
            }
            else
            {
                var user = new User()
                {
                    UserId = u.UserId,
                    UserFirstName = u.UserFirstName,
                    UserMiddleName = null,
                    UserLastName = u.UserLastName,
                    UserDOB = u.UserDOB,
                    Gender = u.Gender,
                    UserPhoneNumber = u.UserPhoneNumber,
                    //UserResume = u.UserResume,
                    //UserImg = u.UserImg,
                    UserAddress = u.UserAddress,
                    UserName = null,
                    EmailId = u.EmailId,
                    Password = null,
                };
                return user;
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await talentPortalDbContext.Users.ToListAsync();
            if (users.Count == 0)
            {
                return null;
            }
            else
            {
                return users;
            }
        }

        public List<User> JustWorkPlease()
        {
            return talentPortalDbContext.Users.ToList();
        }

        public async Task<User> GetUserByName(string username, string password)
        {
            var user = await talentPortalDbContext.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
            return user;

        }
    }
}

