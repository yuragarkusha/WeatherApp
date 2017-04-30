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
        public string WeatherUrlForXml { get; set; }
        public string City { get; set; }
        public string TemperatureCur { get; set; }
        public string TemperatureMin { get; set; }
        public string TemperatureMax { get; set; }
        public string HumidityValue { get; set; }
        public string HumidityUnit { get; set; }
        public string PressureValue { get; set; }
        public string PressureUnit { get; set; }
        public string WindSpeed { get; set; }
        public string WindDescription { get; set; }
        public string WindDirection { get; private set; }
        public string Cloudiness { get; set; }
        public string CloudinessDescription { get; set; }
        public string PrecipitationMode { get; set; }
        public string WeatherDescription { get; set; }
        public string WeatherIconName { get; set; }
        public string WeatherIconUrl { get; set; }

        public WeatherManager(string openWeatherMapAppId, string choosedCity)
        {
            this.OpenWeatherMapAppId = openWeatherMapAppId;
            this.ChoosedCity = choosedCity;
            this.WeatherUrlForXml = "http://api.openweathermap.org/data/2.5/weather?q=" + choosedCity +
                                    "&mode=xml&units=metric&APPID=" + openWeatherMapAppId;
        }

        public async void ParseCurrentWeatherDataFromOpenWeatherMap()
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
            var httpResponse = await httpClient.GetAsync(WeatherUrlForXml);
            httpResponse.EnsureSuccessStatusCode();
            var httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
            xmlDocument.LoadXml(httpResponseBody);
            //xmlDocument.Load(XmlReader.Create(new StringReader(WeatherUrlForXml)));


            City = city[0].Attributes?["name"].Value;
            TemperatureCur = temperature[0].Attributes?["value"].Value;
            TemperatureMin = temperature[0].Attributes?["min"].Value;
            TemperatureMax = temperature[0].Attributes?["max"].Value;
            HumidityValue = humidity[0].Attributes?["value"].Value;
            HumidityUnit = humidity[0].Attributes?["unit"].Value;
            PressureValue = pressure[0].Attributes?["value"].Value;
            PressureUnit = pressure[0].Attributes?["unit"].Value;
            WindSpeed = speed[0].Attributes?["value"].Value;
            WindDescription = speed[0].Attributes?["name"].Value;
            WindDirection = direction[0].Attributes?["name"].Value;
            Cloudiness = clouds[0].Attributes?["value"].Value;
            CloudinessDescription = clouds[0].Attributes?["name"].Value;
            WeatherDescription = weather[0].Attributes?["value"].Value;
            WeatherIconName = weather[0].Attributes?["icon"].Value;
            PrecipitationMode = precipitation[0].Attributes?["mode"].Value;
            WeatherIconUrl = "http://openweathermap.org/img/w/" + WeatherIconName + ".png";
        }
    }
}
