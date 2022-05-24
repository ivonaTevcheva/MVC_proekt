using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_proekt.Data;
using MVC_proekt.Models;

namespace MVC_proekt.Controllers
{
    public class StudentSubjectsController : Controller
    {
        private readonly MVC_proektContext _context;

        public StudentSubjectsController(MVC_proektContext context)
        {
            _context = context;
        }

        // GET: StudentSubjects
        public async Task<IActionResult> Index()
        {
            var mVC_proektContext = _context.StudentSubject.Include(s => s.Course).Include(s => s.Student);
            return View(await mVC_proektContext.ToListAsync());
        }

        // GET: StudentSubjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentSubject == null)
            {
                return NotFound();
            }

            var studentSubject = await _context.StudentSubject
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentSubject == null)
            {
                return NotFound();
            }

            return View(studentSubject);
        }

        // GET: StudentSubjects/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Subject, "Id", "Title");
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FirstName");
            return View();
        }

        // POST: StudentSubjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseId,StudentId,Semester,Year,Grade,SeminaIUrl,ProjectUrl,ExamPoints,SeminalPoints,AdditionalPoints,FinishDate")] StudentSubject studentSubject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentSubject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Subject, "Id", "Title", studentSubject.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FirstName", studentSubject.StudentId);
            return View(studentSubject);
        }

        // GET: StudentSubjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentSubject == null)
            {
                return NotFound();
            }

            var studentSubject = await _context.StudentSubject.FindAsync(id);
            if (studentSubject == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Subject, "Id", "Title", studentSubject.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FirstName", studentSubject.StudentId);
            return View(studentSubject);
        }

        // POST: StudentSubjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseId,StudentId,Semester,Year,Grade,SeminaIUrl,ProjectUrl,ExamPoints,SeminalPoints,AdditionalPoints,FinishDate")] StudentSubject studentSubject)
        {
            if (id != studentSubject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentSubject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentSubjectExists(studentSubject.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Subject, "Id", "Title", studentSubject.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FirstName", studentSubject.StudentId);
            return View(studentSubject);
        }

        // GET: StudentSubjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentSubject == null)
            {
                return NotFound();
            }

            var studentSubject = await _context.StudentSubject
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentSubject == null)
            {
                return NotFound();
            }

            return View(studentSubject);
        }

        // POST: StudentSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentSubject == null)
            {
                return Problem("Entity set 'MVC_proektContext.StudentSubject'  is null.");
            }
            var studentSubject = await _context.StudentSubject.FindAsync(id);
            if (studentSubject != null)
            {
                _context.StudentSubject.Remove(studentSubject);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentSubjectExists(int id)
        {
          return (_context.StudentSubject?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
