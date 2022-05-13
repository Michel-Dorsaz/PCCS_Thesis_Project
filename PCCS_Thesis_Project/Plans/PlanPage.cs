using BLL;
using DTO;
using DTO.Interfaces;
using Serilog;

namespace UI.Plans
{

    /// <summary>
    /// This form represent a page for creation of a menu plan.
    /// </summary>
    public partial class PlanPage : Form
    {

        public MenusPlan Plan { get; set; }
        public DayUnit[]? DayUnitList { get; set; }

        /// <summary>
        /// Business rule for the minimum time between a meal appears again in the plan.
        /// </summary>
        private const int DAY_BETWEEN_SAME_MEALS = 7;
        
        private int SelectionStartIndex { get; set; } // The index of the first of the days displayed in the week table.

        // This multi-dimensional array represents the corresponding labels added to the gridview.
        // We can easily access and modify the gridview by accessing the label at the same position in 
        // this matrix than in the grid column and row.
        private Label[,] MealTable { get; set; }

        /// <summary>
        /// This constructor initialize the components and load the data.
        /// </summary>
        /// <param name="plan"></param>
        public PlanPage(MenusPlan plan)
        {
            InitializeComponent();

            Plan = plan;
            SelectionStartIndex = 0;


            // Initialize the meal table with empty labels

            MealTable = new Label[8, plan.DayModel.MealModels.Count+1];

            for (int row = 0; row < 8; row++)
            {
                Label dayLabel = new Label()
                {
                    Text = "",
                    Font = new Font(this.Font, FontStyle.Bold),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.SandyBrown
                };

                MealTable[row, 0] = dayLabel;

                for (int col = 1; col < plan.DayModel.MealModels.Count+1; col++)
                {
                    Label label = new MealLabel()
                    {
                        Text = "",
                        Font = new Font(this.Font, FontStyle.Bold),
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.White,
                        ForeColor = SystemColors.HotTrack
                    };

                    label.Font = new Font("Bradley Hand ITC", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);

                    label.Click += new EventHandler(Label_Click);
                    label.MouseHover += new EventHandler(Label_MouseHover);
                    label.MouseLeave += new EventHandler(Label_MouseLeave);

                    MealTable[row, col] = label;
                }
            }

            SetupMealTable(plan);          

            LoadData(plan);
        }

        /// <summary>
        /// Get all the day units for the corresponding plan and set them in the schedule
        /// </summary>
        /// <param name="plan"></param>
        private void LoadData(MenusPlan plan)
        {            
            DayUnitList = MenusPlansManager.GetDayUnits(plan);

            SetupScheduleList(DayUnitList);

            SetSelection(SelectionStartIndex);
        }


        /// <summary>
        /// Modify the displayed days selection to start at the parameters start index.
        /// </summary>
        /// <param name="selectionStartIndex"></param>
        private void SetSelection(int selectionStartIndex)
        {
            if (DayUnitList == null)
                return;

            // The selection display 7 days. If the selected days would be over the
            // plan end date, then the selection is set up to display the last 7 days of the plan.
            if (SelectionStartIndex + 7 >= DayUnitList.Length)
            {
                SelectionStartIndex = DayUnitList.Length - 7;
                selectionStartIndex = DayUnitList.Length - 7;
            }       
            
            // If the selection is setup to start before the start day, then the selection is set up to
            // display from the first day instead.
            if (SelectionStartIndex < 0)
            {
                SelectionStartIndex = 0;
                selectionStartIndex = 0;
            }

            /*
             * It is very important to first check if the selection over extend the end date and THEN if it happens
             * before the first day.
             * That way, it the plan has less than 7 days, the selection will over extend the end date so the selection will 
             * be set up to start at selectionStart-7 which whill be before the start date ! So we need now to check that it is
             * before the start date and set it at the first day instead !
            */


            SetupDaysOfWeek(DayUnitList, selectionStartIndex);

            SetupMeals(Plan, DayUnitList, selectionStartIndex);


            // Setup the schedule list to make the selected days appears as solid black 
            // and the other days as light gray.

            listViewSchedule.SelectedItems.Clear();

            for (int i = 0; i < listViewSchedule.Items.Count; i++)
            {
                listViewSchedule.Items[i].ForeColor = Color.LightGray;
            }

            for (int i = 0; i < 7; i++)
            {
                int index = selectionStartIndex + i;

                if (index >= listViewSchedule.Items.Count)
                    return;

                listViewSchedule.Items[index].ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// This method add each day of the parameter array to the schedule list as ShortDateString.
        /// </summary>
        /// <param name="dayUnitList"></param>
        private void SetupScheduleList(DayUnit[]? dayUnitList)
        {
            ListView schedule = listViewSchedule;
            schedule.View = View.Tile;

            if (dayUnitList == null)
                return;

            foreach (DayUnit day in dayUnitList)
            {
                schedule.Items.Add(day.Date.DayOfWeek + " " + day.Date.ToShortDateString());
            }
            
        }

        /// <summary>
        /// This method build the meal table with 8 rows (title + 7days) and a column for
        /// each meals according to the plan mealsmodel.
        /// </summary>
        /// <param name="plan"></param>
        private void SetupMealTable(MenusPlan plan)
        {
            // Table layout setup
            int nbColumns = plan.DayModel.MealModels.Count + 2;
            int nbRows = 8;

            TableLayoutPanel panel = tableLayoutPanelWeekSchedule;

            panel.Controls.Clear();

            panel.ColumnCount = nbColumns;
            panel.RowCount = nbRows;
            panel.ColumnStyles.RemoveAt(0);

            for (int i = 0; i < nbColumns; i++)
            {
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / nbColumns));
            }

            for (int i = 0; i < nbRows; i++)
            {
                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F / 8));
            }


            // Add buttons
            panel.Controls.Add(buttonUp, 0, 0);
            panel.Controls.Add(buttonDown, 0, 8);

            // Add meals titles
            for (int i = 0; i < plan.DayModel.MealModels.Count; i++)
            {
                panel.Controls.Add(new Label()
                {
                    Text = plan.DayModel.MealModels[i].Name,
                    Font = new Font(this.Font, FontStyle.Bold),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.SandyBrown
                }, i + 1, 0); 
            }

            // Add days label
            for (int i = 1; i <= 7; i++)
            {
                panel.Controls.Add(MealTable[i,0], 0, i);
            }

            // Add meals labels
            for (int row = 1; row < 8; row++)
            {
                for (int col = 1; col < plan.DayModel.MealModels.Count+1; col++)
                {
                    panel.Controls.Add(MealTable[row, col], col, row);
                }
            }
            
        }

        /// <summary>
        /// This method modify the labels of the days of week column from the meal table
        /// to correspond to the selected day for display.
        /// </summary>
        /// <param name="dayUnitList"></param>
        /// <param name="selectionStartIndex"></param>
        public void SetupDaysOfWeek(DayUnit[] dayUnitList, int selectionStartIndex)
        {

            int dayIndex = selectionStartIndex;           

            for (int i = 1; i <= 7; i++)
            {
                Label label = MealTable[i, 0];

                if (dayIndex < dayUnitList.Length)
                    label.Text = dayUnitList[dayIndex].Date.DayOfWeek.ToString();
                else
                    label.Text = "";

                dayIndex++;
            }
        }

        /// <summary>
        /// This method set up the labels of the meal table to correspond to the meals of the
        /// plan. A custom label is used to store its position in the matrice that are used when the label is clicked.
        /// </summary>
        /// <param name="plan"></param>
        /// <param name="dayUnits"></param>
        /// <param name="selectionStartIndex"></param>
        public void SetupMeals(MenusPlan plan, DayUnit[] dayUnits, int selectionStartIndex)
        {

            for (int day = 0; day < 7; day++) // Rows
            {
                int dayIndex = selectionStartIndex + day;

                if (dayIndex >= DayUnitList.Length)
                    return;

                for (int mealIndex = 0; mealIndex < plan.DayModel.MealModels.Count; mealIndex++) // Columns
                {
                    string title = "";            

                    if (dayIndex < dayUnits.Length && dayUnits[dayIndex].Meals[mealIndex] != null && dayUnits[dayIndex].Meals[mealIndex].Recipes.Count > 0)
                    {
                        int index;
                        for (index = 0; index < dayUnits[dayIndex].Meals[mealIndex].Recipes.Count-1; index++)
                        {
                            title += dayUnits[dayIndex].Meals[mealIndex].Recipes[index].Name + " with ";
                        }
                        title += dayUnits[dayIndex].Meals[mealIndex].Recipes[index].Name;
                    }

                    MealLabel label = (MealLabel) MealTable[day+1, mealIndex+1];
                    label.Text = title;
                    label.DayIndex = dayIndex;
                    label.MealIndex = mealIndex;
                }
            }
            
        }

        /// <summary>
        /// This method add recipes to the plan randomly, but it follows the business rules.
        /// </summary>
        /// <param name="day"></param>
        /// <param name="dayIndex"></param>
        /// <param name="mealIndex"></param>
        /// <param name="recipes">The recipes from which a random recipe is chosen</param>
        /// <param name="recipeSelection">The array used to know which day the recipe was already added in the plan</param>
        /// <param name="quantity">The quantity of recipes to add that day and meal</param>
        private void AddRecipesRandom(DayUnit day, int dayIndex, int mealIndex, List<Recipe> recipes, int[] recipeSelection, int quantity)
        {
            int recipeAdded = 0;

            while (recipeAdded < quantity)
            {
                int randomIndex = GetValidIndex(recipeSelection, dayIndex); // Return a valid index or -1

                if (randomIndex == -1)
                    return;

                if (day.Meals[mealIndex] == null)
                    day.Meals[mealIndex] = new Meal(-1, day.Id);
                if (day.Meals[mealIndex].Recipes == null)
                    day.Meals[mealIndex].Recipes = new List<Recipe>();

                day.Meals[mealIndex].Recipes.Add(recipes[randomIndex]);
                recipeSelection[randomIndex] = dayIndex + 1;
                recipeAdded++;

            }
        }

        /// <summary>
        /// This method choose a random recipe and check if it can be added that day, if not it will try to pick another
        /// recipe, if none are valid it returns -1
        /// </summary>
        /// <param name="recipeSelection"></param>
        /// <param name="dayIndex"></param>
        /// <returns></returns>
        private int GetValidIndex(int[] recipeSelection, int dayIndex)
        {

            int index = new Random().Next(recipeSelection.Length);

            int resultIndex = index;

            bool indexNotFound = true;

            while (indexNotFound && resultIndex < recipeSelection.Length) // Check from recipe index to the end of the array
            {
                if (recipeSelection[resultIndex] == 0 || dayIndex - recipeSelection[resultIndex] >= DAY_BETWEEN_SAME_MEALS)
                    indexNotFound = false;
                else
                    resultIndex++;
            }

            if (indexNotFound)
            {
                resultIndex = 0;

                while (indexNotFound && resultIndex < index) // Check from the start of the array to the recipe index
                {
                    if (recipeSelection[resultIndex] == 0 || dayIndex - recipeSelection[resultIndex] >= DAY_BETWEEN_SAME_MEALS)
                        indexNotFound = false;
                    else
                        resultIndex++;
                }
            }

            if (indexNotFound)
                resultIndex = -1;

            return resultIndex;

        }

        /// <summary>
        /// Fill the list of recipes into the dayunit array.
        /// </summary>
        /// <param name="dayUnits"></param>
        /// <param name="recipes"></param>
        /// <returns></returns>
        private int[] FillExisting(DayUnit[] dayUnits, List<Recipe> recipes)
        {
            int[] recipesSelection = new int[recipes.Count];

            for (int dayIndex = 0; dayIndex < dayUnits.Length; dayIndex++)
            {

                DayUnit day = dayUnits[dayIndex];
            

                foreach (Meal meal in day.Meals)
                {
                    if(meal != null && meal.Recipes != null)
                    {
                        foreach (Recipe recipe in meal.Recipes)
                        {
                            for (int i = 0; i < recipes.Count; i++)
                            {
                                if (recipe.Id == recipes[i].Id)
                                {
                                    recipesSelection[i] = dayIndex + 1;
                                    i = recipes.Count;
                                }
                            }
                        }
                    }
                }
            }

            return recipesSelection;
        }

        /// <summary>
        /// Get a tree element by its Id.
        /// </summary>
        /// <param name="treeElements"></param>
        /// <param name="elementId"></param>
        /// <returns></returns>
        private TreeElement? GetTreeElement(TreeElement[] treeElements, int elementId)
        {
            int index = 1;

            while(treeElements[index].Id != elementId)
            {
                index++;
            }

            if (index >= treeElements.Length)
                return null;
            else
                return treeElements[index];
        }

        /// <summary>
        /// Get a list of all the child recipe for the parameter treeElement.
        /// </summary>
        /// <param name="treeElement"></param>
        /// <returns></returns>
        private List<Recipe> GetRecipeFromTreeElement(TreeElement? treeElement)
        {           

            List<Recipe> recipes = new List<Recipe>();

            if (treeElement == null)
                return recipes;

            foreach (TreeElement child in treeElement.Nodes)
            {
                if(child is Recipe)
                    recipes.Add((Recipe)child);

                recipes.AddRange(GetRecipeFromTreeElement(child));
            }

            return recipes;
        }

        /// <summary>
        /// Build the tree hierarchy for the specified tree element parent.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="children"></param>
        /// <param name="index"></param>
        public void BuildHierarchy(TreeElement parent, TreeElement[] children, int index)
        {

            for (int i = index; i < children.Length; i++)
            {
                TreeElement child = children[i];

                if (child.ParentId == parent.Id)
                {
                    // The interface check with (child is ICategory checkInterface) syntax did not work...
                    // This alternate works well at least.
                    ICategory? checkInterface = parent as ICategory;

                    if (checkInterface != null)
                    {
                        parent.Nodes.Add(child);
                        BuildHierarchy(child, children, index + 1);
                    }

                }
            }
        }

        /// <summary>
        /// This event is raised when the user click on the down button. It adds one to the displayed selection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDown_Click(object? sender, EventArgs e)
        {
            SelectionStartIndex++;

            SetSelection(SelectionStartIndex);
        }

        /// <summary>
        /// This event is raised when the user click on the up button. It sustracts one to the displayed selection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUp_Click(object sender, EventArgs e)
        {
            SelectionStartIndex--;

            SetSelection(SelectionStartIndex);
        }

        /// <summary>
        /// This event is raised when the user click on a day on the schedule list. It change the displayed
        /// selection to start at the corresponding clicked day.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewSchedule_SelectedIndexChanged(object? sender, EventArgs e)
        {

            if (listViewSchedule.SelectedItems.Count > 0)
            {
                SelectionStartIndex = listViewSchedule.SelectedItems[0].Index;
                SetSelection(SelectionStartIndex);
            }
        }

        /// <summary>
        /// This event is raised when the user click on the autogenerate button. It retrives the recipes and try to add them randomly
        /// to the plan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAutoGenerate_Click(object? sender, EventArgs e)
        {

            TreeElement[]? treeElements = RecipesManager.GetTreeElements(); // Get all elements

            if (treeElements == null)
                return;

            Array.Sort(treeElements);


            // Build the branches for the recipes root elements

            BuildHierarchy(treeElements[(int)MealTypes.Soaps], treeElements, (int)MealTypes.Soaps + 1);
            BuildHierarchy(treeElements[(int)MealTypes.MainCourses], treeElements, (int)MealTypes.MainCourses + 1);
            BuildHierarchy(treeElements[(int)MealTypes.Desserts], treeElements, (int)MealTypes.Desserts + 1);
            BuildHierarchy(treeElements[(int)MealTypes.Snacks], treeElements, (int)MealTypes.Snacks + 1);
            BuildHierarchy(treeElements[(int)MealTypes.Others], treeElements, (int)MealTypes.Others + 1);


            List<MealModel> models = Plan.DayModel.MealModels;

            // For each recipe root element, get the list of child recipes and fill the selection array.
            // The selection array represent the last days each recipe was added to the plan to check that 
            // The business rules are folowwed.

            List<Recipe> soaps = GetRecipeFromTreeElement(GetTreeElement(treeElements, (int)MealTypes.Soaps));
            int[] soapsSelection = FillExisting(DayUnitList, soaps);

            List<Recipe> mainCourses = GetRecipeFromTreeElement(GetTreeElement(treeElements, (int)MealTypes.MainCourses));
            int[] mainCoursesSelection = FillExisting(DayUnitList, mainCourses);

            List<Recipe> desserts = GetRecipeFromTreeElement(GetTreeElement(treeElements, (int)MealTypes.Desserts));
            int[] dessertsSelection = FillExisting(DayUnitList, desserts);

            List<Recipe> snacks = GetRecipeFromTreeElement(GetTreeElement(treeElements, (int)MealTypes.Snacks));
            int[] snacksSelection = FillExisting(DayUnitList, snacks);

            List<Recipe> others = GetRecipeFromTreeElement(GetTreeElement(treeElements, (int)MealTypes.Others));
            int[] othersSelection = FillExisting(DayUnitList, others);


            // Add random recipes for each categories.

            for (int dayIndex = 0; dayIndex < DayUnitList.Length; dayIndex++)
            {
                DayUnit day = DayUnitList[dayIndex];

                for (int i = 0; i < models.Count; i++)
                {

                    if (day.Meals[i] == null || day.Meals[i].Recipes.Count == 0)
                    {
                        MealModel model = models[i];

                        AddRecipesRandom(day, dayIndex + 1, i, soaps, soapsSelection, model.Soups);
                        AddRecipesRandom(day, dayIndex + 1, i, mainCourses, mainCoursesSelection, model.MainCourses);
                        AddRecipesRandom(day, dayIndex + 1, i, desserts, dessertsSelection, model.Desserts);
                        AddRecipesRandom(day, dayIndex + 1, i, snacks, snacksSelection, model.Snacks);
                        AddRecipesRandom(day, dayIndex + 1, i, others, othersSelection, model.Others);
                    }
                }
            }

            MenusPlansManager.Save(DayUnitList);

            SetupMeals(Plan, DayUnitList, SelectionStartIndex); // update plan
        }

        /// <summary>
        /// This event is raised when the user click on a meal label. 
        /// It opens the meal selection page.
        /// The selected meals are then checked and if they do no follows the business rules a warning is showns.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_Click(object? sender, EventArgs e)
        {
            MealLabel? label = sender as MealLabel;

            if (label == null)
                return;

            Meal meal = DayUnitList[label.DayIndex].Meals[label.MealIndex];

            if(meal == null)
            {
                meal = new Meal(-1, DayUnitList[label.DayIndex].Id);
            }

            Log.Information("PlanPage - Meal Label selection clicked");

            using (MealSelectionForm mealSelectionPage = new MealSelectionForm(meal))
            {
                if (mealSelectionPage.ShowDialog() == DialogResult.Continue)
                {
                    Meal addedMeal = mealSelectionPage.Meal;

                    CheckIfAlreadyPlanned(meal.Recipes, DayUnitList, label.DayIndex, 7);                  


                    DayUnitList[label.DayIndex].Meals[label.MealIndex] = addedMeal;

                    MenusPlansManager.Save(DayUnitList);

                    SetupMeals(Plan, DayUnitList, SelectionStartIndex);
                }

            }
        }

        
        /// <summary>
        /// This event is raised when the user mouse hover on a meal label. 
        /// It modify the color of the label to reflect make the user understand he can click here.
        /// The selected meals are then checked and if they do no follows the business rules a warning is showns.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_MouseHover(object? sender, EventArgs e)
        {
            MealLabel? label = sender as MealLabel;

            if (label == null)
                return;

            label.BackColor = Color.LightBlue;

        }

        /// <summary>
        /// This event is raised when the user mouse leave a meal label. 
        /// It modify the color of the label to reflect make the user understand he can click here.
        /// The selected meals are then checked and if they do no follows the business rules a warning is showns.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_MouseLeave(object? sender, EventArgs e)
        {
            MealLabel? label = sender as MealLabel;

            if (label == null)
                return;

            label.BackColor = Color.White;

        }

        /// <summary>
        /// This method check if a recipe is already planned in the plan in the range corresponding
        /// to the business rule to not add the same recipe in 7 days.
        /// </summary>
        /// <param name="recipes"></param>
        /// <param name="dayUnits"></param>
        /// <param name="dayIndex"></param>
        /// <param name="rangeBefore"></param>
        public void CheckIfAlreadyPlanned(List<Recipe> recipes, DayUnit[] dayUnits, int dayIndex, int range)
        {

            int index = dayIndex - range;

            if(index < 0)
                index = 0;

            while(index <= dayIndex+range && index < dayUnits.Length)
            {

                foreach(Meal meal in dayUnits[index].Meals)
                {

                    if(meal != null)
                    {
                        List<Recipe> plannedRecipes = meal.Recipes;

                        if (plannedRecipes != null)
                        {
                            for(int plannedIndex = 0; plannedIndex < plannedRecipes.Count; plannedIndex++)
                            {
                                Recipe plannedRecipe = plannedRecipes[plannedIndex];

                                for (int i = 0; i < recipes.Count; i++)
                                {
                                    Recipe wantedRecipe = recipes[i];

                                    if (plannedRecipe.Id == wantedRecipe.Id)
                                    {

                                        DialogResult choice = MessagesManager.WarningMessage(
                                            "The recipe " + wantedRecipe.Name + " is already planned on " + dayUnits[index].Date.ToShortDateString() +
                                            "\nOK : add the recipe anyway" +
                                            "\nCancel : do not add the recipe", MessageBoxButtons.OKCancel);


                                        if (choice == DialogResult.Cancel)
                                        {
                                            recipes.RemoveAt(i);
                                            i--;
                                        }

                                    }
                                }
                            }
                        }
                    }
                                   
                }


                index++; 
            }
        }
    }
}
