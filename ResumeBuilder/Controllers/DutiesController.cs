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
    public class DutiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DutiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Duties
        public async Task<IActionResult> Index()
        {
            var ResumeBuilderContext = _context.Position
                .AsNoTracking()
                .Include(y => y.PositionID);
            return View(await _context.Duties.ToListAsync());
        }

        // GET: Duties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duties = await _context.Duties
                .AsNoTracking()
                .Include(y => y.Position)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (duties == null)
            {
                return NotFound();
            }
            return View(duties);
        }

        // GET: Duties/Create
        public IActionResult Create()
        {
            ViewData["Position"] = new SelectList(_context.Position, "PositionID", "Title");
            return View();
        }

        // POST: Duties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PositionID,Description")] Duties duties)
        {
            if (ModelState.IsValid)
            {
                _context.Add(duties);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Position"] = new SelectList(_context.Position, "PositionID", "Title", duties.Position);
            return View(duties);
        }

        // GET: Duties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duties = await _context.Duties.SingleOrDefaultAsync(m => m.ID == id);
            if (duties == null)
            {
                return NotFound();
            }
            ViewData["Position"] = new SelectList(_context.Position, "PositionID", "Title", duties.Position);
            return View(duties);
        }

        // POST: Duties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PositionID,Description,ID")] Duties duties)
        {
            if (id != duties.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(duties);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            ViewData["Position"] = new SelectList(_context.Position, "PositionID", "Title", duties.Position);
            return View(duties);
        }

        // GET: Duties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duties = await _context.Duties
                .SingleOrDefaultAsync(m => m.ID == id);
            if (duties == null)
            {
                return NotFound();
            }

            return View(duties);
        }

        // POST: Duties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var duties = await _context.Duties.SingleOrDefaultAsync(m => m.ID == id);
            _context.Duties.Remove(duties);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DutiesExists(int id)
        {
            return _context.Duties.Any(e => e.ID == id);
        }
    }
}
