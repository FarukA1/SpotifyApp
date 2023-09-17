using System;
using Spotify.Api.Models;

namespace Spotify.Api.Services
{
	public interface ISpotifyService
	{
        Task<string> GetToken();
        Task<string> GetAsync(string endpoint);

    }
}

