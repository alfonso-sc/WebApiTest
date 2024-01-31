using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiTest.Models;
using WebApiTest.Services;

namespace WebApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicController : ControllerBase
    {

        MusicService musicService;
        public MusicController(MusicService _musicService)
        {
            musicService = _musicService;
        }

        [HttpGet("GetAllMusic")]
        public ActionResult<List<Music>> GetAllMusic()
        {
            return Ok(musicService.getAllMusic());
        }

        [HttpGet("GetOneMusic")]
        public ActionResult<Music> GetOneMusic()
        {
            return Ok(musicService.getOneMusic());
        }

        [HttpGet("GetTopThree")]
        public ActionResult<Music> GetTopThree()
        {
            return Ok(musicService.getTopThree());
        }

        [HttpGet("GetByRank")]
        public ActionResult<Music> GetByRank(int rank)
        {
            return Ok(musicService.getByRank(rank));
        }

        [HttpGet("GetByArtist")]
        public ActionResult<Music> GetByArtist(string artist)
        {
            return Ok(musicService.getByArtist(artist));
        }

        [HttpPost("AddMusic")]
        public ActionResult<Music> AddMusic(Music music)
        {
            return Ok(musicService.addMusic(music));
        }

        [HttpDelete("DeleteMusicById")]
        public ActionResult<bool> DeleteMusic(int Id)
        {
            return musicService.deleteMusicById(Id);
        }

        [HttpGet("GetMusicById")]
        public ActionResult<Music> GetMusicById(int Id)
        {
            Music? music = musicService.getMusicById(Id);
            if (music != null)
            {
                return Ok(music);
            }
            return BadRequest("No music found with given Id");
        }
    }
}