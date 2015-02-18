# ADC.GMaps


Small c# library for geocoding (using the google maps API)

## Nuget
https://www.nuget.org/packages/Adc.GoogleMaps.ApiHandler/

## Usage
### Get Latitude and Longitude from address
```
var address = new GeoAddress
{
    Street = "Grote Markt",
    City = "Brussel"
};

var location = Geocoding.GetLocationFromAddress(address);
Console.WriteLine(@"{0}, {1}", location.Latitude, location.Longitude);
```
### Get Address from Latitude and Longitude
```
var mylocation = new GeoLocation()
{
   Latitude = "50.25",
   Longitude = "3.15"
};

var myaddress = Geocoding.GetAddressFromLatLong(mylocation);
Console.WriteLine(myaddress.ToString());
```
### Get a static map
Get a static map for 1 location, multiple markers can be added

```
var mapData = StaticImage.GetStaticMap(
                    new StaticMapOptions
                    {
                        Location = location,
                        MapSize = new StaticMapSize { Width = 640, Height = 480 },
                        ZoomLevel = 14,
                        Markers = new List<StaticMapMarker>
                                          {
                                              new StaticMapMarker
                                                  {
                                                      Location = location,
                                                      Label = 'v',
                                                      Color = "orange"
                                                  }
                                          }
                            
                        });


```
## Feature list
### 1.1.0

 - GeoCoding.GetAddressConversionUrl
 - GeoCoding.GetLocationConversionUrl
 - StaticImage.GetStaticMapUrl

### 1.0.0
 - GeoCoding.GetAddressFromLatLong
 - GeoCoding.GetLocationFromAddress
 - StaticImage.GetStaticMap

## Todo
Streetview implementation


