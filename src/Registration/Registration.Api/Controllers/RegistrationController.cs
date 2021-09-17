using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Registration.Api.Entities;
using Registration.Api.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly IUserRepository _repository;

        public RegistrationController(ILogger<RegistrationController> logger, IUserRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> RegistrUser([FromBody] User user)
        {
            try
            {
                await _repository.CreateUser(user);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                return BadRequest();
            }

        }
        [Route("[action]", Name = "CheckUser")]
        [HttpPost]
        public async Task<ActionResult<User>> CheckUser([FromBody] UserLoginDto user)
        {
            try
            {

                var result = await _repository.GetUserByUserName(new User() { UserName = user.UserName, Pasword = user.Pasword });
                if (result != null)
                {
                    var newresult = new UserDto() { UserName = result.UserName, Pasword = result.Pasword, Family = result.Family, Name = result.Name };
                    return Ok(result);
                }
                else
                    return Unauthorized();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                return BadRequest();
            }

        }
    }
}
