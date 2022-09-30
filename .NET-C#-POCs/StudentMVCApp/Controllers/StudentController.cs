using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentMVCWebApplication.Models;
using StudentMVCWebApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCWebApplication.Controllers
{
   
    public class StudentController : Controller
    {
       // List<StudentModel> students = new List<StudentModel>();
        Student student = new Student();
        
        // GET: StudentController
        public ActionResult Index()
        {
           
           var stud= student.list();
            return View(stud);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var studetails = student.Details(id);
            return View(studetails);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
             //students.Where(s => s.id == id).FirstOrDefault();
            var stuEdit =  student.Edit(id);
            return View(stuEdit);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
