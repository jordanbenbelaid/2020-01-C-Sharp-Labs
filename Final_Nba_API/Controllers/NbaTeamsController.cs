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
    public class NbaTeamsController : Controller
    {
        private readonly NbaDbContext _context;

        public NbaTeamsController(NbaDbContext context)
        {
            _context = context;
        }

        // GET: NbaTeams
        public async Task<IActionResult> Index()
        {
            return View(await _context.NbaTeams.ToListAsync());
        }

        // GET: NbaTeams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nbaTeam = await _context.NbaTeams
                .FirstOrDefaultAsync(m => m.NbaTeamID == id);
            if (nbaTeam == null)
            {
                return NotFound();
            }

            return View(nbaTeam);
        }

        // GET: NbaTeams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NbaTeams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NbaTeamID,NbaTeamName,NbaTeamConference")] NbaTeam nbaTeam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nbaTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nbaTeam);
        }

        // GET: NbaTeams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nbaTeam = await _context.NbaTeams.FindAsync(id);
            if (nbaTeam == null)
            {
                return NotFound();
            }
            return View(nbaTeam);
        }

        // POST: NbaTeams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NbaTeamID,NbaTeamName,NbaTeamConference")] NbaTeam nbaTeam)
        {
            if (id != nbaTeam.NbaTeamID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nbaTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NbaTeamExists(nbaTeam.NbaTeamID))
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
            return View(nbaTeam);
        }

        // GET: NbaTeams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nbaTeam = await _context.NbaTeams
                .FirstOrDefaultAsync(m => m.NbaTeamID == id);
            if (nbaTeam == null)
            {
                return NotFound();
            }

            return View(nbaTeam);
        }

        // POST: NbaTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nbaTeam = await _context.NbaTeams.FindAsync(id);
            _context.NbaTeams.Remove(nbaTeam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NbaTeamExists(int id)
        {
            return _context.NbaTeams.Any(e => e.NbaTeamID == id);
        }
    }
}
