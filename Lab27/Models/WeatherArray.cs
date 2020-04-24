using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab27.Models
{
    public class WeatherArray
    {
        [JsonProperty("time")]
        public WeatherTime Time { get; set; }
        [JsonProperty("data")]
        public WeatherData Data { get; set; }
        [JsonProperty("productionCenter")]
        public string ProductionCenter { get; set; }
    }
    public class WeatherTime
    {
        public string layoutKey { get; set; }
        public List<string> startPeriodName { get; set; }
        public List<DateTime> startValidTime { get; set; }
        public List<string> tempLabel { get; set; }
    }
    public class WeatherData
    {
        public List<string> temperature { get; set; }
        public List<string> pop { get; set; }
        public List<string> weather { get; set; }
        public List<string> iconLink { get; set; }
        public List<string> hazard { get; set; }
        public List<string> hazardUrl { get; set; }
        public List<string> text { get; set; }
    }
}
