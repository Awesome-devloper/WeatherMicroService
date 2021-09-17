using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Api.Model
{
    public class UserLoginDto
    {
        public string UserName { get; set; }
        public string Pasword { get; set; }
    }
    public class UserDto : UserLoginDto
    {
        private  string Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }

    }
    public class UserOutDto : UserDto
    {
        public string Token { get; set; }
    }
}
