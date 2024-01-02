using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalentPortalAPI.Data;
using TalentPortalAPI.Models.Domain;
using TalentPortalAPI.Repositories.Interfaces;

namespace TalentPortalAPI.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly TalentPortalDbContext talentPortalDbContext;

        public SkillRepository(TalentPortalDbContext _talentPortalDbContext)
        {
            this.talentPortalDbContext = _talentPortalDbContext;
        }

        public async Task<IEnumerable<Skill>> ListAllSkills()
        {
            var skills = await talentPortalDbContext.Skills.ToListAsync();
            if (skills.Count == 0)
            {
                return null;
            }
            else
            {
                return skills;
            }
        }

        public async Task<Skill> AddSkill(Skill skill)
        {
            var checkskill = await talentPortalDbContext.Skills.FirstOrDefaultAsync(x => x.SkillId == skill.SkillId);
            if (checkskill == null)
            {
                await talentPortalDbContext.Skills.AddAsync(skill);
                await talentPortalDbContext.SaveChangesAsync();

                return skill;
            }
            else
            {
                return null;
            }
        }

        public async Task<Skill> RemoveSkill(int SkillId)
        {
            var skill = await talentPortalDbContext.Skills.FirstOrDefaultAsync(x => x.SkillId == SkillId);

            if(skill != null)
            {
                talentPortalDbContext.Skills.Remove(skill);
                await talentPortalDbContext.SaveChangesAsync();

                return skill;
            }
            else
            {
                return null;
            }
        }


    }
}
