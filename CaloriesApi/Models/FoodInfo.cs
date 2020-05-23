using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaloriesApi.Models
{
    public class FoodInfo
    {
        public string foodName { get; set; }
        public double foodAmount { get; set; }
        public float totalWeight { get; set; }
        
        public totalNutrients totalNutrients { get; set; }
    }
}
