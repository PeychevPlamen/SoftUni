using FootballManager.ViewModels;
using FootballManager.ViewModels.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterPageFormModel model);
        ICollection<string> ValidatePlayer(AddPlayerFormModel model);
    }
}
