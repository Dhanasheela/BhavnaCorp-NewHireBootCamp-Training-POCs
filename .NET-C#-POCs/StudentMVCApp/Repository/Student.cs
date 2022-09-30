using Microsoft.AspNetCore.Mvc;
using StudentMVCWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCWebApplication.Repository
{
  
    public class Student : IStudent
    {
        
       public static List<StudentModel> stud = new List<StudentModel>
      {
        new StudentModel
        {
            id = 1, name = "Dhanu", marks = 100,
          
        },
        new StudentModel
        {
            id = 2, name = "Raki", marks = 89
        },
        new StudentModel
        {
            id = 3, name = "Sahi", marks = 67
        }
    };

        List<StudentViewModel> studentViews = new List<StudentViewModel>
      {
          new StudentViewModel{standard=1,age=10},
          new StudentViewModel{standard=8,age=12},
          new StudentViewModel{standard=9,age=13 },
      };

        public List<StudentModel> list()
        {
           
            return stud.ToList();
            
        }
        public StudentModel Edit(int id)
        {

           var stuEdit = stud.Where(s => s.id ==id).FirstOrDefault();
            return stuEdit;
        }

        public StudentModel Details(int id)
        {
            var stuDetails = stud.Where(s => s.id == id).FirstOrDefault();
            return stuDetails;
        }

        
    }
    //public StudentViewModel get()
    //{
    //    StudentViewModel model = new StudentViewModel();
    //    model.student=student();
    //    model.personals = Personas();
    //    return model;

    //}
}
