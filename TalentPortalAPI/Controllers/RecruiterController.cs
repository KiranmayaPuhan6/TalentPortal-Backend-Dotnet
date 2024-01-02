using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentPortalAPI.Models.Domain;
using TalentPortalAPI.Models.DTO;
using TalentPortalAPI.Repositories.Interfaces;

namespace TalentPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterRepository recruiterRepository;
        private readonly IMapper mapper;
        public RecruiterController(IRecruiterRepository _recruiterRepository, IMapper _mapper)
        {
            recruiterRepository = _recruiterRepository;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecruiters()
        {
            var rec = await recruiterRepository.GetAllRecruiters();
            if (rec == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(mapper.Map<List<Recruiter>>(rec));

            }
        }

        [HttpPost]  
        public async Task<IActionResult> AddRecruiter(int UserId, int JobId)
        {
            var rec = await recruiterRepository.AddRecruiter(UserId, JobId);

            if (rec == null)
            {
                return Conflict();
            }
            else
            {

                var recDTO = mapper.Map<RecruiterDTO>(rec);

                return Ok(recDTO);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRecruiter(int UserId, int JobId)
        {
            var rec = await recruiterRepository.DeleteRecruiter(UserId, JobId);
            if(rec == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(mapper.Map<RecruiterDTO>(rec));
            }
            
        }
    }
}
