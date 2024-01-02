using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentPortalAPI.Models.Domain;
using TalentPortalAPI.Models.DTO;
using TalentPortalAPI.Repositories;
using TalentPortalAPI.Interfaces;
using TalentPortalAPI.Services;

namespace TalentPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public UserController(IUserRepository _userRepository, IMapper _mapper, IJwtAuthenticationManager _jwtAuthenticationManager)
        {
            userRepository = _userRepository;
            mapper = _mapper;
            this.jwtAuthenticationManager = _jwtAuthenticationManager;   
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User u)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                if (u.UserMiddleName != null)
                {
                    var uModel = new User()
                    {
                        UserFirstName = u.UserFirstName,
                        UserMiddleName = u.UserMiddleName,
                        UserLastName = u.UserLastName,
                        UserDOB = u.UserDOB,
                        Gender = u.Gender,
                        UserPhoneNumber = u.UserPhoneNumber,
                        //UserResume = u.UserResume,
                        //UserImg = u.UserImg,
                        UserAddress = u.UserAddress,
                        UserName = u.UserName,
                        EmailId = u.EmailId,
                        Password = u.Password,
                        UserTypeId = u.UserTypeId,
                    };
                    u = await userRepository.RegisterUser(uModel);
                    var uDto = mapper.Map<UserDTO>(u);
                    return Ok(uDto);
                }
                else
                {
                    var uModel = new User()
                    {
                        UserFirstName = u.UserFirstName,
                        UserLastName = u.UserLastName,
                        UserDOB = u.UserDOB,
                        Gender = u.Gender,
                        UserPhoneNumber = u.UserPhoneNumber,
                        //UserResume = u.UserResume,
                        //UserImg = u.UserImg,
                        UserAddress = u.UserAddress,
                        UserName = u.UserName,
                        EmailId = u.EmailId,
                        Password = u.Password,
                        UserTypeId = u.UserTypeId,
                    };
                    u = await userRepository.RegisterUser(uModel);
                    var uDto = mapper.Map<UserDTO>(u);
                    return Ok(uDto);
                }

            }
        }

        [HttpGet("uid")]
        public async Task<IActionResult> GetUserInformation(int uid)
        {
            var u = await userRepository.ReturnUserInformation(uid);
            if (u == null)
            {
                return NoContent();
            }
            else
            {
                var uDto = mapper.Map<UserDTO>(u);

                return Ok(uDto);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveUser(int uid)
        {
            var u = await userRepository.DeleteUser(uid);
            if (u == null)
            {
                return NotFound();
            }
            var uDto = mapper.Map<UserDTO>(u);
            return Ok(uDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userRepository.GetAllUsers();

            if (users == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(mapper.Map<List<UserDTO>>(users));   
            }
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserLoginDetails user) //model binding
        {
            var token = jwtAuthenticationManager.Authenticate(user.UserName, user.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
