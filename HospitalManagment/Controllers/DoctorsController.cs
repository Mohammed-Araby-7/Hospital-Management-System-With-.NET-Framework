using HospitalManagment.Data;
using HospitalManagment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagment.Controllers
{
    public class DoctorsController : Controller
    {
        public readonly AppDBContext _context;
        public DoctorsController(AppDBContext context)
        {
            _context = context;
        }


        //Get Doctors
        public async Task<IActionResult> Index()
        {
            var doctors = await _context.Doctors
                .Include(d => d.Clinic)  // JOIN
                .ToListAsync();
            return View(doctors);
        }

        //Add Doctor 
        public IActionResult Create()
        {
            ViewBag.Clinics = new SelectList(_context.Clinics, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Doctor emp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Clinics = new SelectList(_context.Clinics, "Id", "Name", emp.ClinicId);
            return View(emp);

        }

        public IActionResult Sucess()
        {
            return View();
        }

        //Update


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var Doctor = await _context.Doctors.FindAsync(id);
            if (Doctor == null) return NotFound();

            ViewBag.Clinics = new SelectList(_context.Clinics, "Id", "Name", Doctor.ClinicId);

            return View(Doctor);
        }


        [HttpPost ,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPage(int id, Doctor emp)
        {
            if (id != emp.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Doctors.Update(emp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Doctors.Any(e => e.Id == id))
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
            ViewBag.Clinics = new SelectList(_context.Clinics, "Id", "Name", emp.ClinicId);
            return View(emp);
        }


        //Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var doctor = await _context.Doctors
                .Include(d => d.Clinic)  // JOIN to show clinic name
                .FirstOrDefaultAsync(m => m.Id == id);

            if (doctor == null) return NotFound();

            return View(doctor);
        }

        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Doctor = await _context.Doctors.FindAsync(id);
            if (Doctor != null)
            {
                _context.Doctors.Remove(Doctor);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));

        }
    }
}
