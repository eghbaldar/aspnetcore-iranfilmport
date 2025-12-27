using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json;

namespace IranFilmPort.Application.Services._Turnstile
{
    public sealed class TurnstileVerifyResponse
    {
        public bool success { get; set; }
        public string[] error_codes { get; set; }
    }
    public interface ITurnstileService
    {
        Task<bool> VerifyAsync(string token, string? remoteIp = null);
    }
    public class TurnstileService : ITurnstileService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public TurnstileService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<bool> VerifyAsync(string token, string? remoteIp = null)
        {
            if (string.IsNullOrWhiteSpace(token))
                return false;

            var values = new Dictionary<string, string>
            {
                ["secret"] = _configuration["Cloudflare:Turnstile:SecretKey"],
                ["response"] = token
            };

            if (!string.IsNullOrWhiteSpace(remoteIp))
                values["remoteip"] = remoteIp;

            using var content = new FormUrlEncodedContent(values);
            using var response = await _httpClient
                .PostAsync("https://challenges.cloudflare.com/turnstile/v0/siteverify", content);

            if (!response.IsSuccessStatusCode)
                return false;

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TurnstileVerifyResponse>(json);

            return result?.success == true;
        }
    }
}
