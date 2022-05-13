using BLL;
using DTO;
using DTO.Interfaces;
using Serilog;

namespace UI.Plans
{

    /// <summary>
    /// This form allows the user to select meals 
    /// </summary>
    public partial class MealSelectionForm : Form
    {
        public Meal Meal { get; set; }

        /// <summary>
        /// This constructor initilaize the components and load the data.
        /// </summary>
        /// <param name="meal"></param>
        public MealSelectionForm(Meal meal)
        {
            InitializeComponent();

            Meal = meal;

            LoadData(meal.Recipes);
        }

        /// <summary>
        /// Load the recipe tree elements into the treeview and check all the recipes that 
        /// are already added to the selection.
        /// </summary>
        /// <param name="recipes"></param>
        private void LoadData(List<Recipe> recipes)
        {
            Log.Information("MealsSelectionControl - LoadData()");

            // Retreive all recipes
            TreeElement[]? treeElements = RecipesManager.GetTreeElements();

            // Checks the already selected recipes
            if (treeElements != null)
            {
                foreach (Recipe recipe in recipes)
                {
                    foreach (TreeElement element in treeElements)
                    {
                        element.Expand();

                        if (element is Recipe && element.Id == recipe.Id)
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

            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = checkValue;
                SwitchCheckRecursive(child, checkValue);
            }
        }

        /// <summary>
        /// This method returns the list of Recipes.
        /// </summary>
        /// <returns></returns>
        private List<Recipe> GetSelectedRecipes()
        {
            List<Recipe> recipes = new List<Recipe>();

            FillSelectedRecipeRecursive(recipes, treeView.Nodes);

            return recipes;
        }

        /// <summary>
        /// This method use recursion to fill the target list with all the recipes from the source collection.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        private void FillSelectedRecipeRecursive(List<Recipe> target, TreeNodeCollection source)
        {
            foreach (TreeNode node in source)
            {
                if (node.Checked && node is Recipe)
                    target.Add((Recipe)node);               

                FillSelectedRecipeRecursive(target, node.Nodes);
            }
        }


        /// <summary>
        /// This method is raised when the user click on the continue button.
        /// It retrives the recipes and put it in the meal and it will close this form with dialogresult continue. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonContinue_Click(object sender, EventArgs e)
        {
            Meal.Recipes = GetSelectedRecipes();

            DialogResult = DialogResult.Continue;
            Close();
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

