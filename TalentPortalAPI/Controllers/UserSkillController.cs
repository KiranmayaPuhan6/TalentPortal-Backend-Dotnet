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
    public class UserSkillController : ControllerBase
    {
        private readonly IUserSkillRepository userSkillRepository;
        private readonly IMapper mapper;
        public UserSkillController(IUserSkillRepository _userSkillRepository, IMapper _mapper)
        {
            userSkillRepository = _userSkillRepository;
            mapper = _mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUserSkills()
        {
            var userskilllist = await userSkillRepository.ListAllUserSkills();
            if (userskilllist == null)
            {
                return NoContent();
            }
            else
            {
                var userskilllistDto = mapper.Map<List<UserSkillDTO>>(userskilllist);
                return Ok(userskilllistDto);
            }
        }

        [HttpGet("userid")]
        public async Task<IActionResult> GetUserSkillById(int userid)
        {
            var userskill = await userSkillRepository.GetUserSkillById(userid);
            if (userskill == null)
                return NoContent();
            else
            {
                var userskillDto = mapper.Map<UserSkillDTO>(userskill);
                return Ok(userskillDto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertUserSkill(UserSkill userskill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {

                var newuserskill = await userSkillRepository.AddUserSkill(userskill);
                var newuserskillDto = mapper.Map<UserSkillDTO>(newuserskill);
                return Ok(newuserskillDto);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveUserSkill(int skillId, int userId)
        {
            var deleteduserskill = await userSkillRepository.DeleteUserSkill(skillId, userId);
            if (deleteduserskill == null)
                return NoContent();
            else
            {
                var deleteduserskillDto = mapper.Map<UserSkillDTO>(deleteduserskill);
                return Ok(deleteduserskillDto);
            }
        }
    }
}
