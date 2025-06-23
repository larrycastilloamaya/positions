using Hikru.Positions.Application.Interfaces;
using Hikru.Positions.Application.Positions.Dtos;
using System.Net.Http;
using System.Text.Json;

namespace Hikru.Positions.Infrastructure.Services;

public class ApexPositionService : IApexPositionService
{
    private readonly HttpClient _httpClient;

    public ApexPositionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<PositionDto>> GetAllAsync()
    {
        var url = "https://g5fede71fbf5d03-hikrupositionsdb.adb.mx-queretaro-1.oraclecloudapps.com/ords/admin/positions/getall";

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Error API APEX: {response.StatusCode}");

        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        var items = doc.RootElement.GetProperty("items");

        return JsonSerializer.Deserialize<List<PositionDto>>(items.GetRawText(), new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }
}
