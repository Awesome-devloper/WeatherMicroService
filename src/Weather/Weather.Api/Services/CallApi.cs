using MassTransit;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Weather.Api.Model;

namespace Weather.Api.Services
{
    public class CallApi : ICallApi
    {
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;

        public CallApi(IBus bus, IConfiguration configuration)
        {
            _bus = bus;
            _configuration = configuration;
        }

        public async Task callApi(string location)
        {
            HttpClient http = new HttpClient();

            var myApiKey = _configuration.GetSection("Apikey").Value;
            try
            {
                HttpResponseMessage client = await http.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={location}&appid={myApiKey}");


                if (client.IsSuccessStatusCode)
                {

                    var responseStream = await client.Content.ReadAsStringAsync();
                    var weatherDto = JsonConvert.DeserializeObject<WeatherEvent>(responseStream);
                 //   new System.Linq.SystemCore_EnumerableDebugView<System.Collections.Generic.KeyValuePair<string, Newtonsoft.Json.Linq.JToken>>(weatherDto).Items[3]
                    if (weatherDto != null)
                    {

                       await _bus.Publish(weatherDto);

                    }


                }
            }
            catch (Exception ex)
            {

                throw;
            }


        }
    }
}
