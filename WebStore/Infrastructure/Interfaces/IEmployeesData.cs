using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Infrastructure.Interfaces
{
    public interface IEmployeesData
    {
        /// <summary>
        /// Получение списка сотрудников
        /// </summary>
        /// <returns></returns>
        IEnumerable<Employee> GetAll();
        
        /// <summary>
        /// Получение информации о конкретном сотруднике
        /// </summary>
        /// <param name="id">Уникальный идентификатор сотрудника</param>
        /// <returns></returns>
        Employee GetById(int id);
        
        /// <summary>
        /// Сохранение изменений
        /// </summary>
        void SaveChanged();
        
        /// <summary>
        /// Добавление нового сотрудника
        /// </summary>
        /// <param name="employee">Информация о новом сотруднике</param>
        void AddNewEmployee(Employee employee);
        
        /// <summary>
        /// Удаление конкретного сотрудника
        /// </summary>
        /// <param name="id">Уникальный идентификатор сотрудника</param>
        void DeleteById(int id);
        
        /// <summary>
        /// Очистка списка сотрудников
        /// </summary>
        void DeleteAll();

        void Edit(Employee employee, int id);
    }
}
