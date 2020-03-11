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
    public class HistoricPlayersController : ControllerBase
    {
        private readonly NbaDbContext _context;

        public HistoricPlayersController(NbaDbContext context)
        {
            _context = context;
        }

        // GET: api/HistoricPlayers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricPlayer>>> GetHistoricPlayers()
        {
            return await _context.HistoricPlayers.ToListAsync();
        }

        // GET: api/HistoricPlayers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricPlayer>> GetHistoricPlayer(int id)
        {
            var historicPlayer = await _context.HistoricPlayers.FindAsync(id);

            if (historicPlayer == null)
            {
                return NotFound();
            }

            return historicPlayer;
        }

        // PUT: api/HistoricPlayers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoricPlayer(int id, HistoricPlayer historicPlayer)
        {
            if (id != historicPlayer.HistoricPlayerID)
            {
                return BadRequest();
            }

            _context.Entry(historicPlayer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoricPlayerExists(id))
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

        // POST: api/HistoricPlayers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<HistoricPlayer>> PostHistoricPlayer(HistoricPlayer historicPlayer)
        {
            _context.HistoricPlayers.Add(historicPlayer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistoricPlayer", new { id = historicPlayer.HistoricPlayerID }, historicPlayer);
        }

        // DELETE: api/HistoricPlayers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HistoricPlayer>> DeleteHistoricPlayer(int id)
        {
            var historicPlayer = await _context.HistoricPlayers.FindAsync(id);
            if (historicPlayer == null)
            {
                return NotFound();
            }

            _context.HistoricPlayers.Remove(historicPlayer);
            await _context.SaveChangesAsync();

            return historicPlayer;
        }

        private bool HistoricPlayerExists(int id)
        {
            return _context.HistoricPlayers.Any(e => e.HistoricPlayerID == id);
        }
    }
}
