using System;

namespace WeatherApp.Model
{
    abstract class Weather
    {
        private string _temperatureCur;
        private string _weatherIconName;
        public string WeatherDescription { get; set; }
        public string WeatherIconUrl { get; set; }
        
        public string TemperatureCur
        {
            get { return _temperatureCur; }
            set
            {
                _temperatureCur = TemperatureFormat(value);
            }
        }
        public string WeatherIconName
        {
            get { return _weatherIconName; }
            set
            {
                _weatherIconName = value;
                WeatherIconUrl = "http://openweathermap.org/img/w/" + _weatherIconName + ".png";
            }
        }

        public string TemperatureFormat(string temperature)
        {
            const string celsiusSymbol = " ° C";
            var temperatureInDouble = Convert.ToDouble(temperature);
            temperatureInDouble = Convert.ToDouble(string.Format("{0:0.#}", temperatureInDouble));
            return temperatureInDouble.ToString() + celsiusSymbol;
        }
    }
}
