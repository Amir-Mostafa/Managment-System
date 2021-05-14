using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using review_1.DAL.database;
using review_1.BL.repos;
using review_1.BL.interfaces;
using review_1.Models;
using Microsoft.AspNetCore.Authorization;

namespace review_1.Controllers

{
    [Authorize]
    public class DepartmentController : Controller
    {

        private IDepartmentRepo repo;
        public DepartmentController(IDepartmentRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            
            return View(repo.Get());
        }
        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(DepartmentVM dpt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Add(dpt);
                    return RedirectToAction("index");
                }
                else
                {
                    return View(dpt);
                }
            }
            catch(Exception e)
            {
                return RedirectToAction("create");
            }
            
        }
        [HttpGet]
        public IActionResult edit(int id)
        {
            return View(repo.getById(id));
        }
        [HttpPost]
        public IActionResult edit(DepartmentVM dpt)
        {
            if(ModelState.IsValid)
            {
                repo.edit(dpt);
                return RedirectToAction("index");
            }
            else
            {
                return View(dpt);
            }
        }
        public IActionResult delete(int id)
        {

            return View(repo.getById(id));
        }
        [HttpPost]
        public IActionResult delete(DepartmentVM dpt)
        {

            repo.delete(dpt);
            return RedirectToAction("index");
        }
    }
}
