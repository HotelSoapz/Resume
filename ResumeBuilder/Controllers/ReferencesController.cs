using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResumeBuilderContext.Data;
using ResumeBuilderContext.Models;

namespace ResumeBuilderContext.Controllers
{
    public class ReferencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReferencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: References
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var ResumeBuilderContext = _context.References
                .AsNoTracking()
                .Include(y => y.Applicant);
            return View(await _context.References.ToListAsync());
        }

        // GET: References/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var references = await _context.References
                .AsNoTracking()
                .Include(y => y.Applicant)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (references == null)
            {
                return NotFound();
            }

            return View(references);
        }

        // GET: References/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["Applicant"] = new SelectList(_context.Applicant, "ID", "FullName");
            return View();
        }

        // POST: References/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,RefferenceName,Title,CompanyName,PhoneNumber,EmailAddress,Relation,ApplicantID")] References references)
        {
            if (ModelState.IsValid)
            {
                _context.Add(references);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Applicant"] = new SelectList(_context.Applicant, "ID", "FullName",references.Applicant);
            return View(references);
        }

        // GET: References/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var references = await _context.References.SingleOrDefaultAsync(m => m.ID == id);
            if (references == null)
            {
                return NotFound();
            }
            ViewData["Applicant"] = new SelectList(_context.Applicant, "ID", "FullName", references.Applicant);
            return View(references);
        }

        // POST: References/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,RefferenceName,Title,CompanyName,PhoneNumber,EmailAddress,Relation,ApplicantID")] References references)
        {
            if (id != references.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(references);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Applicant"] = new SelectList(_context.Applicant, "ID", "FullName",references.Applicant);
            return View(references);
        }

        // GET: References/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var references = await _context.References
                .SingleOrDefaultAsync(m => m.ID == id);
            if (references == null)
            {
                return NotFound();
            }

            return View(references);
        }

        // POST: References/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var references = await _context.References.SingleOrDefaultAsync(m => m.ID == id);
            _context.References.Remove(references);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferencesExists(int id)
        {
            return _context.References.Any(e => e.ID == id);
        }
    }
}
