using Microsoft.AspNetCore.Mvc;
using gameapi.repository;
using gameapi.dtos;

namespace gameapi.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class gamecontroller:ControllerBase
    {
        private readonly IgameRepository _repository;

        public gamecontroller(IgameRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult  gatGames()
        {
            return Ok(_repository.GetGames());
        }

        [HttpPost("User/{UserId}")]
        public IActionResult grtGameByUserId(string UserId)
        {
            try
            {
                _repository.GameByUserId(UserId);
            }
            catch(InvalidOperationException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Games Not Found" });
            }
            
            return NoContent();
        }

        [HttpPost("{GameId}")]
        public async Task<IActionResult> RateGame(int GameId,GameRateDto gameRate)
        {
            try
            {
                await _repository.RateGame(GameId,gameRate.UserId,gameRate.Rate);
            }
            catch(InvalidOperationException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Game Already Rated by User" });
            }
            
            return NoContent();
        }

    }
}
