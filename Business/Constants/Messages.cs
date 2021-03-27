using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ColorAdded = "Color added!";
        public static string ColorUpdated = "Color updated!";
        public static string ColorDeleted = "Color deleted!";

        public static string CarAdded = "New car added! ";
        public static string CarUpdated = "Information about car updated!";
        public static string CarCouldNotUpdated = "Information about car could not be updated.Daily Price must be greater than 0.";
        public static string CarDeleted = "Car deleted!";
        public static string InvalidDailyPrice = "Car could not be added. Daily Price must be greater than 0.";
        public static string InvalidCarName = "Car could not be added. The lenght of the car name must be greater or equal to 2.";
        
        public static string BrandAdded = "Brand added!";
        public static string BrandUpdated = "Brand updated!";
        public static string BrandDeleted = "Brand deleted!";

        public static string CustomerAdded = "Customer added!";
        public static string CustomerUpdated = "Customer updated!";
        public static string CustomerDeleted = "Customer deleted!";

        public static string RentalCarAdded = "Rental car added!";
        public static string RentalCarUpdated = "Rental car updated!";
        public static string RentalCarDeleted = "Rental car deleted!";
        public static string RentalCarCouldNotAdded = "Rental car could not be added.";
        public static string RentalCarReturnDateError = "Rental car could not be added.";

        public static string CarImageAdded = " Image of the car added!";
        public static string CarImageUpdated = "Image of the car updated!";
        public static string CarImageDeleted = "Image of the car deleted!";
        public static string CarImageLimitExceeded = " Image limit exceded.Image could not be added!";
        public static string NoCarImages = "The car does not have any images";

        public static string AuthorizationDenied = " Authorization denied!";
        public static string UserAdded = "User added!";
        public static string UserRegistered = " User registered";
        public static string UserNotFound = "User could not be found ";
        public static string UserAlreadyExists = "User already exists!";
        public static string PasswordError = "Password error!";
        public static string SuccessfulLogin = "Successful login!";       
        public static string AccessTokenCreated = "Access token created!";

        public static string CardAdded = "Card added!";
        public static string CardUpdated = "Card updated!";
        public static string CardDeleted = "Card deleted!";
        public static string NoCard = "The car does not find in the system.";
    }
}