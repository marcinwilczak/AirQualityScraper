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
            ICsvWriter csvWriter = new CsvWriterService();

            //comment section if do not want to print results in console

            #region PrintDataInConsole

            try
            {
                var stations = stationService.GetAllStations();

                if (stations == null || !stations.Any())
                {
                    Console.WriteLine("No stations data retrieved or an error occurred.");
                    return;
                }

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

            #endregion PrintDataInConsole

            //comment section if u do not want to save data as a *.csv file

            #region SaveAsCSV

            try
            {
                var stations = stationService.GetAllStations().ToList();
                foreach (var station in stations)
                {
                    station.Sensors = stationService.GetSensorsByStationId(station.Id).ToList();
                }

                string projectRootDirectory = PathHelper.GetProjectRootDirectory();
                string filePath = Path.Combine(projectRootDirectory, @"Files/stations.csv");
                csvWriter.WriteToCsv(stations, filePath);

                Console.WriteLine($"Data has been written to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            #endregion SaveAsCSV
        }
    }
}