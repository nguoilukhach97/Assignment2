using Assignment2.App.DTOs;
using Assignment2.App.ViewModels;
using Assignment2.Data.EF;
using Assignment2.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2.App.Public
{
    public class PublicStudent : IPublicproductService<Student>
    {
        private readonly Assignment2DbContext _context;
        public PublicStudent(Assignment2DbContext context)
        {
            _context = context;
        }
        public PagedViewModel<StudentViewModel> GetAllStudent()
        {
            List<StudentViewModel> student = _context.Students.Select(x=>
            new StudentViewModel()
                {
                    Id=x.Id,
                    Name=x.Name,
                    IdAdress = x.IdAdress,
                    YearOfBirth = x.YearOfBirth,
                    PhoneNumber = x.PhoneNumber,
                    AddressDetails = x.AddressDetails,
                    Address = new Address()
                    {
                        Id= x.Address.Id,
                        Commune=x.Address.Commune,
                        District = x.Address.District,
                        Province =x.Address.Province
                    }

                }
            ).ToList();

            return new PagedViewModel<StudentViewModel>() { TotalRecord = student.Count };
        }
    }
}
