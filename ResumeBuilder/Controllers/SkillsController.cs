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
    public class SkillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Skills
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var ResumeBuilderContext = _context.Skills
                .AsNoTracking()
                .Include(y => y.Applicant);
            return View(await _context.Skills.ToListAsync());
        }

        // GET: Skills/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skills = await _context.Skills
                .AsNoTracking()
                .Include(y => y.Applicant)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (skills == null)
            {
                return NotFound();
            }

            return View(skills);
        }

        // GET: Skills/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["Applicant"] = new SelectList(_context.Applicant, "ID", "FullName");
            return View();
        }

        // POST: Skills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Skill,ApplicantID")] Skills skills)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skills);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Applicant"] = new SelectList(_context.Applicant, "ID", "FullName", skills.Applicant);
            return View(skills);
        }

        // GET: Skills/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skills = await _context.Skills.SingleOrDefaultAsync(m => m.ID == id);
            if (skills == null)
            {
                return NotFound();
            }
            ViewData["Applicant"] = new SelectList(_context.Applicant, "ID", "FullName", skills.Applicant);
            return View(skills);
        }

        // POST: Skills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Skill,ApplicantID")] Skills skills)
        {
            if (id != skills.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(skills);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Applicant"] = new SelectList(_context.Applicant, "ID", "FullName", skills.Applicant);
            return View(skills);
        }

        // GET: Skills/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skills = await _context.Skills
                .SingleOrDefaultAsync(m => m.ID == id);
            if (skills == null)
            {
                return NotFound();
            }

            return View(skills);
        }

        // POST: Skills/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skills = await _context.Skills.SingleOrDefaultAsync(m => m.ID == id);
            _context.Skills.Remove(skills);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkillsExists(int id)
        {
            return _context.Skills.Any(e => e.ID == id);
        }
    }
}
