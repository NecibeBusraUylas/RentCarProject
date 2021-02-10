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
            ColorTest();

            BrandTest();

            CarTest();
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("\n----- All colors in the system. -----");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
            Console.WriteLine("\n");

            colorManager.Add(new Color { ColorName = "Red" });
            Console.WriteLine("\n");

            Console.WriteLine("\n----- All colors in the system. -----");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("\n----- All brands in the system. -----");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
            Console.WriteLine("\n");

            brandManager.Add(new Brand { BrandName = "H" });
            Console.WriteLine("\n");

            brandManager.Add(new Brand { BrandName = "Honda" });
            Console.WriteLine("\n");

            Console.WriteLine("\n----- All brands in the system. -----");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //Console.WriteLine("----- All cars in the system. -----");
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine($"{car.Id}\t{brandManager.GetById(car.BrandId).BrandName}\t\t\t{colorManager.GetById(car.ColorId).ColorName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            //}
            //Console.WriteLine("\n");

            //Console.WriteLine("----- Cars with brand id 3 in the system. -----");
            //foreach (var car in carManager.GetAllByBrandId(3))
            //{
            //    Console.WriteLine($"{car.Id}\t{brandManager.GetById(car.BrandId).BrandName}\t\t\t{colorManager.GetById(car.ColorId).ColorName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            //}
            //Console.WriteLine("\n");

            //Console.WriteLine("----- Cars with color id 2 in the system. -----");
            //foreach (var car in carManager.GetAllByColorId(2))
            //{
            //    Console.WriteLine($"{car.Id}\t{brandManager.GetById(car.BrandId).BrandName}\t\t\t{colorManager.GetById(car.ColorId).ColorName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            //}
            //Console.WriteLine("\n");

            //Console.WriteLine("----- Cars with daily price of 90-180 in the system. -----");
            //foreach (var car in carManager.GetByDailyPrice(90, 180))
            //{
            //    Console.WriteLine($"{car.Id}\t{brandManager.GetById(car.BrandId).BrandName}\t\t\t{colorManager.GetById(car.ColorId).ColorName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            //}
            //Console.WriteLine("\n");

            //carManager.Add(new Car { BrandId = 3, ColorId = 3, ModelYear = 2000, DailyPrice = 50, Description = "Ford Fusion" });

            //Console.WriteLine("----- All cars in the system. -----");
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine($"{car.Id}\t{brandManager.GetById(car.BrandId).BrandName}\t\t\t{colorManager.GetById(car.ColorId).ColorName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            //}
            //Console.WriteLine("\n");

            //carManager.Add(new Car { BrandId = 2, ColorId = 3, ModelYear = 2010, DailyPrice = 150, Description = "T" });
            //Console.WriteLine("\n");

            //carManager.Add(new Car { BrandId = 5, ColorId = 2, ModelYear = 2010, DailyPrice = 150, Description = "Honda Civic" });
            //Console.WriteLine("\n");

            //Console.WriteLine("----- All cars in the system. -----");
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine($"{car.Id}\t{brandManager.GetById(car.BrandId).BrandName}\t\t\t{colorManager.GetById(car.ColorId).ColorName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            //}

            Console.WriteLine("\n----- All cars in the system. -----");
            Console.WriteLine("Brand Name \t\t  Color Name \t Model Year \t  Daily Price \t Description");
            Console.WriteLine("\n");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName + "\t\t\t\t" + car.ColorName + "\t\t" + car.ModelYear + "\t\t" + car.DailyPrice + "\t\t" + car.Description);
            }

            carManager.Add(new Car { BrandId = 2, ColorId = 3, ModelYear = 2010, DailyPrice = 150, Description = "T" });
            Console.WriteLine("\n");

            carManager.Add(new Car { BrandId =2 , ColorId = 2, ModelYear = 2010, DailyPrice = 150, Description = "Toyota Corolla" });
            Console.WriteLine("\n");

            Console.WriteLine("Brand Name \t\t  Color Name \t Model Year \t  Daily Price \t Description");
            Console.WriteLine("\n");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName + "\t\t\t\t" + car.ColorName + "\t\t" + car.ModelYear + "\t\t" + car.DailyPrice + "\t\t" + car.Description);
            }
        }
    }
}