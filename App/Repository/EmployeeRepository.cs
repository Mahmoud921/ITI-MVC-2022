using App.Models;

namespace App.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        AppDbContext _context;
        public EmployeeRepository( AppDbContext db)
        {
            _context = db;
        }

        public Guid Id { get; set ; }
        public EmployeeRepository()
        {
            Id = Guid.NewGuid();
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }
        public Employee GetById(int id)
        {
            return _context.Employees.FirstOrDefault(e=> e.Id==id);
        }
        public List<Employee> GetByDeptId(int deptId)
        {
            return _context.Employees.Where(e => e.DeptId == deptId).ToList();
        }
        public void Insert(Employee employee) {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
        public void Update(int id,Employee employee) {
            //old Reference
            var emp = GetById(id);
            //Set Value
            emp.Name = employee.Name;
            emp.Email = employee.Email;
            emp.Salary = employee.Salary;
            emp.Address = employee.Address;
            emp.DeptId = employee.DeptId;
            //save
            _context.SaveChanges();

        }
        public void Delete(int id) {
            //old Reference
            var emp = GetById(id);
            _context.Employees.Remove(emp);
            _context.SaveChanges();
        }
    }
}
