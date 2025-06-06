using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://api.example.com/");
        
        // GET request
        var getResponse = await GetAsync("data/123");
        Console.WriteLine($"GET Response: {getResponse}");
        
        // POST request
        var postData = new { Name = "Test", Value = 42 };
        var postResponse = await PostAsync("submit", postData);
        Console.WriteLine($"POST Response: {postResponse}");
    }

    static async Task<string> GetAsync(string endpoint)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    static async Task<string> PostAsync<T>(string endpoint, T data)
    {
        using var client = new HttpClient();
        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync(endpoint, content);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}