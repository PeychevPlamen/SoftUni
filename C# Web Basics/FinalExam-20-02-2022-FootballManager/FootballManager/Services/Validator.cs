using FootballManager.ViewModels;
using FootballManager.ViewModels.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using static FootballManager.Data.DataConstants;

namespace FootballManager.Services
{
    public class Validator : IValidator
    {
        private readonly List<string> errors;

        public Validator()
        {
            this.errors = new List<string>();
        }

        public ICollection<string> ValidateUser(RegisterPageFormModel user)
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

            if (user.Email.Length < EmailMinLength || user.Email.Length > EmailMaxLength)
            {
                errors.Add($"Email must be between {EmailMinLength} and {EmailMaxLength} characters long");
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

        public ICollection<string> ValidatePlayer(AddPlayerFormModel player)
        {

            if (player.FullName.Length < PlayerFullNameMinLength || player.FullName.Length > PlayerFullNameMaxLength || player.FullName == null)
            {
                errors.Add($"Fullname is not valid.It must be between {PlayerFullNameMinLength} and {PlayerFullNameMaxLength} characters long");
            }
            if (player.Position.Length < PositionMinLength || player.Position.Length > PositionMaxLength || player.Position == null)
            {
                errors.Add($"Position is not valid.It must be between {PositionMinLength} and {PositionMaxLength} characters long");
            }
            if (player.Speed < SpeedMin || player.Speed > SpeedMax)
            {
                errors.Add($"Speed cannot be negative or bigger than {SpeedMax}");
            }
            if (player.Endurance < EnduranceMin || player.Endurance > EnduranceMax)
            {
                errors.Add($"Endurance cannot be negative or bigger than {EnduranceMax}");
            }
            if (player.Description == null || player.Description.Length > DescriptionMaxLength)
            {
                errors.Add($"Description is required with max length {DescriptionMaxLength}.");
            }
            if (player.ImageUrl == null)
            {
                errors.Add("ImageUrl is required.");
            }
            return errors;
        }

    }
}
