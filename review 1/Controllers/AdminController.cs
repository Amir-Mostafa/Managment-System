using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using review_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace review_1.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminController(RoleManager<IdentityRole>roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roles = roleManager.Roles;
            return View(roles);
        
        }
        public  IActionResult createRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>createRole(RoleVM model)
        {
            if(ModelState.IsValid)
            {
                var role = new IdentityRole {
                    Name = model.Name
                };
                var result=await roleManager.CreateAsync(role);
                if(result.Succeeded)
                {
                    ViewBag.success ="Role "+ model.Name+ " Add Successfully";
                    return View();
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
                
            }
            return View(model);
        }

        public IActionResult editRole(string id)
        {
            if(id!=null)
            {
                var result = roleManager.FindByIdAsync(id);
                if (result.Result != null)
                {
                    RoleVM role = new RoleVM()
                    {
                        Name = result.Result.Name,
                        id = result.Result.Id


                    };
                    return View(role);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Data");
                    return View();
                }
            }
            else
            return View("index","Home");
        }
        [HttpPost]
        public async Task<IActionResult>editRole(RoleVM model)
        {
            if(ModelState.IsValid)
            {
                var role =  roleManager.FindByIdAsync(model.id);
                if (role != null)
                {
                    role.Result.Name = model.Name;
                var result = await roleManager.UpdateAsync(role.Result);
                
                    if (result.Succeeded)
                    {
                        return RedirectToAction("index");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                        return View(model);
                    }
                }

            }
            ModelState.AddModelError("", "Invalid Data");
            return View(model);
        }


        public IActionResult deleteRole(string id)
        {
            if (id != null)
            {
                var result = roleManager.FindByIdAsync(id);
                if (result.Result != null)
                { 
                    RoleVM role = new RoleVM()
                    {
                        Name = result.Result.Name,
                        id = result.Result.Id


                    };
                return View(role);
                }
            }
            else
                return View("index", "Home");

            ModelState.AddModelError("", "Invalid Data");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> deleteRole(RoleVM model)
        {
            if (ModelState.IsValid)
            {
                var role =  roleManager.FindByIdAsync(model.id);
                if (role.Result != null)
                {
                    role.Result.Name = model.Name;
                    var result = await roleManager.DeleteAsync(role.Result);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("index");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                        return View(model);
                    }
                }

            }
            ModelState.AddModelError("", "Invalid Data");
            return View(model);
        }

    }
}
