using System;
namespace Spotify.Api.Services
{
	public interface IArtistService
	{
        Task<string> GetArtistById(string id);
        Task<string> GetArtistAlbum(string id);

    }
}

