using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Repository
{
    public interface IDepartmentRepository
    {
         List<Department> GetAll();

         List<Department> GetAllWithEmp();

         Department GetById(int id);

         void Insert(Department dept);

         void Update(int id, Department newDept);

         void Delete(int id);
    }
}
