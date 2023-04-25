using OpenWeatherMap.Standard.Models;

namespace Weather.API.Models
{
    public class WindInfo
    {
        public WindDirection Direction { get; set; }

        public float Speed { get; set; }

        public WindInfo(Wind wind)
        {
            Speed = wind.Speed;
            Direction = (WindDirection)((wind.Degree + 22.5) % 360 / 45);
        }
    }
}
