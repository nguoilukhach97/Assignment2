using System;
using System.Collections.Generic;
using Assignment2.Data.Entities;
using System.Text;

namespace Assignment2.App.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public int IdAddress { get; set; }
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        
    }
}
