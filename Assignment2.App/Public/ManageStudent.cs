using Assignment2.App.Manages;
using Assignment2.Data.EF;
using Assignment2.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.App.Public
{
    public class ManageStudent : IManageStudentService
    {
        private readonly Assignment2DbContext _context;
        public ManageStudent(Assignment2DbContext context)
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
    }
}
