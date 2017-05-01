using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

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
            var currentWerather = new CurrentWerather();
            var choosedCity = CityTextBox.Text;
            var weatherManager = new WeatherManager("afeced2c92fe061c2d3150a13323e4d9", choosedCity);
            try
            {
                currentWerather = await weatherManager.ParseCurrentWeatherDataFromOpenWeatherMap(currentWerather);
            }
            catch (Exception)
            {
                // ignored
            }

            const string celsiusSymbol = " ° C";
            var temperatureCurInDouble = Convert.ToDouble(currentWerather.TemperatureCur);
            temperatureCurInDouble = Convert.ToDouble(string.Format("{0:0.#}", temperatureCurInDouble));

            if (currentWerather.City != null)
            {
                TemperatureTextBlock.Text = temperatureCurInDouble + celsiusSymbol;
                CityTextBlock.Text = "Weather station: " + currentWerather.City;
                PrecipitationTextBlock.Text = "Precipitation: " + currentWerather.PrecipitationMode;
                ForecastTextBlock.Text = currentWerather.WeatherDescription;
                MinTemparatureTextBlock.Text = currentWerather.TemperatureMin + celsiusSymbol;
                MaxTemparatureTextBlock.Text = currentWerather.TemperatureMax + celsiusSymbol;
                WindSpeedTextBlock.Text = currentWerather.WindSpeed + "kph";
                WindDirectionTextBlock.Text = currentWerather.WindDirection;
                HumidityTextBlock.Text = currentWerather.HumidityValue + " " + currentWerather.HumidityUnit;
                PressureTextBlock.Text = currentWerather.PressureValue + " " + currentWerather.PressureUnit;
                WeatherImage.Source =
                    new BitmapImage(new Uri(currentWerather.WeatherIconUrl, UriKind.RelativeOrAbsolute));
            }
            else
            {
                CityTextBox.Text = "Wrong city";
            }
        }
    }
}
