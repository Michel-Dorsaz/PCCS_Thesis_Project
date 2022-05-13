using DTO;
using Serilog;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// This class is the DB access layer for menus plans and their meals.
    /// </summary>
    public class MenusPlanDB
    {

        #region MenusPlan


        /// <summary>
        /// 
        /// </summary>
        /// <returns>List of all menus plan or an empty list.</returns>
        /// <exception cref="Exception"></exception>
        public static List<MenusPlan> GetAllMenusPlans()
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            List<MenusPlan> list;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"SELECT Id, Name, StartDate, EndDate
                                    FROM MenusPlan;";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    list = new List<MenusPlan>();

                    while (reader.Read())
                    {

                        MenusPlan menusPlan = new MenusPlan(
                                reader.GetInt32(0), // Id
                                reader.GetString(1), // Name
                                reader.GetDateTime(2), // StartDate
                                reader.GetDateTime(3) // EndDate
                            );

                        list.Add(menusPlan);
                    }

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while loading the menus plans : {e}", e.Message);
                throw new Exception("Error while loading the menus plans.", e);
            }

            return list;
        }


        /// <summary>
        /// Delete a menu plan
        /// </summary>
        /// <param name="plan"></param>
        /// <exception cref="Exception"></exception>
        public static void Delete(MenusPlan plan)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"DELETE FROM MenusPlan 
                                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Id", plan.Id);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while deleting the plan {plan} : {e}", plan, e.Message);
                throw new Exception("Error while deleting the plan : " + plan.Name, e);
            }

        }

        /// <summary>
        /// Update a menu plan
        /// </summary>
        /// <param name="plan"></param>
        /// <exception cref="Exception"></exception>
        public static void Update(MenusPlan plan)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"UPDATE MenusPlan
                                    SET Name = @Name, StartDate = @StartDate, EndDate = @EndDate 
                                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, connection);


                    cmd.Parameters.AddWithValue("@Name", plan.Name);
                    cmd.Parameters.AddWithValue("@StartDate", plan.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", plan.EndDate);
                    cmd.Parameters.AddWithValue("@Id", plan.Id);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while updating the plan {plan} : {e}", plan, e.Message);
                throw new Exception("Error while updating the plan : " + plan.Name, e);
            }
        }

        /// <summary>
        /// Insert a menus plan
        /// </summary>
        /// <param name="plan"></param>
        /// <exception cref="Exception"></exception>
        public static void Insert(MenusPlan plan)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"INSERT INTO MenusPlan 
                        (Name, StartDate, EndDate) 
                        Values 
                        (@Name, @StartDate, @EndDate);
                        SELECT CAST(scope_identity() AS int);";

                    SqlCommand cmd = new SqlCommand(query, connection);


                    cmd.Parameters.AddWithValue("@Name", plan.Name);
                    cmd.Parameters.AddWithValue("@StartDate", plan.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", plan.EndDate);

                    connection.Open();

                    plan.Id = (int)cmd.ExecuteScalar();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while saving the plan {plan} : {e}", plan, e.Message);
                throw new Exception("Error while saving the plan : " + plan.Name, e);
            }
        }

        /// <summary>
        /// Delete all day units coresponding to menus plan parameter.
        /// </summary>
        /// <param name="plan"></param>
        /// <exception cref="Exception"></exception>
        public static void RefreshDayUnits(MenusPlan plan)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"DELETE FROM DayUnit 
                                    WHERE MenusPlanId = @MenusPlanId";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@MenusPlanId", plan.Id);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while refreshing the day units : {e}", e.Message);
                throw new Exception("Error while refreshing the day units", e);
            }
        }


        #endregion

        #region MealModels

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menu"></param>
        /// <returns>List of Meal models from menu plan or an empty list.</returns>
        /// <exception cref="Exception"></exception>
        public static List<MealModel> GetMealModelsFor(MenusPlan menu)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            List<MealModel> list;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"SELECT Id, Name, Soups, MainCourses, Desserts, Snacks, Others 
                                    FROM MealModel 
                                    WHERE MenusPlanId = @MenusPlanId;";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@MenusPlanId", menu.Id);

                    connection.Open();


                    SqlDataReader reader = cmd.ExecuteReader();

                    list = new List<MealModel>();

                    while (reader.Read())
                    {

                        MealModel model = new MealModel(
                                reader.GetInt32(0), // Id
                                reader.GetString(1), // Name
                                reader.GetInt32(2), // Soups
                                reader.GetInt32(3), // Main courses
                                reader.GetInt32(4), // Desserts
                                reader.GetInt32(5), // Snacks
                                reader.GetInt32(6) // Others
                            );

                        list.Add(model);
                    }

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while loading the model : {e}", e.Message);
                throw new Exception("Error while loading the model.", e);
            }

            return list;
        }

        /// <summary>
        /// Delete a meal model
        /// </summary>
        /// <param name="model"></param>
        /// <exception cref="Exception"></exception>
        public static void Delete(MealModel model)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"DELETE FROM MealModel 
                                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Id", model.Id);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while deleting the model {model} : {e}", model, e.Message);
                throw new Exception("Error while deleting the model : " + model.Name, e);
            }

        }

        /// <summary>
        /// Update a model
        /// </summary>
        /// <param name="planId"></param>
        /// <param name="model"></param>
        /// <exception cref="Exception"></exception>
        public static void Update(int planId, MealModel model)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"UPDATE MealModel
                                    SET MenusPlanId = @MenusPlanId, Name = @Name, Soups = @Soups, MainCourses = @MainCourses, 
                                    Desserts = @Desserts, Snacks = @Snacks, Others = @Others
                                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@MenusPlanId", planId);
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@Soups", model.Soups);
                    cmd.Parameters.AddWithValue("@MainCourses", model.MainCourses);
                    cmd.Parameters.AddWithValue("@Desserts", model.Desserts);
                    cmd.Parameters.AddWithValue("@Snacks", model.Snacks);
                    cmd.Parameters.AddWithValue("@Others", model.Others);
                    cmd.Parameters.AddWithValue("@Id", model.Id);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while updating the meal model {model} : {e}", model, e.Message);
                throw new Exception("Error while updating the model : " + model.Name, e);
            }
        }

        /// <summary>
        /// Insert a model
        /// </summary>
        /// <param name="planId"></param>
        /// <param name="model"></param>
        /// <exception cref="Exception"></exception>
        public static void Insert(int planId, MealModel model)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"INSERT INTO MealModel 
                        (MenusPlanId, Name, Soups, MainCourses, Desserts, Snacks, Others) 
                        Values 
                        (@MenusPlanId, @Name, @Soups, @MainCourses, @Desserts, @Snacks, @Others);
                        SELECT CAST(scope_identity() AS int);";

                    SqlCommand cmd = new SqlCommand(query, connection);


                    cmd.Parameters.AddWithValue("@MenusPlanId", planId);
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@Soups", model.Soups);
                    cmd.Parameters.AddWithValue("@MainCourses", model.MainCourses);
                    cmd.Parameters.AddWithValue("@Desserts", model.Desserts);
                    cmd.Parameters.AddWithValue("@Snacks", model.Snacks);
                    cmd.Parameters.AddWithValue("@Others", model.Others);

                    connection.Open();

                    model.Id = (int)cmd.ExecuteScalar();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while saving the model {model} : {e}", model, e.Message);
                throw new Exception("Error while saving the model : " + model.Name, e);
            }
        }


        #endregion

        #region Meals

        /// <summary>
        /// Delete all meal recipes corresponding to meal parameter
        /// </summary>
        /// <param name="meal"></param>
        /// <exception cref="Exception"></exception>
        public static void RefreshMealRecipes(Meal meal)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"DELETE FROM MealRecipes 
                                    WHERE MealId = @MealId";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@MealId", meal.Id);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while refreshing the meal's recipes {meal} : {e}", meal, e.Message);
                throw new Exception("Error while refreshing the meal's recipes", e);
            }
        }

        /// <summary>
        /// Insert a recipe
        /// </summary>
        /// <param name="meal"></param>
        /// <param name="recipe"></param>
        /// <exception cref="Exception"></exception>
        public static void Insert(Meal meal, Recipe recipe)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"INSERT INTO MealRecipes 
                        (MealId, RecipeId) 
                        Values 
                        (@MealId, @RecipeId);";

                    SqlCommand cmd = new SqlCommand(query, connection);


                    cmd.Parameters.AddWithValue("@MealId", meal.Id);
                    cmd.Parameters.AddWithValue("@RecipeId", recipe.Id);

                    connection.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Log.Error("Error while saving the meal's recipe {recipe} : {e}", recipe, e.Message);
                throw new Exception("Error while saving the meal's recipe : " + recipe.Name, e);
            }
        }

        /// <summary>
        /// Insert a meal
        /// </summary>
        /// <param name="meal"></param>
        /// <exception cref="Exception"></exception>
        public static void Insert(Meal meal)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"INSERT INTO Meal 
                        (DayUnitId) 
                        Values 
                        (@DayUnitId);
                        SELECT CAST(scope_identity() AS int);";

                    SqlCommand cmd = new SqlCommand(query, connection);


                    cmd.Parameters.AddWithValue("@DayUnitId", meal.DayUnitId);

                    connection.Open();

                    meal.Id = (int)cmd.ExecuteScalar();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while saving the meal {meal} : {e}", meal, e.Message);
                throw new Exception("Error while saving the meal", e);
            }
        }

        /// <summary>
        /// Upate a meal
        /// </summary>
        /// <param name="meal"></param>
        /// <exception cref="Exception"></exception>
        public static void Update(Meal meal)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"UPDATE Meal
                                    SET DayUnitId = @DayUnitId 
                                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@DayUnitId", meal.DayUnitId);
                    cmd.Parameters.AddWithValue("@Id", meal.Id);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while updating the meal {meal} : {e}", meal, e.Message);
                throw new Exception("Error while updating the meal", e);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="mealId"></param>
        /// <returns>A list of recipes corresponding to meal id or empty list</returns>
        /// <exception cref="Exception"></exception>
        public static List<Recipe>? GetMealRecipes(int mealId)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            List<Recipe> list;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"SELECT Id, Name, CategoryId, NodeLevel, WPP, Portions 
                                    FROM Recipe R 
                                    INNER JOIN MealRecipes M 
                                    ON R.Id = M.RecipeId 
                                    WHERE M.MealId = @mealId
                                    ;";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@mealId", mealId);


                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    list = new List<Recipe>();

                    while (reader.Read())
                    {

                        Recipe recipe = new Recipe(
                               reader.GetInt32(0), // Id
                               reader.GetString(1), // Name
                               reader.GetInt32(2), // Category Id
                               reader.GetInt32(3), // Node level
                               reader.GetInt32(4), // WPP
                               reader.GetInt32(5) // Portions
                           );

                        list.Add(recipe);
                    }

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while loading the meal recipes : {e}", e.Message);
                throw new Exception("Error while loading the meal recipes.", e);
            }

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dayUnit"></param>
        /// <returns>A meal array corresponding to day unit or empty array</returns>
        /// <exception cref="Exception"></exception>
        public static Meal[] GetMeals(DayUnit dayUnit)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            Meal[] list;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"SELECT Id, DayUnitId 
                                    FROM Meal 
                                    WHERE DayUnitId = @dayUnitId;";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@dayUnitId", dayUnit.Id);

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    list = new Meal[dayUnit.Meals.Length];
                    int index = 0;

                    while (reader.Read() && index < dayUnit.Meals.Length)
                    {
                        Meal meal = new Meal(
                                reader.GetInt32(0), // Id
                                reader.GetInt32(1) // Day unit Id
                            );

                        list[index++] = meal;
                    }

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while loading the meals : {e}", e.Message);
                throw new Exception("Error while loading the meals.", e);
            }

            return list;
        }

        /// <summary>
        /// Delete a meal
        /// </summary>
        /// <param name="plan"></param>
        /// <exception cref="Exception"></exception>
        public static void Delete(Meal meal)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"DELETE FROM Meal 
                                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Id", meal.Id);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while deleting the meal {meal} : {e}", meal, e.Message);
                throw new Exception("Error while deleting the meal", e);
            }

        }

        #endregion

        #region DayUnits

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="planId"></param>
        /// <param name="mealsNumber"></param>
        /// <returns>A day unit corresponding to parameters.</returns>
        /// <exception cref="Exception"></exception>
        public static DayUnit GetDayUnit(DateTime date, int planId, int mealsNumber)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            DayUnit dayunit = new DayUnit(date, planId, mealsNumber);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"SELECT Id, Date, MenusPlanId 
                                    FROM DayUnit 
                                    WHERE Date = @date 
                                    AND MenusPlanId = @planId;";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@planId", planId);


                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();



                    while (reader.Read())
                    {
                        dayunit = new DayUnit(
                                            reader.GetInt32(0), // Id
                                            reader.GetDateTime(1), // Date
                                            reader.GetInt32(2), // MenusPlan Id
                                            mealsNumber
                                        );

                    }

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while loading the day unit {d} : {e}", date, e.Message);
                throw new Exception("Error while loading the day unit.", e);
            }

            return dayunit;
        }

        /// <summary>
        /// Insert a day unit
        /// </summary>
        /// <param name="day"></param>
        /// <exception cref="Exception"></exception>
        public static void Insert(DayUnit day)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"INSERT INTO DayUnit 
                        (Date, MenusPlanId) 
                        Values 
                        (@Date, @MenusPlanId);
                        SELECT CAST(scope_identity() AS int);";

                    SqlCommand cmd = new SqlCommand(query, connection);


                    cmd.Parameters.AddWithValue("@Date", day.Date);
                    cmd.Parameters.AddWithValue("@MenusPlanId", day.MenusPlanId);

                    connection.Open();

                    day.Id = (int)cmd.ExecuteScalar();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while saving the day unit {day} : {e}", day, e.Message);
                throw new Exception("Error while saving the day unit : " + day.Date.ToShortDateString(), e);
            }
        }

        /// <summary>
        /// Update a day unit
        /// </summary>
        /// <param name="day"></param>
        /// <exception cref="Exception"></exception>
        public static void Update(DayUnit day)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"UPDATE DayUnit
                                    SET Date = @Date, MenusPlanId = @MenusPlanId 
                                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Date", day.Date);
                    cmd.Parameters.AddWithValue("@MenusPlanId", day.MenusPlanId);
                    cmd.Parameters.AddWithValue("@Id", day.Id);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while updating the day unit {day} : {e}", day, e.Message);
                throw new Exception("Error while updating the day unit : " + day.Date.ToShortDateString(), e);
            }
        }

        /// <summary>
        /// Delete a day unit
        /// </summary>
        /// <param name="plan"></param>
        /// <exception cref="Exception"></exception>
        public static void Delete(DayUnit dayUnit)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"DELETE FROM DayUnit 
                                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Id", dayUnit.Id);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while deleting the dayUnit {dayUnit} : {e}", dayUnit, e.Message);
                throw new Exception("Error while deleting the dayUnit", e);
            }

        }

        #endregion

    }
}
