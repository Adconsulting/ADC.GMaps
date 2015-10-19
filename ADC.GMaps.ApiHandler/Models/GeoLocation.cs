using ADC.GMaps.ApiHandler.Enums;

namespace ADC.GMaps.ApiHandler.Models
{
    public class GeoLocation
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public LocationType LocationType { get; set; }

        public override string ToString()
        {
            return string.Format(@"{0},{1} ({2})", Latitude, Longitude, LocationType );
        }
    }
}
