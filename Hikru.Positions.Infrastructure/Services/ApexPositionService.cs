using Hikru.Positions.Application.Interfaces;
using Hikru.Positions.Application.Positions.Dtos;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace Hikru.Positions.Infrastructure.Services;

public class ApexPositionService : IApexPositionService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApexPositionService> _logger;

    public ApexPositionService(HttpClient httpClient, ILogger<ApexPositionService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<bool> CreateAsync(PositionCreateDto dto, CancellationToken cancellationToken)
    {
        var url = "https://g5fede71fbf5d03-hikrupositionsdb.adb.mx-queretaro-1.oraclecloudapps.com/ords/admin/positions/create";

            var response = await _httpClient.PostAsJsonAsync(url, new
            {
                title = dto.Title,
                description = dto.Description,
                location = dto.Location,
                status = dto.Status,
                recruiter_id = dto.RecruiterId,
                department_id = dto.DepartmentId,
                budget = dto.Budget,
                closing_date = dto.ClosingDate?.ToString("yyyy-MM-dd")
            }, cancellationToken);

            return response.IsSuccessStatusCode;

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

    public async Task<bool> UpdateAsync(UpdatePositionDto dto, CancellationToken cancellationToken)
    {
        var url = $"https://g5fede71fbf5d03-hikrupositionsdb.adb.mx-queretaro-1.oraclecloudapps.com/ords/admin/positions/{dto.Id}";

        var response = await _httpClient.PutAsJsonAsync(url, new
        {
            title = dto.Title,
            description = dto.Description,
            location = dto.Location,
            status = dto.Status,
            recruiter_id = dto.RecruiterId,
            department_id = dto.DepartmentId,
            budget = dto.Budget,
            closing_date = dto.ClosingDate?.ToString("yyyy-MM-dd")
        }, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            _logger.LogError("Error desde APEX (status: {Status}): {Content}", response.StatusCode, content);
            return false;
        }

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken)
    {
        var url = $"https://g5fede71fbf5d03-hikrupositionsdb.adb.mx-queretaro-1.oraclecloudapps.com/ords/admin/positions/{id}";

        try
        {
            var response = await _httpClient.DeleteAsync(url, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                _logger.LogError("Error eliminando posición en APEX. Status: {Status}, Content: {Content}",
                    response.StatusCode, content);
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Excepción al eliminar posición en APEX");
            return false;
        }
    }

    public async Task<PositionDto?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var url = $"https://g5fede71fbf5d03-hikrupositionsdb.adb.mx-queretaro-1.oraclecloudapps.com/ords/admin/positions/{id}";

        try
        {
            var response = await _httpClient.GetAsync(url, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                _logger.LogWarning("No se pudo obtener la posición. Status: {Status}, Content: {Content}", response.StatusCode, content);
                return null;
            }

            var result = await response.Content.ReadFromJsonAsync<PositionDto>(cancellationToken: cancellationToken);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error obteniendo posición por ID en APEX");
            return null;
        }
    }



}
