using CrudR.Data_Access;
using CrudR.Models;
using CrudR.Repo.Contract;
using CrudR.Repo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudR.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomer _customerService;
        public CustomerController(ICustomer customerService)
        {
            _customerService = customerService;

        }

        public IActionResult Index()
        {

            var data = _customerService.GetAllDetails();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer data)
        {
            _customerService.InsertCustomer(data);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteDetails(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            _customerService.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateDetails(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
           var data =  _customerService.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult UpdateDetails(Customer data1)
        {

            if (data1 == null)
            {
                return NotFound();
            }

            _customerService.Update(data1);
            return RedirectToAction("Index");

        }
    }
}
