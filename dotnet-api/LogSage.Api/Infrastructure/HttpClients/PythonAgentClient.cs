namespace LogSage.Api.Infrastructure.HttpClients;

public class PythonAgentClient : IPythonAgentClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;

    public PythonAgentClient(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
    }

    public async Task<string> SendLogAnalysisRequestAsync(string logContent, string query)
    {
        var payload = new
        {
            log = logContent,
            query
        };

        var response = await _httpClient.PostAsJsonAsync("/analyze", payload);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
        return json?["result"] ?? "No result.";
    }
}