using HospitalManagment.Data;
using HospitalManagment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagment.Controllers
{
    public class PatientsController : Controller
    {

        public AppDBContext _context;

        public PatientsController(AppDBContext context)
        {
            _context = context;
        }
        //Get Employees
        public async Task<IActionResult> Index()
        {
            var patients = await _context.Patients
                                         .Include(p => p.Doctor)
                                         .ToListAsync();
            return View(patients);
        }

        //Add Employee 
        public IActionResult Create()
        {
            ViewBag.Doctors = new SelectList(_context.Doctors, "Id", "Name");
            return View();
        }

        [HttpPost]  
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Patient emp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // إعادة اختيار الدكتور عند حدوث خطأ
            ViewBag.Doctors = new SelectList(_context.Doctors, "Id", "Name", emp.DoctorId);
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

            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return NotFound();

            ViewBag.Doctors = new SelectList(_context.Doctors, "Id", "Name", patient.DoctorId);

            return View(patient);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Patient emp)
        {
            if (id != emp.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Patients.Any(e => e.Id == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Doctors = new SelectList(_context.Doctors, "Id", "Name", emp.DoctorId);
            return View(emp);
        }


        //Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var patient = await _context.Patients
                                        .Include(p => p.Doctor)
                                          .FirstOrDefaultAsync(m => m.Id == id);

            if (patient == null) return NotFound();

            return View(patient);
        }

        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));

        }
    }
}
