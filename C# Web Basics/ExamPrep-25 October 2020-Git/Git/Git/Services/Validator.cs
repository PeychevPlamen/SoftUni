using Git.ViewModels;
using Git.ViewModels.Repositories;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

using static Git.Data.DataConstants;

namespace Git.Services
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

        public ICollection<string> ValidateRepository(CreateRepoViewModel model)
        {
            if (model.Name.Length < RepoNameMinLength || model.Name.Length > RepoNameMaxLength)
            {
                errors.Add($"Repository name should be between {RepoNameMinLength} and {RepoNameMaxLength}");
            }
            if (model.RepositoryType != RepositoryPrivateType && model.RepositoryType != RepositoryPublicType)
            {
                errors.Add($"Repository type must be {RepositoryPrivateType} or {RepositoryPublicType}.");
            }

            return errors;
        }
    }
}
