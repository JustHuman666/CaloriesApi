using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaloriesApi.Models
{
    public class Recipe
    {
        
        public string image { get; set; }
        public string shareAs { get; set; }
        public List<string> ingredientLines { get; set; }
        public float totalWeight { get; set; }
        public float totalTime { get; set; }
        public totalNutrients totalNutrients { get; set; }
    }
}
