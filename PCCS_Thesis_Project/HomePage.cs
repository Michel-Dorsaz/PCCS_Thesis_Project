using Serilog;
using UI;
using UI.Ingredients;
using UI.Plans;
using UI.Recipes;

namespace PCCS_Thesis_Project
{
    /// <summary>
    /// Represents the first and main page of the application.
    /// </summary>
    public partial class HomePage : Form
    {

        private FormEdit? FormIngredients;
        private FormEdit? FormRecipes;
        private PlanSelectionPage? FormPlans;

        public HomePage()
        {         
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("logs\\serilog.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            Log.Information("Program started");
        }

        /// <summary>
        /// Open the ingredients' page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonIngredient_Click(object? sender, EventArgs e)
        {
            Log.Information("HomePage - Button ingredient clicked");

            labelInfo.Text = "";

            // If the form already exists, we just ensure it is displayed to the user.
            // Otherwise, the form is created.
            if (FormIngredients != null && !FormIngredients.IsDisposed)
            {
                if (FormIngredients.WindowState == FormWindowState.Minimized)
                    FormIngredients.WindowState = FormWindowState.Maximized;
                
                bool topSetting = FormIngredients.TopMost;
                FormIngredients.TopMost = true;
                FormIngredients.TopMost = topSetting;

                FormIngredients.Show();
            }               
            else
                FormIngredients = new FormEdit("Ingredients"); // The Show method is controlled by the instance  

            new IngredientsTreeviewControl(FormIngredients);  // The Show method is controlled by the instance           
        }

        /// <summary>
        /// Open the recipes' page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRecipe_Click(object sender, EventArgs e)
        {
            Log.Information("HomePage - Button recipe clicked");

            labelInfo.Text = "";

            // If the form already exists, we just ensure it is displayed to the user.
            // Otherwise, the form is created.
            if (FormRecipes != null && !FormRecipes.IsDisposed)
            {
                if (FormRecipes.WindowState == FormWindowState.Minimized)
                    FormRecipes.WindowState = FormWindowState.Maximized;

                bool topSetting = FormRecipes.TopMost;
                FormRecipes.TopMost = true;
                FormRecipes.TopMost = topSetting;

                FormRecipes.Show();
            }
            else
                FormRecipes = new FormEdit("Recipes"); // The Show method is controlled by the instance  

            new RecipesTreeviewControl(FormRecipes);  // The Show method is controlled by the instance 
        }

        private void ButtonPlans_Click(object sender, EventArgs e)
        {
            Log.Information("HomePage - Button plans clicked");

            labelInfo.Text = "";

            // If the form already exists, we just ensure it is displayed to the user.
            // Otherwise, the form is created.
            if (FormPlans != null && !FormPlans.IsDisposed)
            {
                if (FormPlans.WindowState == FormWindowState.Minimized)
                    FormPlans.WindowState = FormWindowState.Maximized;

                bool topSetting = FormPlans.TopMost;
                FormPlans.TopMost = true;
                FormPlans.TopMost = topSetting;

                FormPlans.Show();
            }
            else
                FormPlans = new PlanSelectionPage(); // The Show method is controlled by the instance  
        }
    }
}