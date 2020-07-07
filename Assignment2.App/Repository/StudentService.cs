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
                IdAdress = request.IdAdress,
                Name = request.Name,
                YearOfBirth = request.YearOfBirth,
                PhoneNumber = request.PhoneNumber,
                AddressDetails = request.AddressDetails
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
                IdAdress = x.IdAdress,
                YearOfBirth = x.YearOfBirth,
                PhoneNumber = x.PhoneNumber,
                AddressDetails = x.AddressDetails,
                Address = new Address()
                {
                    Id = x.Address.Id,
                    Commune = x.Address.Commune,
                    District = x.Address.District,
                    Province = x.Address.Province
                }

            }
            );

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
            List<StudentViewModel> student = _context.Students.Select(x =>
            new StudentViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                IdAdress = x.IdAdress,
                YearOfBirth = x.YearOfBirth,
                PhoneNumber = x.PhoneNumber,
                AddressDetails = x.AddressDetails,
                Address = new Address()
                {
                    Id = x.Address.Id,
                    Commune = x.Address.Commune,
                    District = x.Address.District,
                    Province = x.Address.Province
                }

            }
            ).ToList();

            return new PagedViewModel<StudentViewModel>() { TotalRecord = student.Count };
        }

        
    }
}
