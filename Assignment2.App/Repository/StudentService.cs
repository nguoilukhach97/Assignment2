using Assignment2.App.DTOs;
using Assignment2.App.Manages;
using Assignment2.App.ViewModels;
using Assignment2.Data.EF;
using Assignment2.Data.Entities;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.App.Repository
{
    public class StudentService : IStudentService
    {
        private readonly Assignment2DbContext _context;
        public StudentService(Assignment2DbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(StudentCreateRequest request)
        {
            var student = new Student()
            {
                
                Name = request.Name,
                YearOfBirth = request.YearOfBirth,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address
            };
            _context.Students.Add(student);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedViewModel<StudentViewModel>> GetAllPaging(string keyword, int pageIndex, int pageSize)
        {
            var student = _context.Students.Select(x =>
            new StudentViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                
                YearOfBirth = x.YearOfBirth,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address,
                
            });

            if (!string.IsNullOrEmpty(keyword))
            {
                student = student.Where(p => p.Name.Contains(keyword));
            }
            int totalRow = await student.CountAsync();
            var data = student.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var page = new PagedViewModel<StudentViewModel>()
            {
                TotalRecord = totalRow,
                Items = await student.ToListAsync()
            };
            return page;
        }

        public async Task<PagedViewModel<StudentViewModel>> GetAllStudent()
        {
            var student = _context.Students.Select(x =>
            new StudentViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                
                YearOfBirth = x.YearOfBirth,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address,
                

            });

            var data = new PagedViewModel<StudentViewModel>()
            {
                Items = await student.ToListAsync(),
                TotalRecord = await student.CountAsync()
            };

            return data;
        }

        
    }
}
