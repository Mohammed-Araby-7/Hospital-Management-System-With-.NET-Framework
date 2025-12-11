using HospitalManagment.Data;
using HospitalManagment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagment.Controllers
{
    public class EmployeesController : Controller
    {
        public readonly AppDBContext _context;
        public EmployeesController(AppDBContext context)
        {
            _context = context;
        }


        //Get Employees
        public async Task<IActionResult> Index()
        {
            var Employees = await _context.Employees.ToListAsync();
            return View(Employees);
        }

        //Add Employee 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emp);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Sucess));
            }

            return View(emp);

        }

        public IActionResult Sucess()
        {
            return View();
        }

        //Update
        

        public async Task<IActionResult> Edit(int?id)
        {
            if (id == null) return NotFound();

            var Employee  = await _context.Employees.FindAsync(id);
            if (Employee == null) return NotFound();

            return View(Employee);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee emp)
        {
            if(id != emp.Id) return NotFound();

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(emp);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!_context.Employees.Any(e=>e.Id == id))
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
            return View(emp);
        }


        //Delete
        public async Task<IActionResult> Delete(int?id)
        {
            if (id == null) return NotFound();
            var Employee = await _context.Employees.FindAsync(id);
            if(Employee ==null) return NotFound();

            return View(Employee);
        }

        [HttpPost,ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Employee = await _context.Employees.FindAsync(id);
            if(Employee != null)
            {
                _context.Employees.Remove(Employee);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));

        }
    }
}
