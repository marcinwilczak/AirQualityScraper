using DataScraper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScraper.Services
{
    internal interface IStationService
    {
        IEnumerable<Station> GetAllStations();

        IEnumerable<Sensor> GetSensorsByStationId(int stationId);
    }
}