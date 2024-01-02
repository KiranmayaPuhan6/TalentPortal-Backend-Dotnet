using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentPortalAPI.Models.DTO;
using TalentPortalAPI.Repositories.Interfaces;

namespace TalentPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSkillController : ControllerBase
    {
        private readonly IJobSkillRepository jobSkillRepository;
        private readonly IMapper mapper;
        public JobSkillController(IJobSkillRepository _jobSkillRepository, IMapper _mapper)
        {
            jobSkillRepository = _jobSkillRepository;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobSkills() // Works as intended
        {
            var jobSkills = await jobSkillRepository.GetAllJobSkills();
            if (jobSkills == null)
            {
                return NoContent();
            }
            else
            {
                var jobSkillsDTO = mapper.Map<List<JobSkillDTO>>(jobSkills);

                return Ok(jobSkillsDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostOrUpdateJobSkills(int JobId, int SkillId) // Works as intended
        {
            var jobskill = await jobSkillRepository.PostOrUpdateJobSkill(JobId, SkillId);
            if (jobskill == null)
            {
                return Conflict();
            }
            else
            {
                var jobskillDTO = mapper.Map<JobSkillDTO>(jobskill);

                return Ok(jobskillDTO);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllJobSkills(int JobId)
        {
            var jobSkills = await jobSkillRepository.DeleteAllJobSkills(JobId);

            if (jobSkills == null)
            {
                return NoContent();
            }
            else
            {
                var jobSkillsDTO = mapper.Map<List<JobSkillDTO>>(jobSkills);
                return Ok(jobSkillsDTO);
            }
        }

        [HttpDelete("DeleteSingleJobSkill")]
        public async Task<IActionResult> DeleteJobSkill(int JobId, int SkillId)
        {
            var jobskill = await jobSkillRepository.DeleteJobSkill(JobId, SkillId);   

            if(jobskill == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(mapper.Map<JobSkillDTO>(jobskill));
            }
        }
    }
}
