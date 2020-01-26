using System;
using System.Collections.Generic;
using System.Text;

namespace MOQdigital.LHAntenatal.Common.DTO
{
    public class DtResponse
    {
        public string RequestId { get; set; }

        public string ResultCount { get; set; }

        public string ErrorMessage { get; set; }

        public List<AddressSearchResult> Result { get; set; }
    }

    public class KleberMultipleAddress
    {
        public DtResponse DtResponse { get; set; }
    }
}
