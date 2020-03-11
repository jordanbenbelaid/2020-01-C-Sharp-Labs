using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Final_Nba_API.Models;

namespace Nba_Actual_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentPlayersController : ControllerBase
    {
        private readonly NbaDbContext _context;

        public CurrentPlayersController(NbaDbContext context)
        {
            _context = context;
        }

        // GET: api/CurrentPlayers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrentPlayer>>> GetCurrentPlayers()
        {
            return await _context.CurrentPlayers.ToListAsync();
        }

        // GET: api/CurrentPlayers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CurrentPlayer>> GetCurrentPlayer(int id)
        {
            var currentPlayer = await _context.CurrentPlayers.FindAsync(id);

            if (currentPlayer == null)
            {
                return NotFound();
            }

            return currentPlayer;
        }

        // PUT: api/CurrentPlayers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrentPlayer(int id, CurrentPlayer currentPlayer)
        {
            if (id != currentPlayer.CurrentPlayerID)
            {
                return BadRequest();
            }

            _context.Entry(currentPlayer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrentPlayerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CurrentPlayers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CurrentPlayer>> PostCurrentPlayer(CurrentPlayer currentPlayer)
        {
            _context.CurrentPlayers.Add(currentPlayer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurrentPlayer", new { id = currentPlayer.CurrentPlayerID }, currentPlayer);
        }

        // DELETE: api/CurrentPlayers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CurrentPlayer>> DeleteCurrentPlayer(int id)
        {
            var currentPlayer = await _context.CurrentPlayers.FindAsync(id);
            if (currentPlayer == null)
            {
                return NotFound();
            }

            _context.CurrentPlayers.Remove(currentPlayer);
            await _context.SaveChangesAsync();

            return currentPlayer;
        }

        private bool CurrentPlayerExists(int id)
        {
            return _context.CurrentPlayers.Any(e => e.CurrentPlayerID == id);
        }
    }
}
