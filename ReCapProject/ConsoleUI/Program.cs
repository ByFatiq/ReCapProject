using Business.Concrete;
using DataAccess.Concrete.EntityFramework.Repository;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleAppUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal(), new EfColorDal(), new EfBrandDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager ColorManager = new ColorManager(new EfColorDal());

            ColorManager.Add(new Color { ColorName = "White" });
            ColorManager.Add(new Color { ColorName = "Red" });
            ColorManager.Add(new Color { ColorName = "Green" });
            ColorManager.Add(new Color { ColorName = "Yellow" });
            ColorManager.Add(new Color { ColorName = "Gray" });
            ColorManager.Add(new Color { ColorName = "Black" });
            ColorManager.Add(new Color { ColorName = "Blue" });


            brandManager.Add(new Brand { BrandName = "Tofaş" });
            brandManager.Add(new Brand { BrandName = "Opel" });
            brandManager.Add(new Brand { BrandName = "Honda" });
            brandManager.Add(new Brand { BrandName = "Volvo" });
            brandManager.Add(new Brand { BrandName = "Peugeot" });
            brandManager.Add(new Brand { BrandName = "Ford" });

            carManager.Add(new Car { ColorId = 1, BrandId = 1, ModelYear = 1992, DailyPrice = 50, CarDescription = "Tofaş Kartal" });
            carManager.Add(new Car { ColorId = 2, BrandId = 2, ModelYear = 2016, DailyPrice = 90, CarDescription = "Opel Astra" });
            carManager.Add(new Car { ColorId = 4, BrandId = 3, ModelYear = 2018, DailyPrice = 180, CarDescription = "Honda Civic" });

            carManager.Add(new Car { ColorId = 4, BrandId = 3, ModelYear = 2018, DailyPrice = 0, CarDescription = "Honda Civic" });
            carManager.Add(new Car { ColorId = 4, BrandId = 3, ModelYear = 2018, DailyPrice = 100, CarDescription = "l" });
            Console.WriteLine("\n\n");
            Console.WriteLine("-*-*-*-*-*Renk ID'si 1 olan Item -*-*-*-*-*");
            var resultColor = ColorManager.GetById(1);
            Console.WriteLine("ColorId \t ColorName ");
            Console.WriteLine("{0} \t\t {1}", resultColor.ColorId, resultColor.ColorName);

            Console.WriteLine("-*-*-*-*-*Marka ID 2 olan Item -*-*-*-*-*");
            var resultBrand = brandManager.GetById(2);
            Console.WriteLine("BrandId \t BrandName ");
            Console.WriteLine("{0} \t\t {1}", resultBrand.BrandId, resultBrand.BrandName);
            Console.WriteLine("\n\n");

            GetList(carManager.GetAll());
            GetItem(carManager.GetByCarId(3));
        }
        static void GetList(List<CarJoin> cars)
        {
            Console.WriteLine("\n-*-*-*-*-* TÜM LİSTE -*-*-*-*-*\n");
            Console.WriteLine("CarId \t Color Name \t Brand Name \t DailyPrice \t Model Year \t Description");
            foreach (var car in cars)
            {
                
                if (car.ColorName.Length > 5)
                {
                    Console.WriteLine("{0} \t {1} \t {2} \t\t {3} \t\t {4} \t\t {5}", car.CarId, car.ColorName, car.BrandName, car.DailyPrice, car.ModelYear, car.CarDescription);
                }
                else
                {
                   Console.WriteLine("{0} \t {1} \t\t {2} \t\t {3} \t\t {4} \t\t {5}", car.CarId, car.ColorName, car.BrandName, car.DailyPrice, car.ModelYear, car.CarDescription);
                 //   Console.WriteLine($"{car.CarId} \t {car.ColorName} \t\t {car.BrandName}\t{car.DailyPrice}\t{car.ModelYear}\t{car.CarDescription}");
                }

            }
        }
        static void GetItem(CarJoin car)
        {
            Console.WriteLine("\n*****************************************************************\n");
            Console.WriteLine("CarId \t Color Name \t Brand Name \t DailyPrice \t Model Year \t Description");
            if (car.BrandName.Length > 6)
            {
                Console.WriteLine("{0} \t {1} \t {2} \t {3} \t\t {4} \t\t {5}", car.CarId, car.ColorName, car.BrandName, car.DailyPrice, car.ModelYear, car.CarDescription);
            }
            else
            {
                Console.WriteLine("{0} \t {1} \t {2} \t\t {3} \t\t {4} \t\t {5}", car.CarId, car.ColorName, car.BrandName, car.DailyPrice, car.ModelYear, car.CarDescription);
            }

        }
    }
}
