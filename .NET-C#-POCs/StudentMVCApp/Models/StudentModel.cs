using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCWebApplication.Models
{
    public class StudentModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public float marks { get; set; }
        public StudentViewModel studentViewModel { get; set; }
    }
}
