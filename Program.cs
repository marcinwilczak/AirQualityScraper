using DataScraper.Infrastructure;
using DataScraper.Models;
using DataScraper.Services;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace DataScraper
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IStationRepository stationRepository = new StationRepository();
            IStationService stationService = new StationService(stationRepository);

            try
            {
                var stations = stationService.GetAllStations();
                foreach (var station in stations)
                {
                    Console.WriteLine($"Station #{station.Id} ({station.StationName}):");

                    var sensors = stationService.GetSensorsByStationId(station.Id);
                    if (sensors != null)
                    {
                        foreach (var sensor in sensors)
                        {
                            if (sensor.Param != null)
                            {
                                Console.WriteLine($"installation #{sensor.Id}: '{sensor.Param.ParamName}'");
                            }
                            else
                            {
                                Console.WriteLine($"installation #{sensor.Id}: 'Unknown parameter'");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Failed to fetch sensors for station {station.Id}.");
                    }

                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}