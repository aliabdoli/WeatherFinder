using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class City
    {
        public string Code { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// in case it is used as an orm navigation property
        /// </summary>
        public virtual Country Country { get; set; }
    }
}