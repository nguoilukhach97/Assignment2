using Assignment2.App.ViewModels;
using Assignment2.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2.Services
{
    public interface IStudentAPI
    {
        Task<ApiResult<List<StudentViewModel>>> GetAllPaging();
    }
}
