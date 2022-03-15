using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DayModel
    {
        public List<MealModel> MealModels { get; set; }

        public DayModel()
        {
            MealModels = new List<MealModel>();
            MealModels.Add(new MealModel("Breakfast"));
            MealModels.Add(new MealModel("Lunch"));
            MealModels.Add(new MealModel("Dinner"));
        }
    }
}
