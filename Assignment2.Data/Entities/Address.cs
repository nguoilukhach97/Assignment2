using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2.Data.Entities
{
    public class Address
    {
        public int Id { get; set; }
       
        public string Commune { get; set; }
        public string District { get; set; }
        public string Province { get; set; }

        public List<Student> Students { get; set; }
    }
}
