using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaloriesApi.Models
{
    public class User
    {
        public string Id { get; set; }
        public List<FoodInfo> food = new List<FoodInfo>();

    }
}
