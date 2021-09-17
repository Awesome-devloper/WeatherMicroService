using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitClass
{
    public class WeatherCunsumer : IConsumer<WeatherEvent>
    {
        public async Task Consume(ConsumeContext<WeatherEvent> context)
        {
            System.Console.WriteLine(context.Message.main.temp-97);
        }
    }
    public class WeatherEvent
    {
        public dynamic coord { get; set; }
        public dynamic weather { get; set; }
        public string baseName { get; set; }
        public MainData main { get; set; }
        public double visibility { get; set; }
        public Wind wind { get; set; }
        public Cloud clouds { get; set; }
        public double dt { get; set; }
        public dynamic sys { get; set; }
        public decimal timezone { get; set; }
        public double id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
    public class Cloud
    {
        public decimal all { get; set; }
    }
    public class Wind
    {
        public decimal speed { get; set; }
        public decimal deg { get; set; }
    }
    public class MainData
    {
        public decimal temp { get; set; }
        public decimal feels_like { get; set; }
        public decimal temp_min { get; set; }
        public decimal temp_max { get; set; }
        public decimal pressure { get; set; }
        public decimal humidity { get; set; }

    }
}
