using AutoMapper;
using TalentPortalAPI.Models.Domain;
using TalentPortalAPI.Models.DTO;

namespace TalentPortalAPI.Profiles
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<Job, JobDTO>().ReverseMap();
        }
    }
}
