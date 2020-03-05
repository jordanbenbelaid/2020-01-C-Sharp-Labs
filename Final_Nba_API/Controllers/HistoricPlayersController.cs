using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final_Nba_API.Models;

namespace Final_Nba_API.Controllers
{
    public class HistoricPlayersController : Controller
    {
        private readonly NbaDbContext _context;

        public HistoricPlayersController(NbaDbContext context)
        {
            _context = context;
        }

        // GET: HistoricPlayers
        public async Task<IActionResult> Index()
        {
            var nbaDbContext = _context.HistoricPlayers.Include(h => h.NbaTeam);
            return View(await nbaDbContext.ToListAsync());
        }

        // GET: HistoricPlayers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicPlayer = await _context.HistoricPlayers
                .Include(h => h.NbaTeam)
                .FirstOrDefaultAsync(m => m.HistoricPlayerID == id);
            if (historicPlayer == null)
            {
                return NotFound();
            }

            return View(historicPlayer);
        }

        // GET: HistoricPlayers/Create
        public IActionResult Create()
        {
            ViewData["NbaTeamID"] = new SelectList(_context.NbaTeams, "NbaTeamID", "NbaTeamName");
            return View();
        }

        // POST: HistoricPlayers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoricPlayerID,HistoricPlayerName,HistoricPlayerPosition,HistoricPlayerDOB,PlayerRetired,NbaTeamID")] HistoricPlayer historicPlayer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historicPlayer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NbaTeamID"] = new SelectList(_context.NbaTeams, "NbaTeamID", "NbaTeamName", historicPlayer.NbaTeamID);
            return View(historicPlayer);
        }

        // GET: HistoricPlayers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicPlayer = await _context.HistoricPlayers.FindAsync(id);
            if (historicPlayer == null)
            {
                return NotFound();
            }
            ViewData["NbaTeamID"] = new SelectList(_context.NbaTeams, "NbaTeamID", "NbaTeamName", historicPlayer.NbaTeamID);
            return View(historicPlayer);
        }

        // POST: HistoricPlayers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistoricPlayerID,HistoricPlayerName,HistoricPlayerPosition,HistoricPlayerDOB,PlayerRetired,NbaTeamID")] HistoricPlayer historicPlayer)
        {
            if (id != historicPlayer.HistoricPlayerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historicPlayer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoricPlayerExists(historicPlayer.HistoricPlayerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["NbaTeamID"] = new SelectList(_context.NbaTeams, "NbaTeamID", "NbaTeamName", historicPlayer.NbaTeamID);
            return View(historicPlayer);
        }

        // GET: HistoricPlayers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicPlayer = await _context.HistoricPlayers
                .Include(h => h.NbaTeam)
                .FirstOrDefaultAsync(m => m.HistoricPlayerID == id);
            if (historicPlayer == null)
            {
                return NotFound();
            }

            return View(historicPlayer);
        }

        // POST: HistoricPlayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historicPlayer = await _context.HistoricPlayers.FindAsync(id);
            _context.HistoricPlayers.Remove(historicPlayer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoricPlayerExists(int id)
        {
            return _context.HistoricPlayers.Any(e => e.HistoricPlayerID == id);
        }
    }
}
