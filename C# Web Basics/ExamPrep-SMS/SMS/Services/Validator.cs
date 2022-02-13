
using SMS.ViewModels;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

using static SMS.Data.DataConstants;

namespace SMS.Services
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

        public ICollection<string> ValidateProduct(ProductCreateView model)
        {
            //decimal price = 0;

            //if (!decimal.TryParse(model.Price.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out price)
            //    || price < PriceMinValue || price > PriceMaxValue)
            //{
            //    errors.Add($"Price should be between {PriceMinValue} and {PriceMaxValue}");
            //}

            if (model.Name.Length < UsernameMinLength || model.Name.Length > UsernameMaxLength)
            {
                errors.Add($"Product name must be between {UsernameMinLength} and {UsernameMaxLength}");
            }
            if (model.Price < PriceMinValue || model.Price > PriceMaxValue)
            {
                errors.Add($"Price should be between {PriceMinValue} and {PriceMaxValue}");
            }

            return errors;
        }

        private void Required(string text, string field)
        {
            if (text == null)
            {
                errors.Add($"The {field} is required.");
            }
        }
    }
}
