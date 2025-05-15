using Microsoft.AspNetCore.Mvc;
using LogSage.Api.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace LogSage.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LogAnalysisController : ControllerBase
{
    private readonly ILogAnalysisService _logAnalysisService;

    public LogAnalysisController(ILogAnalysisService logAnalysisService)
    {
        _logAnalysisService = logAnalysisService;
    }

    public class LogAnalysisRequest
    {
        public IFormFile File { get; set; }
        public string Query { get; set; }
    }

    [HttpPost("analyze")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Analyze([FromForm] LogAnalysisRequest request)
    {
        if (request.File == null || string.IsNullOrWhiteSpace(request.Query))
            return BadRequest("Log file and query are required.");

        var result = await _logAnalysisService.AnalyzeLogAsync(request.File, request.Query);
        return Ok(new
        {
            result = result,
            pretty = result.Replace("\n", "<br>").Replace("  ", "&nbsp;&nbsp;")
        });

    }

}