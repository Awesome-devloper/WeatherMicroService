using Login.Api.Model;
using Login.Api.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Login.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //private readonly IHttpClientFactory _clientFactory;

        private readonly ILogger<LoginController> _logger;

        public LoginController( ILogger<LoginController> logger)
        {
           // _clientFactory = clientFactory;
            _logger = logger;

        }

        [HttpPost]
        public async Task<ActionResult<UserOutDto>> Login([FromBody] UserLoginDto userLogin)
        {


            HttpClient http = new HttpClient();


            HttpResponseMessage  client =await http.PostAsync("http://registration.api/api/v1/Registration/CheckUser",
                new StringContent(JsonConvert.SerializeObject(userLogin), Encoding.UTF8, "application/json"));
            if (client.IsSuccessStatusCode)
            {

              var responseStream = await client.Content.ReadAsStringAsync();
                var Branches =  JsonConvert.DeserializeObject<UserDto>(responseStream);
                if (Branches != null)
                {
                    ///bulid token
                    ///

                    return Ok(new UserOutDto()
                    {
                        Name = Branches.Name,
                        Family = Branches.Family,
                        UserName = Branches.UserName,
                        Token = JWTGenrtor.BulidJWT(Branches)
                    });
                }
                else
                    return Ok(new UserOutDto()
                    {
                        Name = "",
                        Family = "",
                        UserName = "",
                        Token = ""
                    });
            }
            else
            {
                return Ok(new UserOutDto()
                {
                    Name = "",
                    Family = "",
                    UserName = "",
                    Token = ""
                });
            }

        }
    }
}
