using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ADC.GMaps.ApiHandler.Enums.StaticMap;

namespace ADC.GMaps.ApiHandler.Models
{
    public class StaticMapMarker
    {
        /// <summary>
        /// Gets or Sets the Color
        /// Availible colors: black, brown, green, purple, yellow, blue, gray, orange, red, white
        /// </summary>
        public virtual string Color { get; set; }

        /// <summary>
        /// Gets or Sets the MarkerSize
        /// </summary>
        public virtual MarkerSize MarkerSize { get; set; }

        /// <summary>
        /// Gets or Sets the Label
        /// </summary>
        public virtual Char Label { get; set; }

        /// <summary>
        /// Gets or Sets the Location
        /// </summary>
        public virtual GeoLocation Location { get; set; }

        /// <summary>
        /// Gets or Sets the Address
        /// </summary>
        public virtual GeoAddress Address { get; set; }


        public override string ToString()
        {
            var marker = new StringBuilder();

            marker.Append("markers=");
            if (!string.IsNullOrWhiteSpace(Color))
            {
                marker.AppendFormat("color:{0}", Color);
            }

            if (Label != null)
            {
                if (marker.ToString().Last() != '=') marker.Append("|");
                marker.AppendFormat("label:{0}", Label.ToString(CultureInfo.InvariantCulture).ToUpper());
            }
            if (Location != null)
            {
                if (marker.ToString().Last() != '=') marker.Append("|");
                marker.Append(Location);
            }

            if (Address != null)
            {
                if (marker.ToString().Last() != '=') marker.Append("|");
                marker.Append(Address);
            }


            return marker.ToString();
        }
    }
}
