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
    public class NbaTeamsController : ControllerBase
    {
        private readonly NbaDbContext _context;

        public NbaTeamsController(NbaDbContext context)
        {
            _context = context;
        }

        // GET: api/NbaTeams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NbaTeam>>> GetNbaTeams()
        {
            return await _context.NbaTeams.ToListAsync();
        }

        // GET: api/NbaTeams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NbaTeam>> GetNbaTeam(int id)
        {
            var nbaTeam = await _context.NbaTeams.FindAsync(id);

            if (nbaTeam == null)
            {
                return NotFound();
            }

            return nbaTeam;
        }

        // PUT: api/NbaTeams/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNbaTeam(int id, NbaTeam nbaTeam)
        {
            if (id != nbaTeam.NbaTeamID)
            {
                return BadRequest();
            }

            _context.Entry(nbaTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NbaTeamExists(id))
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

        // POST: api/NbaTeams
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<NbaTeam>> PostNbaTeam(NbaTeam nbaTeam)
        {
            _context.NbaTeams.Add(nbaTeam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNbaTeam", new { id = nbaTeam.NbaTeamID }, nbaTeam);
        }

        // DELETE: api/NbaTeams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NbaTeam>> DeleteNbaTeam(int id)
        {
            var nbaTeam = await _context.NbaTeams.FindAsync(id);
            if (nbaTeam == null)
            {
                return NotFound();
            }

            _context.NbaTeams.Remove(nbaTeam);
            await _context.SaveChangesAsync();

            return nbaTeam;
        }

        private bool NbaTeamExists(int id)
        {
            return _context.NbaTeams.Any(e => e.NbaTeamID == id);
        }
    }
}
