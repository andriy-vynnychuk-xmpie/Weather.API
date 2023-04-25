namespace Weather.API
{
    public class WeatherRequest
    {
        public string City { get; set; }
        public DateTime RequestedDate {
            get;
            set;
        }
    }
}
