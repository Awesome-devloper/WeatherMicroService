using Hangfire;
using Hangfire.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Api.Model;
using Weather.Api.Services;

namespace Weather.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WheatherController : ControllerBase
    {
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly ICallApi _callApi;

        public WheatherController(IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager, ICallApi callApi)
        {
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
            _callApi = callApi;
        }
        [HttpPost]
        public IActionResult RunApi([FromBody] CallApiMethodInput location)
        {
            if (!string.IsNullOrEmpty(location.location) && location.Munit > 0 && location.Munit < 60)
            {
                _recurringJobManager.AddOrUpdate("CallWheatherApi", () => _callApi.callApi(location.location), $"*/{location.Munit} * * * *");
                return Ok();
            }
            return BadRequest();
        }
    }
}
