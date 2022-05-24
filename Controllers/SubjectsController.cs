using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_proekt.Data;
using MVC_proekt.Models;
using MVC_proekt.ViewModels;

namespace MVC_proekt.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly MVC_proektContext _context;

        public SubjectsController(MVC_proektContext context)
        {
            _context = context;
        }

        // GET: Subjects
        public async Task<IActionResult> Index(string ProgramaString, int SemestarString, string SearchString)
        {
            IQueryable<Subject> subjects = _context.Subject.AsQueryable();
            IQueryable<string> programaQuery = _context.Subject.OrderBy(m => m.Programme).Select(m => m.Programme).Distinct();
            IQueryable<int> semesterQuery = _context.Subject.OrderBy(m => m.Semester).Select(m => m.Semester).Distinct();
            if (!string.IsNullOrEmpty(SearchString))
            {
                subjects = subjects.Where(s => s.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(ProgramaString))
            {
                subjects = subjects.Where(x => x.Programme == ProgramaString);
            }
            if (SemestarString != null && SemestarString!=0)
            {
                subjects = subjects.Where(x => x.Semester == SemestarString);
            }
            subjects = subjects.Include(m => m.FirstProfessor).Include(m => m.SecondProfessor);
            var predmetFilter = new PredmetFilter
            {
                ProgramaList = new SelectList(await programaQuery.ToListAsync()),
                SemestarList = new SelectList(await semesterQuery.ToListAsync()),
                Subject = await subjects.ToListAsync()
            };
            return View(predmetFilter);

        }

        // GET: Subjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Subject == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject
                .Include(s => s.FirstProfessor)
                .Include(s => s.SecondProfessor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: Subjects/Create
        public IActionResult Create()
        {
            ViewData["FirstProfessorId"] = new SelectList(_context.Professor, "Id", "FirstName");
            ViewData["SecondProfessorId"] = new SelectList(_context.Professor, "Id", "FirstName");
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Credits,Semester,Programme,EducationLevel,FirstProfessorId,SecondProfessorId")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FirstProfessorId"] = new SelectList(_context.Professor, "Id", "FirstName", subject.FirstProfessorId);
            ViewData["SecondProfessorId"] = new SelectList(_context.Professor, "Id", "FirstName", subject.SecondProfessorId);
            return View(subject);
        }

        // GET: Subjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Subject == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            ViewData["FirstProfessorId"] = new SelectList(_context.Professor, "Id", "FirstName", subject.FirstProfessorId);
            ViewData["SecondProfessorId"] = new SelectList(_context.Professor, "Id", "FirstName", subject.SecondProfessorId);
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Credits,Semester,Programme,EducationLevel,FirstProfessorId,SecondProfessorId")] Subject subject)
        {
            if (id != subject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.Id))
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
            ViewData["FirstProfessorId"] = new SelectList(_context.Professor, "Id", "FirstName", subject.FirstProfessorId);
            ViewData["SecondProfessorId"] = new SelectList(_context.Professor, "Id", "FirstName", subject.SecondProfessorId);
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Subject == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject
                .Include(s => s.FirstProfessor)
                .Include(s => s.SecondProfessor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Subject == null)
            {
                return Problem("Entity set 'MVC_proektContext.Subject'  is null.");
            }
            var subject = await _context.Subject.FindAsync(id);
            if (subject != null)
            {
                _context.Subject.Remove(subject);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int id)
        {
          return (_context.Subject?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: PregledPredmetiPoNastavnik
        public async Task<IActionResult> PregledPredmetiPoNastavnik(int id)
        {
            IQueryable<Subject> subjects = _context.Subject.Where(x => x.Id == id).Include(x => x.FirstProfessor).Include(x => x.SecondProfessor);
           
            return View(await subjects.ToListAsync());

        }
    }
}
