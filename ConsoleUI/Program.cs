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
            //ColorTest();
            //BrandTest();
            //CarTest();
            UserTest();
            CustomerTest();
            RentalTest();
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rentalCar = new Rental
            {
                CarId = 4,
                CustomerId = 1,
                RentDate = DateTime.Now
            };
            Console.WriteLine(rentalManager.Add(rentalCar).Message);
            Rental rentalCar2 = new Rental
            {
                CarId = 10,
                CustomerId = 3,
                RentDate = DateTime.Now
            };
            Console.WriteLine(rentalManager.Add(rentalCar2).Message);

            Console.WriteLine("\n----- All rental cars in the system. -----");
            Console.WriteLine("Car Name \t\t\t\t\t Customer Name ");
            foreach (var rental in rentalManager.GetRentalCarDetails().Data)
            {
                Console.WriteLine( rental.CarName  + rental.CustomerName );
            }
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer
            {
                UserId = 1,
                CompanyName = "My Company"
            }) ;
            Console.WriteLine(result.Message);

            Console.WriteLine("\n----- All customers in the system. -----");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine( customer.CompanyName);
            }
            Console.WriteLine("\n");
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Add(new User
            {
                FirstName = "Ahmet",
                LastName = "Yılmaz",
                Email = "ahmet@gmail.com",
                Password = 12456
            });
            Console.WriteLine(result.Message);

            Console.WriteLine("\n----- All users in the system. -----");
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine( user.FirstName +  user.LastName);
            }
            Console.WriteLine("\n");
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