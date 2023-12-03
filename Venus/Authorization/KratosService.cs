using Newtonsoft.Json;

namespace Venus.Authorization;

public class KratosService
{
    private readonly string _kratosUrl;
    private readonly HttpClient _client;

    public KratosService()
    {
        _client = new HttpClient();
        _kratosUrl = "http://127.0.0.1:4433";
    }

    public async Task<string> GetUserIdByToken(string token)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_kratosUrl}/sessions/whoami");
        request.Headers.Add("Authorization", token);
        return await SendWhoamiRequestAsync(request);            
    }
        
    public async Task<string> GetUserIdByCookie(string cookieName, string cookieContent)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_kratosUrl}/sessions/whoami");
        request.Headers.Add("Cookie", $"{cookieName}={cookieContent}");
        return await SendWhoamiRequestAsync(request);            
    }

    private async Task<string> SendWhoamiRequestAsync(HttpRequestMessage request)
    {
        var res = await _client.SendAsync(request);
        res.EnsureSuccessStatusCode();

        var json = await res.Content.ReadAsStringAsync();
        var session = JsonConvert.DeserializeObject<KratosSession>(json);    
        if (session is not { Active: true })
            throw new InvalidOperationException("Session is not active.");

        return session.Identity.Id;
    }
}