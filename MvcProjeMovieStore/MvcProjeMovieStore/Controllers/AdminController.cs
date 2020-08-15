using MvcProjeMovieStore.Models;
using MvcProjeMovieStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeMovieStore.Controllers
{
    public class AdminController : Controller
    {
        MovieStoreEntities _db = new MovieStoreEntities();

        //Employees operasyonlari baslangic
        [HttpGet]
        public ActionResult ListMyEmployees()
        {
            ListEmployeesViewModel model = new ListEmployeesViewModel
            {
                Employees = _db.Employees.ToList()
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult AddMyEmployee()
        {
            EmployeeManiViewModel model = new EmployeeManiViewModel
            {
                Employee = new Employee(),
                Titles = _db.Titles.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddMyEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                EmployeeManiViewModel model = new EmployeeManiViewModel
                {
                    Employee = new Employee(),
                    Titles = _db.Titles.ToList()
                };

                return View(model);
            }

            _db.Entry(employee).State = System.Data.Entity.EntityState.Added;
            _db.SaveChanges();

            return RedirectToAction("AddMyEmployeeDetail", new { id = employee.EmployeeID});
        }

        [HttpGet]
        public ActionResult AddMyEmployeeDetail(int id)
        {
            EmployeeManiViewModel model = new EmployeeManiViewModel
            {
                Employee = _db.Employees.FirstOrDefault(x => x.EmployeeID == id),
                EmployeeDetail = new EmployeeDetail()
            };

            model.EmployeeDetail.EmployeeDetailID = id;

            return View(model);
        }

        [HttpPost]
        public ActionResult AddMyEmployeeDetail(EmployeeDetail employeeDetail)
        {
            if (!ModelState.IsValid)
            {
                EmployeeManiViewModel model = new EmployeeManiViewModel
                {
                    Employee = _db.Employees.FirstOrDefault(x => x.EmployeeID == employeeDetail.EmployeeDetailID),
                    EmployeeDetail = new EmployeeDetail()
                };

                return View(model);
            }

            _db.Entry(employeeDetail).State = System.Data.Entity.EntityState.Added;
            _db.SaveChanges();

            return RedirectToAction("ListMyEmployees");
        }

        //Employees operasyonlari bitis

        //titles operasoynlari baslangic
        [HttpGet]
        public ActionResult ListMyTitles()
        {
            ListTitlesViewModel model = new ListTitlesViewModel
            {
                Titles = _db.Titles.ToList()
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult AddMyTitle()
        {
            TitleManiViewModel model = new TitleManiViewModel
            {
                Title = new Title()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddMyTitle(Title title)
        {
            if (!ModelState.IsValid)
            {
                TitleManiViewModel model = new TitleManiViewModel
                {
                    Title = new Title()
                };

                return View(model);
            }

            _db.Entry(title).State = System.Data.Entity.EntityState.Added;
            _db.SaveChanges();

            TempData["message"] = "Veri eklendi";

            return RedirectToAction("ListMyTitles");
        }

        //titles operasyonlari bitis
    }
}