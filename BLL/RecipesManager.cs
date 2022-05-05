using DAL;
using DTO;

namespace BLL
{
    /// <summary>
    /// This class is the Business logic layer for recipes and their categories.
    /// </summary>
    public static class RecipesManager
    {

        /// <summary>
        /// Get all the recipes and categories into a TreeElement array. The elements are not sorted. The
        /// array contains the root element with a nodelevel of -1.
        /// <para />
        /// If an error happens it returns null and display a warning message.
        /// </summary>
        /// <returns></returns>
        public static TreeElement[]? GetTreeElements()
        {
            try
            {
                List<Recipe> recipes = RecipeDB.GetAllRecipes();
                List<RecipeCategory> categories = RecipeDB.GetAllCategories();

                TreeElement[] treeElements = new TreeElement[recipes.Count + categories.Count];
                int index = 0;

                foreach (Recipe recipe in recipes)
                    treeElements[index++] = recipe;

                foreach (RecipeCategory category in categories)
                    treeElements[index++] = category;

                return treeElements;

            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
                return null;
            }
        }

        /// <summary>
        /// Save the new category in the DB or update it if it already exists.
        /// </summary>
        /// <param name="category"></param>
        public static void Save(RecipeCategory category)
        {
            try
            {
                if (category.Id == -1)
                    RecipeDB.Insert(category);
                else
                    RecipeDB.Update(category);
            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
            }


        }

        /// <summary>
        /// Save the new recipe in the DB or update it if it already exists.
        /// </summary>
        /// <param name="recipe"></param>
        public static void Save(Recipe recipe, List<Tuple<Ingredient, Quantity>> ingredients)
        {
            try
            {
                if (recipe.Id == -1)                
                    RecipeDB.Insert(recipe);                 
                else               
                    RecipeDB.Update(recipe);


                RecipeDB.ClearRecipeIngredients(recipe.Id);

                foreach (Tuple<Ingredient, Quantity> ingredient in ingredients)
                {
                    RecipeDB.InsertRecipeIngredients(recipe.Id, ingredient);
                }

            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
            }

        }

        /// <summary>
        /// Update the quantity and measure Id of a recipe's ingredient.
        /// </summary>
        /// <param name="tuple"></param>
        /// <param name="target"></param>
        public static void ModifyIngredientMeasure(Tuple<Ingredient, Quantity, int> tuple, Measure target)
        {

            Ingredient ingredient = tuple.Item1;
            Quantity quantity = tuple.Item2;
            int recipeId = tuple.Item3;

            double convertedAmount = QuantitiesManager.ConvertMeasureAmount(quantity.Amount, quantity.Measure, target);

            RecipeDB.UpdateIngredientMeasure(recipeId, ingredient.Id, convertedAmount, target.Id);

        }

        /// <summary>
        /// Delete the category and remove it from the TreeView. Manage the deletion
        /// of a category containing children TreeElement by asking the user its intended
        /// action for the children : delete them or add them to the parent of the deleted
        /// category.
        /// </summary>
        /// <param name="category"></param>
        public static void Delete(RecipeCategory category)
        {

            if (category.Id <= 6)
            {
                MessagesManager.WarningMessage("You can't remove a base recipe category", MessageBoxButtons.OK);
                return;
            }

            TreeNode parent = category.Parent;
            TreeView treeView = category.TreeView;

            //Remove the category and its children from the TreeView
            if (parent != null)
                parent.Nodes.Remove(category);
            else
                treeView.Nodes.Remove(category);

            try
            {
                if (HasChildren(category))
                {
                    // Ask the user is intent about the children
                    DialogResult result = MessagesManager.QuestionMessage("Do you want to delete the children too ?",
                                                        "Yes - The children are deleted\r\n" +
                                                        "No - The children are added to the parent of the deleted" + "\r\n" +
                                                        "Cancel - The deletion is cancelled.",
                                                         MessageBoxButtons.YesNoCancel);

                    // Do as the user choosed
                    switch (result)
                    {
                        case DialogResult.Yes: // Delete all children using recursion

                            DeleteRecursive(category);
                            break;
                        case DialogResult.No: // Move the children to the parent

                            // Move each children of deleted category to the parent of the deleted category
                            foreach (TreeElement child in category.Nodes)
                            {
                                child.ParentId = category.ParentId;
                                child.NodeLevel = category.NodeLevel;

                                if (child.GetType() == typeof(RecipeCategory))
                                    RecipeDB.Update((RecipeCategory)child);
                                else if (child.GetType() == typeof(Recipe))
                                    RecipeDB.Update((Recipe)child);

                                if (parent != null)
                                    parent.Nodes.Add(child);
                                else
                                    treeView.Nodes.Add(child);

                                UpdateChildrenNodeLevel(child); // Update the nodelevels of the children
                            }

                            RecipeDB.Delete(category);

                            break;
                        default: // Cancel the action by adding back the category to the TreeView
                            if (parent != null)
                                parent.Nodes.Add(category);
                            else
                                treeView.Nodes.Add(category);
                            break;
                    }

                }
                else // If the category has no children then it is just deleted without question
                {
                    RecipeDB.Delete(category);
                }
            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
            }

        }

        /// <summary>
        /// This method uses recursion to delete the TreeElement parameter and all
        /// its children.
        /// </summary>
        /// <param name="element"></param>
        public static void DeleteRecursive(TreeElement element)
        {
            foreach (TreeElement children in element.Nodes)
            {
                DeleteRecursive(children);
            }

            if (element.GetType() == typeof(RecipeCategory))
                RecipeDB.Delete((RecipeCategory)element);
            else if (element.GetType() == typeof(Recipe))
                RecipeDB.Delete((Recipe)element);
        }

        /// <summary>
        /// Delete a recipe and remove it from the TreeView
        /// </summary>
        /// <param name="recipe"></param>
        public static void Delete(Recipe recipe)
        {

            try
            {              
                if(recipe.Parent != null)
                    recipe.Parent.Nodes.Remove(recipe);
                else
                    recipe.TreeView.Nodes.Remove(recipe);

                RecipeDB.Delete(recipe);
            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
            }
        }

        public static List<Tuple<Ingredient, Quantity>> GetIngredientsFor(Recipe recipe)
        {
            return RecipeDB.GetIngredientsFor(recipe);
        }

        public static List<Tuple<Ingredient, Quantity, int>> GetIngredients(Ingredient ingredient)
        {
            return RecipeDB.GetIngredients(ingredient);
        }


        /// <summary>
        /// This method checks whether a TreeElement has children or not.
        /// </summary>
        /// <param name="element"></param>
        /// <returns>True if it has children, false otherwise</returns>
        public static bool HasChildren(TreeElement element)
        {
            return element.Nodes.Count > 0;
        }

        /// <summary>
        /// This method update the node level of all the children of the 
        /// TreeElement parameter.
        /// </summary>
        /// <param name="parent"></param>
        public static void UpdateChildrenNodeLevel(TreeElement parent)
        {
            foreach (TreeElement child in parent.Nodes)
            {
                child.NodeLevel = parent.NodeLevel + 1;

                if (child.GetType() == typeof(RecipeCategory))
                    RecipeDB.Update((RecipeCategory)child);
                else if (child.GetType() == typeof(Recipe))
                    RecipeDB.Update((Recipe)child);

                UpdateChildrenNodeLevel(child);
            }
        }
    }
}
