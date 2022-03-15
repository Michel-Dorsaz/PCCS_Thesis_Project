using BLL;
using DTO;
using DTO.Interfaces;
using Serilog;

namespace UI.Recipes
{

    /// <summary>
    /// This Form is used to select one or many ingredients.
    /// </summary>
    public partial class IngredientsSelectionForm : Form
    {
        public List<Tuple<Ingredient, Quantity>> Ingredients { get; set; }

        public IngredientsSelectionForm(List<Tuple<Ingredient, Quantity>> ingredients)
        {
            InitializeComponent();
            LoadData(ingredients);

            Ingredients = ingredients;
        }

        private void LoadData(List<Tuple<Ingredient, Quantity>> ingredients)
        {
            Log.Information("IngredientsSelectionControl - LoadData()");

            // Retreive all ingredients
            TreeElement[]? treeElements = IngredientsManager.GetTreeElements();

            // Checks the already selected ingredients
            if(treeElements != null)
            {
                foreach (Tuple<Ingredient, Quantity> tuple in ingredients)
                {
                    foreach (TreeElement element in treeElements)
                    {
                        element.Expand();

                        if (element is Ingredient && element.Id == tuple.Item1.Id)
                            element.Checked = true;                    
                    }                  
                }
            }

            new TreeManager(treeView).SetTreeElements(treeElements);

            treeView.AfterCheck += new TreeViewEventHandler(TreeView_AfterCheck);
        }

        /// <summary>
        /// This method is fired by a check of an element. If the element is a Category,
        /// It will check on cascade the child of this category, which allow easy multiple
        /// selection/unselection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView_AfterCheck(object? sender, TreeViewEventArgs e)
        {
            if (e.Node is ICategory)
            {
                // Has this method change the checked property it will fire itself if the
                // event handler is not disabled during the process.
                treeView.AfterCheck -= new TreeViewEventHandler(TreeView_AfterCheck);
                SwitchCheckRecursive(e.Node, e.Node.Checked);
                treeView.AfterCheck += new TreeViewEventHandler(TreeView_AfterCheck);
            }             
        }

        /// <summary>
        /// This method will apply the check value to all the children of the node parameter
        /// </summary>
        /// <param name="node"></param>
        /// <param name="checkValue"></param>
        private void SwitchCheckRecursive(TreeNode node, bool checkValue)
        {
            node.Expand();

            foreach(TreeNode child in node.Nodes)
            {
                child.Checked = checkValue;
                SwitchCheckRecursive(child, checkValue);
            }
        }

        /// <summary>
        /// This method returns the list of Ingredients and their quantities.
        /// </summary>
        /// <returns></returns>
        private List<Tuple<Ingredient, Quantity>> GetSelectedIngredients()
        {
            List<Tuple<Ingredient, Quantity>> ingredients = new List<Tuple<Ingredient, Quantity>>();

            FillSelectedIngredientRecursive(ingredients, treeView.Nodes);

            return ingredients;
        }

        /// <summary>
        /// This method use recursion to fill the target list with all the ingredients and their quantities from the source collection.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        private void FillSelectedIngredientRecursive(List<Tuple<Ingredient, Quantity>> target, TreeNodeCollection source)
        {
            foreach (TreeNode node in source)
            {
                if (node.Checked && node is Ingredient)
                {
                    Ingredient ingredient = (Ingredient) node;
                    Quantity? quantity = GetQuantityFromIngredients(Ingredients, ingredient);

                    if(quantity == null)
                    {
                        Measure? measure = QuantitiesManager.GetBaseMeasureFor(ingredient.QuantityTypeId);
                        if (measure == null)
                            measure = new Measure(-1, "g", 1, 1);
                            quantity = new Quantity(1, measure);

                    }

                    target.Add(new Tuple<Ingredient, Quantity>(ingredient, quantity));
                }
                   
                FillSelectedIngredientRecursive(target, node.Nodes);
            }
        }

        /// <summary>
        /// This method retrive the quantity of a target ingredient inside the list of pairs ingredient-quantity.
        /// </summary>
        /// <param name="ingredients"></param>
        /// <param name="target"></param>
        /// <returns>Quantity or null</returns>
        private Quantity? GetQuantityFromIngredients(List<Tuple<Ingredient, Quantity>> ingredients, Ingredient target)
        {
            foreach(Tuple<Ingredient, Quantity> ingredient in ingredients)
            {
                if (target.Id == ingredient.Item1.Id)
                    return ingredient.Item2;
            }

            return null;
        }

        /// <summary>
        /// This method is raised when the user click on the continue button.
        /// It will retreive the selected ingredients and display the quantity selection form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonContinue_Click(object sender, EventArgs e)
        {
            Ingredients = GetSelectedIngredients();

            // If nothing selected, no need to display quantity selection
            if(Ingredients.Count == 0)
            {
                DialogResult = DialogResult.Continue;
                Close();
                return;
            }

            using (QuantitiesSelectionForm quantitySelectionPage = new QuantitiesSelectionForm(Ingredients))
            {
                if (quantitySelectionPage.ShowDialog() == DialogResult.Continue)
                {
                    Ingredients = quantitySelectionPage.Ingredients;
                    DialogResult = DialogResult.Continue;
                    Close();
                }
            }        
        }

        /// <summary>
        /// This method is raised when the user click on the cancel button.
        /// It will close this form with dialogresult cancel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
