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
            MealModels.Add(new MealModel("Breakfast", 1, 1, 1, 0, 0));
            MealModels.Add(new MealModel("Lunch", 1, 1, 1, 0, 0));
            MealModels.Add(new MealModel("Dinner", 1, 1, 1, 0, 0));
        }

        public DayModel(List<MealModel> mealModels)
        {
            MealModels = mealModels;
        }
    }
}
