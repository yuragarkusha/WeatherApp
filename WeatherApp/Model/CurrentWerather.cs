using System;

namespace WeatherApp
{
    public class CurrentWerather
    {
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
        public string WindDirection { get; set; }
        public string Cloudiness { get; set; }
        public string CloudinessDescription { get; set; }
        public string PrecipitationMode { get; set; }
        public string WeatherDescription { get; set; }
        public string WeatherIconUrl { get; set; }
        private string _weatherIconName;
        
        

        public string WeatherIconName
        {
            get { return _weatherIconName; }
            set
            {
                _weatherIconName = value;
                WeatherIconUrl = "http://openweathermap.org/img/w/" + _weatherIconName + ".png";
            }
        }
    }
}