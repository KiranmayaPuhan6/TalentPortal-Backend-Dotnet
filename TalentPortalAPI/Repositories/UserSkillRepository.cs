using Microsoft.EntityFrameworkCore;
using TalentPortalAPI.Data;
using TalentPortalAPI.Models.Domain;
using TalentPortalAPI.Repositories.Interfaces;

namespace TalentPortalAPI.Repositories
{
    public class UserSkillRepository : IUserSkillRepository
    {
        private readonly TalentPortalDbContext talentPortalDbContext;

        public UserSkillRepository(TalentPortalDbContext _talentPortalDbContext)
        {
            talentPortalDbContext = _talentPortalDbContext;
        }

        public async Task<UserSkill> AddUserSkill(UserSkill userSkill)
        {
            await talentPortalDbContext.UserSkills.AddAsync(userSkill);
            await talentPortalDbContext.SaveChangesAsync();
            return userSkill;
        }

        public async Task<UserSkill> DeleteUserSkill(int skillId, int userId)
        {
            var userskill= await talentPortalDbContext.UserSkills.FirstOrDefaultAsync(x => x.SkillId == skillId && x.UserId == userId);
            if (userskill != null)
            {
                talentPortalDbContext.UserSkills.Remove(userskill);
                await talentPortalDbContext.SaveChangesAsync();
                return userskill;
            }
            else
            {
                return null;
            }
        }

        public async Task<UserSkill> GetUserSkillById(int userId)
        {
            var userskill= await talentPortalDbContext.UserSkills.FirstOrDefaultAsync(x => x.UserId == userId);
            if (userskill == null)
            {
                return null;
            }
            else
            {
                return userskill;
            }
        }

        public async Task<IEnumerable<UserSkill>> ListAllUserSkills()
        {
            var userSkills = await talentPortalDbContext.UserSkills.ToListAsync();
            if (userSkills.Count == 0)
            {
                return null;
            }
            else
            {
                return userSkills;
            }
        }
    }
}
