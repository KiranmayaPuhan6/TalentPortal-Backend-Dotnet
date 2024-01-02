using TalentPortalAPI.Models.Domain;

namespace TalentPortalAPI.Repositories.Interfaces
{
    public interface IUserSkillRepository
    {
        Task<IEnumerable<UserSkill>> ListAllUserSkills();
        Task<UserSkill> GetUserSkillById(int userId);
        Task<UserSkill> AddUserSkill(UserSkill userSkill);
        Task<UserSkill> DeleteUserSkill(int skillId, int userId);
    }
}
