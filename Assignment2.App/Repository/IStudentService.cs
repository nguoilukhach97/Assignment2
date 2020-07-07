﻿using Assignment2.App.DTOs;
using Assignment2.App.Manages;
using Assignment2.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.App.Repository
{
    public interface IStudentService
    {
        Task<PagedViewModel<StudentViewModel>> GetAllStudent();
        Task<PagedViewModel<StudentViewModel>> GetAllPaging(string keyword,int pageIndex,int pageSize);
        Task<int> Create(StudentCreateRequest request);
    }
}