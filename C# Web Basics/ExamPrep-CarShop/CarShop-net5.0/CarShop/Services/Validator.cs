
using CarShop.ViewModels;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

using static CarShop.Data.DataConstants;

namespace CarShop.Services
{
    public class Validator : IValidator
    {
        private readonly List<string> errors;

        public Validator()
        {
            this.errors = new List<string>();
        }

        public ICollection<string> ValidateUser(RegisterViewModel user)
        {
            //var errors = new List<string>();

            if (user.Username == null || user.Username.Length < UsernameMinLength || user.Username.Length > UsernameMaxLength)
            {
                errors.Add($"Username '{user.Username}' is not valid. It must be between {UsernameMinLength} and {UsernameMaxLength} characters long.");
            }

            if (user.Email == null || !Regex.IsMatch(user.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email '{user.Email}' is not a valid e-mail address.");
            }

            if (user.Password == null || user.Password.Length < PasswordMinLength || user.Password.Length > PasswordMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {PasswordMinLength} and {PasswordMaxLength} characters long.");
            }

            if (user.Password != null && user.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (user.Password != user.ConfirmPassword)
            {
                errors.Add("Password and its confirmation are different.");
            } 

            return errors;
        }

        public ICollection<string> ValidateCar(AddNewCarViewModel model)
        {
            
            if (model.Model.Length < ModelMinLength || model.Model.Length > ModelMaxLength)
            {
                errors.Add($"Model must be between {ModelMinLength} and {ModelMaxLength}");
            }
            if (model.PlateNumber == null || !Regex.IsMatch(model.PlateNumber, PlateNumberRegex))
            {
                errors.Add($"Plate number '{model.PlateNumber}' is not valid. It should be in 'XX0000XX' format.");
            }
            if (model.Image == null)
            {
                errors.Add("Image is required.");
            }

            return errors;
        }

        //private void Required(string text, string field)
        //{
        //    if (text == null)
        //    {
        //        errors.Add($"The {field} is required.");
        //    }
        //}
    }
}
