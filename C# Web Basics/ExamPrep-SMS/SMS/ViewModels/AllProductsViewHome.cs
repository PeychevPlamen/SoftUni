﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.ViewModels
{
    public class AllProductsViewHome
    {
        public string Username { get; set; }

        public List<ProductHomeView> Products { get; set; } = new List<ProductHomeView>();
    }
}
