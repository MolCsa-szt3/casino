using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SzerenceVallalat.Backend.Models;

namespace SzerenceVallalat.Backend.Controllers
{
    [Route("api/")]
    [ApiController]
    public class GamingController : ControllerBase
    {
        private GamingdbContext _context = new();

        

        [HttpGet("players/number")]
        public async Task<IActionResult> GetPlayerCount() {
            return Ok(await _context.Players.CountAsync());
        }
        [HttpGet("players/amount/{amount}")]
        public async Task<IActionResult> GetPlayersAboveAmount(int amount)
        {
            return Ok(await _context.Players.Where(x => x.Amount > amount).ToListAsync());
        }
        [HttpGet("games/sort")]
        public async Task<IActionResult> GetGamesSorted()
        {
            return Ok(await _context.Games.Join(
                _context.Plays, games =>games.Id, plays => plays.GameId, (games, plays)=> new {Name=games.Game1, Amount = plays.Amount })
                .GroupBy(x => x.Name)
                .Select(x => new {Name=x.Key, Sum = x.Sum(y => y.Amount)})
                .OrderBy(x => x.Sum)
                .ToListAsync());
        }
        [HttpGet("games/player/{id}")]
        public async Task<IActionResult> GetGamesWhere3Played(int id)
        {
            return Ok(await _context.Games.Join(
                _context.Plays,
                games => games.Id,
                plays => plays.GameId, 
                (games, plays) => new { Name = games.Game1, Player=plays.PlayerId })
                .Where(x => x.Player == id)
                .ToListAsync());
        }
        [HttpDelete("/player/{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            Player? toBeDeleted = await _context.Players.Where(x =>x.Id == id).FirstOrDefaultAsync();
            if (toBeDeleted == null) return NotFound();
            _context.Players.Remove(toBeDeleted);
            _context.SaveChanges();
            return Ok();
        }


    }
}
