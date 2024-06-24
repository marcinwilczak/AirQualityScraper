using DataScraper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScraper.Infrastructure
{
    internal interface IStationRepository
    {
        IEnumerable<Station> FetchAllStations();

        IEnumerable<Sensor> FetchSensorsByStationId(int stationId);
    }
}