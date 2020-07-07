using Assignment2.App.DTOs;
using Assignment2.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2.App
{
    public interface IPublicproductService<T>
    {
        PagedViewModel<StudentViewModel> GetAllStudent();
    }
}
