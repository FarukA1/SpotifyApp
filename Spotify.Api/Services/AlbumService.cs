using System;
using System.Text.Json;
using Spotify.Api.Models;
namespace Spotify.Api.Services
{
	public class AlbumService : IAlbumService
    {
		private readonly ISpotifyService _spotifyService;
        public AlbumService(ISpotifyService spotifyService)
		{
			_spotifyService = spotifyService;
		}

        public async Task<string> GetAlbumById(string id)
        {
            string endpoint = $"albums/{id}";

            var response = await _spotifyService.GetAsync(endpoint);

            return response.ToString();

        }

        public async Task<string> GetNewReleases()
        {
            string endpoint = "browse/new-releases?country=GB&offset=0&limit=20";

            var response = await _spotifyService.GetAsync(endpoint);

            return response.ToString();
        }
    }
}

