using Microsoft.AspNetCore.Mvc;
using ShopPlatform.Web2.Services;
using System.Threading.Tasks;

namespace ShopPlatform.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetCustomersAsync();
            return View(customers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.CreationDate = DateTime.Now;
                customer.CreationUser = 1;

                var success = await _customerService.CreateCustomerAsync(customer);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Error al crear el customer");
            }
            return View(customer);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (id != customer.CustId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                customer.ModifyDate = DateTime.Now;
                customer.ModifyUser = 1;

                var success = await _customerService.UpdateCustomerAsync(id, customer);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Error al actualizar el customer");
            }
            return View(customer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _customerService.DeleteCustomerAsync(id, 1); // deleteUser hardcodeado
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "Error al eliminar el customer";
            return RedirectToAction(nameof(Index));
        }
    }
}
