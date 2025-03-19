using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        AppDbContext _context;
        public DepartmentRepository(AppDbContext db)
        {
            _context = db;
        }
        public List<Department> GetAll()
        {
            return _context.Departments.ToList();
        }
        public List<Department> GetAllWithEmp()
        {
            return _context.Departments.Include(d => d.Employees).ToList();
        }
        public Department GetById(int id)
        {
            return _context.Departments.FirstOrDefault(e => e.Id == id);
        }
        public void Insert(Department dept)
        {
            _context.Departments.Add(dept);
            _context.SaveChanges();
        }
        public void Update(int id, Department newDept)
        {
            //old Reference
            var dept = GetById(id);
            //Set Value
            dept.Name = newDept.Name;
            dept.ManagerName = newDept.ManagerName;
            //save
            _context.SaveChanges();

        }
        public void Delete(int id)
        {
            //old Reference
            var dept = GetById(id);
            _context.Departments.Remove(dept);
            _context.SaveChanges();
        }
    }
}
