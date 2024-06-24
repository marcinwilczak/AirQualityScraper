using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScraper.Models
{
    internal class Sensor
    {
        public int Id { get; set; }

        public Param Param { get; set; }
    }
}