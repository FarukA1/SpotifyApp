using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Spotify.Api.Models;
//using Spotify.Api.Models.;

namespace Spotify.Api.Services
{
	public class SpotifyService : ISpotifyService
	{
        private readonly IConfiguration _configration;
        private readonly HttpClient _httpClient;
        private readonly string clientId;
        private readonly string clientSecret;
        private readonly Uri tokenUrl;
        private readonly Uri baseUrl;


        public SpotifyService(IConfiguration configration, HttpClient httpClient) {
            _configration = configration;
			_httpClient = httpClient;
            clientId = (_configration["Spotify:ClientID"]);
            clientSecret = (_configration["Spotify:Test"]);
            tokenUrl = new Uri(_configration["Spotify:TokenUrl"]);
            baseUrl = new Uri(_configration["Spotify:BaseUrl"]);
        }

        public async Task<string> GetToken()
        {
            var parameters = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "client_id", clientId.ToString() },
                { "client_secret", clientSecret.ToString() },
            };

            var content = new FormUrlEncodedContent(parameters);

            var response = await _httpClient.PostAsync(tokenUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var token = JsonSerializer.Deserialize<Token>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return token.Access_Token;
            }
            else
            {
                throw new Exception($"Failed to retrieve access token. Status code: {response.StatusCode}");
            }
        }

        public async Task<string> GetAsync(string endpoint)
        {
            Uri requestUri = new Uri(baseUrl, endpoint);

            _httpClient.BaseAddress = requestUri;
            var token = await GetToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.ToString());

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(requestUri);

                if(response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent;
                }
                else
                {
                    throw new Exception($"Request failed with status code {response.StatusCode}");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error posting to Spotify", e);
            }

        }

    }
}

