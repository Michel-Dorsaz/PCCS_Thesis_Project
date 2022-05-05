using DTO;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MenusPlanDB
    {
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

        public static DayUnit GetDayUnit(DateTime date, int planId,  int mealsNumber)
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

        public static void Update(MenusPlan plan)
        {
            throw new NotImplementedException();
        }

        public static void Insert(MenusPlan plan)
        {
            throw new NotImplementedException();
        }

        public static List<Recipe>? getMealRecipes(int mealId)
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
  
       
    }
}
