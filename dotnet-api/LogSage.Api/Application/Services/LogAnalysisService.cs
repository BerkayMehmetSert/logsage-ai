using LogSage.Api.Application.Interfaces;
using LogSage.Api.Infrastructure.HttpClients;
using Microsoft.AspNetCore.Http;

namespace LogSage.Api.Application.Services;

public class LogAnalysisService : ILogAnalysisService
{
    private readonly IPythonAgentClient _agentClient;

    public LogAnalysisService(IPythonAgentClient agentClient)
    {
        _agentClient = agentClient;
    }

    public async Task<string> AnalyzeLogAsync(IFormFile file, string query)
    {
        using var reader = new StreamReader(file.OpenReadStream());
        var logContent = await reader.ReadToEndAsync();

        var result = await _agentClient.SendLogAnalysisRequestAsync(logContent, query);
        return result;
    }
}