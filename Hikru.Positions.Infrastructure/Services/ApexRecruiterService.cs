using Hikru.Positions.Application.Recruiters.Dtos;
using Hikru.Positions.Application.Interfaces;
using System.Net.Http;
using System.Text.Json;

namespace Hikru.Positions.Infrastructure.Services;

public class ApexRecruiterService : IApexRecruiterService
{
    private readonly HttpClient _httpClient;

    public ApexRecruiterService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<RecruiterDto>> GetAllAsync()
    {
        var url = "https://g5fede71fbf5d03-hikrupositionsdb.adb.mx-queretaro-1.oraclecloudapps.com/ords/admin/positions/getrecruiters";

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Error API APEX: {response.StatusCode}");

        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        var items = doc.RootElement.GetProperty("items");

        return JsonSerializer.Deserialize<List<RecruiterDto>>(items.GetRawText(), new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }
}
