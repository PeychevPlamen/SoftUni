﻿using SMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterViewModel model);
       // ICollection<string> ValidateTrip(TripAddFormModel model);
    }
}
