using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dbMVC.Lib;

namespace dbMVC.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        public ActionResult Index()
        {
            var manager = new EmployeeManager();
            return View(manager.GetAll());
        }

        //
        // GET: /Employee/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var manager = new EmployeeManager();
            return View(manager.Single(x => x.ID ==id));
        }

        //
        // GET: /Employee/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Employee/Create

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var manager = new EmployeeManager();
                    manager.Add(employee);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Employee/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var manager = new EmployeeManager();
            var data2 = manager.Single(x => x.ID == id);
            return View(data2);
        }

        //
        // POST: /Employee/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                var manager = new EmployeeManager();
                var emp = manager.Single(x => x.ID == id);
                if (ModelState.IsValid && emp != null)
                {
                    manager.Update(employee);
                    return RedirectToAction("Index");
                }
                else
                {
                return View();    
                }
            
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Employee/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var manager = new EmployeeManager();

            var emp = manager.Single(x => x.ID == id);
            return View(emp as Employee);
        }

        //
        // POST: /Employee/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                var manager = new EmployeeManager();  
                var emp = manager.Single(x => x.ID == id);
                manager.Remove(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }
    }
}
