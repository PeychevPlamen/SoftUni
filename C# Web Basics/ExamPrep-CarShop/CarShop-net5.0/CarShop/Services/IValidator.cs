using CarShop.ViewModels;
using CarShop.ViewModels.Issues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterViewModel model);

        ICollection<string> ValidateCar(AddNewCarViewModel model);

        ICollection<string> ValidateIssue(AddIssueFormModel model);
    }
}
