namespace LogSage.Api.Application.Interfaces;

public interface ILogAnalysisService
{
    Task<string> AnalyzeLogAsync(IFormFile file, string query);
}