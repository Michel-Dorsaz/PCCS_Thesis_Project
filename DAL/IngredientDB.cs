using DTO;
using Serilog;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// This class is the DB access layer for ingredients and ingredients' categories.
    /// </summary>
    public static class IngredientDB
    {
        #region Ingredients

        /// <summary>
        /// 
        /// </summary>
        /// <returns>List of all ingredients or an empty list</returns>
        /// <exception cref="Exception"></exception>
        public static List<Ingredient> GetAllIngredients()
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            List<Ingredient> list;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"SELECT Id, Name, CategoryId, NodeLevel, Glucid, Lipid, Protein, QuantityTypeId 
                                    FROM Ingredient;";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    list = new List<Ingredient>();

                    while (reader.Read())
                    {

                        Ingredient ingredient = new Ingredient(
                                reader.GetInt32(0), // Id
                                reader.GetString(1), // Name
                                reader.GetInt32(2), // Category Id
                                reader.GetInt32(3), // Node level
                                reader.GetInt32(4), // Glucid
                                reader.GetInt32(5), // Lipid
                                reader.GetInt32(6), // Protein
                                reader.GetInt32(7) // Quantity Type id
                            );

                        list.Add(ingredient);
                    }

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while loading the ingredients : {e}", e.Message);
                throw new Exception("Error while loading the ingredients.", e);
            }

            return list;
        }

        /// <summary>
        /// The Id of the inserted ingredient is set to the id of the inserted row during
        /// the operation.
        /// </summary>
        /// <param name="ingredient"></param>
        /// <exception cref="Exception"></exception>
        public static void Insert(Ingredient ingredient)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"INSERT INTO Ingredient 
                        (Name, CategoryId, NodeLevel, Glucid, Lipid, Protein, QuantityTypeId) 
                        Values 
                        (@Name, @CategoryId, @NodeLevel, @Glucid, @Lipid, @Protein, @QuantityTypeId);
                        SELECT CAST(scope_identity() AS int);";

                    SqlCommand cmd = new SqlCommand(query, connection);


                    cmd.Parameters.AddWithValue("@Name", ingredient.Text);
                    cmd.Parameters.AddWithValue("@CategoryId", ingredient.ParentId);
                    cmd.Parameters.AddWithValue("@NodeLevel", ingredient.NodeLevel);
                    cmd.Parameters.AddWithValue("@Glucid", ingredient.Glucid);
                    cmd.Parameters.AddWithValue("@Lipid", ingredient.Lipid);
                    cmd.Parameters.AddWithValue("@Protein", ingredient.Protein);
                    cmd.Parameters.AddWithValue("@QuantityTypeId", ingredient.QuantityTypeId);

                    connection.Open();

                    ingredient.Id = (int)cmd.ExecuteScalar();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while saving the ingredient {ingredient} : {e}", ingredient, e.Message);
                throw new Exception("Error while saving the ingredient : " + ingredient.Text, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredient"></param>
        /// <exception cref="Exception"></exception>
        public static void Update(Ingredient ingredient)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"UPDATE Ingredient
                                    SET Name = @Name, CategoryId = @CategoryId, NodeLevel = @NodeLevel, 
                                    Glucid = @Glucid, Lipid = @Lipid, Protein = @Protein, QuantityTypeId = @QuantityTypeId 
                                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Id", ingredient.Id);
                    cmd.Parameters.AddWithValue("@Name", ingredient.Text);
                    cmd.Parameters.AddWithValue("@CategoryId", ingredient.ParentId);
                    cmd.Parameters.AddWithValue("@NodeLevel", ingredient.NodeLevel);
                    cmd.Parameters.AddWithValue("@Glucid", ingredient.Glucid);
                    cmd.Parameters.AddWithValue("@Lipid", ingredient.Lipid);
                    cmd.Parameters.AddWithValue("@Protein", ingredient.Protein);
                    cmd.Parameters.AddWithValue("@QuantityTypeId", ingredient.QuantityTypeId);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while updating the ingredient {ingredient} : {e}", ingredient, e.Message);
                throw new Exception("Error while updating the ingredient : " + ingredient.Text, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredient"></param>
        /// <exception cref="Exception"></exception>
        public static void Delete(Ingredient ingredient)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"DELETE FROM Ingredient 
                                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Id", ingredient.Id);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while deleting the ingredient {ingredient} : {e}", ingredient, e.Message);
                throw new Exception("Error while deleting the ingredient : " + ingredient.Text, e);
            }
        }


        #endregion

        #region Categories

        /// <summary>
        /// 
        /// </summary>
        /// <returns>List of all categories or an empty list</returns>
        /// <exception cref="Exception"></exception>
        public static List<IngredientCategory> GetAllCategories()
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            List<IngredientCategory> list;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"SELECT Id, Name, ParentCategoryId, NodeLevel 
                                    FROM IngredientCategory;";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    list = new List<IngredientCategory>();

                    while (reader.Read())
                    {

                        IngredientCategory category = new IngredientCategory(
                                reader.GetInt32(0), // Id
                                reader.GetString(1), // Name
                                reader.GetInt32(2), // Parent category Id
                                reader.GetInt32(3) // Node level
                            );


                        list.Add(category);
                    }

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while loading the categories : {e}", e.Message);
                throw new Exception("Error while loading the categories.", e);
            }

            return list;
        }

        /// <summary>
        /// The Id of the inserted category is set to the id of the inserted row during
        /// the operation.
        /// </summary>
        /// <param name="category"></param>
        /// <exception cref="Exception"></exception>
        public static void Insert(IngredientCategory category)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"INSERT INTO IngredientCategory 
                        (Name, ParentCategoryId, NodeLevel) 
                        Values 
                        (@Name, @ParentCategoryId, @NodeLevel);
                        SELECT CAST(scope_identity() AS int);";

                    SqlCommand cmd = new SqlCommand(query, connection);


                    cmd.Parameters.AddWithValue("@Name", category.Text);
                    cmd.Parameters.AddWithValue("@ParentCategoryId", category.ParentId);
                    cmd.Parameters.AddWithValue("@NodeLevel", category.NodeLevel);

                    connection.Open();

                    category.Id = (int)cmd.ExecuteScalar();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while saving the ingredient's category {category} : {e}", category, e.Message);
                throw new Exception("Error while saving the ingredient's category : " + category.Text, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <exception cref="Exception"></exception>
        public static void Update(IngredientCategory category)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"UPDATE IngredientCategory
                                    SET Name = @Name, ParentCategoryId = @ParentCategoryId, NodeLevel = @NodeLevel 
                                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Id", category.Id);
                    cmd.Parameters.AddWithValue("@Name", category.Text);
                    cmd.Parameters.AddWithValue("@ParentCategoryId", category.ParentId);
                    cmd.Parameters.AddWithValue("@NodeLevel", category.NodeLevel);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while updating the ingredient's category {category} : {e}", category, e.Message);
                throw new Exception("Error while updating the ingredient's category : " + category.Text, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <exception cref="Exception"></exception>
        public static void Delete(IngredientCategory category)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"DELETE FROM IngredientCategory 
                                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Id", category.Id);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while deleting the ingredient's category {category} : {e}", category, e.Message);
                throw new Exception("Error while deleting the category : " + category.Text, e);
            }
        }

        #endregion
    }
}

    

