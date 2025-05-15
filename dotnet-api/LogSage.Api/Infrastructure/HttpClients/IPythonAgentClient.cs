namespace LogSage.Api.Infrastructure.HttpClients;

public interface IPythonAgentClient
{
    Task<string> SendLogAnalysisRequestAsync(string logContent, string query);
}