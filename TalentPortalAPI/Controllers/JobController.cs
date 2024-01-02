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
    public class JobController : ControllerBase
    {
        private readonly IJobRepository jobRepository;
        private readonly IMapper mapper;
        public JobController(IJobRepository _jobRepository, IMapper _mapper)
        {
            jobRepository = _jobRepository;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobs() // Works as intended
        {
            var jobs = await jobRepository.ListAllJobs();
            if (jobs == null)
            {
                return NoContent();
            }
            var jobsDTO = mapper.Map<List<JobDTO>>(jobs);    
            return Ok(jobsDTO);
        }

        [HttpPost]
        public async Task<IActionResult> PostNewJob(Job job) // Works as intended
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var newJob = await jobRepository.PostJob(job);
                var newJobDTO = mapper.Map<JobDTO>(job);

                return Ok(newJobDTO);

            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJob(int JobId, Job job) // works as intended
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var daJob = await jobRepository.UpdateJob(JobId, job);

            if (daJob == null)
            {
                return NotFound();
            }
            else
            {

                var daJobDTO = mapper.Map<JobDTO>(daJob);

                return Ok(daJobDTO);
            }
        }

        [HttpGet("JobsPostedByUser")]
        public async Task<IActionResult> JobsPostedByUser(int UserId) // Works as intended
        {
            var jobs = await jobRepository.ListOfJobsPostedByUser(UserId);
            if(jobs == null)
            {
                return NoContent();
            }
            else
            {
                var jobsDTO = mapper.Map<List<JobDTO>>(jobs);
                return Ok(jobsDTO);
            }
            
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteJob(int JobId) // Works as intended
        {
            var job = await jobRepository.DeleteJob(JobId);
            if (job == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(job);
            }
        }

        [HttpGet("searchText")]
        public async Task<IActionResult> Get_JobsBySearchAsync(string searchText)
        {
            var result = await jobRepository.GetJobsBySearchAsync(searchText);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
