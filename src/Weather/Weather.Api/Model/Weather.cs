using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitClass
{
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

    //    {
    //  "coord": {"lon": -0.1257,"lat": 51.5085},
    //  "weather": [{"id": 804,"main": "Clouds","description": "overcast clouds","icon": "04d"}],
    //  "base": "stations",
    //  "main": { "temp": 293.86,"feels_like": 293.74, "temp_min": 292.42, "temp_max": 294.82, "pressure": 1014, "humidity": 67 },
    //  "visibility": 10000,
    //  "wind": {
    //"speed": 2.57,
    //    "deg": 0
    //  },
    //  "clouds": { "all": 100 },
    //  "dt": 1631897458,
    //  "sys": {"type": 2,"id": 2019646, "country": "GB", "sunrise": 1631857125, "sunset": 1631902284},
    //  "timezone": 3600,
    //  "id": 2643743,
    //  "name": "London",
    //  "cod": 200
    //}

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
