using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeesData _employeesData;
        public EmployeeController (IEmployeesData employeesData)
        {
            _employeesData = employeesData;
        }
        public IActionResult Index()
        {
            return View(_employeesData.GetAll());
        }
        public IActionResult Employee(int Id)
        {
            return View(_employeesData.GetById(Id));
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
                return View(new EmployeeViewModel());

            var model = _employeesData.GetById(id);
            return View(new EmployeeViewModel
            { Id = model.Id,
                Surname = model.Surname,
                Name = model.Name,
                Age = model.Age,
                LevelEducation = model.LevelEducation,
                StartOfWork = model.StartOfWork
            });
        }
        
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            _employeesData.Edit(employee, employee.Id);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteByID(int id)
        {
            _employeesData.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}