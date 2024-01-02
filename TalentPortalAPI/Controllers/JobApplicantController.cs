using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentPortalAPI.Models.Domain;
using TalentPortalAPI.Models.DTO;
using TalentPortalAPI.Repositories;
using TalentPortalAPI.Repositories.Interfaces;

namespace TalentPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicantController : ControllerBase
    {
        private readonly IJobApplicantRepository jobApplicantRepository;
        private readonly IMapper mapper;
        public JobApplicantController(IJobApplicantRepository _jobApplicantRepository, IMapper _mapper)
        {
            jobApplicantRepository = _jobApplicantRepository;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobApplicants()
        {
            var jobapplicants = await jobApplicantRepository.ListAllJobApplicants();
            if (jobapplicants == null)
            {
                return NoContent();
            }
            else
            {
                var jobapplicantsDTO = mapper.Map<List<JobApplicantDTO>>(jobapplicants);
                return Ok(jobapplicantsDTO);
            }
        }

        [HttpGet("ApplicationStatus")]
        public async Task<IActionResult> FindAppStatusAsync(int userid, int jobid)
        {
            var allstatus = await jobApplicantRepository.FindApplicationStatus(userid, jobid);

            if (allstatus == null)
            {
                return null;
            }
            else
            {
                var jobappDto = mapper.Map<JobApplicantDTO>(allstatus);

                return Ok(jobappDto.ApplicationStatus);
            }
        }
       
        [HttpGet("ListUserApplications")]
        public async Task<IActionResult> ListappjobsAsync(int userid)
        {
            var allappjobs = await jobApplicantRepository.ListApplicantJobs(userid);
            if (allappjobs == null)
            {
                return NoContent();
            }
            else
            {
                var jobnameDto = mapper.Map<List<JobDTO>>(allappjobs);

                return Ok(jobnameDto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostJobApp(JobApplicant jobapplicant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var jobapp = await jobApplicantRepository.PostJobApplication(jobapplicant);
                var jobappDTO = mapper.Map<JobApplicantDTO>(jobapp);

                return Ok(jobappDTO);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteJobApp(int UserId, int JobId)
        {
            var ja = await jobApplicantRepository.DeleteJobApplicant(UserId, JobId);
            if(ja != null)
            {
                return Ok(ja);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("UpdateJobAppStatus")]
        public async Task<IActionResult> UpdateJobAppStatus(int UserId, int JobId, string newApplicationStatus)
        {
            var ja = await jobApplicantRepository.UpdateJobApplicationStatus(UserId, JobId, newApplicationStatus);
            if (ja != null)
            {
                return Ok(ja);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
