using System;
namespace Spotify.Api.Services
{
	public class SearchService : ISearchService
    {
        private readonly ISpotifyService _spotifyService;
        public SearchService(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        public async Task<string> SearchArtistOrAlbumOrTrack(string query)
        {
            string endpoint = $"search?q={query}&type=album%2Cartist%2Ctrack";

            var response = await _spotifyService.GetAsync(endpoint);

            return response.ToString();

        }
    }
}

