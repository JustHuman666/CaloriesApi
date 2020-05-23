using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaloriesApi.Models
{
    public class totalNutrients
    {
        public CHOCDF cHOCDF { get; set; }
        public ENERC_KCAL eNERC_KCAL { get; set; }
        public FAT fat { get; set; }
        public PROCNT pROCNT { get; set; }

    }
}
