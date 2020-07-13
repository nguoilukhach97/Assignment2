using Assignment2.Common.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2.App.DTOs
{
    public class PagedViewModel<T> : PagedResultBase
    {
        public List<T> Items { get; set; }
        
    }
}
