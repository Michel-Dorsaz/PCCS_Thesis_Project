
namespace DTO
{

    /// <summary>
    /// This class represent the model for the meals each day, by specifying the quantity of each
    /// specific meals.
    /// </summary>
    public class MealModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Soups { get; set; }
        public int MainCourses { get; set; }
        public int Desserts { get; set; }
        public int Snacks { get; set; }
        public int Others { get; set; }

        /// <summary>
        /// This is the constructor with parameters.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="soups">quantity of soups</param>
        /// <param name="mainCourses">quantity of main courses</param>
        /// <param name="desserts">quantity of desserts</param>
        /// <param name="snacks">quantity of snacks</param>
        /// <param name="others">quantity of others</param>
        public MealModel(int id, string name, int soups, int mainCourses, int desserts, int snacks, int others)
        {
            Id = id;
            Name = name;
            Soups = soups;
            MainCourses = mainCourses;
            Desserts = desserts;
            Snacks = snacks;
            Others = others;
        }

        /// <summary>
        /// This constructor initialize the meal model with default parameters.
        /// To create the meal model with specific parameter
        /// see constructor MealModel(int id, string name, int soups, int mainCourses, int desserts, int snacks, int others)
        /// </summary>
        public MealModel()
        {
            Id = -1;
            Name = "";
            Soups = 1;
            MainCourses = 1;
            Desserts = 1;
            Snacks = 0;
            Others = 0;
        }
    }
}
