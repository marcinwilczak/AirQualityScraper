using CsvHelper;
using DataScraper.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScraper.Infrastructure
{
    internal class CsvWriterService : ICsvWriter
    {
        public void WriteToCsv(IEnumerable<Station> stations, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(stations.SelectMany(station =>
                    station.Sensors.Select(sensor => new
                    {
                        StationId = station.Id,
                        StationName = station.StationName,
                        SensorId = sensor.Id,
                        ParameterName = sensor.Param?.ParamName ?? "Unknown"
                    })
                ));
            }
        }
    }
}