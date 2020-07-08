﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2.ViewModel.Common
{
    public class ApiResult<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public T Result { get; set; }
    }
}
