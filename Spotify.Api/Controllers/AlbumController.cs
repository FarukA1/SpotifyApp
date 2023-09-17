using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Spotify.Api.Models;
using Spotify.Api.Services;

namespace Spotify.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<string> GetAlbumById(string id)
        {
            var ablum = await _albumService.GetAlbumById(id);
            return ablum;
        }

        [HttpGet]
        [Route("new-releases")]
        public async Task<string> GetNewReleases()
        {
            var newReleases = await _albumService.GetNewReleases();
            return newReleases;
        }
    }
}

