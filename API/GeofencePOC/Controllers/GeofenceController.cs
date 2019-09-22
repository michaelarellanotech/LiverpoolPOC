using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GeofencePOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeofenceController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string _serviceURL = "https://kleber-devuat.datatoolscloud.net.au/KleberWebService/DtKleberService.svc/";
        private const string _serviceRequestKey = "RK-66790-25DAF-5E733-BDF40-35FDA-1BBD8-D9C89-FA1A6";
        public GeofenceController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("autocomplete/{addressline}")]
        public async Task<ActionResult> GetAddress([FromRoute]string addressline)
        {
            int limit = 20;
            string serviceRequestedQueryString = "{0}/ProcessQueryStringRequest?Method=DataTools.Capture.Address.Predictive.Gnaf.SearchAddress&AddressLine={1}&ResultLimit={2}&RequestKey={3}&OutputFormat=json";

            var qualifiedQueryString = string.Format(serviceRequestedQueryString, _serviceURL, addressline, limit, _serviceRequestKey);

            var request = new HttpRequestMessage(HttpMethod.Get, qualifiedQueryString);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var lstResult = new List<Result>();

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                var kleberAddress = JsonConvert.DeserializeObject<KleberMultipleAddressViewModel>(result);

                if (kleberAddress != null && kleberAddress.DtResponse != null && kleberAddress.DtResponse.Result.Count() > 0)
                {
                    lstResult = kleberAddress.DtResponse.Result;
                }
            }

            return Ok(lstResult);
        }

        [HttpGet("geocode/{gnafId}/{displayLine}")]
        public async Task<ActionResult> GetGeoCode([FromRoute]string gnafId, [FromRoute]string displayLine)
        {
            string serviceRequestedQueryString = "{0}/ProcessQueryStringRequest?Method=DataTools.Capture.Address.Predictive.Gnaf.RetrieveGeocode&RecordId={1}&RequestKey={2}&OutputFormat=json";

            var qualifiedQueryString = string.Format(serviceRequestedQueryString, _serviceURL, gnafId, _serviceRequestKey);

            var request = new HttpRequestMessage(HttpMethod.Get, qualifiedQueryString);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var singleResult = new Result();

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var kleberAddress = JsonConvert.DeserializeObject<KleberMultipleAddressViewModel>(result);

                if (kleberAddress != null && kleberAddress.DtResponse != null && kleberAddress.DtResponse.Result.Count() > 0)
                {
                    singleResult = kleberAddress.DtResponse.Result[0];
                    singleResult.IsInWesternSydney = IsInWesternSydney(singleResult.Longitude, singleResult.Latitude);
                    
                    var fullAddress = await GetFullAddressByRecordId(gnafId);
                    singleResult.DisplayLine = displayLine;
                    singleResult.AddressLine = fullAddress.AddressLine;
                    singleResult.Locality = fullAddress.Locality;
                    singleResult.State = fullAddress.State;
                    singleResult.Postcode = fullAddress.Postcode;
                }
            }

            return Ok(singleResult);
        }

        private string connectionString =
            "Server=MD-R90Q8NH0\\LOCALSQL;Database=Liverpool;User Id=sa;Password=sa;";

        private bool IsInWesternSydney(string longitude, string latitude)
        {
            String commandText = "dbo.GetLHD";

            // Specify the year of StartDate  
            SqlParameter parameterLongitude = new SqlParameter("longitude", SqlDbType.VarChar);
            SqlParameter parameterLatitude = new SqlParameter("latitude", SqlDbType.VarChar);
            parameterLongitude.Value = longitude;
            parameterLatitude.Value = latitude;

            var oValue = SqlHelper.ExecuteScalar(connectionString, commandText, CommandType.StoredProcedure, parameterLongitude, parameterLatitude);
            Int32 result;
            if (Int32.TryParse(oValue.ToString(), out result))
            {
                return result == 1;
            }

            return false;
        }

        public async Task<Result> GetFullAddressByRecordId(string gnafId)
        {
            string serviceRequestedQueryString = "{0}/ProcessQueryStringRequest?Method=DataTools.Capture.Address.Predictive.Gnaf.RetrieveAddress&RecordId={1}&RequestKey={2}&OutputFormat=json";

            var qualifiedQueryString = string.Format(serviceRequestedQueryString, _serviceURL, gnafId, _serviceRequestKey);

            var request = new HttpRequestMessage(HttpMethod.Get, qualifiedQueryString);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var singleResult = new Result();

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var kleberAddress = JsonConvert.DeserializeObject<KleberMultipleAddressViewModel>(result);

                if (kleberAddress != null && kleberAddress.DtResponse != null && kleberAddress.DtResponse.Result.Count() > 0)
                {
                    singleResult = kleberAddress.DtResponse.Result[0];
                }
            }

            return singleResult;
        }

        #region DTO
        public class DtResponse
        {
            public string RequestId { get; set; }

            public string ResultCount { get; set; }

            public string ErrorMessage { get; set; }

            public List<Result> Result { get; set; }
        }

        public class Result
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

        public class KleberMultipleAddressViewModel
        {
            public DtResponse DtResponse { get; set; }
        }

        #endregion

    }
}
