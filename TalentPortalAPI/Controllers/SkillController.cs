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
    public class SkillController : ControllerBase
    {
        private readonly ISkillRepository skillRepository;
        private readonly IMapper mapper;
        public SkillController(ISkillRepository _skillRepository, IMapper _mapper)
        {
            skillRepository = _skillRepository;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSkills()
        {

            var skills = await skillRepository.ListAllSkills();
            if(skills == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(mapper.Map<List<SkillDTO>>(skills));
            }
        }

        [HttpPost]
        public async Task<IActionResult> PutSkill(Skill skill)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sk = await skillRepository.AddSkill(skill);

            if(sk == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(mapper.Map<SkillDTO>(sk));

            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSkill(int SkillId)
        {
            var sk = await skillRepository.RemoveSkill(SkillId);

            if (sk == null)
            {
                return NoContent();
            }
            else
            {

                return Ok(mapper?.Map<SkillDTO>(sk));
            }

        }
    }
}
