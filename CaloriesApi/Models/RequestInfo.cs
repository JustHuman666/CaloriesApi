﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaloriesApi.Models
{
    public class RequestInfo
    {
        
        public string Food { get; set; }
        public double AmountFood = 1;
        public string Recipe { get; set; }
        public int AmountRecipe = 5;
        public string id { get; set; }
        public int numberNote { get; set; }
        public string link { get; set; } 
    }
}
