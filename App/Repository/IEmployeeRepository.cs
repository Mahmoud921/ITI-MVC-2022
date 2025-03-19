using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Repository
{
    public interface IEmployeeRepository
    {
         Guid Id { get; set; }
         List<Employee> GetAll();
         Employee GetById(int id);
         List<Employee> GetByDeptId(int deptId);
         void Insert(Employee employee);
         void Update(int id, Employee employee);
         void Delete(int id);
    }
}
