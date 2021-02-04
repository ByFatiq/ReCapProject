using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Business.Concrete;
using ReCapProject.DataAccess.Concrete.InMemory;

namespace ReCapProject.ConsoleUI
{

    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine("Araç ID'si, Marka, RenkID'si, Model, StokAdedi, Günlük Satış, Tip, Açıklama");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("CarId :{0} --BranId :{1} --ColorId :{2} --ModelYear :{3}--UnitInStock:{4} --DailyPrice :{5} --Type :{6}", car.CarId, car.BrandId, car.ColorId, car.UnitInStock, car.DailyPrice, car.ModelYear, car.Description);
            }
            Console.WriteLine("**********************************************");

            Console.WriteLine("Araç Markaları-------");

            foreach (var car in carManager.GetByBrandId(2))
            {
                Console.WriteLine("CarId :{0} --BrandId :{1} --Type :{2}", car.CarId, car.BrandId, car.Description);
            }
            Console.WriteLine("**********************************************");

            Console.WriteLine("Araç Renkleri ----");
            foreach (var car in carManager.GetByColorId(2))
            {
                Console.WriteLine("CarId :{0} --ColorId :{1} --Type :{2}", car.CarId, car.ColorId, car.Description);
            }

        }
    }
}
