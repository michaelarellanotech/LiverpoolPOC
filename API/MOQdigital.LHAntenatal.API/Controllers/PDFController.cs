using Microsoft.AspNetCore.Mvc;
using MOQdigital.LHAntenatal.API.Services;
using System.Threading.Tasks;

namespace Pdf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly IPDFService _pdfService;

        public PdfController(IPDFService pdfService)
        {
            _pdfService = pdfService;
        }


        [HttpGet("test")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]
        public async Task<IActionResult> GetPDF()
        {
            var result = await _pdfService.Test();

            return result;
        }

    }
}
