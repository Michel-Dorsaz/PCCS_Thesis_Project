using BLL;
using DTO;
using Serilog;

namespace UI.Recipes
{
    /// <summary>
    /// Implements the selection of a recipe. This UserControl display
    /// the data of a recipe and allow the user to edit it.
    /// </summary>
    public partial class RecipeControl : UserControl, ISelection
    {
        private Recipe CurrentRecipe; // The current displayed recipe
        private List<Tuple<Ingredient, Quantity>> Ingredients; // The ingredients in the current recipe

        private RecipeSelectionHandler SelectionHandler; // The selection handler to which this class belongs 
        private Label InfoLabel;

        public RecipeControl(RecipeSelectionHandler selectionHandler, Label infoLabel)
        {
            InitializeComponent();

            SelectionHandler = selectionHandler;
            CurrentRecipe = new Recipe();
            Ingredients = new List<Tuple<Ingredient, Quantity>>();
            InfoLabel = infoLabel;

            richTextBoxIngredients.AllowDrop = true;

            Dock = DockStyle.Fill;

            /*
             * Supress the windows sound when pressing the enter key. The sound
             * is due to input boxes not being multi-line, thus the program trigger a
             * warning sound on return key as no additional line is allowed. The sound is
             * removed because it is not clear for the user what it means.
             */
            textBoxName.KeyDown += new KeyEventHandler(KeyEventHandler);
            numericUpDownWPP.KeyDown += new KeyEventHandler(KeyEventHandler);

            richTextBoxIngredients.Click += new EventHandler(Ingredients_OnClick);
        }

        /// <summary>
        /// Update all the field into the current selection and save it to the DB.
        /// <para/>
        /// Raise the UpdateCurrentNode method of the selection handler to update the TreeView
        /// </summary>
        public void Save()
        {
            CurrentRecipe.Name = textBoxName.Text;
            CurrentRecipe.Text = CurrentRecipe.Name + " (WPP: " + CurrentRecipe.WPP + ")";
            CurrentRecipe.WPP = (int) numericUpDownWPP.Value;

            RecipesManager.Save(CurrentRecipe, Ingredients);

            SelectionHandler.TreeView.UpdateCurrentNode(CurrentRecipe);
        }

        /// <summary>
        /// Update the current selection with a new recipe.
        /// </summary>
        /// <param name="node"></param>
        public void Update(TreeElement node)
        {
            // Only update if the new element is an recipe.
            // Otherwise it modify the selection and let the selection handler
            // manage the update of the new selection.
            if (node.GetType() == typeof(Recipe))
            {

                Recipe recipe = (Recipe) node;
                CurrentRecipe = recipe;

                Ingredients = RecipesManager.GetIngredientsFor(recipe);

                if(Ingredients.Count == 0)
                    richTextBoxIngredients.Text = "Click here to add ingredients !";
                else
                {
                    richTextBoxIngredients.Text = "";
                    foreach (Tuple<Ingredient, Quantity> tuple in Ingredients)
                    {
                        richTextBoxIngredients.Text += tuple.Item2.Amount + tuple.Item2.Measure.Name + " " + tuple.Item1.Text + "\r\n";
                    }
                }              

                textBoxName.Text = recipe.Name;
                labelCategoryText.Text = recipe.GetNodePath(node.Parent);
                numericUpDownWPP.Value = recipe.WPP;

            }
            else if (node.GetType() == typeof(RecipeCategory))
            {
                SelectionHandler.Set(this, SelectionHandler.RecipeCategoryControl);
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
        private void KeyEventHandler(object? sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Return)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
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

        /// <summary>
        /// This method is raised when the user click on the ingredients richtextbox.
        /// It open a ingredients selection form for the user to select the wanted ingredients to be 
        /// added.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ingredients_OnClick(object? sender, EventArgs e)
        {
            Log.Information("RecipeControl - Ingredients selection clicked");

            using (IngredientsSelectionForm ingredientSelectionPage = new IngredientsSelectionForm(Ingredients))
            {
                if (ingredientSelectionPage.ShowDialog() == DialogResult.Continue)
                    SetIngredients(ingredientSelectionPage.Ingredients);
            }
        }

        /// <summary>
        /// Add all the element from the list of pairs Ingredient-Quantity.
        /// </summary>
        /// <param name="ingredients"></param>
        private void SetIngredients(List<Tuple<Ingredient, Quantity>> ingredients)
        {

            if(ingredients.Count == 0)
            {
                richTextBoxIngredients.Text = "Click here to add ingredients !";
                Ingredients = new List<Tuple<Ingredient, Quantity>>();
                return;
            }

            // Clear the textBox
            richTextBoxIngredients.Text = "";

            // Update the current recipes' ingredients
            for(int i = 0; i < Ingredients.Count; i++)
            {
                Ingredient existingIngredient = Ingredients[i].Item1;

                for (int j = 0; j < ingredients.Count; j++)
                {
                    if (existingIngredient.Id == ingredients[j].Item1.Id)
                    {
                        ingredients.Remove(ingredients[j]);
                        j--;
                    }                     
                }
            }

            Ingredients.AddRange(ingredients);

            // Update the textBox
            foreach (Tuple<Ingredient, Quantity> tuple in Ingredients)
            {
                richTextBoxIngredients.Text += tuple.Item2.Amount + tuple.Item2.Measure.Name + " " + tuple.Item1.Text + "\r\n";
            }
        }
    }
}
