namespace ADC.GMaps.ApiHandler.Models
{
    public class GeoLocation
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public override string ToString()
        {
            return string.Format(@"{0},{1}", Latitude, Longitude);
        }
    }
}
