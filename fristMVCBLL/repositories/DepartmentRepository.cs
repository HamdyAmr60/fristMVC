﻿using fristMVCBLL.interfaces;
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
    public class DepartmentRepository : IRepostory<Department>
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(Department department)
        {
            _context.Departments.Add(department);
            return _context.SaveChanges();
        }

        public int Delete(Department department)
        {
            _context.Departments.Remove(department);
            return _context.SaveChanges();
        }

        public Department Get(int id)
        {
            var result = _context.Departments.Find(id);
            return result;
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.AsNoTracking().ToList();
        }

        public int Update(Department department)
        {
            _context.Departments.Update(department);
            return _context.SaveChanges();
        }
    }
}
