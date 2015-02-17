﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ADC.GMaps.ApiHandler
{
    public static class Geocoding
    {
        private const string AddressBaseUri = "http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false";
        private const string BaseUri = "http://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false";

        /// <summary>
        /// Get the address from a latitude and longitude
        /// </summary>
        /// <param name="location"><see cref="GeoLocation"/></param>
        /// <returns>Null if no address is resolved</returns>
        public static GeoAddress GetAddressFromLatLong(GeoLocation location)
        {
            var requestUri = string.Format(BaseUri, location.Latitude, location.Longitude);
            using (var wc = new WebClient())
            {
                try
                {
                    var result = wc.DownloadString(new Uri(requestUri));
                    var xmlElm = XElement.Parse(result);
                    var status = (from elm in xmlElm.Descendants()
                                  where elm.Name == "status"
                                  select elm).FirstOrDefault();
                    Console.WriteLine("Google Status {0}", status);
                    if (status != null && status.Value.ToLower() == "ok")
                    {
                        var address = new GeoAddress();
                        var street = string.Empty;
                        var country = string.Empty;
                        var city = string.Empty;
                        var zip = string.Empty;
                        var region1 = string.Empty;
                        var region2 = string.Empty;
                        var region3 = string.Empty;
                        foreach (var descendant in xmlElm.Descendants("address_component"))
                        {
                            var type = descendant.Descendants("type").FirstOrDefault();
                            if (type != null && type.Value == "street_number")
                            {
                                address.Number = descendant.Descendants("long_name").First().Value;
                            }
                            if (type != null && type.Value == "route")
                            {
                                street = descendant.Descendants("long_name").First().Value;
                            }
                            if (type != null && type.Value == "locality")
                            {
                                city = descendant.Descendants("long_name").First().Value;
                            }
                            if (type != null && type.Value == "administrative_area_level_3")
                            {
                                region3 = descendant.Descendants("long_name").First().Value;
                            }
                            if (type != null && type.Value == "administrative_area_level_2")
                            {
                                region2 = descendant.Descendants("long_name").First().Value;
                            }
                            if (type != null && type.Value == "administrative_area_level_1")
                            {
                                region1 = descendant.Descendants("long_name").First().Value;
                            }
                            if (type != null && type.Value == "country")
                            {
                                country = descendant.Descendants("long_name").First().Value;
                            }
                            if (type != null && type.Value == "postal_code")
                            {
                                zip = descendant.Descendants("long_name").First().Value;
                            }
                            //Console.WriteLine(descendant.Name);
                        }
                        address.City = city;
                        address.Zip = zip;
                        address.Country = country;
                        address.Region1 = region1;
                        address.Region2 = region2;
                        address.Region3 = region3;
                        address.Street = street;
                        return address;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }


        public static GeoLocation GetLocationFromAddress(GeoAddress address)
        {
            var requestUri = string.Format(AddressBaseUri, string.Format(@"{0} {1}, {2} {3}", address.Street, address.Number, address.Zip, address.City));
            var geolocation = new GeoLocation();
            using (var wc = new WebClient())
            {
                var result = wc.DownloadString(new Uri(requestUri));
                var xmlElm = XElement.Parse(result);

                var status = (from elm in xmlElm.Descendants()
                              where elm.Name == "status"
                              select elm).FirstOrDefault();
                //Console.WriteLine("Google Status {0}", status);
                if (status != null && status.Value.ToLower() == "ok")
                {
                    var location = (from elm in xmlElm.Descendants()
                                    where elm.Name == "location"
                                    select elm).FirstOrDefault();
                    if (location != null)
                    {
                        var lat = location.Descendants("lat").First().Value;
                        var lng = location.Descendants("lng").First().Value;
                        geolocation.Latitude = lat;
                        geolocation.Longitude = lng;
                    }
                }
            }
            return geolocation;
        }
    }
}
