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
    public class VideoGameController : ControllerBase
    {

        VideoGameService videoGameService;

        public VideoGameController(VideoGameService _videoGameService)
        {
            videoGameService = _videoGameService;
        }

        [HttpGet("GetAllVideoGames")]
        public ActionResult<List<VideoGame>> GetAllVideoGames()
        {
            return Ok(videoGameService.getAllVideoGames());
        }

        [HttpGet("GetOneVideoGame")]
        public ActionResult<VideoGame> GetOneVideoGame()
        {
            return Ok(videoGameService.getOneVideoGame());
        }

        [HttpPost("AddVideoGame")]
        public ActionResult<Music> AddVideoGame(VideoGame videoGame)
        {
            return Ok(videoGameService.addVideoGame(videoGame));
        }

        [HttpDelete("DeleteVideoGameById")]
        public ActionResult<bool> DeleteVideoGameById(int Id)
        {
            return videoGameService.deleteVideoGameById(Id);
        }

        [HttpGet("GetVideoGameById")]
        public ActionResult<VideoGame> GetVideoGameById(int Id)
        {
            VideoGame? videoGame = videoGameService.getVideoGameById(Id);
            if (videoGame != null)
            {
                return Ok(videoGame);
            }
            return BadRequest("No video game found with given Id");
        }

    }
}