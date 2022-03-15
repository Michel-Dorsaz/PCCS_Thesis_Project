using DTO;

namespace UI.Ingredients
{
    /// <summary>
    /// Implements an empty selection. This UserControl manage the action when nothing is selected.
    /// </summary>
    public class EmptyIngredientSelection : ISelection
    {

        private IngredientSelectionHandler SelectionHandler; // The selection handler to which this class belongs 

        public EmptyIngredientSelection(IngredientSelectionHandler selectionHandler)
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
            if (node.GetType() == typeof(Ingredient))
            {
                SelectionHandler.Set(null, SelectionHandler.IngredientControl);
                SelectionHandler.Update(node);
            }
            else if (node.GetType() == typeof(IngredientCategory))
            {
                SelectionHandler.Set(null, SelectionHandler.IngredientCategoryControl);
                SelectionHandler.Update(node);
            }
        }
    }
}
