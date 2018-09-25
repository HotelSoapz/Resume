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
    public class JobHistoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobHistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobHistories
        public async Task<IActionResult> Index()
        {
            var ResumeBuilderContext = _context.JobHistory
                .AsNoTracking()
                .Include(y => y.Applicant);
            return View(await ResumeBuilderContext.ToListAsync());
        }

        // GET: JobHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobHistory = await _context.JobHistory
                .AsNoTracking()
                .Include(y => y.Applicant)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (jobHistory == null)
            {
                return NotFound();
            }

            return View(jobHistory);
        }

        // GET: JobHistories/Create
        public IActionResult Create()
        {
            ViewData["Applicant"] = new SelectList(_context.Applicant, "ID", "FullName");
            return View();
        }

        // POST: JobHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,JobTitle,Employer,City,State,StartMonth,StartYear,EndMonth,EndYear,CurrentlyEmployed,ApplicantID")] JobHistory jobHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Applicant"] = new SelectList(_context.Applicant, "ID", "FullName", jobHistory.Applicant);
            return View(jobHistory);
        }

        // GET: JobHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobHistory = await _context.JobHistory.SingleOrDefaultAsync(m => m.ID == id);
            if (jobHistory == null)
            {
                return NotFound();
            }
            ViewData["Applicant"] = new SelectList(_context.Applicant, "ID", "FullName", jobHistory.Applicant);
            return View(jobHistory);

        }

        // POST: JobHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,JobTitle,Employer,City,State,StartMonth,StartYear,EndMonth,EndYear,CurrentlyEmployed,ApplicantID")] JobHistory jobHistory)
        {
            if (id != jobHistory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(jobHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Applicant"] = new SelectList(_context.Applicant, "ID", "FullName", jobHistory.Applicant);
            return View(jobHistory);
            
        }

        // GET: JobHistories/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? concurrencyError)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobHistory = await _context.JobHistory
                .SingleOrDefaultAsync(m => m.ID == id);
            if (jobHistory == null)
            {
                return NotFound();
            }
            return View(jobHistory);
        }

        // POST: JobHistories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(JobHistory jobHistory)
        {
            
            try
            {
                if(await _context.JobHistory.AnyAsync(y => y.ID == jobHistory.ID))
                {
                    _context.JobHistory.Remove(jobHistory);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction(nameof(Delete), new { concurrencyError = true, id = jobHistory.ID });
            }
        }

        private bool JobHistoryExists(int id)
        {
            return _context.JobHistory.Any(e => e.ID == id);
        }
    }
}
