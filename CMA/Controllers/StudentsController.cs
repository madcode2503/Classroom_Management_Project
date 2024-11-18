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
    public class StudentsController : Controller
    {
        private readonly CMAContext _context;

        public StudentsController(CMAContext context)
        {
            _context = context;
        }

        // GET: Student's parents list
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }
        // Display students list with full of CRUD operations, only logged in users can access
        [Authorize]
        public async Task<IActionResult> Index2()
        {
            return View(await _context.Students.ToListAsync());
        }
        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student,Student_Backup student_Backup,Grade_Book grade_Book,
            Math_Attendance math_Attendance,Physics_Attendance physics_Attendance,Chemistry_Attendance chemistry_Attendance
            ,Biology_Attendance biology_Attendance,History_Attendance history_Attendance,Literature_Attendance literature_Attendance
            ,Attendance_Chart chart)

        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            student.CreatedBy = User.Identity.Name;
            student.CreatedOn = DateTime.Now;
            grade_Book.Remarks = "Admission Allowed";
            math_Attendance.Percentage = 100;
            math_Attendance.Remarks = "Admission Allowed";
            physics_Attendance.Percentage = 100;
            physics_Attendance.Remarks = "Admission Allowed";
            chemistry_Attendance.Percentage = 100;
            chemistry_Attendance.Remarks = "Admission Allowed";
            biology_Attendance.Percentage = 100;
            biology_Attendance.Remarks = "Admission Allowed";
            history_Attendance.Percentage = 100;
            history_Attendance.Remarks = "Admission Allowed";
            literature_Attendance.Percentage = 100;
            literature_Attendance.Remarks = "Admission Allowed";
            chart.Math_Attendance = 100;
            chart.History_Attendance = 100;
            chart.Physics_Attendance = 100;
            chart.Biology_Attendance = 100;
            chart.Literature_Attendance = 100;
            chart.Chemitry_Attendance = 100;
            chart.Remarks = "Admission Allowed";
            if (ModelState.IsValid)
            {
                _context.Add(student);
                _context.Add(student_Backup);
                _context.Add(grade_Book);  
                _context.Add(math_Attendance);
                _context.Add(physics_Attendance);
                _context.Add(chemistry_Attendance);
                _context.Add(biology_Attendance);
                _context.Add(history_Attendance);
                _context.Add(literature_Attendance);
                _context.Add(chart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index2));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Student student,Student_Backup student_Backup)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.

                student.ModifiedBy = User.Identity.Name;
                student.ModifiedOn = DateTime.Now;

                try
                {
                    _context.Update(student);
                    _context.Update(student_Backup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        /*
         Used to ensure that when delete a student from students list , this student in other lists will be removed as well.
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            var gb_student= await _context.GradeBook.FindAsync(student.Id);
            var math_attend= await _context.math_Attendance.FindAsync(student.Id);
            var physics_attend = await _context.physics_Attendance.FindAsync(student.Id);
            var chemistry_attend = await _context.chemistry_Attendance.FindAsync(student.Id);
            var bio_attend = await _context.biology_Attendance.FindAsync(student.Id);
            var history_attend = await _context.history_Attendance.FindAsync(student.Id);
            var lit_attend = await _context.lit_Attendance.FindAsync(student.Id);
            var chart= await _context.attendance_Chart.FindAsync(student.Id);
            if (student != null)
            {
                _context.Students.Remove(student);
#pragma warning disable CS8604 // Possible null reference argument.
                _context.GradeBook.Remove(gb_student);
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning disable CS8604 // Possible null reference argument.
                _context.math_Attendance.Remove(math_attend);
#pragma warning restore CS8604 // Possible null reference argument.
                _context.physics_Attendance.Remove(physics_attend);
                _context.chemistry_Attendance.Remove(chemistry_attend);
                _context.biology_Attendance.Remove(bio_attend);
                _context.history_Attendance.Remove(history_attend);
                _context.lit_Attendance.Remove(lit_attend);
                _context.attendance_Chart.Remove(chart);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index2));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
