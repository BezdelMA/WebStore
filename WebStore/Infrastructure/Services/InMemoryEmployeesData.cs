using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.ViewModels
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        private readonly List<Employee> lEmployees;

        public InMemoryEmployeesData()
        {
            lEmployees = new List<Employee>()
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
        }
        /// <summary>
        /// Получение списка сотрудников
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetAll()
        {
            return lEmployees;
        }

        /// <summary>
        /// Получение информации о конкретном сотруднике
        /// </summary>
        /// <param name="id">Уникальный идентификатор сотрудника</param>
        /// <returns></returns>
        public Employee GetById(int id)
        {
            if (lEmployees == null)
                throw new ArgumentNullException(nameof(Employee));
            if (id <= 0)
                throw new ArgumentOutOfRangeException();
            return lEmployees.FirstOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// Сохранение изменений
        /// </summary>
        public void SaveChanged()
        {

        }

        /// <summary>
        /// Добавление нового сотрудника
        /// </summary>
        /// <param name="employee">Информация о новом сотруднике</param>
        public void AddNewEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(Employee));
            if (lEmployees.Contains(employee)) return;
            employee.Id = lEmployees.Count == 0 ? 1 : lEmployees.Max(e => e.Id) + 1;
            lEmployees.Add(employee);
        }

        /// <summary>
        /// Удаление конкретного сотрудника
        /// </summary>
        /// <param name="id">Уникальный идентификатор сотрудника</param>
        public void DeleteById(int id)
        {
            Employee tmpEmployee = lEmployees.FirstOrDefault(e => e.Id == id);
            lEmployees.Remove(tmpEmployee);
        }
        /// <summary>
        /// Очистка списка сотрудников
        /// </summary>
        public void DeleteAll() => lEmployees.Clear();

        public void Edit(Employee employee, int id)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(Employee));
            if (id < 0)
                throw new ArgumentOutOfRangeException();
            if (id == 0)
            {
                employee.Id = lEmployees.Max(e => e.Id) + 1;
                AddNewEmployee(employee);
            }
            
            if (lEmployees.Contains(employee))
                return;

            var tmpEmployee = GetById(id);
            tmpEmployee.Surname = employee.Surname;
            tmpEmployee.Name = employee.Name;
            tmpEmployee.Age = employee.Age;
            tmpEmployee.LevelEducation = employee.LevelEducation;
            tmpEmployee.StartOfWork = employee.StartOfWork;
        }
    }
}
