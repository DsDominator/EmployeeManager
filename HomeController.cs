using CrudOperationInMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CrudOperationInMVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
  
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {

            var result = new AccountModel().Login(model.UserName, model.Password);
            if (result && ModelState.IsValid)
                return RedirectToAction("Index", "Home");
            else
                ModelState.AddModelError("", "Username or password is incorrect.");
            return View(model);
        }
        TutorialsCS _context = new TutorialsCS();

        public ActionResult Index()
        {
            var listofData = _context.Employees.ToList();
            return View(listofData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee model)
        {
            int id = _context.Employees.Count();
            model.EmployeeId = id;
            _context.Employees.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Employee Model)
        {
            var data = _context.Employees.Where(x => x.EmployeeId == Model.EmployeeId).FirstOrDefault();
            if (data != null)
            {
                data.EmployeeCity = Model.EmployeeCity;
                data.EmployeeName = Model.EmployeeName;
                data.EmployeeSalary = Model.EmployeeSalary;
                data.EmployeePhone = Model.EmployeePhone;
                data.StartDate = Model.StartDate;
                data.EndDate = Model.EndDate;
                _context.SaveChanges();
            }

            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            var data = _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            _context.Employees.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }
        public ActionResult Detail(int id)
        {
            var data = _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "PhongWeb description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "PhongWeb contact page.";

            return View();
        }
    }
}