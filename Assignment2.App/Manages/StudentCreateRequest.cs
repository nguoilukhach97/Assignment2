using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2.App.Manages
{
    public class StudentCreateRequest
    {
        public int Id { get; set; }
        public int IdAdress { get; set; }
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressDetails { get; set; }
        
    }
}
