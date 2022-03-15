using BLL;
using DTO;

namespace UI.Ingredients
{
    /// <summary>
    /// Implements the selection of an ingredient's category. This UserControl display
    /// the data of a category and allow the user to edit it.
    /// </summary>
    public partial class IngredientCategoryControl : UserControl, ISelection
    {
        private IngredientCategory CurrentCategory; // The current displayed ingredient

        private IngredientSelectionHandler SelectionHandler; // The selection handler to which this class belongs 
        private Label InfoLabel;

        public IngredientCategoryControl(IngredientSelectionHandler selectionHandler, Label infoLabel)
        {
            InitializeComponent();

            SelectionHandler = selectionHandler;
            InfoLabel = infoLabel;

            CurrentCategory = new IngredientCategory();
            
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
            CurrentCategory.Text = textBoxName.Text;

            IngredientsManager.Save(CurrentCategory);
            SelectionHandler.TreeView.UpdateCurrentNode(CurrentCategory);
        }

        /// <summary>
        /// Update the current selection with a new ingredient.
        /// </summary>
        /// <param name="node"></param>
        public void Update(TreeElement node)
        {
            // Only update if the new element is an ingredient's category.
            // Otherwise it modify the selection and let the selection handler
            // manage the update of the new selection.
            if (node.GetType() == typeof(IngredientCategory))
            {
                IngredientCategory category = (IngredientCategory) node;
                CurrentCategory = category;

                textBoxName.Text = category.Text;
                labelCategoryText.Text = category.GetNodePath(node.Parent);

            }
            else if (node.GetType() == typeof(Ingredient))
            {
                SelectionHandler.Set(this, SelectionHandler.IngredientControl);
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
            SelectionHandler.TreeView.UpdateCurrentNodeText(textBoxName.Text);
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
    } 
}
