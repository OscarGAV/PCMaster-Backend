using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace PCMasterFrontend.Infrastructure.HttpClient;

public interface IApiClient
{
    Task<T?> GetAsync<T>(string endpoint);
    Task<TResponse?> PostAsync<TResponse>(string endpoint, object data);
    Task<TResponse?> PutAsync<TResponse>(string endpoint, object data);
    Task DeleteAsync(string endpoint);
    void SetAuthToken(string token);
    void ClearAuthToken();
}

public class ApiClient : IApiClient
{
    private readonly System.Net.Http.HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;
    private static string? _authToken;

    public ApiClient(System.Net.Http.HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public void SetAuthToken(string token)
    {
        _authToken = token;
        Console.WriteLine($"[ApiClient] SetAuthToken called. Token: {(!string.IsNullOrEmpty(token) ? token.Substring(0, Math.Min(20, token.Length)) + "..." : "NULL")}");
    }

    public void ClearAuthToken()
    {
        _authToken = null;
        Console.WriteLine("[ApiClient] ClearAuthToken called");
    }

    private void ApplyAuthHeader(HttpRequestMessage request)
    {
        Console.WriteLine($"[ApiClient] ApplyAuthHeader. Current token: {(_authToken != null ? "YES" : "NO")}");
        if (!string.IsNullOrEmpty(_authToken))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
            Console.WriteLine($"[ApiClient] Auth header SET: Bearer {_authToken.Substring(0, Math.Min(20, _authToken.Length))}...");
        }
    }

    public async Task<T?> GetAsync<T>(string endpoint)
    {
        Console.WriteLine($"[ApiClient] GET {endpoint}");
        var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
        ApplyAuthHeader(request);
        var response = await _httpClient.SendAsync(request);
        Console.WriteLine($"[ApiClient] Response: {(int)response.StatusCode} {response.StatusCode}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<T>(_jsonOptions);
    }

    public async Task<TResponse?> PostAsync<TResponse>(string endpoint, object data)
    {
        Console.WriteLine($"[ApiClient] POST {endpoint}");
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        ApplyAuthHeader(request);
        var json = JsonSerializer.Serialize(data, _jsonOptions);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        request.Content = content;
        var response = await _httpClient.SendAsync(request);
        Console.WriteLine($"[ApiClient] Response: {(int)response.StatusCode} {response.StatusCode}");
        response.EnsureSuccessStatusCode();
        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            return default;
        return await response.Content.ReadFromJsonAsync<TResponse>(_jsonOptions);
    }

    public async Task<TResponse?> PutAsync<TResponse>(string endpoint, object data)
    {
        var request = new HttpRequestMessage(HttpMethod.Put, endpoint);
        ApplyAuthHeader(request);
        var json = JsonSerializer.Serialize(data, _jsonOptions);
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TResponse>(_jsonOptions);
    }

    public async Task DeleteAsync(string endpoint)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, endpoint);
        ApplyAuthHeader(request);
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }
}
