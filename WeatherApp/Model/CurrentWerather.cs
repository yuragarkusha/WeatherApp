using System;

namespace WeatherApp.Model
{
    class CurrentWerather : Weather
    {
        private string _temperatureMin;
        private string _temperatureMax;
        public string City { get; set; }
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

        public string TemperatureMin
        {
            get { return _temperatureMin; }
            set
            {
                _temperatureMin = TemperatureFormat(value);
            }
        }

        public string TemperatureMax
        {
            get { return _temperatureMax; }
            set
            {
                _temperatureMax = TemperatureFormat(value);
            }
        }
    }
}