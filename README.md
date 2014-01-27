# ADC.GMaps


Small c# library for geocoding (using the google maps API)

## Usage
### Get Latitude and Longitude from address
...
var address = new GeoAddress
{
    Street = "Grote Markt",
    City = "Brussel"
};
...
var location = Geocoding.GetLocationFromAddress(address);
Console.WriteLine(@"{0}, {1}", location.Latitude, location.Longitude);

### Get Address from Latitude and Longitude
...
var mylocation = new GeoLocation()
{
   Latitude = "50.25",
   Longitude = "3.15"
};

var myaddress = Geocoding.GetAddressFromLatLong(mylocation);
Console.WriteLine(myaddress.ToString());
...


