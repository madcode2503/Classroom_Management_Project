using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMA.Context;
using CMA.Models;
using Microsoft.AspNetCore.Authorization;

namespace CMA.Controllers
{
    public class Attendance_ChartController : Controller
    {
        private readonly CMAContext _context;

        public Attendance_ChartController(CMAContext context)
        {
            _context = context;
        }

        // GET: Attendance_Chart 
        // Sort by Name from A->Z
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.attendance_Chart.FromSql($"Select * from attendance_Chart Order By FirstName ASC").ToListAsync());
            
        }

        // GET: Attendance_Chart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance_Chart = await _context.attendance_Chart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendance_Chart == null)
            {
                return NotFound();
            }

            return View(attendance_Chart);
        }

        private bool Attendance_ChartExists(int id)
        {
            return _context.attendance_Chart.Any(e => e.Id == id);
        }
    }
}
