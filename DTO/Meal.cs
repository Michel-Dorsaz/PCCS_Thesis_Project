

namespace DTO
{

    /// <summary>
    /// This class represents a meal with its recipes.
    /// </summary>
    public class Meal
    {
        public int Id { get; set; }
        public int DayUnitId { get; set; }
        public List<Recipe>? Recipes { get; set; }

        /// <summary>
        /// The recipes list is initialized as an empty list.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dayUnitId"></param>
        public Meal(int id, int dayUnitId)
        {
            Id = id;
            DayUnitId = dayUnitId;
            Recipes = new List<Recipe>();
        }
    }
}
