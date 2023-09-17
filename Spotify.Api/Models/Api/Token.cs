using System;
namespace Spotify.Api.Models
{
	public class Token
	{
        public string Access_Token { get; set; }
        public string Token_Type { get; set; }
        public int Expires_In { get; set; }
    }
}

