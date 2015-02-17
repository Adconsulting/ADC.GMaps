using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ADC.GMaps.ApiHandler.Enums.StaticMap;

namespace ADC.GMaps.ApiHandler.Models
{
    /// <summary>
    /// Get a Static map 
    /// </summary>
    public class StaticMapOptions
    {
        /// <summary>
        /// Gets or Sets the ApiKey
        /// </summary>
        public virtual string ApiKey { get; set; }

        /// <summary>
        /// Gets or Sets the Address
        /// </summary>
        public virtual GeoAddress Address { get; set; }

        /// <summary>
        /// Gets or Sets the Location
        /// </summary>
        public virtual GeoLocation Location { get; set; }

        /// <summary>
        /// Gets or Sets the ZoomLevel
        /// </summary>
        public virtual int? ZoomLevel { get; set; }

        /// <summary>
        /// Gets or Sets the MapSize
        /// </summary>
        public virtual StaticMapSize MapSize { get; set; }

        /// <summary>
        /// Gets or Sets the ImageFormat
        /// </summary>
        public virtual ImageFormat ImageFormat { get; set; }

        /// <summary>
        /// Gets or Sets the MapType
        /// </summary>
        public virtual MapType MapType { get; set; }

        /// <summary>
        /// Gets or Sets the Language
        /// </summary>
        public virtual string Language { get; set; }

        /// <summary>
        /// Gets or Sets the Markers
        /// </summary>
        public virtual List<StaticMapMarker> Markers { get; set; }



        public override string ToString()
        {
            var parameterString = new StringBuilder();

            if(Location == null && Address == null )
                throw new ArgumentNullException("Location and Address are both NULL, cannot resolve map");

            if (MapSize == null)
                throw new ArgumentNullException("No mapsize given, cannot resolve map");

            if (Location != null)
            {
                parameterString.AppendFormat(@"center={0}", Location);
            }
            else
            {
                parameterString.AppendFormat(@"center={0}", Address);
            }

            if (ZoomLevel.HasValue)
            {
                parameterString.Append("&");
                parameterString.AppendFormat("zoom={0}", ZoomLevel);
            }

            parameterString.Append("&");
            parameterString.AppendFormat("size={0}", MapSize);

            parameterString.Append("&");
            parameterString.AppendFormat(
                @"maptype={0}",
                MapType.ToString()
                    .ToLower());

            if (Markers != null && Markers.Any())
            {
                foreach (var marker in Markers)
                {
                    parameterString.Append("&");
                    parameterString.Append(marker.ToString());
                }
            }



            return parameterString.ToString();
        }
    }
}
