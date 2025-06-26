using Hikru.Positions.Application.Departments.Dtos;
using Hikru.Positions.Application.Interfaces;
using System.Net.Http;
using System.Text.Json;

namespace Hikru.Positions.Infrastructure.Services;

public class ApexDepartmentService : IApexDepartmentService
{
    private readonly HttpClient _httpClient;

    public ApexDepartmentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<DepartmentDto>> GetAllAsync()
    {
        var url = "https://g5fede71fbf5d03-hikrupositionsdb.adb.mx-queretaro-1.oraclecloudapps.com/ords/admin/positions/getdepartments";

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Error API APEX: {response.StatusCode}");

        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        var items = doc.RootElement.GetProperty("items");

        return JsonSerializer.Deserialize<List<DepartmentDto>>(items.GetRawText(), new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }
}
