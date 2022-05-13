using DTO;
using Serilog;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// This class is the DB access layer for recipes and recipes' categories.
    /// </summary>
    public static class RecipeDB
    {
        #region Recipes

        /// <summary>
        /// 
        /// </summary>
        /// <returns>List of all recipes or an empty list</returns>
        /// <exception cref="Exception"></exception>
        public static List<Recipe> GetAllRecipes()
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            List<Recipe> list;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"SELECT Id, Name, CategoryId, NodeLevel, WPP, Portions 
                                    FROM Recipe;";

                    SqlCommand cmd = new SqlCommand(query, connection);

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
                Log.Error("Error while loading the recipes : {e}", e.Message);
                throw new Exception("Error while loading the recipes.", e);
            }

            return list;
        }

        /// <summary>
        /// The Id of the inserted recipe is set to the id of the inserted row during
        /// the operation.
        /// </summary>
        /// <param name="recipe"></param>
        /// <exception cref="Exception"></exception>
        public static void Insert(Recipe recipe)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"INSERT INTO Recipe 
                        (Name, CategoryId, NodeLevel, WPP) 
                        Values 
                        (@Name, @CategoryId, @NodeLevel, @WPP);
                        SELECT CAST(scope_identity() AS int);";

                    SqlCommand cmd = new SqlCommand(query, connection);


                    cmd.Parameters.AddWithValue("@Name", recipe.Name);
                    cmd.Parameters.AddWithValue("@CategoryId", recipe.ParentId);
                    cmd.Parameters.AddWithValue("@NodeLevel", recipe.NodeLevel);
                    cmd.Parameters.AddWithValue("@WPP", recipe.WPP);

                    connection.Open();

                    recipe.Id = (int)cmd.ExecuteScalar();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while saving the recipe {recipe} : {e}", recipe, e.Message);
                throw new Exception("Error while saving the recipe : " + recipe.Text, e);
            }
        }


        /// <summary>
        /// Update the quantity and measure Id of a recipe's ingredient.
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="ingredientId"></param>
        /// <param name="quantity"></param>
        /// <param name="measureId"></param>
        /// <exception cref="Exception"></exception>
        public static void UpdateIngredientMeasure(int recipeId, int ingredientId, double quantity, int measureId)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"UPDATE RecipeIngredients 
                                    SET Quantity = @quantity, QuantityMeasureId = @measureId 
                                    WHERE RecipeId = @recipeId
                                    AND IngredientId = @ingredientId;";

                    SqlCommand cmd = new SqlCommand(query, connection);


                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@measureId", measureId);
                    cmd.Parameters.AddWithValue("@recipeId", recipeId);
                    cmd.Parameters.AddWithValue("@ingredientId", ingredientId);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while updating the recipe ingredient measure : {e}", e.Message);
                throw new Exception("Error while updating the recipe ingredient measure : ", e);
            }
        }

        /// <summary>
        /// Remove all the ingredients from a recipe.
        /// </summary>
        /// <param name="recipeId"></param>
        /// <exception cref="Exception"></exception>
        public static void ClearRecipeIngredients(int recipeId)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"DELETE FROM RecipeIngredients 
                                    WHERE RecipeId = @RecipeId";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@RecipeId", recipeId);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while clearing the recipe's ingredients : {e}", e.Message);
                throw new Exception("Error while clearing the recipe's ingredients", e);
            }
        }

        /// <summary>
        /// Insert ingredients into a recipe with corresponding quantities.
        /// </summary>
        /// <param name="RecipeId"></param>
        /// <param name="ingredient"></param>
        /// <exception cref="Exception"></exception>
        public static void InsertRecipeIngredients(int RecipeId, Tuple<Ingredient, Quantity> ingredient)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"INSERT INTO RecipeIngredients 
                        (RecipeId, IngredientId, Quantity, QuantityMeasureId) 
                        Values 
                        (@RecipeId, @IngredientId, @Quantity, @QuantityMeasureId);
                        SELECT CAST(scope_identity() AS int);";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@RecipeId", RecipeId);
                    cmd.Parameters.AddWithValue("@IngredientId", ingredient.Item1.Id);
                    cmd.Parameters.AddWithValue("@Quantity", ingredient.Item2.Amount);
                    cmd.Parameters.AddWithValue("@QuantityMeasureId", ingredient.Item2.Measure.Id);

                    connection.Open();

                    cmd.ExecuteScalar();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while inserting the recipe's ingredient {ingredient} - {quantity} : {e}", ingredient.Item1, ingredient.Item2.Amount, e.Message);
                throw new Exception("Error while inserting the recipe's ingredient : " + ingredient.Item1.Text, e);
            }
        }


        /// <summary>
        /// Get all the ingredients for a given recipe
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns>List of pairs : Ingredient - Quantity</returns>
        /// <exception cref="Exception"></exception>
        public static List<Tuple<Ingredient, Quantity>> GetIngredientsFor(Recipe recipe)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            List<Tuple<Ingredient, Quantity>> list;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"SELECT I.Id, I.Name, I.CategoryId, I.NodeLevel, I.Glucid, I.Lipid, I.Protein, I.QuantityTypeId,  
                                    Q.Id, Q.Name, Q.Amount, Q.QuantityTypeId ,
                                    R.Quantity 
                                    FROM Ingredient I 
                                    INNER JOIN RecipeIngredients R 
                                    ON R.IngredientId = I.Id 
                                    INNER JOIN QuantityMeasure Q 
                                    ON Q.Id = R.QuantityMeasureId 
                                    WHERE R.RecipeId = @RecipeId;";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@RecipeId", recipe.Id);

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    list = new List<Tuple<Ingredient, Quantity>>();

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
                                reader.GetInt32(7) // Quantity type id
                                );

                        Measure measure = new Measure(
                                reader.GetInt32(8), // Id
                                reader.GetString(9), // Name
                                reader.GetDouble(10), // Amount
                                reader.GetInt32(11) // Quantity type id
                            );

                        Quantity quantity = new Quantity(
                            reader.GetDouble(12), // quantities
                            measure
                            );

                        list.Add(new Tuple<Ingredient, Quantity>(ingredient, quantity));
                    }

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while loading the recipe' ingredients : {e}", e.Message);
                throw new Exception("Error while loading recipe' ingredients.", e);
            }

            return list;
        }

        /// <summary>
        /// Get all the ingredients and their quantities that relate to the parameter's ingredient.
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<Tuple<Ingredient, Quantity, int>> GetIngredients(Ingredient ingredient)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            List<Tuple<Ingredient, Quantity, int>> list;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"SELECT I.Id, I.Name, I.CategoryId, I.NodeLevel, I.Glucid, I.Lipid, I.Protein, I.QuantityTypeId,  
                                    Q.Id, Q.Name, Q.Amount, Q.QuantityTypeId, 
                                    R.Quantity, R.RecipeId 
                                    FROM Ingredient I 
                                    INNER JOIN RecipeIngredients R 
                                    ON R.IngredientId = I.Id 
                                    INNER JOIN QuantityMeasure Q 
                                    ON Q.Id = R.QuantityMeasureId 
                                    WHERE R.IngredientId = @IngredientID;";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@IngredientID", ingredient.Id);

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    list = new List<Tuple<Ingredient, Quantity, int>>();

                    while (reader.Read())
                    {
                        Ingredient i = new Ingredient(
                                reader.GetInt32(0), // Id
                                reader.GetString(1), // Name
                                reader.GetInt32(2), // Category Id
                                reader.GetInt32(3), // Node level
                                reader.GetInt32(4), // Glucid
                                reader.GetInt32(5), // Lipid
                                reader.GetInt32(6), // Protein
                                reader.GetInt32(7) // Quantity type id
                                );

                        Measure measure = new Measure(
                                reader.GetInt32(8), // Id
                                reader.GetString(9), // Name
                                reader.GetDouble(10), // Amount
                                reader.GetInt32(11) // Quantity type id
                            );

                        Quantity quantity = new Quantity(
                            reader.GetDouble(12), // quantities
                            measure
                            );

                        int recipeId = reader.GetInt32(13);

                        list.Add(new Tuple<Ingredient, Quantity, int>(i, quantity, recipeId));
                    }

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while loading the ingredients {ingredient} : {e}", ingredient.Name, e.Message);
                throw new Exception("Error while loading ingredients " + ingredient.Name, e);
            }

            return list;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <exception cref="Exception"></exception>
        public static void Update(Recipe recipe)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"UPDATE Recipe
                                    SET Name = @Name, CategoryId = @CategoryId, NodeLevel = @NodeLevel, 
                                    WPP = @WPP  
                                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Id", recipe.Id);
                    cmd.Parameters.AddWithValue("@Name", recipe.Name);
                    cmd.Parameters.AddWithValue("@CategoryId", recipe.ParentId);
                    cmd.Parameters.AddWithValue("@NodeLevel", recipe.NodeLevel);
                    cmd.Parameters.AddWithValue("@WPP", recipe.WPP);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while updating the recipe {recipe} : {e}", recipe, e.Message);
                throw new Exception("Error while updating the recipe : " + recipe.Text, e);
            }
        }

        /// <summary>
        /// Delete a recipe and ensure the deletion in related usages.
        /// </summary>
        /// <param name="recipe"></param>
        /// <exception cref="Exception"></exception>
        public static void Delete(Recipe recipe)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"DELETE FROM MealRecipes
                                    WHERE RecipeId = @Id;
                                    DELETE FROM RecipeIngredients
                                    WHERE RecipeId = @Id;
                                    DELETE FROM Recipe 
                                    WHERE Id = @Id;";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Id", recipe.Id);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while deleting the recipe {recipe} : {e}", recipe, e.Message);
                throw new Exception("Error while deleting the recipe : " + recipe.Text, e);
            }
        }


        #endregion

        #region Categories

        /// <summary>
        /// 
        /// </summary>
        /// <returns>List of all categories or an empty list</returns>
        /// <exception cref="Exception"></exception>
        public static List<RecipeCategory> GetAllCategories()
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            List<RecipeCategory> list;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"SELECT Id, Name, ParentCategoryId, NodeLevel, WPP 
                                    FROM RecipeCategory;";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    list = new List<RecipeCategory>();

                    while (reader.Read())
                    {

                        RecipeCategory category = new RecipeCategory(
                                reader.GetInt32(0), // Id
                                reader.GetString(1), // Name
                                reader.GetInt32(2), // Parent category Id
                                reader.GetInt32(3), // Node level
                                reader.GetInt32(4) // WPP
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
        public static void Insert(RecipeCategory category)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"INSERT INTO RecipeCategory 
                        (Name, ParentCategoryId, NodeLevel, WPP) 
                        Values 
                        (@Name, @ParentCategoryId, @NodeLevel, @WPP);
                        SELECT CAST(scope_identity() AS int);";

                    SqlCommand cmd = new SqlCommand(query, connection);


                    cmd.Parameters.AddWithValue("@Name", category.Name);
                    cmd.Parameters.AddWithValue("@ParentCategoryId", category.ParentId);
                    cmd.Parameters.AddWithValue("@NodeLevel", category.NodeLevel);
                    cmd.Parameters.AddWithValue("@WPP", category.WPP);

                    connection.Open();

                    category.Id = (int)cmd.ExecuteScalar();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while saving the recipe's category {category} : {e}", category, e.Message);
                throw new Exception("Error while saving the recipe's category : " + category.Text, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <exception cref="Exception"></exception>
        public static void Update(RecipeCategory category)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"UPDATE RecipeCategory
                                    SET Name = @Name, ParentCategoryId = @ParentCategoryId, NodeLevel = @NodeLevel, WPP = @WPP  
                                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Id", category.Id);
                    cmd.Parameters.AddWithValue("@Name", category.Name);
                    cmd.Parameters.AddWithValue("@ParentCategoryId", category.ParentId);
                    cmd.Parameters.AddWithValue("@NodeLevel", category.NodeLevel);
                    cmd.Parameters.AddWithValue("@WPP", category.WPP);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while updating the recipe's category {category} : {e}", category, e.Message);
                throw new Exception("Error while updating the recipe's category : " + category.Text, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <exception cref="Exception"></exception>
        public static void Delete(RecipeCategory category)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"DELETE FROM RecipeCategory 
                                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Id", category.Id);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Log.Error("Error while deleting the recipe's category {category} : {e}", category, e.Message);
                throw new Exception("Error while deleting the recipe's category : " + category.Text, e);
            }
        }

        #endregion
    }
}



