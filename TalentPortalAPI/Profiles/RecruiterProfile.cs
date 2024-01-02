using AutoMapper;
using TalentPortalAPI.Models.Domain;
using TalentPortalAPI.Models.DTO;

namespace TalentPortalAPI.Profiles
{
    public class RecruiterProfile : Profile
    {
        public RecruiterProfile()
        {
            CreateMap<Recruiter, RecruiterDTO>().ReverseMap();
        }
    }
}