using HospitalManagment.Data;
using HospitalManagment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace HospitalManagment.Controllers
{
    public class PerciptionController : Controller
    {
        private readonly AppDBContext _context;

        public PerciptionController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Perciption
        public async Task<IActionResult> Index()
        {
            var perciptions = await _context.Perciptions
                                    .Include(p => p.Doctor)
                                    .Include(p => p.Patient)
                                    .ToListAsync();
            return View(perciptions);
        }

        // GET: Perciption/Create
        public IActionResult Create()
        {
            ViewBag.Doctors = new SelectList(_context.Doctors, "Id", "Name");
            ViewBag.Patients = new SelectList(_context.Patients, "Id", "Name");
            return View();
        }

        // POST: Perciption/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Perciption perciption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perciption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Doctors = new SelectList(_context.Doctors, "Id", "Name", perciption.DoctorId);
            ViewBag.Patients = new SelectList(_context.Patients, "Id", "Name", perciption.PatientId);
            return View(perciption);
        }

        // GET: Perciption/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var perciption = await _context.Perciptions.FindAsync(id);
            if (perciption == null) return NotFound();

            ViewBag.Doctors = new SelectList(_context.Doctors, "Id", "Name", perciption.DoctorId);
            ViewBag.Patients = new SelectList(_context.Patients, "Id", "Name", perciption.PatientId);

            return View(perciption);
        }

        // POST: Perciption/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Perciption perciption)
        {
            if (id != perciption.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perciption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Perciptions.Any(e => e.Id == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Doctors = new SelectList(_context.Doctors, "Id", "Name", perciption.DoctorId);
            ViewBag.Patients = new SelectList(_context.Patients, "Id", "Name", perciption.PatientId);
            return View(perciption);
        }

        // GET: Perciption/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var perciption = await _context.Perciptions
                .Include(p => p.Doctor)
                .Include(p => p.Patient)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (perciption == null) return NotFound();

            return View(perciption);
        }

        // POST: Perciption/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perciption = await _context.Perciptions.FindAsync(id);
            if (perciption != null)
            {
                _context.Perciptions.Remove(perciption);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
