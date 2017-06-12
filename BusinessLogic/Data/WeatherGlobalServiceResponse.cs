using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class WeatherGlobalServiceResponse
    {
        /// <summary>
        /// Basically equals to the City.Code
        /// </summary>
        public string Code { get; set; }
        public City City { get; set; }

        public string Location { get; set; }
        public DateTime Time { get; set; }
        public string Wind { get; set; }
        public string Visibility { get; set; }
        public string SkyConditions { get; set; }
        public double Temprature { get; set; }
        public string DewPoint { get; set; }
        public double RelativeHumidity { get; set; }
        public double Pressure { get; set; }
        
    }
}
