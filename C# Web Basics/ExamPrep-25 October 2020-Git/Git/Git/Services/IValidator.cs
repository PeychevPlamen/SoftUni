using Git.ViewModels;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterViewModel model);

        ICollection<string> ValidateRepository(CreateRepoViewModel model);

        //ICollection<string> ValidateIssue(AddIssueFormModel model);
    }
}
