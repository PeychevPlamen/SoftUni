﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Data
{
    public class DataConstants
    {
        public const int IdMaxLength = 40;

        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 20;

        public const int PasswordMinLength = 6;
        public const int PasswordMaxLength = 20;

        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        //public const string PlateNumberRegex = @"^([A-Z]{2}[0-9]{4}[A-Z]{2})$";

        //public const decimal PriceMinValue = 0.05m;
        //public const decimal PriceMaxValue = 1000m;

        public const int RepoNameMinLength = 3;
        public const int RepoNameMaxLength = 10;

        public const int DescriptionMinLength = 5;

        public const string RepositoryPublicType = "Public";
        public const string RepositoryPrivateType = "Private";

    }
}
