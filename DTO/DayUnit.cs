
namespace DTO
{

    /// <summary>
    /// This class represents a day unit and the meals associated to that day.
    /// </summary>
    public class DayUnit
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int MenusPlanId { get; set; }
        public Meal[] Meals { get; set; }

        /// <summary>
        /// This constructor create a day unit with specific parameters.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <param name="menusPlanId"></param>
        /// <param name="mealsNumber">The number of meals that day</param>
        public DayUnit(int id, DateTime date, int menusPlanId, int mealsNumber)
        {
            Id = id;
            Date = date;
            MenusPlanId = menusPlanId;
            Meals = new Meal[mealsNumber];
        }

        /// <summary>
        /// This constructor initialize the day unit with default paramters.
        /// To create a day unit with specific parameters
        /// see the constructor DayUnit(int id, DateTime date, int menusPlanId, int mealsNumber)
        /// </summary>
        /// <param name="date"></param>
        /// <param name="menusPlanId"></param>
        /// <param name="mealsNumber"></param>
        public DayUnit(DateTime date, int menusPlanId, int mealsNumber)
        {
            Id = -1;
            Date = date;
            MenusPlanId = menusPlanId;
            Meals = new Meal[mealsNumber];
        }
    }
}
