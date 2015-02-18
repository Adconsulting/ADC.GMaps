using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using ADC.GMaps.ApiHandler.Models;

namespace ADC.GMaps.ApiHandler
{
    public static class StaticImage
    {
        private const string MapUrl = "https://maps.googleapis.com/maps/api/staticmap?{0}";

        private const string StreetViewUrl = "https://maps.googleapis.com/maps/api/streetview?{0}";

        /// <summary>
        /// Get a static map 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static byte[] GetStaticMap(StaticMapOptions options)
        {
            var url = GetStaticMapUrl(options);

            using (var wc = new WebClient())
            {
                var result = wc.DownloadData(url);

                return result;
            }
        }


        /// <summary>
        /// Get the url for a static map
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string GetStaticMapUrl(StaticMapOptions options)
        {
            return string.Format(MapUrl, options);
        }
    }
}
