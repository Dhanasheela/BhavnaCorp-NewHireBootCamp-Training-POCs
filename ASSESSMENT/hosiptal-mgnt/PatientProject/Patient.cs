using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientProject
{
    public class Patient : IPatient
    {
        List<PatientModel> GetPatients = new List<PatientModel>();
        public List<PatientModel> AddPaitents()
        {
            PatientModel patientModel = new PatientModel();

            Console.WriteLine("Enter following information to add new Patient:");
            Console.WriteLine("Enter Patient name");
            patientModel.patient_name= Console.ReadLine();
            Console.WriteLine("Enter Patient age");
            patientModel.age = Console.ReadLine();
            Console.WriteLine("Enter patient Gender");
            patientModel.gender = Console.ReadLine();
            Console.WriteLine("Enter patient disease");
            patientModel.disease = Console.ReadLine();
            Console.WriteLine( "patients Name:" + patientModel.patient_name + "\n" + " Patient age:"
                + patientModel.age + "\n"+"Patient gender"+patientModel.gender+"\n"+"patient Disease"+patientModel.disease);
            return GetPatients;
        }
    }
}
