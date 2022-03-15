using BLL;
using DTO;

namespace UI.Ingredients
{
    /// <summary>
    /// Implements the selection of an ingredient. This UserControl display
    /// the data of an ingredient and allow the user to edit it.
    /// </summary>
    public partial class IngredientControl : UserControl, ISelection
    {
        private Ingredient CurrentIngredient; // The current displayed ingredient

        private IngredientSelectionHandler SelectionHandler; // The selection handler to which this class belongs 
        private Label InfoLabel;

        public IngredientControl(IngredientSelectionHandler selectionHandler, Label infoLabel)
        {
            InitializeComponent();

            SelectionHandler = selectionHandler;
            CurrentIngredient = new Ingredient();
            InfoLabel = infoLabel;

            Dock = DockStyle.Fill;

            comboBoxQuantityType.DataSource = QuantitiesManager.GetAllQuantityTypes();

            /*
             * Supress the windows sound when pressing the enter key. The sound
             * is due to input boxes not being multi-line, thus the program trigger a
             * warning sound on return key as no additional line is allowed. The sound is
             * removed because it is not clear for the user what it means.
             */
            textBoxName.KeyDown += new KeyEventHandler(KeyEventHandler);
            numericUpDownGlucid.KeyDown += new KeyEventHandler(KeyEventHandler);
            numericUpDownLipid.KeyDown += new KeyEventHandler(KeyEventHandler);
            numericUpDownProtein.KeyDown += new KeyEventHandler(KeyEventHandler);
            comboBoxQuantityType.KeyDown += new KeyEventHandler(KeyEventHandler);
        }

        /// <summary>
        /// Update all the field into the current selection and save it to the DB.
        /// <para/>
        /// Raise the UpdateCurrentNode method of the selection handler to update the TreeView
        /// </summary>
        public void Save()
        {
            CurrentIngredient.Text = textBoxName.Text;
            CurrentIngredient.Glucid = (int)numericUpDownGlucid.Value;
            CurrentIngredient.Lipid = (int)numericUpDownLipid.Value;
            CurrentIngredient.Protein = (int)numericUpDownProtein.Value;
            CurrentIngredient.QuantityTypeId = ((QuantityType) comboBoxQuantityType.SelectedItem).Id;

            IngredientsManager.Save(CurrentIngredient);
            SelectionHandler.TreeView.UpdateCurrentNode(CurrentIngredient);
        }

        /// <summary>
        /// Update the current selection with a new ingredient.
        /// </summary>
        /// <param name="node"></param>
        public void Update(TreeElement node)
        {
            // Only update if the new element is an ingredient.
            // Otherwise it modify the selection and let the selection handler
            // manage the update of the new selection.
            if (node.GetType() == typeof(Ingredient))
            {

                Ingredient ingredient = (Ingredient) node;
                CurrentIngredient = ingredient;

                textBoxName.Text = ingredient.Text;
                labelCategoryText.Text = ingredient.GetNodePath(node.Parent);
                numericUpDownLipid.Value = ingredient.Lipid;
                numericUpDownGlucid.Value = ingredient.Glucid;
                numericUpDownProtein.Value = ingredient.Protein;
                comboBoxQuantityType.SelectedItem = QuantitiesManager.GetQuantityTypeById(ingredient.QuantityTypeId);
            }
            else if (node.GetType() == typeof(IngredientCategory))
            {
                SelectionHandler.Set(this, SelectionHandler.IngredientCategoryControl);
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
        private void KeyEventHandler(object? sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char) Keys.Return)
            { 
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
