using DataScraper.Infrastructure;
using DataScraper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScraper.Services
{
    internal class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;

        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public IEnumerable<Station> GetAllStations()
        {
            return _stationRepository.FetchAllStations();
        }

        public IEnumerable<Sensor> GetSensorsByStationId(int stationId)
        {
            return _stationRepository.FetchSensorsByStationId(stationId);
        }
    }
}