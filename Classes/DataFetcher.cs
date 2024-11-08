using System.IO;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

class DataFetcher
{
    private readonly HttpClient _httpClient;

    public DataFetcher(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task Fetch()
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(
                "https://api.sampleapis.com/beers/ale"
            );
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            File.WriteAllText("data/ale.json", responseBody);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request exception: {e.Message}");
            throw;
        }
    }
}
