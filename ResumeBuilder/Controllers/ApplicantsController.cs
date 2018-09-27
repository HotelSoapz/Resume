using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResumeBuilderContext.Data;
using ResumeBuilderContext.Models;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace ResumeBuilderContext.Controllers
{
    public class ApplicantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Applicants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Applicant.ToListAsync());
        }

        // GET: Applicants/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.Applicant
                .SingleOrDefaultAsync(m => m.ID == id);
            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        // GET: Applicants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,StreedAddress,City,State,ZipCode,PhoneNumber,EmailAddress,Summary")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicant);
        }

        // GET: Applicants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.Applicant.SingleOrDefaultAsync(m => m.ID == id);
            if (applicant == null)
            {
                return NotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,StreedAddress,City,State,ZipCode,PhoneNumber,EmailAddress,Summary")] Applicant applicant)
        {
            if (id != applicant.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(applicant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(applicant);
        }

        // GET: Applicants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.Applicant
                .SingleOrDefaultAsync(m => m.ID == id);
            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicant = await _context.Applicant.FirstOrDefaultAsync(m => m.ID == id);



            foreach (var current in _context.Duties.Where(y => y.Position.JobHistories.ApplicantID == id))
            {
                _context.Duties.Remove(current);
            }
            foreach (var current in _context.Position.Where(y => y.JobHistories.ApplicantID == id))
            {
                _context.Position.Remove(current);
            }
            foreach (var current in _context.JobHistory.Where(y => y.ApplicantID == id))
            {
                _context.JobHistory.Remove(current);
            }
            foreach (var current in _context.Skills.Where(y => y.ApplicantID == id))
            {
                _context.Skills.Remove(current);
            }
            foreach (var current in _context.References.Where(y => y.ApplicantID == id))
            {
                _context.References.Remove(current);
            }
            foreach (var current in _context.Portfolio.Where(y => y.ApplicantID == id))
            {
                _context.Portfolio.Remove(current);
            }
            foreach (var current in _context.Education.Where(y => y.ApplicantID == id))
            {
                _context.Education.Remove(current);
            }

            _context.Applicant.Remove(applicant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool ApplicantExists(int id)
        {
            return _context.Applicant.Any(e => e.ID == id);
        }
    }
}
