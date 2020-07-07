using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2.App.DTOs
{
    public class PagingRequestBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
