using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<Employee> lEmployees = new List<Employee>()
        {
            new Employee
            {
                Id = 1,
                Surname = "Иванов",
                Name = "Сергей",
                Age = 26,
                LevelEducation = "высшее",
                StartOfWork = new DateTime(2015, 01, 15)
            },

            new Employee
            {
                Id = 2,
                Surname = "Смирнов",
                Name = "Анатолий",
                Age = 34,
                LevelEducation = "среднее специальное",
                StartOfWork = new DateTime(2015, 03, 20)
            },

            new Employee
            {
                Id = 3,
                Surname = "Петрова",
                Name = "Елизавета",
                Age = 24,
                LevelEducation = "неоконченное высшее",
                StartOfWork = new DateTime(2018, 11, 05)
            }
        };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }
        public IActionResult Employees()
        {
            return View(lEmployees);
        }

        public IActionResult Employee(int Id)
        {
            var employee = lEmployees.FirstOrDefault(e => e.Id == Id);
            if (employee == null)
                return NotFound();
            return View(employee);
        }
    }
}