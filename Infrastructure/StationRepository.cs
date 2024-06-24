using DataScraper.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataScraper.Infrastructure
{
    internal class StationRepository : IStationRepository
    {
        private const string StationsUrl = "http://api.gios.gov.pl/pjp-api/rest/station/findAll";
        private const string SensorsUrlTemplate = "http://api.gios.gov.pl/pjp-api/rest/station/sensors/{0}";

        private readonly RestClient _client;

        public StationRepository()
        {
            _client = new RestClient();
        }

        public IEnumerable<Station> FetchAllStations()
        {
            return FetchWithRetry<List<Station>>(StationsUrl);
        }

        public IEnumerable<Sensor> FetchSensorsByStationId(int stationId)
        {
            string url = string.Format(SensorsUrlTemplate, stationId);
            return FetchWithRetry<List<Sensor>>(url);
        }

        private T FetchWithRetry<T>(string url, int maxRetries = 3) where T : class
        {
            int retries = 0;
            while (retries < maxRetries)
            {
                try
                {
                    var request = new RestRequest(url, Method.Get);
                    var response = _client.Execute(request);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return JsonConvert.DeserializeObject<T>(response.Content);
                    }
                    else
                    {
                        Console.WriteLine($"Failed to fetch data from {url}. Status code: {response.StatusCode}");

                        if (response.StatusCode == HttpStatusCode.NotFound)
                        {
                            break; // Exit retry loop if URL is not found
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while fetching data from {url}: {ex.Message}");
                }

                retries++;
                System.Threading.Thread.Sleep(1000); // Wait for 1 second before retrying
            }

            return null;
        }
    }
}