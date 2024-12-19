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
    public class Literature_AttendanceController : Controller
    {
        private readonly CMAContext _context;

        public Literature_AttendanceController(CMAContext context)
        {
            _context = context;
        }

        // GET: Literature_Attendance
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.lit_Attendance.FromSql($"Select * from lit_Attendance Order By FirstName ASC ").ToListAsync());
        }
        /*
        * Get a list of selected student ID from the user. Traverse the attendance list to find the student with matched ID
        * If a student exists, plus their number of lecture absences by 1
        * The percentage of absences in the Chart as well as in the Gradebook will be assigned as that one of Attendance Tracker table 
        * If the percentage of absences is smaller than 80, the Remarks will be "Admission Rejected", then the student will be rejected from class.
        * Consequencely, their information in the gradebook will not be displayed.
        * 
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
                        var data = _context.lit_Attendance.Where(x => x.Id == id).FirstOrDefault();
                        var gradebook = _context.GradeBook.Where(y => y.Id == id).FirstOrDefault();
                        var attend = _context.attendance_Chart.Where(z => z.Id == id).FirstOrDefault();
                        if (data != null)
                        {
                            data.Lectures_Absent++;
                            data.Percentage = 100 - (((float)data.Lectures_Absent / 25) * 100);
                            attend.Literature_Attendance = data.Percentage;
                            if (data.Percentage < 80)
                            {
                                data.Remarks = "Admission Rejected";
                                gradebook.Remarks = "Admission Rejected";
                                gradebook.Literature = 0;
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
        public IActionResult Edit_Num_Lectures()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit_Num_Lectures([Bind("Total_lectures")] Literature_Attendance m_a)
        {

            if (ModelState.IsValid)
            {
                _context.lit_Attendance.Where(x => x.Total_lectures == 0 || x.Total_lectures != 0)
                    .ExecuteUpdate(x => x.SetProperty(p => p.Total_lectures, m_a.Total_lectures));

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(m_a);
        }

        private bool Literature_AttendanceExists(int id)
        {
            return _context.lit_Attendance.Any(e => e.Id == id);
        }
    }
}
