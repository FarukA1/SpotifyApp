using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spotify.Api.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Spotify.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {

        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<string> GetArtistById(string id)
        {
            var artist = await _artistService.GetArtistById(id);
            return artist;
        }

        [HttpGet]
        [Route("{id}/albums")]
        public async Task<string> GetArtistAlbum(string id)
        {
            var artist = await _artistService.GetArtistAlbum(id);
            return artist;
        }
    }
}

