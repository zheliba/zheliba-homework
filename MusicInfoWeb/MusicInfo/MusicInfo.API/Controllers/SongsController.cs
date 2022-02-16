using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MusicInfo.API.Models;
using MusicInfo.API.Models.Repositories;
using MusicInfo.API.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MusicInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        public static string accessToken;
        private readonly ISongRepository _songRepository;
        private readonly ISpotifyAccountService _spotifyAccountService;
        private readonly IConfiguration _configuration;
        private readonly ISpotifySongSearch _spotifySongSearch;
        public SongsController(ISongRepository songRepository, ISpotifyAccountService spotifyAccountService, IConfiguration configuration, ISpotifySongSearch spotifySongSearch)
        {
            _songRepository = songRepository;
            _spotifyAccountService = spotifyAccountService;
            _configuration = configuration;
            _spotifySongSearch = spotifySongSearch;
        }

        [HttpGet]
        public async Task<IEnumerable<Song>> GetAll()
        {
            return await _songRepository.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Song>> Get(string id)
        {
            try
            {
                accessToken = await _spotifyAccountService.GetToken(
                    _configuration["Spotify:ClientId"],
                    _configuration["Spotify:ClientSecret"]);

                var searchResults = await _spotifySongSearch.GetResults("money", "track", "UA", 5, accessToken);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }
            return await _songRepository.Get(id);
        }

        [HttpPost]
        [Route("CreateSong")]
        public async Task<ActionResult<Song>> CreateSong([FromBody] Song song)
        {
            var newSong = await _songRepository.Create(song);
            return CreatedAtAction(nameof(GetAll), new { id = newSong.Id }, newSong);
        }
    }

}
