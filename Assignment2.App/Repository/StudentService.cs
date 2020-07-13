using Assignment2.App.DTOs;
using Assignment2.App.Manages;
using Assignment2.App.ViewModels;
using Assignment2.Data.EF;
using Assignment2.Data.Entities;
using Assignment2.App.Common;
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
                IdAddress =request.IdAddress,
                Name = request.Name,
                YearOfBirth = request.YearOfBirth,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address
            };
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return student.Id;
        }

        public async Task<int> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            return await _context.SaveChangesAsync();

        }

        public async Task<PagedViewModel<StudentViewModel>> GetAllPaging(string keyword, int pageIndex, int pageSize,int sort)
        {
            var student = _context.Students.Select(x =>
            new StudentViewModel()
            {
                Id = x.Id,
                IdAddress = x.IdAddress,
                Name = x.Name,
                YearOfBirth = x.YearOfBirth,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address,
                
            });

            if (!string.IsNullOrEmpty(keyword))
            {
                student = student.Where(p => p.Name.Contains(keyword) || p.Address.Contains(keyword) || p.PhoneNumber.Contains(keyword));
            }
            int totalRow = await student.CountAsync();

            if (sort==1)
            {
                student = student.OrderBy(p => p.Name);
            }
            if(sort ==2)
            {
               student= student.OrderBy(p => p.YearOfBirth);
            }    
            var data = student.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var page = new PagedViewModel<StudentViewModel>()
            {
                TotalRecord = totalRow,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Items = await data.ToListAsync()
            };
            return page;
        }

        public async Task<PagedViewModel<StudentViewModel>> GetAllStudent(int pageIndex,int pageSize)
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
            var listSt = student.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            var data = new PagedViewModel<StudentViewModel>()
            {
                Items = await listSt.ToListAsync(),
                TotalRecord = await student.CountAsync()
            };

            return data;
        }

        public async Task<StudentUpdateRequest> GetById(int id)
        {
           
            var student = await _context.Students.FindAsync(id);
            string[] lstAddress = student.Address.Split(',');
            string addressSt =lstAddress[0] ;
            for (int i = 1; i < lstAddress.Length-3; i++)
            {
                addressSt += ", "+lstAddress[i];
            }
            var result = new StudentUpdateRequest()
            {
                Id = student.Id,
                IdAddress= student.IdAddress,
                Name= student.Name,
                Address= addressSt,
                PhoneNumber= student.PhoneNumber,
                YearOfBirth = student.YearOfBirth
            };
            return result;
        }

        public async Task<int> Update(StudentUpdateRequest request)
        {
            var student = await _context.Students.FindAsync(request.Id);
            if (student != null)
            {
                student.Name = request.Name;
                student.IdAddress = request.IdAddress;
                student.PhoneNumber = request.PhoneNumber;
                student.Address = request.Address;
                student.YearOfBirth = request.YearOfBirth;

                return await _context.SaveChangesAsync();
            }
            return 0;
        }

       

        
    }
}
