
namespace DTO
{
    /// <summary>
    /// This class represents a day model and is used for business logic and meals auto-generation.
    /// </summary>
    public class DayModel
    {
        public List<MealModel> MealModels { get; set; }

        /// <summary>
        /// This constructor initialize the day model with default parameters.
        /// To create a model with parameters see constructor DayModel(List<MealModel> mealModels)
        /// </summary>
        /// <param name="mealModels"></param>
        public DayModel()
        {
            MealModels = new List<MealModel>();
            MealModels.Add(new MealModel(-1, "Breakfast", 1, 1, 1, 0, 0));
            MealModels.Add(new MealModel(-1, "Lunch", 1, 1, 1, 0, 0));
            MealModels.Add(new MealModel(-1, "Dinner", 1, 1, 1, 0, 0));
        }

        /// <summary>
        /// This constructor initialize a day model with specifics meal models.
        /// </summary>
        /// <param name="mealModels"></param>
        public DayModel(List<MealModel> mealModels)
        {
            MealModels = mealModels;
        }
    }
}
