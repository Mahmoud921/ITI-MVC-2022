﻿using App.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class EmployeeController : Controller
    {
        AppDbContext _context = new AppDbContext();

        public IActionResult Index()
        {
            var emp = _context.Employees.ToList();
            return View(emp);
        }

        //Add New Employee
        [HttpGet]
        public IActionResult New()
        {
            ViewData["deptList"] = _context.Departments.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult SaveNew(Employee emp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Employees.Add(emp);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex) {
                    ModelState.AddModelError(String.Empty,ex.Message.ToString());
                }
                
            }
            ViewData["deptList"] = _context.Departments.ToList();
            return View("New",emp);
        }

        // Edit Employee
        public IActionResult Edit(int id)
        {
            var emp = _context.Employees.FirstOrDefault(e => e.Id == id);
            ViewData["deptList"]= _context.Departments.ToList();
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(int id,Employee newEmp)
        {
            if (ModelState.IsValid) // validation server side
            {
                var oldEmp = _context.Employees.FirstOrDefault(e => id == e.Id);
                if (oldEmp != null) {
                    oldEmp.Name = newEmp.Name;
                    oldEmp.Email = newEmp.Email;
                    oldEmp.Salary = newEmp.Salary;
                    oldEmp.Address = newEmp.Address;
                    oldEmp.DeptId = newEmp.DeptId;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            ViewData["deptList"] = _context.Departments.ToList();
            return View("Edit",newEmp);
        }
    }
}
