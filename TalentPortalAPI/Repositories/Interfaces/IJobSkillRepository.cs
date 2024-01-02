using TalentPortalAPI.Models.Domain;

namespace TalentPortalAPI.Repositories.Interfaces
{
    public interface IJobSkillRepository
    {
        Task<IEnumerable<JobSkill>> GetAllJobSkills(); // Works as intended
        Task<JobSkill> PostOrUpdateJobSkill(int JobId, int SkillId); // Works as intended
        Task<IEnumerable<JobSkill>> DeleteAllJobSkills(int JobId);
        Task<JobSkill> DeleteJobSkill(int JobId, int SkillId);
    }
}
