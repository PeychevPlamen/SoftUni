using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Data
{
    public class DataConstants
    {
        public const int IdMaxLength = 40;

        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 20;

        public const int PasswordMinLength = 5;
        public const int PasswordMaxLength = 20;

        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
       
        public const int EmailMinLength = 10;
        public const int EmailMaxLength = 60;

        public const int PlayerFullNameMinLength = 5;
        public const int PlayerFullNameMaxLength = 80;


        public const int PositionMinLength = 5;
        public const int PositionMaxLength = 20;

        public const int SpeedMin = 0;
        public const int SpeedMax = 10;

        public const int EnduranceMin = 0;
        public const int EnduranceMax = 10;

        public const int DescriptionMaxLength = 200;

        
    }
}
