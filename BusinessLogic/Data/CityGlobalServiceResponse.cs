using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BusinessLogic.Data
{
    [XmlRoot("NewDataSet")]
    public class CityGlobalServiceResponse
    {
        [XmlElement("Table")]
        public List<Table> Table { get; set; }
    }

    public class Table
    {
        [XmlElement("Country")]
        public string CountryName { get; set; }

        [XmlElement("City")]
        public string CityName { get; set; }
    }
}
