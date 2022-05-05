using BLL;
using DTO;
using DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Plans
{
    public partial class PlanPage : Form
    {

        public const int DAY_BETWEEN_SAME_MEALS = 7; 
        private DayUnit[] DayUnitList { get; set; }
        private MenusPlan Plan { get; set; }
        private int SelectionStartIndex { get; set; }

        private Label[,] MealTable { get; set; }

        public PlanPage(MenusPlan plan)
        {
            InitializeComponent();

            Plan = plan;
            SelectionStartIndex = 0;

            MealTable = new Label[8, plan.DayModel.MealModels.Count+1];

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < plan.DayModel.MealModels.Count+1; col++)
                {
                    MealTable[row, col] = new Label()
                    {
                        Text = "",
                        Font = new Font(this.Font, FontStyle.Bold),
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        BorderStyle = BorderStyle.FixedSingle

                    };
                }
            }

            SetupMealTable(plan);          

            LoadData(plan);
        }

        private void LoadData(MenusPlan plan)
        {
            
            DayUnitList = MenusPlansManager.GetDayUnits(plan);
            SetupScheduleList(DayUnitList);

            SetSelection(SelectionStartIndex);

        }

        private void SetSelection(int selectionStartIndex)
        {

            if (SelectionStartIndex + 7 >= DayUnitList.Length)
            {
                SelectionStartIndex = DayUnitList.Length - 7;
                selectionStartIndex = DayUnitList.Length - 7;
            }            
            if (SelectionStartIndex < 0)
            {
                SelectionStartIndex = 0;
                selectionStartIndex = 0;
            }


            SetupDaysOfWeek(DayUnitList, selectionStartIndex);

            SetupMeals(Plan, DayUnitList, selectionStartIndex);

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

        private void SetupScheduleList(DayUnit[] dayUnitList)
        {
            ListView schedule = listViewSchedule;
            schedule.View = View.Tile;

            foreach (DayUnit day in dayUnitList)
            {
                schedule.Items.Add(day.Date.DayOfWeek + " " + day.Date.ToShortDateString());
            }
            
        }

            private void SetupMealTable(MenusPlan plan)
        {
            // Table layout setup
            int nbColumns = plan.DayModel.MealModels.Count + 1;
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

            panel.ColumnStyles.RemoveAt(0);

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
                    BorderStyle = BorderStyle.FixedSingle
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

                    Label label = MealTable[day+1, mealIndex+1];
                    label.Text = title;
                }
            }
            
        }

        private void ButtonDown_Click(object? sender, EventArgs e)
        {
            SelectionStartIndex++;

            SetSelection(SelectionStartIndex);
        }

        private void ButtonUp_Click(object sender, EventArgs e)
        {
            SelectionStartIndex--;

            SetSelection(SelectionStartIndex);
        }

        private void ListViewSchedule_SelectedIndexChanged(object? sender, EventArgs e)
        {

            if(listViewSchedule.SelectedItems.Count > 0)
            {
                SelectionStartIndex = listViewSchedule.SelectedItems[0].Index;
                SetSelection(SelectionStartIndex);
            }
        }

        private void ButtonAutoGenerate_Click(object? sender, EventArgs e)
        {

            TreeElement[]? treeElements = RecipesManager.GetTreeElements();

            if (treeElements == null)
                return;

            Array.Sort(treeElements);

            BuildHierarchy(treeElements[(int)MealTypes.Soaps], treeElements, (int)MealTypes.Soaps + 1);
            BuildHierarchy(treeElements[(int)MealTypes.MainCourses], treeElements, (int)MealTypes.MainCourses + 1);
            BuildHierarchy(treeElements[(int)MealTypes.Desserts], treeElements, (int)MealTypes.Desserts + 1);
            BuildHierarchy(treeElements[(int)MealTypes.Snacks], treeElements, (int)MealTypes.Snacks + 1);
            BuildHierarchy(treeElements[(int)MealTypes.Others], treeElements, (int)MealTypes.Others + 1);



            List<MealModel> models = Plan.DayModel.MealModels; 

            List<Recipe> soaps = GetRecipeFromTreeElement(GetTreeElement(treeElements, (int) MealTypes.Soaps));
            int[] soapsSelection = FillExisting(DayUnitList, soaps);
            
            List<Recipe> mainCourses = GetRecipeFromTreeElement(GetTreeElement(treeElements, (int)MealTypes.MainCourses));
            int[] mainCoursesSelection = FillExisting(DayUnitList, mainCourses);

            List<Recipe> desserts = GetRecipeFromTreeElement(GetTreeElement(treeElements, (int)MealTypes.Desserts));
            int[] dessertsSelection = FillExisting(DayUnitList, desserts);

            List<Recipe> snacks = GetRecipeFromTreeElement(GetTreeElement(treeElements, (int)MealTypes.Snacks));
            int[] snacksSelection = FillExisting(DayUnitList, snacks);

            List<Recipe> others = GetRecipeFromTreeElement(GetTreeElement(treeElements, (int)MealTypes.Others));
            int[] othersSelection = FillExisting(DayUnitList, others);

            for (int dayIndex = 0; dayIndex < DayUnitList.Length; dayIndex++)
            {
                DayUnit day = DayUnitList[dayIndex];

                for (int i = 0; i < models.Count; i++)
                {                  

                    if(day.Meals[i] == null || day.Meals[i].Recipes.Count == 0)
                    {
                        MealModel model = models[i];                        

                        AddRecipesRandom(day, dayIndex+1, i, soaps, soapsSelection, model.Soaps, "Soaps");
                        AddRecipesRandom(day, dayIndex+1, i, mainCourses, mainCoursesSelection, model.MainCourses, "Main courses");
                        AddRecipesRandom(day, dayIndex+1, i, desserts, dessertsSelection, model.Desserts, "Desserts");
                        AddRecipesRandom(day, dayIndex+1, i, snacks, snacksSelection, model.Snacks, "Snacks");
                        AddRecipesRandom(day, dayIndex+1, i, others, othersSelection, model.Others, "Others");
                    }
                }
            }

            SetupMeals(Plan, DayUnitList, SelectionStartIndex);
        }

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
        private void AddRecipesRandom(DayUnit day, int dayIndex, int mealIndex, List<Recipe> recipes, int[] recipeSelection, int quantity, string recipeType)
        {
            int recipeAdded = 0;

            while(recipeAdded < quantity)
            {
                int randomIndex = GetValidIndex(recipeSelection, dayIndex);

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

        private int GetValidIndex(int[] recipeSelection, int dayIndex)
        {

            int index = new Random().Next(recipeSelection.Length);

            int resultIndex = index;

            bool indexNotFound = true;          

            while (indexNotFound && resultIndex < recipeSelection.Length)
            {
                if (recipeSelection[resultIndex] == 0 || dayIndex - recipeSelection[resultIndex] >= DAY_BETWEEN_SAME_MEALS)
                    indexNotFound = false;
                else
                    resultIndex++;
            }

            if (indexNotFound)
            {
                resultIndex = 0;

                while (indexNotFound && resultIndex < index)
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
    }
}
