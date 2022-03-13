using CrudR.Data_Access;
using CrudR.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudR.Controllers
{
    public class CustomerController : Controller
    {
        public DatabaseConn _DBCONN { get; }
        public CustomerController(DatabaseConn DBCONN)
        {
            this._DBCONN = DBCONN;
        }

        public IActionResult Index()
        {
            //List<Customer> data = _DBCONN.Customers.ToList();
            var data = _DBCONN.Customers.ToList();
            return View(data);
        }
        public IActionResult Create()
        {            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customers)
        {
            _DBCONN.Customers.Add(customers);
            _DBCONN.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteDetails(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var data = _DBCONN.Customers.SingleOrDefault(x=>x.Id==id);
            _DBCONN.Customers.Remove(data);
            _DBCONN.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult UpdateDetails(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var data = _DBCONN.Customers.SingleOrDefault(x => x.Id == id);
            return View(data);
        }
        [HttpPost]
        public IActionResult UpdateDetails(Customer cu)
        {
            
            if (cu == null)
            {
                return NotFound();
            }
            
                _DBCONN.Customers.Update(cu);
                _DBCONN.SaveChanges();
                return RedirectToAction("Index");

        }

        public IActionResult GetCountry()
        {
            var get = _DBCONN.newcountries.ToList();
            return Json(get);
        }
        public IActionResult GetState(int id)
        {
            var get1 = _DBCONN.states.Where(x => x.country.c_Id== id).ToList();
            return Json(get1);
            
        }

    }
}
