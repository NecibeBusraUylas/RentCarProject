using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleuI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("----- All cars in the system. -----");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Id}\t{brandManager.GetById(car.BrandId).BrandName}\t\t\t{colorManager.GetById(car.ColorId).ColorName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
            Console.WriteLine("\n");

            Console.WriteLine("----- Cars with brand id 3 in the system. -----");
            foreach (var car in carManager.GetAllByBrandId(3))
            {
                Console.WriteLine($"{car.Id}\t{brandManager.GetById(car.BrandId).BrandName}\t\t\t{colorManager.GetById(car.ColorId).ColorName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
            Console.WriteLine("\n");

            Console.WriteLine("----- Cars with color id 2 in the system. -----");
            foreach (var car in carManager.GetAllByColorId(2))
            {
                Console.WriteLine($"{car.Id}\t{brandManager.GetById(car.BrandId).BrandName}\t\t\t{colorManager.GetById(car.ColorId).ColorName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
            Console.WriteLine("\n");

            Console.WriteLine("----- Cars with daily price of 90-180 in the system. -----");
            foreach (var car in carManager.GetByDailyPrice(90, 180))
            {
                Console.WriteLine($"{car.Id}\t{brandManager.GetById(car.BrandId).BrandName}\t\t\t{colorManager.GetById(car.ColorId).ColorName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
            Console.WriteLine("\n");

            carManager.Add(new Car {Id=9, BrandId = 3, ColorId = 3, ModelYear = 2000, DailyPrice = 50, Description = "Ford Fusion" });

            Console.WriteLine("----- All cars in the system. -----");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Id}\t{brandManager.GetById(car.BrandId).BrandName}\t\t\t{colorManager.GetById(car.ColorId).ColorName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
            Console.WriteLine("\n");

            brandManager.Add(new Brand { Id = 5,BrandName = "H" });
            carManager.Add(new Car { Id = 10, BrandId = 2, ColorId = 3, ModelYear = 2010, DailyPrice = 150, Description = "T" });
            Console.WriteLine("\n");

            brandManager.Add(new Brand {Id=5, BrandName = "Honda" });
            carManager.Add(new Car {Id=11,BrandId = 5, ColorId = 2, ModelYear = 2010, DailyPrice = 150, Description = "Honda Civic" });
            Console.WriteLine("\n");

            Console.WriteLine("----- All cars in the system. -----");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Id}\t{brandManager.GetById(car.BrandId).BrandName}\t\t\t{colorManager.GetById(car.ColorId).ColorName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
        }
    }
}