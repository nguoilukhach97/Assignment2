using Assignment2.App.DTOs;
using Assignment2.App.Manages;
using Assignment2.App.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2.Services
{
    public interface IStudentAPI
    {
        Task<PagedViewModel<StudentViewModel>> GetAllPaging(string keyword,int pageIndex,int pageSize,int order);
        Task<int> Create(StudentCreateRequest request);
        Task<int> Update(StudentUpdateRequest request);
        Task<int> Delete(int id);
        Task<StudentUpdateRequest> GetStudent(int id);
         
    }
}
