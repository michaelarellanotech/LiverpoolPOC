using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GeofencePOC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MOQdigital.LHAntenatal.Common.DTO;
using MOQdigital.LHAntenatal.DataLayer.Helpers;
using Newtonsoft.Json;

namespace Geofence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeofenceController : ControllerBase
    {
        private string _connectionString;
        private readonly IHttpClientFactory _clientFactory;
        private const string _serviceURL = "https://kleber-devuat.datatoolscloud.net.au/KleberWebService/DtKleberService.svc/";
        private const string _serviceRequestKey = "RK-66790-25DAF-5E733-BDF40-35FDA-1BBD8-D9C89-FA1A6";
        private readonly ISurveyService _surveyService;

        public GeofenceController(IHttpClientFactory clientFactory, IConfiguration configuration, ISurveyService surveyService)
        {
            _clientFactory = clientFactory;
            _connectionString = configuration.GetConnectionString("conn");
            _surveyService = surveyService;
        }

        [HttpGet("autocomplete/{addressline}")]
        public async Task<ActionResult> GetAddress([FromRoute]string addressline)
        {
            int limit = 10;
            string serviceRequestedQueryString = "{0}/ProcessQueryStringRequest?Method=DataTools.Capture.Address.Predictive.Gnaf.SearchAddress&AddressLine={1}&ResultLimit={2}&RequestKey={3}&OutputFormat=json";

            var qualifiedQueryString = string.Format(serviceRequestedQueryString, _serviceURL, addressline, limit, _serviceRequestKey);

            var request = new HttpRequestMessage(HttpMethod.Get, qualifiedQueryString);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var lstResult = new List<AddressSearchResult>();

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                var kleberAddress = JsonConvert.DeserializeObject<KleberMultipleAddress>(result);

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

            var singleResult = new AddressSearchResult();

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var kleberAddress = JsonConvert.DeserializeObject<KleberMultipleAddress>(result);

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

        private bool IsInWesternSydney(string longitude, string latitude)
        {
            String commandText = "dbo.GetLHD";

            // Specify the year of StartDate  
            SqlParameter parameterLongitude = new SqlParameter("longitude", SqlDbType.VarChar);
            SqlParameter parameterLatitude = new SqlParameter("latitude", SqlDbType.VarChar);
            parameterLongitude.Value = longitude;
            parameterLatitude.Value = latitude;

            var oValue = SqlHelper.ExecuteScalar(_connectionString, commandText, CommandType.StoredProcedure, parameterLongitude, parameterLatitude);
            Int32 result;
            if (Int32.TryParse(oValue.ToString(), out result))
            {
                return result == 1;
            }

            return false;
        }

        public async Task<AddressSearchResult> GetFullAddressByRecordId(string gnafId)
        {
            string serviceRequestedQueryString = "{0}/ProcessQueryStringRequest?Method=DataTools.Capture.Address.Predictive.Gnaf.RetrieveAddress&RecordId={1}&RequestKey={2}&OutputFormat=json";

            var qualifiedQueryString = string.Format(serviceRequestedQueryString, _serviceURL, gnafId, _serviceRequestKey);

            var request = new HttpRequestMessage(HttpMethod.Get, qualifiedQueryString);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var singleResult = new AddressSearchResult();

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var kleberAddress = JsonConvert.DeserializeObject<KleberMultipleAddress>(result);

                if (kleberAddress != null && kleberAddress.DtResponse != null && kleberAddress.DtResponse.Result.Count() > 0)
                {
                    singleResult = kleberAddress.DtResponse.Result[0];
                }
            }

            return singleResult;
        }

        [HttpGet("questiongroup/{questionGroupId}/language/{languageId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetQuestionGroup([FromRoute] int questionGroupId, [FromRoute]int languageId)
        {
            var result = await _surveyService.GetQuestionGroup(questionGroupId, languageId);
            return result == null
               ? (IActionResult)NotFound()
               : Ok(result);
        }

    }
}
