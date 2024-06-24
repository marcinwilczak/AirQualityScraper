using DataScraper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScraper.Infrastructure
{
    internal interface ICsvWriter
    {
        void WriteToCsv(IEnumerable<Station> stations, string filePath);
    }
}