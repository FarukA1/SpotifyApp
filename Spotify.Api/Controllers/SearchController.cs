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
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        [Route("{query}")]
        public async Task<string> SearchForArtistOrAlbum(string query)
        {
            if(query == null)
            {
                throw new Exception("Search query needs a value");
            }

            query = query.Replace(" ", "");

            var result = await _searchService.SearchArtistOrAlbumOrTrack(query);
            return result;
        }
    }
}

