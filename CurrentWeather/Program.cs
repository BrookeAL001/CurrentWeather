using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace CurrentWeather
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var apiKey = "3cfca54d2f1bd762451ef9adeae77dc9";


            while (true)
            {
                Console.WriteLine($"Please enter your zip code: ");
                var zipCode = Console.ReadLine();

                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode}&units=Imperial&appid={apiKey}";

                var response = client.GetStringAsync(weatherURL).Result;
                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                var wind = JObject.Parse(response).GetValue("wind").ToString();
                var weather = JObject.Parse(response).GetValue("weather").ToString();

                Console.WriteLine($"The forecast for today: {formattedResponse}");
                Console.WriteLine();
                Console.WriteLine($"The wind for today: {wind}");
                Console.WriteLine();
                Console.WriteLine($"The weather conditions for today: {weather}");
                Console.WriteLine();
                Console.WriteLine("Would you like to enter a different city?");
                var userInput = Console.ReadLine();
                Console.WriteLine();
                if (userInput.ToLower() == "no")
                {
                    break;
                }
            }


        }
    }
}
