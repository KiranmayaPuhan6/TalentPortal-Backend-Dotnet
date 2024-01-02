using AutoMapper;
using TalentPortalAPI.Models.Domain;
using TalentPortalAPI.Models.DTO;

namespace TalentPortalAPI.Profiles
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<Skill, SkillDTO>().ReverseMap();
        }
    }
}