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
    public class ScheduleController : Controller
    {
        private readonly CMAContext _context;

        public ScheduleController(CMAContext context)
        {
            _context = context;
        }

        // GET: Schedules
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.schedule
                .ToListAsync());
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Index2()
        {
            return View(await _context.schedule.ToListAsync());
        }
        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.schedule.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Time,Monday,Tuesday,Wednesday,Thursday,Friday")] Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index2));
            }
            return View(schedule);
        }
        private bool ScheduleExists(int id)
        {
            return _context.schedule.Any(e => e.Id == id);
        }
    }
}
