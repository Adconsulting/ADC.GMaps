using System.Dynamic;
using System.Text;

namespace ADC.GMaps.ApiHandler.Models
{
    public class GeoAddress
    {
        public virtual string Number { get; set; }
        public virtual string Mailbox { get; set; }
        public virtual string City { get; set; }
        public virtual string Zip { get; set; }
        public virtual string Country { get; set; }
        public virtual string Street { get; set; }
        /// <summary>
        /// Top level region (vb: vlaams gewest)
        /// </summary>
        public virtual string Region1 { get; set; }
        /// <summary>
        /// region (vb: West vlaanderen)
        /// </summary>
        public virtual string Region2 { get; set; }
        /// <summary>
        /// region (vb: Kortrijk)
        /// </summary>
        public virtual string Region3 { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendFormat(@"{0} {1}, {2}", Street, Number, City);

            if (!string.IsNullOrWhiteSpace(Country)) builder.AppendFormat(" - {0}", Country);

            if (!string.IsNullOrWhiteSpace(Region1) || !string.IsNullOrWhiteSpace(Region2)
                || !string.IsNullOrWhiteSpace(Region3))
            {
                builder.Append("(");

                if (!string.IsNullOrWhiteSpace(Region1)) builder.AppendFormat(" {0}", Region1);
                if (!string.IsNullOrWhiteSpace(Region2)) builder.AppendFormat(" {0}", Region2);
                if (!string.IsNullOrWhiteSpace(Region3)) builder.AppendFormat(" {0}", Region3);

                builder.Append(")");


            }

            return builder.ToString();
        }
    }
}
