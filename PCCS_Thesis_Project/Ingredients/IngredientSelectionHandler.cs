using DTO;

namespace UI.Ingredients
{
    /// <summary>
    /// This class handle the selection of the ingredient TreeView.
    /// It displays the selected data into a panel according to the
    /// type of the data : Ingredient or Ingredient's category.
    /// <para />
    /// This class is also responsible to update and save the managed data.
    /// </summary>
    public class IngredientSelectionHandler : ISelection
    {
        public IngredientControl IngredientControl { get; set; } // UserControl for ingredients
        public IngredientCategoryControl IngredientCategoryControl { get; set; } // UserControl for ingredient's category
        private ISelection CurrentSelection; // The actual UserControl displayed

        public IngredientsTreeviewControl TreeView { get; set; }
        private Panel Panel;
        private Label InfoLabel;

        /// <summary>
        /// Create the Ingredient and Ingredient's category userControl, initiate the CurrentSelection as
        /// Empty and add the selection to the panel.
        /// </summary>
        /// <param name="treeview"></param>
        /// <param name="panel"></param>
        /// <param name="infoLabel"></param>
        public IngredientSelectionHandler(IngredientsTreeviewControl treeview, Panel panel, Label infoLabel)
        {          
            TreeView = treeview;
            Panel = panel;
            InfoLabel = infoLabel;

            CurrentSelection = new EmptyIngredientSelection(this);
            IngredientControl = new IngredientControl(this, infoLabel);
            IngredientCategoryControl = new IngredientCategoryControl(this, infoLabel);            
        }

        /// <summary>
        /// Raise the Save method of the current selection
        /// </summary>
        public void Save()
        {
            CurrentSelection.Save();
        }

        /// <summary>
        /// Raise the Update method of the current selection
        /// </summary>
        /// <param name="node"></param>
        public void Update(TreeElement node)
        {
            CurrentSelection.Update(node);
        }

        /// <summary>
        /// Replace the current selection with another.
        /// </summary>
        /// <param name="oldForm"></param>
        /// <param name="newForm"></param>
        public void Set(UserControl? oldForm, UserControl newForm)
        {
            // Check the type of the new selection
            if (newForm.GetType() == typeof(IngredientControl))
                CurrentSelection = IngredientControl;
            else if (newForm.GetType() == typeof(IngredientCategoryControl))
                CurrentSelection = IngredientCategoryControl;
            else
                return;

            // Replace the content of the panel with the new selection
            Panel.Controls.Clear();
            Panel.Controls.Add(newForm);
            newForm.Show();

            // Hide previous selection if exist
            if(oldForm != null)
                oldForm.Hide();
        }
    }
}

