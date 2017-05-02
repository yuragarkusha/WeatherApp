using System;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;
using WeatherApp.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WeatherApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void SelectionButton_Click(object sender, RoutedEventArgs e)
        {
            const string appId = "afeced2c92fe061c2d3150a13323e4d9";
            var currentWerather = new CurrentWerather();
            var weatherForecastDay1 = new WeatherForecast();
            var weatherForecastDay2 = new WeatherForecast();
            var weatherForecastDay3 = new WeatherForecast();
            var weatherForecastDay4 = new WeatherForecast();
            var weatherForecastDay5 = new WeatherForecast();
            var choosedCity = CityTextBox.Text;
            var weatherManager = new WeatherManager(appId, choosedCity);

            try
            {
                currentWerather = await weatherManager.ParseCurrentWeatherDataFromOpenWeatherMap(currentWerather);
                weatherForecastDay1 =
                    await weatherManager.ParseWeatherForecastDataFromOpenWeatherMap(weatherForecastDay1, 1);
                weatherForecastDay2 =
                    await weatherManager.ParseWeatherForecastDataFromOpenWeatherMap(weatherForecastDay2, 2);
                weatherForecastDay3 =
                    await weatherManager.ParseWeatherForecastDataFromOpenWeatherMap(weatherForecastDay3, 3);
                weatherForecastDay4 =
                    await weatherManager.ParseWeatherForecastDataFromOpenWeatherMap(weatherForecastDay4, 4);
                weatherForecastDay5 =
                    await weatherManager.ParseWeatherForecastDataFromOpenWeatherMap(weatherForecastDay5, 5);
            }
            catch (Exception)
            {
                // ignored
            }

            if (currentWerather.City != null)
            {
                //Current weather values
                TemperatureTextBlock.Text = currentWerather.TemperatureCur;
                CityTextBlock.Text = "Weather station: " + currentWerather.City;
                PrecipitationTextBlock.Text = "Precipitation: " + currentWerather.PrecipitationMode;
                ForecastTextBlock.Text = "Weather: " + currentWerather.WeatherDescription;
                MinTemparatureTextBlock.Text = currentWerather.TemperatureMin;
                MaxTemparatureTextBlock.Text = currentWerather.TemperatureMax;
                WindSpeedTextBlock.Text = currentWerather.WindSpeed + " mps";
                WindDirectionTextBlock.Text = currentWerather.WindDirection;
                HumidityTextBlock.Text = currentWerather.HumidityValue + " " + currentWerather.HumidityUnit;
                PressureTextBlock.Text = currentWerather.PressureValue + " " + currentWerather.PressureUnit;
                WeatherImage.Source =
                    new BitmapImage(new Uri(currentWerather.WeatherIconUrl, UriKind.RelativeOrAbsolute));

                //Weather values for day 1
                DateDay1TextBlock.Text = weatherForecastDay1.Date;
                TemperatureCurDay1TextBlock.Text = weatherForecastDay1.TemperatureCur;
                WeatherDescriptionDay1TextBlock.Text = weatherForecastDay1.WeatherDescription;
                WeatherImageDay1.Source =
                    new BitmapImage(new Uri(weatherForecastDay1.WeatherIconUrl, UriKind.RelativeOrAbsolute));

                //Weather values for day 2
                DateDay2TextBlock.Text = weatherForecastDay2.Date;
                TemperatureCurDay2TextBlock.Text = weatherForecastDay2.TemperatureCur;
                WeatherDescriptionDay2TextBlock.Text = weatherForecastDay2.WeatherDescription;
                WeatherImageDay2.Source =
                    new BitmapImage(new Uri(weatherForecastDay2.WeatherIconUrl, UriKind.RelativeOrAbsolute));

                //Weather values for day 3
                DateDay3TextBlock.Text = weatherForecastDay3.Date;
                TemperatureCurDay3TextBlock.Text = weatherForecastDay3.TemperatureCur;
                WeatherDescriptionDay3TextBlock.Text = weatherForecastDay3.WeatherDescription;
                WeatherImageDay3.Source =
                    new BitmapImage(new Uri(weatherForecastDay3.WeatherIconUrl, UriKind.RelativeOrAbsolute));

                //Weather values for day 4
                DateDay4TextBlock.Text = weatherForecastDay4.Date;
                TemperatureCurDay4TextBlock.Text = weatherForecastDay4.TemperatureCur;
                WeatherDescriptionDay4TextBlock.Text = weatherForecastDay4.WeatherDescription;
                WeatherImageDay4.Source =
                    new BitmapImage(new Uri(weatherForecastDay4.WeatherIconUrl, UriKind.RelativeOrAbsolute));

                //Weather values for day 5
                DateDay5TextBlock.Text = weatherForecastDay5.Date;
                TemperatureCurDay5TextBlock.Text = weatherForecastDay5.TemperatureCur;
                WeatherDescriptionDay5TextBlock.Text = weatherForecastDay5.WeatherDescription;
                WeatherImageDay5.Source =
                    new BitmapImage(new Uri(weatherForecastDay5.WeatherIconUrl, UriKind.RelativeOrAbsolute));
            }
            else
            {
                CityTextBox.Text = "Wrong city";
            }
        }

        private void CityTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                SelectionButton_Click(sender, e);
            }
        }
    }
}
