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
    public class CurrentPlayersController : Controller
    {
        private readonly NbaDbContext _context;

        public CurrentPlayersController(NbaDbContext context)
        {
            _context = context;
        }

        // GET: CurrentPlayers
        public async Task<IActionResult> Index()
        {
            var nbaDbContext = _context.CurrentPlayers.Include(c => c.NbaTeam);
            return View(await nbaDbContext.ToListAsync());
        }

        // GET: CurrentPlayers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentPlayer = await _context.CurrentPlayers
                .Include(c => c.NbaTeam)
                .FirstOrDefaultAsync(m => m.CurrentPlayerID == id);
            if (currentPlayer == null)
            {
                return NotFound();
            }

            return View(currentPlayer);
        }

        // GET: CurrentPlayers/Create
        public IActionResult Create()
        {
            ViewData["NbaTeamID"] = new SelectList(_context.NbaTeams, "NbaTeamID", "NbaTeamName");
            return View();
        }

        // POST: CurrentPlayers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CurrentPlayerID,CurrentPlayerName,CurrentPlayerPosition,CurrentPlayerDOB,NbaTeamID")] CurrentPlayer currentPlayer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(currentPlayer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NbaTeamID"] = new SelectList(_context.NbaTeams, "NbaTeamID", "NbaTeamName", currentPlayer.NbaTeamID);
            return View(currentPlayer);
        }

        // GET: CurrentPlayers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentPlayer = await _context.CurrentPlayers.FindAsync(id);
            if (currentPlayer == null)
            {
                return NotFound();
            }
            ViewData["NbaTeamID"] = new SelectList(_context.NbaTeams, "NbaTeamID", "NbaTeamName", currentPlayer.NbaTeamID);
            return View(currentPlayer);
        }

        // POST: CurrentPlayers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CurrentPlayerID,CurrentPlayerName,CurrentPlayerPosition,CurrentPlayerDOB,NbaTeamID")] CurrentPlayer currentPlayer)
        {
            if (id != currentPlayer.CurrentPlayerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currentPlayer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurrentPlayerExists(currentPlayer.CurrentPlayerID))
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
            ViewData["NbaTeamID"] = new SelectList(_context.NbaTeams, "NbaTeamID", "NbaTeamName", currentPlayer.NbaTeamID);
            return View(currentPlayer);
        }

        // GET: CurrentPlayers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentPlayer = await _context.CurrentPlayers
                .Include(c => c.NbaTeam)
                .FirstOrDefaultAsync(m => m.CurrentPlayerID == id);
            if (currentPlayer == null)
            {
                return NotFound();
            }

            return View(currentPlayer);
        }

        // POST: CurrentPlayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var currentPlayer = await _context.CurrentPlayers.FindAsync(id);
            _context.CurrentPlayers.Remove(currentPlayer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurrentPlayerExists(int id)
        {
            return _context.CurrentPlayers.Any(e => e.CurrentPlayerID == id);
        }
    }
}
