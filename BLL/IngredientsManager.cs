using DAL;
using DTO;

namespace BLL
{
    /// <summary>
    /// This class is the Business logic layer for ingredients and their categories.
    /// </summary>
    public static class IngredientsManager
    {

        /// <summary>
        /// Get all the ingredients and categories into a TreeElement array. The elements are not sorted. The
        /// array contains the root element with a nodelevel of -1.
        /// <para />
        /// If an error happens it returns null and display a warning message.
        /// </summary>
        /// <returns></returns>
        public static TreeElement[]? GetTreeElements()
        {       
            try
            {
                List<Ingredient> ingredients = IngredientDB.GetAllIngredients();
                List<IngredientCategory> categories = IngredientDB.GetAllCategories();

                TreeElement[] treeElements = new TreeElement[ingredients.Count + categories.Count];
                int index = 0;

                foreach (Ingredient ingredient in ingredients)
                    treeElements[index++] = ingredient;

                foreach (IngredientCategory category in categories)
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
        public static void Save(IngredientCategory category)
        {
            try
            {
                if (category.Id == -1)
                    IngredientDB.Insert(category);
                else
                    IngredientDB.Update(category);
            }
            catch(Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
            }

            
        }

        /// <summary>
        /// Save the new ingredient in the DB or update it if it already exists.
        /// </summary>
        /// <param name="ingredient"></param>
        public static void Save(Ingredient ingredient)
        {

            try
            {
                if (ingredient.Id == -1)
                    IngredientDB.Insert(ingredient);
                else
                    IngredientDB.Update(ingredient);
            } 
            catch(Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
            }
            
        }

        /// <summary>
        /// Delete the category and remove it from the TreeView. Manage the deletion
        /// of a category containing children TreeElement by asking the user its intended
        /// action for the children : delete them or add them to the parent of the deleted
        /// category.
        /// </summary>
        /// <param name="category"></param>
        public static void Delete(IngredientCategory category)
        {

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

                                if (child.GetType() == typeof(IngredientCategory))
                                    IngredientDB.Update((IngredientCategory) child);
                                else if (child.GetType() == typeof(Ingredient))
                                    IngredientDB.Update((Ingredient) child);

                                if (parent != null)
                                    parent.Nodes.Add(child);
                                else
                                    treeView.Nodes.Add(child);

                                UpdateChildrenNodeLevel(child); // Update the nodelevels of the children
                            }

                            IngredientDB.Delete(category);

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
                    IngredientDB.Delete(category);
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
            foreach(TreeElement children in element.Nodes)
            {             
                DeleteRecursive(children);               
            }

            if (element.GetType() == typeof(IngredientCategory))
                Delete((IngredientCategory)element);
            else if (element.GetType() == typeof(Ingredient))
                Delete((Ingredient)element);
        }

        /// <summary>
        /// Delete an ingredient and remove it from the TreeView
        /// </summary>
        /// <param name="ingredient"></param>
        public static void Delete(Ingredient ingredient)
        {
            try
            {
                if (ingredient.Parent != null)
                    ingredient.Parent.Nodes.Remove(ingredient);
                else
                    ingredient.TreeView.Nodes.Remove(ingredient);

                IngredientDB.Delete(ingredient);
            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// This method checks wheter a TreeElement has children or not.
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
            foreach(TreeElement child in parent.Nodes)
            {
                child.NodeLevel = parent.NodeLevel + 1;

                if (child.GetType() == typeof(IngredientCategory))
                    IngredientDB.Update((IngredientCategory)child);
                else if(child.GetType() == typeof(Ingredient))
                    IngredientDB.Update((Ingredient) child);

                UpdateChildrenNodeLevel(child);
            }
        }
    }
}
