using HospitalManagment.Data;
using HospitalManagment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagment.Controllers
{
    public class AppoinitmentsController : Controller
    {
        private readonly AppDBContext _context;

        public AppoinitmentsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Appoinitments
        public async Task<IActionResult> Index()
        {
            var appointments = await _context.Appoinitments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Clinic)
                .ToListAsync();

            return View(appointments);
        }

        // GET: Create
        public IActionResult Create()
        {
            ViewBag.Doctors = new SelectList(_context.Doctors, "Id", "Name");
            ViewBag.Patients = new SelectList(_context.Patients, "Id", "Name");
            ViewBag.Clinics = new SelectList(_context.Clinics, "Id", "Name");
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appoinitment app)
        {
            if (ModelState.IsValid)
            {
                _context.Add(app);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Doctors = new SelectList(_context.Doctors, "Id", "Name", app.DoctorId);
            ViewBag.Patients = new SelectList(_context.Patients, "Id", "Name", app.PatientId);
            ViewBag.Clinics = new SelectList(_context.Clinics, "Id", "Name", app.ClinicId);
            return View(app);
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var appointment = await _context.Appoinitments.FindAsync(id);
            if (appointment == null) return NotFound();

            ViewBag.Doctors = new SelectList(_context.Doctors, "Id", "Name", appointment.DoctorId);
            ViewBag.Patients = new SelectList(_context.Patients, "Id", "Name", appointment.PatientId);
            ViewBag.Clinics = new SelectList(_context.Clinics, "Id", "Name", appointment.ClinicId);
            return View(appointment);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Appoinitment app)
        {
            if (id != app.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(app);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Appoinitments.Any(e => e.Id == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Doctors = new SelectList(_context.Doctors, "Id", "Name", app.DoctorId);
            ViewBag.Patients = new SelectList(_context.Patients, "Id", "Name", app.PatientId);
            ViewBag.Clinics = new SelectList(_context.Clinics, "Id", "Name", app.ClinicId);
            return View(app);
        }

        // GET: Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var appointment = await _context.Appoinitments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Clinic)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (appointment == null) return NotFound();

            return View(appointment);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appoinitments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appoinitments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
