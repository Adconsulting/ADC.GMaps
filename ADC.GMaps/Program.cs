using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ADC.GMaps.ApiHandler;

namespace ADC.GMaps
{
    class Program
    {
        static void Main(string[] args)
        {
            var location =
                Geocoding.GetLocationFromAddress(
                    new GeoAddress { Zip = "8880", City = "Sint-Eloois-Winkel", Street = "'t lindeke", Number = "13" });

            Console.WriteLine(@"Lat:{0} - Long:{1}",location.Latitude, location.Longitude);
            Console.ReadLine();
        }
    }
}
