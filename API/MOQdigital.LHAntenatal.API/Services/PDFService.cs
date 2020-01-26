using Microsoft.AspNetCore.Mvc;
using Rotativa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace MOQdigital.LHAntenatal.API.Services
{
    public class PDFService : IPDFService
    {
        private readonly IGeneratePdf _generatePdf;

        private readonly string htmlView = @"@model Rotativa.Models.TestData
<!DOCTYPE html>
<html>
<head>
<style>
table {
width: 100%;
}
table, th, td {
  border: 1px solid black;
  border-collapse: collapse;  
}
th, td {
  padding: 15px;
}
</style>
</head>
<body>
 <header>
	<h1>@Model.Text</h1>
</header>
<div>
	<h2>@Model.Number</h2>
</div>	
<table>
<tr >
    <td >Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
<tr>
    <td>Question</td>
    <td>Answer</td>
    <td>Comment</td>
    <td>Score</td>
</tr>
</table>
</body>
</html>                        

";

        public PDFService(IGeneratePdf generatePdf) 
        {
            _generatePdf = generatePdf;
        }

        public async Task<IActionResult> Test() 
        {
            var data = new TestData
            {
                Text = "This is not a test",
                Number = 12345678
            };

            return await _generatePdf.GetPdfViewInHtml(htmlView, data);
        }
    }

    public interface IPDFService 
    {
        Task<IActionResult> Test();
    }
}
