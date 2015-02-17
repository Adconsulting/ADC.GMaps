using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADC.GMaps.ApiHandler.Models
{
    /// <summary>
    /// The dimensions of the map
    /// </summary>
    public class StaticMapSize
    {
        /// <summary>
        /// Gets or Sets the Width
        /// </summary>
        public virtual int Width { get; set; }

        /// <summary>
        /// Gets or Sets the Height
        /// </summary>
        public virtual int Height { get; set; }

        public override string ToString()
        {
            return string.Format(@"{0}x{1}", Width, Height);
        }
    }
}
