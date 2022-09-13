using CAR_ManufacturingApp.App;
using System;

namespace CAR_ManufacturingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AppCar car = new AppCar();
            //car.InitializeData();
            car.CheckEmpNameAndPassword();
          car.Run();
        }
    }
}
