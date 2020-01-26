using System;
using System.Collections.Generic;
using System.Text;

namespace MOQdigital.LHAntenatal.Common.DTO
{
    public class AddressSearchResult
    {
        public string RecordId { get; set; }
        public string DisplayLine { get; set; }
        public string AddressLine { get; set; }
        public string Locality { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string AddressSiteId { get; set; }
        public string GeocodeTypeCode { get; set; }
        public string ReliabilityCode { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }

        public bool IsInWesternSydney { get; set; }
    }
}
