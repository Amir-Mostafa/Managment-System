using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using review_1.BL.interfaces;
using review_1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using review_1.BL.helper;
using Microsoft.AspNetCore.Authorization;

namespace review_1.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private IEmployeeRepo repo;
        private IDepartmentRepo department;

        private ICountryRepo country;
        private ICityRepo city;

        public EmployeeController(IEmployeeRepo repo,IDepartmentRepo department,ICountryRepo country,ICityRepo city)
        {
            this.repo = repo;

            this.department = department;
            this.city = city;
            this.country = country;
        }
        public IActionResult Index()
        {

            return View(repo.Get()); 
        }
        [HttpGet]
        public IActionResult create()
        {

       
            var data = department.Get();
            ViewBag.depts = new SelectList(data, "id", "DepartmentName");

            var data2 = country.Get();
            ViewBag.countries = new SelectList(data2, "Id", "CountryName");
            return View();
        }
        [HttpPost]
        public IActionResult create(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //save photo

                    emp.PhotoName= uploadeFile.uploade(emp.PhotoURL, "/wwwroot/files/photoes/");
                    emp.CVName=uploadeFile.uploade(emp.CVURL, "/wwwroot/files/cvs/");
                    repo.Add(emp);
                    return RedirectToAction("index");
                }
                else
                {
                    var data = department.Get();
                    ViewBag.depts = new SelectList(data, "id", "DepartmentName");
                    return View(emp);
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("create");
            }

        }
        [HttpGet]
        public IActionResult edit(int id)
        {

            EmployeeVM e = repo.getById(id);
            var data = department.Get();
            //DepartmentVM d = repo.getDepartId(e.DepartmentID);
            ViewBag.depts = new SelectList(data, "id", "DepartmentName", selectedValue: e.DepartmentID);
            return View(e);
        }
        [HttpPost]
        public IActionResult edit(EmployeeVM emp)
        {
            if (ModelState.IsValid)
            {
                repo.edit(emp);
                return RedirectToAction("index");
            }
            else
            {
                var data = department.Get();
                
                ViewBag.depts = new SelectList(data, "id", "DepartmentName", selectedValue: emp.DepartmentID);
                return View(emp);
            }
        }
        public IActionResult delete(int id)
        {

            EmployeeVM e = repo.getById(id);
            var data = department.Get();
            ViewBag.depts = new SelectList(data, "id", "DepartmentName", selectedValue: e.DepartmentID);
            return View(e);
        }
        [HttpPost]
        public IActionResult delete(EmployeeVM emp)
        {
            EmployeeVM deleted = repo.getById(emp.id);
            uploadeFile.delete("photoes", deleted.PhotoName);
            uploadeFile.delete("cvs", deleted.CVName);
            repo.delete(emp);
            return RedirectToAction("index");
        }



        //////////////Ajax///////////////////////
        ///

        [HttpPost]
        public JsonResult AllCountry(int id)
        {
            return Json(city.Get().Where(n => n.Id == id));
        }
    }
}
