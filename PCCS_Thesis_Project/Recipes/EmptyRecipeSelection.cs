using DTO;

namespace UI.Recipes
{
    /// <summary>
    /// Implements an empty selection. This UserControl manage the action when nothing is selected.
    /// </summary>
    public class EmptyRecipeSelection : ISelection
    {

        private RecipeSelectionHandler SelectionHandler; // The selection handler to which this class belongs 

        public EmptyRecipeSelection(RecipeSelectionHandler selectionHandler)
        {
            SelectionHandler = selectionHandler;
        }

        /// <summary>
        /// When there is no selection, the Save method do nothing
        /// </summary>
        public void Save()
        {
            return;
        }

        /// <summary>
        /// Update the current selection with the corresponding UserControl.
        /// </summary>
        /// <param name="node"></param>
        public void Update(TreeElement node)
        {
            if (node.GetType() == typeof(Recipe))
            {
                SelectionHandler.Set(null, SelectionHandler.RecipeControl);
                SelectionHandler.Update(node);
            }
            else if (node.GetType() == typeof(RecipeCategory))
            {
                SelectionHandler.Set(null, SelectionHandler.RecipeCategoryControl);
                SelectionHandler.Update(node);
            }
        }
    }
}
