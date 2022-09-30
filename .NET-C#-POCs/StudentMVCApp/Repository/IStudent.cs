using Microsoft.AspNetCore.Mvc;
using StudentMVCWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCWebApplication.Repository
{
    public interface IStudent
    {
        List<StudentModel> list();
        StudentModel Edit(int id);
        StudentModel Details(int id);
    }
}
