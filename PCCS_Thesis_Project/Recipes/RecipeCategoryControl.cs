using BLL;
using DTO;

namespace UI.Recipes
{
    /// <summary>
    /// Implements the selection of a recipe's category. This UserControl display
    /// the data of a category and allow the user to edit it.
    /// </summary>
    public partial class RecipeCategoryControl : UserControl, ISelection
    {
        private RecipeCategory CurrentCategory; // The current displayed recipe

        private RecipeSelectionHandler SelectionHandler; // The selection handler to which this class belongs 
        private Label InfoLabel;

        public RecipeCategoryControl(RecipeSelectionHandler selectionHandler, Label infoLabel)
        {
            InitializeComponent();

            SelectionHandler = selectionHandler;
            InfoLabel = infoLabel;

            CurrentCategory = new RecipeCategory();

            Dock = DockStyle.Fill;

            /*
             * Supress the windows sound when pressing the enter key. The sound
             * is due to input boxes not being multi-line, thus the program trigger a
             * warning sound on return key as no additional line is allowed. The sound is
             * removed because it is not clear for the user what it means.
             */
            textBoxName.KeyDown += new KeyEventHandler(KeyEventHandler);

        }


        /// <summary>
        /// Update all the field into the current selection and save it to the DB.
        /// <para/>
        /// Raise the UpdateCurrentNode method of the selection handler to update the TreeView
        /// </summary>
        public void Save()
        {
            CurrentCategory.Name = textBoxName.Text;
            CurrentCategory.Text = CurrentCategory.Name + " (WPP: " + CurrentCategory.WPP + ")";
            CurrentCategory.WPP = (int) numericUpDownWPP.Value;
            RecipesManager.Save(CurrentCategory);
            SelectionHandler.TreeView.UpdateCurrentNode(CurrentCategory);
        }

        /// <summary>
        /// Update the current selection with a new recipe.
        /// </summary>
        /// <param name="node"></param>
        public void Update(TreeElement node)
        {
            // Only update if the new element is an recipe's category.
            // Otherwise it modify the selection and let the selection handler
            // manage the update of the new selection.
            if (node.GetType() == typeof(RecipeCategory))
            {
                RecipeCategory category = (RecipeCategory) node;
                CurrentCategory = category;

                textBoxName.Text = category.Name;
                labelCategoryText.Text = category.GetNodePath(node.Parent);
                numericUpDownWPP.Value = category.WPP;
            }
            else if (node.GetType() == typeof(Recipe))
            {
                SelectionHandler.Set(this, SelectionHandler.RecipeControl);
                SelectionHandler.Update(node);
            }
        }

        /// <summary>
        /// When the name is changed, it modifies the treeView's node at the same
        /// time. 
        /// <para />
        /// The Save method is not triggered upon text modification. The Save occurs
        /// only when the selection changes to improves performance.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxName_TextChanged(object? sender, EventArgs e)
        {
            SelectionHandler.TreeView.UpdateCurrentNodeText(textBoxName.Text + " (WPP : " + numericUpDownWPP.Value + ")");
        }

        /// <summary>
        /// Supress the windows sound when pressing the enter key. The sound
        /// is due to input boxes not being multi-line, thus the program trigger a
        /// warning sound on return key as no additional line is allowed. The sound is
        /// removed because it is not clear for the user what it means.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void KeyEventHandler(object? sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Return)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            };
        }

        /// <summary>
        /// When the WPP is changed, it modifies the treeView's node at the same
        /// time. 
        /// <para />
        /// The Save method is not triggered upon text modification. The Save occurs
        /// only when the selection changes to improves performance.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDownWPP_ValueChanged(object sender, EventArgs e)
        {
            SelectionHandler.TreeView.UpdateCurrentNodeText(textBoxName.Text + " (WPP : " + numericUpDownWPP.Value + ")");
        }
    }
}
