using AutoMapper;
using TalentPortalAPI.Models.Domain;
using TalentPortalAPI.Models.DTO;

namespace TalentPortalAPI.Profiles
{
    public class UserSkillProfile : Profile
    {
        public UserSkillProfile()
        {
            CreateMap<UserSkill, UserSkillDTO>().ReverseMap();
        }
    }
}
