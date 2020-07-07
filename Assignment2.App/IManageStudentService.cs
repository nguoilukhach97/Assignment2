using Assignment2.App.Manages;
using Assignment2.App.ViewModels;
using Assignment2.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.App
{
    public interface IManageStudentService
    {
        Task<int> Create(StudentCreateRequest request);
    }
}
