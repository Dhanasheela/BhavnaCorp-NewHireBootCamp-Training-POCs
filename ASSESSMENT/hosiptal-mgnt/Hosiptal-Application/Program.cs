using DoctorsProject;
using PatientProject;
using RoomProject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hosiptal_Application
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Doctors doctors = new Doctors();
            Patient patient = new Patient();

            //room
            RoomModel roomModel = new RoomModel();
            List<RoomModel> GetList = new List<RoomModel>();
            GetList.Add(new RoomModel()
            { room_no=101,room_type="General",status="active"});
            GetList.Add(new RoomModel()
            { room_no = 102, room_type = "non-General", status = "inactive" });
            GetList.Add(new RoomModel()
            { room_no = 103, room_type = "OPT", status = "active" });
            

            Console.WriteLine("Enter Ur Option");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    doctors.AddDoctors();
                    break;
                case 2:
                    patient.AddPaitents();
                    break;
                case 3:
                    var room = GetList.Where(e => e.status == "active").ToList();
                    foreach (RoomModel rooms in room)
                    {
                        Console.WriteLine("-------------------" + "\n" + "Rooms details:"+"\n"+"Room no:"+"\n" + rooms.room_no + "\n" +"Room type:"+ rooms.room_type + "\n" +"Room status:"+ rooms.status );
                    }
                    break;
                default:
                    Console.WriteLine("invalid options");
                    break;


            }
        }
    }
}
