using AutoMapper;
using TalentPortalAPI.Models.Domain;
using TalentPortalAPI.Models.DTO;

namespace TalentPortalAPI.Profiles
{
    public class JobApplicantProfile : Profile
    {
        public JobApplicantProfile()
        {
            CreateMap<JobApplicant, JobApplicantDTO>().ReverseMap();
        }
    }
}
