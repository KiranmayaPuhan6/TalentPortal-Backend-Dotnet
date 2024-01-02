using TalentPortalAPI.Models.Domain;

namespace TalentPortalAPI.Repositories.Interfaces
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>> ListAllSkills();

        Task<Skill> AddSkill(Skill skill);
        Task<Skill> RemoveSkill(int SkillId);
    }
}
