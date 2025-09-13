using Microsoft.AspNetCore.Mvc;
using ShopPlatform.Web2.Services;
using System.Threading.Tasks;

namespace ShopPlatform.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            return View(employees);
        }

        public async Task<IActionResult> Details(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.CreationDate = DateTime.Now;
                employee.CreationUser = 1; // Por ahora hardcodeado

                var success = await _employeeService.CreateEmployeeAsync(employee);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Error al crear el empleado");
            }
            return View(employee);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.EmpId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                employee.ModifyDate = DateTime.Now;
                employee.ModifyUser = 1; 

                var success = await _employeeService.UpdateEmployeeAsync(id, employee);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Error al actualizar el empleado");
            }
            return View(employee);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _employeeService.DeleteEmployeeAsync(id, 1); // deleteUser hardcodeado
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "Error al eliminar el empleado";
            return RedirectToAction(nameof(Index));
        }
    }
}
