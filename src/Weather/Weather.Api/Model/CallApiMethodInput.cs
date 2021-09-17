using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Api.Model
{
    public class CallApiMethodInput
    {
        public string location { get; set; }
        public int Munit { get; set; }
    }
}
