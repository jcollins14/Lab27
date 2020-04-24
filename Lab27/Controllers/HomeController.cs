using Lab27.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab27.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Forecast(string lat, string lon) {
            if (lat == null)
            {
                lat = "38.47247341";
            }
            if (lon == null)
            {
                lon = "-86.9624086";
            }
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://forecast.weather.gov");
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; GrandCircus/1.0)");
            string endpoint = "MapClick.php?lat="+lat+"&lon="+lon+"&FcstType=json";
            var data = await client.GetStringAsync(endpoint);
            var result = JsonConvert.DeserializeObject<WeatherArray>(data);
            return View(result);
        }

        public IActionResult ForecastByCoord()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}