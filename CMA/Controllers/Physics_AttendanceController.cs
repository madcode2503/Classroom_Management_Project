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
    public class Physics_AttendanceController : Controller
    {
        private readonly CMAContext _context;

        public Physics_AttendanceController(CMAContext context)
        {
            _context = context;
        }

        // GET: Physics_Attendance
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var data_set = await _context.physics_Attendance.FromSql($"Select * from physics_Attendance Order By FirstName ASC ").ToListAsync();
            return View(data_set);
        }

        // GET: Physics_Attendance/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var physics_Attendance = await _context.physics_Attendance
                .FirstOrDefaultAsync(m => m.Id == id);
            if (physics_Attendance == null)
            {
                return NotFound();
            }

            return View(physics_Attendance);
        }
        /*
        * Get a list of selected student ID from the user. Traverse the attendance list to find the student with matched ID
        * If a student exists, plus their number of lecture absences by 1
        * The percentage of absences in the Chart as well as in the Gradebook will be assigned as that one of Attendance Tracker table 
        * If the percentage of absences is smaller than 80, the Remarks will be "Admission Rejected", then the student will be rejected from class.
        * Consequencely, their information in the gradebook will not be displayed.
        * Return the result to the user and reload the page to display new data 
        */
        public async Task<IActionResult> Update_Attendance(int[] ids)
        {
            string result = string.Empty;
            try
            {
                if (ids.Count() > 0)
                {
                    foreach (int id in ids)
                    {
                        var data = _context.physics_Attendance.Where(x => x.Id == id).FirstOrDefault();
                        var gradebook = _context.GradeBook.Where(y => y.Id == id).FirstOrDefault();
                        var attend = _context.attendance_Chart.Where(z => z.Id == id).FirstOrDefault();
                        if (data != null)
                        {
                            data.Lectures_Absent++;
                            // Percentage of absences
                            data.Percentage = 100 - (((float)data.Lectures_Absent / 25) * 100);
                            attend.Physics_Attendance = data.Percentage;
                            if (data.Percentage < 80)
                            {
                                data.Remarks = "Admission Rejected";
                                gradebook.Remarks = "Admission Rejected";
                                attend.Remarks = "Admission Rejected";
                            }
                        }
                    }
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Update successfully";
                    result = "success";
                }
            }
            catch (Exception)
            {
                throw;
            };
            return new JsonResult(result);
        }
        private bool Physics_AttendanceExists(int id)
        {
            return _context.physics_Attendance.Any(e => e.Id == id);
        }
    }
}
