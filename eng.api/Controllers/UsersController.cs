using AutoMapper;
using eng.api.Model;
using eng.application.Model;
using eng.application.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace eng.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersService UsersService;
        private IMapper _mapper;
        public UsersController(IUsersService usersService, IMapper mapper) 
        {
            UsersService = usersService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                return Ok(await UsersService.GetUsers());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO userDto)
        {
            try
            {
                User user = _mapper.Map<User>(userDto);
                bool result = await UsersService.CreateUser(user);
                return Ok(result);
            }
                        catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPatch]
        public async Task<IActionResult> UpdateActiveStatusForUser(Guid id, [FromBody] ActiveStatusDTO status)
        {
            try
            {
                bool newStatus = status.Active;

                return Ok(_mapper.Map<UserDTO>(await UsersService.UpdateUserStatus(id, newStatus)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserById(Guid userId)
        {
            try
            {
                return Ok(await UsersService.DeleteById(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
