using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Net;
using System.Net.Http;


namespace WeatherApp
{
    class WeatherManager
    {
        public string OpenWeatherMapAppId { get; set; }
        public string ChoosedCity { get; set; }
        public string CurrentWeatherUrlForXml { get; set; }
        
        public WeatherManager(string openWeatherMapAppId, string choosedCity)
        {
            this.OpenWeatherMapAppId = openWeatherMapAppId;
            this.ChoosedCity = choosedCity;
            this.CurrentWeatherUrlForXml = "http://api.openweathermap.org/data/2.5/weather?q=" + choosedCity +
                                    "&mode=xml&units=metric&APPID=" + openWeatherMapAppId;
        }

        public async Task<CurrentWerather> ParseCurrentWeatherDataFromOpenWeatherMap(CurrentWerather currentWerather)
        {
            var xmlDocument = new XmlDocument();

            var city = xmlDocument.GetElementsByTagName("city");
            var temperature = xmlDocument.GetElementsByTagName("temperature");
            var humidity = xmlDocument.GetElementsByTagName("humidity");
            var pressure = xmlDocument.GetElementsByTagName("pressure");
            var speed = xmlDocument.GetElementsByTagName("speed");
            var direction = xmlDocument.GetElementsByTagName("direction");
            var clouds = xmlDocument.GetElementsByTagName("clouds");
            var weather = xmlDocument.GetElementsByTagName("weather");
            var precipitation = xmlDocument.GetElementsByTagName("precipitation");

            var httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync(CurrentWeatherUrlForXml);
            httpResponse.EnsureSuccessStatusCode();
            var httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
            xmlDocument.LoadXml(httpResponseBody);

            currentWerather.City = city[0].Attributes?["name"].Value;
            currentWerather.TemperatureCur = temperature[0].Attributes?["value"].Value;
            currentWerather.TemperatureMin = temperature[0].Attributes?["min"].Value;
            currentWerather.TemperatureMax = temperature[0].Attributes?["max"].Value;
            currentWerather.HumidityValue = humidity[0].Attributes?["value"].Value;
            currentWerather.HumidityUnit = humidity[0].Attributes?["unit"].Value;
            currentWerather.PressureValue = pressure[0].Attributes?["value"].Value;
            currentWerather.PressureUnit = pressure[0].Attributes?["unit"].Value;
            currentWerather.WindSpeed = speed[0].Attributes?["value"].Value;
            currentWerather.WindDescription = speed[0].Attributes?["name"].Value;
            currentWerather.WindDirection = direction[0].Attributes?["name"].Value;
            currentWerather.Cloudiness = clouds[0].Attributes?["value"].Value;
            currentWerather.CloudinessDescription = clouds[0].Attributes?["name"].Value;
            currentWerather.WeatherDescription = weather[0].Attributes?["value"].Value;
            currentWerather.WeatherIconName = weather[0].Attributes?["icon"].Value;
            currentWerather.PrecipitationMode = precipitation[0].Attributes?["mode"].Value;

            return currentWerather;
        }
    }
}
