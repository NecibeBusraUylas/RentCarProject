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
            var result = colorManager.GetAll();
            if (result.Success)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine(result.Message);
                Console.WriteLine("\n");
            }

            //colorManager.Add(new Color { ColorName = "Red" });
            //Console.WriteLine("\n");

            //Console.WriteLine("\n----- All colors in the system. -----");
            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.ColorName);
            //}
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("\n----- All brands in the system. -----");
            var result = brandManager.GetAll();
            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName );
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine(result.Message);
                Console.WriteLine("\n");
            }

            //brandManager.Add(new Brand { BrandName = "H" });
            //Console.WriteLine("\n");

            //brandManager.Add(new Brand { BrandName = "Honda" });
            //Console.WriteLine("\n");

            //Console.WriteLine("\n----- All brands in the system. -----");
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.BrandName);
            //}

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("\n----- All cars in the system. -----");
            Console.WriteLine("Brand Name \t\t\t\t\t  Car Name ");
            Console.WriteLine("\n");
            var result = carManager.GetCarDetails();
            if(result.Success)
            {
                foreach(var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + car.CarName);
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine(result.Message);
                Console.WriteLine("\n");
            }

            //carManager.Add(new Car { BrandId = 2, ColorId = 3, ModelYear = 2010, DailyPrice = 150, Description = "T" });
            //Console.WriteLine("\n");

            //carManager.Add(new Car { BrandId =2 , ColorId = 2, ModelYear = 2010, DailyPrice = 150, Description = "Toyota Corolla" });
            //Console.WriteLine("\n");

            //Console.WriteLine("Brand Name \t\t  Color Name \t Model Year \t  Daily Price \t Description");
            //Console.WriteLine("\n");
            //foreach (var car in carManager.GetCarDetails())
            //{
            //    Console.WriteLine(car.BrandName + "\t\t\t\t" + car.ColorName + "\t\t" + car.ModelYear + "\t\t" + car.DailyPrice + "\t\t" + car.Description);
            //}
        }
    }
}