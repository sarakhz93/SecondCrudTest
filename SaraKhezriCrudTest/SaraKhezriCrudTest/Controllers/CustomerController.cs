using Microsoft.AspNetCore.Mvc;
using SaraKhezriCrudTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaraKhezriCrudTest.Controllers
{
    public class CustomerController : Controller
    {
        readonly CustomerCommands _customerCommands;
        readonly CustomerQueries _customerQueries;

        public CustomerController(CustomerCommands customerCommands
                                , CustomerQueries customerQueries)
        {
            _customerCommands = customerCommands;
            _customerQueries = customerQueries;
        }

        [HttpGet]
        public ActionResult<List<Customer>> Find()
        {
            var customers = _customerQueries.FindAllCustomers_Execute();
            return View(customers);

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var customer = _customerQueries.FindCustomerById_Execute(id);

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerCommands.AddCustomer_Execute(customer);
                return RedirectToAction("Find");
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var customer = _customerQueries.FindCustomerById_Execute(id);

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _customerCommands.EditCustomer_Execute(id, customer);
                return RedirectToAction("Find");
            }
            return View(customer);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = _customerQueries.FindCustomerById_Execute(id);

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _customerCommands.DeleteCustomer_Execute(id);
            return RedirectToAction("Find");
        }
    }
}
