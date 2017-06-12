using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    //[SerializeAs(Name ="weather")]
    public class WeatherOpenServiceResponse
    {
        [SerializeAs(Name = "id")]
        public int Id { get; set; }
        [SerializeAs(Name = "name")]
        public string Name { get; set; }

        [SerializeAs(Name = "cod")]
        public string Cod { get; set; }

        [SerializeAs(Name = "coord")]
        public Coord Coord { get; set; }

        [SerializeAs(Name = "weather")]
        public List<OpenServiceWeather> Weather { get; set; }

        [SerializeAs(Name = "base")]
        public string Base { get; set; }


        [SerializeAs(Name = "main")]
        public MainInfo Main { get; set; }

        [SerializeAs(Name = "visibility")]
        public string visibility { get; set; }

        [SerializeAs(Name = "wind")]
        public Wind Wind { get; set; }


        [SerializeAs(Name = "clouds")]
        public Cloud Clouds { get; set; }

        [SerializeAs(Name = "dt")]
        public DateTime Dt { get; set; }

        [SerializeAs(Name = "sys")]
        public WeatherSystem Sys { get; set; }

    }

    public class Wind
    {
        [SerializeAs(Name = "speed")]
        public double Speed { get; set; }

        [SerializeAs(Name = "deg")]
        public double Degree { get; set; }

    }

    public class WeatherSystem  
    {
        [SerializeAs(Name = "type")]
        public int Type { get; set; }

        [SerializeAs(Name = "id")]
        public int Id { get; set; }

        [SerializeAs(Name = "message")]
        public string Message { get; set; }

        [SerializeAs(Name = "country")]
        public string Country { get; set; }

        [SerializeAs(Name = "sunrise")]
        public string Sunrise { get; set; }

        [SerializeAs(Name = "sunset")]
        public string Sunset { get; set; }
    }

    
    public class Cloud
    {
        [SerializeAs(Name = "all")]
        public string All { get; set; }

    }

    
    public class Coord
    {
        [SerializeAs(Name = "lon")]
        public double Lon { get; set; }

        [SerializeAs(Name = "lats")]
        public double Lat { get; set; }
    }

    
    public class OpenServiceWeather {

        [SerializeAs(Name = "id")]
        public int Id { get; set; }

        [SerializeAs(Name = "main")]
        public string Main { get; set; }

        [SerializeAs(Name = "description")]
        public string Description { get; set; }

        [SerializeAs(Name = "icon")]
        public string Icon { get; set; }
    }

    
    public  class MainInfo
    {
        [SerializeAs(Name = "temp")]
        public double Temp { get; set; }


        [SerializeAs(Name = "pressure")]
        public double Pressure { get; set; }
            

        [SerializeAs(Name = "humidity")]
        public double Humidity { get; set; }

        [SerializeAs(Name = "temp_min")]
        public double TempMin { get; set; }

        [SerializeAs(Name = "temp_max")]
        public double TempMax { get; set; }
    }
}
