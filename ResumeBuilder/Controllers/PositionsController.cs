using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResumeBuilderContext.Data;
using ResumeBuilderContext.Models;

namespace ResumeBuilderContext.Controllers
{
    public class PositionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PositionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Positions
        public async Task<IActionResult> Index()
        {
            var ResumeBuilderContext = _context.Position
                .AsNoTracking()
                .Include(y => y.JobHistories);
            return View(await ResumeBuilderContext.ToListAsync());
        }

        // GET: Positions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Position
                .AsNoTracking()
                .Include(y => y.JobHistories)
                .SingleOrDefaultAsync(y => y.PositionID == id);

            if(position == null)
            {
                return NotFound();
            }
            return View(position);

        }

        // GET: Positions/Create
        public IActionResult Create()
        {
            ViewData["JobHistory"] = new SelectList(_context.JobHistory, "ID", "Employer");
            return View();
        }

        // POST: Positions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,StartYear,EndYear,JobHistoryID")] Position position)
        {
            if (ModelState.IsValid)
            {
                _context.Add(position);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobHistory"] = new SelectList(_context.JobHistory, "ID", "Employer");
            return View(position);
        }

        // GET: Positions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Position.SingleOrDefaultAsync(y => y.PositionID == id);
            if (position == null)
            {
                return NotFound();
            }
            ViewData["JobHistory"] = new SelectList(_context.JobHistory, "ID", "Employer");
            return View(position);
        }

        // POST: Positions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PositionID,Title,StartYear,EndYear,JobHistoryID")] Position position)
        {
            if (id != position.PositionID)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                _context.Update(position);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobHistory"] = new SelectList(_context.JobHistory, "ID", "Employer");
            return View(position);
        }

        // GET: Positions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Position
                .SingleOrDefaultAsync(m => m.PositionID == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var position = await _context.Position.SingleOrDefaultAsync(m => m.PositionID == id);
            _context.Position.Remove(position);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PositionExists(int id)
        {
            return _context.Position.Any(e => e.PositionID == id);
        }
    }
}
