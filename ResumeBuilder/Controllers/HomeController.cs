using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeBuilderContext.Data;
using ResumeBuilderContext.Models;

namespace ResumeBuilderContext.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var MyResume = await _context.Applicant
                .AsNoTracking()
                .Include(y => y.Education)
                .Include(y => y.References)
                .Include(y => y.Skills)
                .Include(y => y.Portfolio)
                .Include(y => y.JobHistory)
                    .ThenInclude(y => y.Positions)
                        .ThenInclude(y => y.Duties)
                        .FirstOrDefaultAsync(y => y.FirstName == "Dustin");
            return View(MyResume);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
