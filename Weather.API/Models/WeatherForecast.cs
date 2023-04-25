using OpenWeatherMap.Standard.Models;

namespace Weather.API.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public float FeelsLikeTemperature { get; set; }
        public float Temperature { get; set; }
        public Summary Summary { get; set; }
        public WindInfo WindInfo { get; set; }

        public WeatherForecast(WeatherData data) {
            Date = data.AcquisitionDateTime;
            Temperature = data.WeatherDayInfo.Temperature;
            FeelsLikeTemperature = data.WeatherDayInfo.FeelsLike;
            WindInfo = new WindInfo(data.Wind);

            if (data.Snow != null)
            {
                Summary = Summary.Snow;
            }
            else if (data.Rain != null)
            {
                Summary = Summary.Rain;
            }
            else
            {
                Summary = (Summary)(data.Clouds.All / 25.25);
            }
        }
    }
}
