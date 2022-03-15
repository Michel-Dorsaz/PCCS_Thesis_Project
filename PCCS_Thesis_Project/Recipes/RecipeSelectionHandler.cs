using DTO;

namespace UI.Recipes
{
    /// <summary>
    /// This class handle the selection of the recipe TreeView.
    /// It displays the selected data into a panel according to the
    /// type of the data : Recipe or Recipe's category.
    /// <para />
    /// This class is also responsible to update and save the managed data.
    /// </summary>
    public class RecipeSelectionHandler : ISelection
    {
        public RecipeControl RecipeControl { get; set; } // UserControl for recipes
        public RecipeCategoryControl RecipeCategoryControl { get; set; } // UserControl for recipe's category
        private ISelection CurrentSelection; // The actual UserControl displayed

        public RecipesTreeviewControl TreeView { get; set; }
        private Panel Panel;
        private Label InfoLabel;

        /// <summary>
        /// Create the Recipe and Recipe's category userControl, initiate the CurrentSelection as
        /// Empty and add the selection to the panel.
        /// </summary>
        /// <param name="treeview"></param>
        /// <param name="panel"></param>
        /// <param name="infoLabel"></param>
        public RecipeSelectionHandler(RecipesTreeviewControl treeview, Panel panel, Label infoLabel)
        {
            TreeView = treeview;
            Panel = panel;
            InfoLabel = infoLabel;

            CurrentSelection = new EmptyRecipeSelection(this);
            RecipeControl = new RecipeControl(this, infoLabel);
            RecipeCategoryControl = new RecipeCategoryControl(this, infoLabel);
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
            if (newForm.GetType() == typeof(RecipeControl))
                CurrentSelection = RecipeControl;
            else if (newForm.GetType() == typeof(RecipeCategoryControl))
                CurrentSelection = RecipeCategoryControl;
            else
                return;

            // Replace the content of the panel with the new selection
            Panel.Controls.Clear();
            Panel.Controls.Add(newForm);
            newForm.Show();

            // Hide previous selection if exist
            if (oldForm != null)
                oldForm.Hide();
        }
    }
}

