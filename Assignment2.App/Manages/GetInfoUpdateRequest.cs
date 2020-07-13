using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2.App.Manages
{
    public class GetInfoUpdateRequest
    {
        public StudentUpdateRequest Student { get; set; }
        public IdAddressRequest Address { get; set; }
    }
}
