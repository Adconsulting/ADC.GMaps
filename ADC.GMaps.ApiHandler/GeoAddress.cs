namespace ADC.GMaps.ApiHandler
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
            return string.Format(@"{0} {1}, {2} - {3} ({4}/{5}/{6})",
            Street,
            Number,
            City,
            Country,
            (Region1 ?? ""),
            (Region2 ?? ""),
            (Region3 ?? "")
            );
        }
    }
}
