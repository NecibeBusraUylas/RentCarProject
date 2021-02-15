using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ColorAdded = "\nColor added!\n";
        public static string ColorUpdated = "\nColor updated!\n";
        public static string ColorDeleted = "\nColor deleted!\n";

        public static string CarAdded = "\nNew car added! ";
        public static string CarUpdated = "\nInformation about car updated!\n";
        public static string CarCouldNotUpdated = "\nInformation about car could not be updated.Daily Price must be greater than 0.\n";
        public static string CarDeleted = "\nCar deleted!\n";
        public static string InvalidDailyPrice = "\nCar could not be added. Daily Price must be greater than 0.\n";
        public static string InvalidCarName = "\nCar could not be added. The lenght of the car name must be greater or equal to .\n";
        
        public static string BrandAdded = "\nBrand added!\n";
        public static string BrandUpdated = "\nBrand updated!\n";
        public static string BrandDeleted = "\nBrand deleted!\n";

        public static string UserAdded = "\nUser added!\n";
        public static string UserUpdated = "\nUser updated!\n";
        public static string UserDeleted = "\nUser deleted!\n";

        public static string CustomerAdded = "\nCustomer added!\n";
        public static string CustomerUpdated = "\nCustomer updated!\n";
        public static string CustomerDeleted = "\nCustomer deleted!\n";

        public static string RentalCarAdded = "\nRental car added!\n";
        public static string RentalCarUpdated = "\nRental car updated!\n";
        public static string RentalCarDeleted = "\nRental car deleted!\n";
        public static string RentalCarCouldNotAdded = "\nRental car could not be added.\n";
        public static string RentalCarReturnDateError = "\nRental car could not be added.\n";
    }
}
