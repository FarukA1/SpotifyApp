using System;
namespace Spotify.Api.Services
{
	public class ArtistService : IArtistService
    {
        private readonly ISpotifyService _spotifyService;
        public ArtistService(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        public async Task<string> GetArtistById(string id)
        {
            string endpoint = $"artists/{id}";

            var response = await _spotifyService.GetAsync(endpoint);

            return response.ToString();

        }

        public async Task<string> GetArtistAlbum(string id)
        {
            string endpoint = $"artists/{id}/albums";

            var response = await _spotifyService.GetAsync(endpoint);

            return response.ToString();

        }
    }
}

