using fristMVCBLL.interfaces;
using fristMVCDAL.Data;
using fristMVCDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fristMVCBLL.repositories
{
    public class EmployeeRepository : IRepostory<Employee>
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(Employee employee)
        {
            _context.Employees.Add(employee);
            return _context.SaveChanges();
        }

        public int Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
            return _context.SaveChanges();
        }

        public Employee Get(int? id)
        {
          var result =  _context.Employees.Find(id);
            return result;
        }

        public IEnumerable<Employee> GetAll()
        {
          return  _context.Employees.AsNoTracking().ToList();
            
        }

        public int Update(Employee employee)
        { 
            _context.Employees.Update(employee);
            return _context.SaveChanges();
        }
    }
}
