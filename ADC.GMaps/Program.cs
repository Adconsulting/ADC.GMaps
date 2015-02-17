using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ADC.GMaps.ApiHandler;
using ADC.GMaps.ApiHandler.Enums.StaticMap;
using ADC.GMaps.ApiHandler.Models;

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



            var mapData =
                StaticImage.GetStaticMap(
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

            var filename = string.Format(@"c:\temp\map-{0}.png", Guid.NewGuid());
            ByteArrayToFile(filename, mapData);

            Process.Start(filename);

            Console.ReadLine();
        }


        private static bool ByteArrayToFile(string _FileName, byte[] _ByteArray)
        {
            try
            {
                // Open file for reading
                System.IO.FileStream _FileStream =
                   new System.IO.FileStream(_FileName, System.IO.FileMode.Create,
                                            System.IO.FileAccess.Write);
                // Writes a block of bytes to this stream using data from
                // a byte array.
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);

                // close file stream
                _FileStream.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}",
                                  _Exception.ToString());
            }

            // error occured, return false
            return false;
        }

    }
}
