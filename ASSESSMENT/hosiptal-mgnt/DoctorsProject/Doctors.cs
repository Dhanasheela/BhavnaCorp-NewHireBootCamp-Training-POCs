using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsProject
{
    public class Doctors : IDoctors
    {
        List<DoctorsModel> GetDoctors = new List<DoctorsModel>();
        public List<DoctorsModel> AddDoctors()
        {
            DoctorsModel doctorsModel = new DoctorsModel();

            Console.WriteLine("Enter following information to add new Doctor:");
            Console.WriteLine("Enter Doctors Id");
            doctorsModel.doctors_id= int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Doctors name");
            doctorsModel.doctors_name = Console.ReadLine();
            Console.WriteLine("Enter Doctors specialization");
            doctorsModel.specialization = Console.ReadLine();
            Console.WriteLine("Doctors ID:" + doctorsModel.doctors_id + "\n" + "Doctors Name:" + doctorsModel.doctors_name + "\n" + " Doctors specialization:" + doctorsModel.specialization+ "\n");
                        return GetDoctors;
        }
    }
}
