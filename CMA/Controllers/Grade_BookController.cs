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
    public class Grade_BookController : Controller
    {
        private readonly CMAContext _context;

        public Grade_BookController(CMAContext context)
        {
            _context = context;
        }

        // GET: Grade_Book
        public async Task<IActionResult> Index()
        {
            var gradebooks = await _context.GradeBook.FromSql($"Select * from GradeBook where Remarks='Admission Allowed' ").ToListAsync();
            foreach (var gradebook in gradebooks)
            {
                // Calculate the average grade as well as the letter grade of each student
                
                    gradebook.Avg_grade = (gradebook.Mathematics + gradebook.Physics + gradebook.Chemistry +
                    gradebook.History + gradebook.Biology + gradebook.Literature) / 6f;
                    if (gradebook.Avg_grade >= 97)
                    {
                        gradebook.Letter_grade = "A+";
                    }
                    else if (gradebook.Avg_grade >= 93)
                    {
                        gradebook.Letter_grade = "A";
                    }
                    else if (gradebook.Avg_grade >= 90)
                    {
                        gradebook.Letter_grade = "A-";
                    }
                    else if (gradebook.Avg_grade >= 87)
                    {
                        gradebook.Letter_grade = "B+";
                    }
                    else if (gradebook.Avg_grade >= 83)
                    {
                        gradebook.Letter_grade = "B";
                    }
                    else if (gradebook.Avg_grade >= 80)
                    {
                        gradebook.Letter_grade = "B-";
                    }
                    else if (gradebook.Avg_grade >= 77)
                    {
                        gradebook.Letter_grade = "C+";
                    }
                    else if (gradebook.Avg_grade >= 73)
                    {
                        gradebook.Letter_grade = "C";
                    }
                    else if (gradebook.Avg_grade >= 70)
                    {
                        gradebook.Letter_grade = "C-";
                    }
                    else if (gradebook.Avg_grade >= 67)
                    {
                        gradebook.Letter_grade = "D+";
                    }
                    else if (gradebook.Avg_grade >= 65)
                    {
                        gradebook.Letter_grade = "D";
                    }
                    else
                    {
                        gradebook.Letter_grade = "F";
                    }
                
            }
            return View(gradebooks);
        }
        //Require user to login before accessing to this feature.
        [Authorize]
        // Gradebook with full of CRUD operations
        public async Task<IActionResult> Index2()
        {
            var gradebooks= await _context.GradeBook.FromSql($"Select * from GradeBook where Remarks='Admission Allowed' ").ToListAsync();
            foreach (var gradebook in gradebooks)
            {
                    gradebook.Avg_grade = (gradebook.Mathematics + gradebook.Physics + gradebook.Chemistry +
                    gradebook.History + gradebook.Biology + gradebook.Literature) / 6f;
                    if (gradebook.Avg_grade >= 97)
                    {
                        gradebook.Letter_grade = "A+";
                    }
                    else if (gradebook.Avg_grade >= 93)
                    {
                        gradebook.Letter_grade = "A";
                    }
                    else if (gradebook.Avg_grade >= 90)
                    {
                        gradebook.Letter_grade = "A-";
                    }
                    else if (gradebook.Avg_grade >= 87)
                    {
                        gradebook.Letter_grade = "B+";
                    }
                    else if (gradebook.Avg_grade >= 83)
                    {
                        gradebook.Letter_grade = "B";
                    }
                    else if (gradebook.Avg_grade >= 80)
                    {
                        gradebook.Letter_grade = "B-";
                    }
                    else if (gradebook.Avg_grade >= 77)
                    {
                        gradebook.Letter_grade = "C+";
                    }
                    else if (gradebook.Avg_grade >= 73)
                    {
                        gradebook.Letter_grade = "C";
                    }
                    else if (gradebook.Avg_grade >= 70)
                    {
                        gradebook.Letter_grade = "C-";
                    }
                    else if (gradebook.Avg_grade >= 67)
                    {
                        gradebook.Letter_grade = "D+";
                    }
                    else if (gradebook.Avg_grade >= 65)
                    {
                        gradebook.Letter_grade = "D";
                    }
                    else
                    {
                        gradebook.Letter_grade = "F";
                    }
                
            }
            return View(gradebooks);
            
        }

        // GET: Grade_Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade_Book = await _context.GradeBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grade_Book == null)
            {
                return NotFound();
            }

            return View(grade_Book);
        }

        // GET: Grade_Book/Create
        public IActionResult Create()
        {
            return View();
        }

        
        // GET: Grade_Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade_Book = await _context.GradeBook.FindAsync(id);
            if (grade_Book == null)
            {
                return NotFound();
            }
            return View(grade_Book);
        }

        // POST: Grade_Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Grade_Book grade_Book)
        {
            if (id != grade_Book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    grade_Book.Remarks = "Admission Allowed";
                    _context.Update(grade_Book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Grade_BookExists(grade_Book.Id))
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
            return View(grade_Book);
        }

        // GET: Grade_Book/Delete/5
        public async Task<IActionResult> Reset_grades(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade_Book = await _context.GradeBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grade_Book == null)
            {
                return NotFound();
            }

            return View(grade_Book);
        }

        // POST: Reset all the grades of a specificed student to 0 in order to update new grades in case it is a new semester. 
        [HttpPost,ActionName("Reset_grades")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reset_grades_Confirmed(int id)
        {
            var grade_Book = await _context.GradeBook.FindAsync(id);
            if (grade_Book != null)
            {
                grade_Book.Mathematics = 0;
                grade_Book.Literature= 0;
                grade_Book.Biology = 0;
                grade_Book.History = 0;
                grade_Book.Chemistry = 0;
                grade_Book.Physics = 0;
                grade_Book.Remarks = "Admission Allowed";
                _context.Update(grade_Book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index2));
        }
        //public async Task<IActionResult> Reset_Grade(int id)
        //{
        //    var data=_context.GradeBook.Where(x=>x.Id == id).FirstOrDefault();
        //    string res=string.Empty;
        //    if(data != null){
        //        data.Mathematics=0;
        //        data.Literature = 0;
        //        data.Biology = 0;
        //        data.History = 0;
        //        data.Chemistry = 0;
        //        data.Physics = 0;
        //        data.Remarks = "Admission Allowed";
        //    }
        //    await _context.SaveChangesAsync();
        //    TempData['success'] = "Update Successfully";
        //    res = "success";
        //    return JsonResult(res);
        //}
        private bool Grade_BookExists(int id)
        {
            return _context.GradeBook.Any(e => e.Id == id);
        }
    }
}
