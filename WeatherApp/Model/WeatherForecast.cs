using System;

namespace WeatherApp.Model
{
    class WeatherForecast : Weather
    {
        public string _date;

        public string Date
        {
            get { return _date; }
            set
            {
                _date = DateFormat(value);
            }
        }

        private static string DateFormat(string date)
        {
            var dateTime = DateTime.Parse(date);
            date = dateTime.ToString("dd.MM.yy");
            return date;
        }
        
    }
}
