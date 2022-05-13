using DAL;
using DTO;

namespace BLL
{
    /// <summary>
    /// This class is the Business logic layer for menus plan an their meals.
    /// </summary>
    public class MenusPlansManager
    {

        /// <summary>
        /// Get all the menus plan into a list. The meal models are added to the menus plan.
        /// </summary>
        /// <returns>A list of menus plan</returns>
        public static List<MenusPlan> GetMenusPlans()
        {

            List<MenusPlan> menus = new List<MenusPlan>();

            try
            {
                menus = MenusPlanDB.GetAllMenusPlans();

                for (int i = 0; i < menus.Count; i++)
                {
                    menus[i].DayModel.MealModels = MenusPlanDB.GetMealModelsFor(menus[i]);
                }
            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);               
            }

            return menus;
        }

        /// <summary>
        /// Get the day units for the parameter's plan. The meals and their recipes are added to each day.
        /// </summary>
        /// <param name="plan"></param>
        /// <returns>An array of day units</returns>
        public static DayUnit[]? GetDayUnits(MenusPlan plan)
        {

            DayUnit[] dayUnits = new DayUnit[plan.DaysNumber];
            DateTime date = plan.StartDate; 

            try
            {
                for (int i = 0; i < dayUnits.Length; i++)
                {
                    dayUnits[i] = MenusPlanDB.GetDayUnit(date, plan.Id, plan.DayModel.MealModels.Count);

                    date = date.AddDays(1);
                }

                foreach (DayUnit dayUnit in dayUnits)
                {

                    dayUnit.Meals = MenusPlanDB.GetMeals(dayUnit);

                    foreach (Meal meal in dayUnit.Meals)
                    {
                        if(meal != null)
                            meal.Recipes = MenusPlanDB.GetMealRecipes(meal.Id);
                    }          
                }

                return dayUnits;
            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
                return null;
            }
        }

        /// <summary>
        /// Save a day units array into the DB. Each day unit is saved separately using method Save(DayUnit)
        /// </summary>
        /// <param name="dayUnits"></param>
        public static void Save(DayUnit[] dayUnits)
        {
            try
            {
                foreach (DayUnit day in dayUnits)
                {
                    Save(day);
                }
            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Save a day unit into the DB or update it if it already exists. Its meals are saved too using
        /// the method Save(Meal).
        /// </summary>
        /// <param name="day"></param>
        public static void Save(DayUnit day)
        {

            try
            {

                if (day.Id == -1)
                {
                    MenusPlanDB.Insert(day);

                    foreach (Meal meal in day.Meals)
                    {
                        if(meal != null)
                            meal.DayUnitId = day.Id;
                    }
                }
                else
                {
                    MenusPlanDB.Update(day);
                }
                 
                foreach(Meal meal in day.Meals)
                {
                    Save(meal);
                }

                
            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Save a Meal into the DB or update it if it already exists. The meal recipes are saved too using Save(Meal, Recipe).
        /// </summary>
        /// <param name="meal"></param>
        public static void Save(Meal? meal)
        {
            if (meal == null)
                return;

            try
            {
                
                if (meal.Id == -1)
                {
                    MenusPlanDB.Insert(meal);
                }
                else
                {
                    MenusPlanDB.Update(meal);
                }

                MenusPlanDB.RefreshMealRecipes(meal); // Clear the meal's recipes entity

                foreach (Recipe recipe in meal.Recipes) // Add the updated meal's recipes entity to the DB
                {
                    Save(meal, recipe);
                }


            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Save a meal's recipe into the DB.
        /// </summary>
        /// <param name="meal"></param>
        /// <param name="recipe"></param>
        public static void Save(Meal meal, Recipe recipe)
        {

            if (recipe == null)
                return;

            try
            {               
                MenusPlanDB.Insert(meal, recipe);
            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Save a menu plan into the DB or update it if it already exists. The meal models are saved
        /// using the method Save(planId, Model)
        /// </summary>
        /// <param name="plan"></param>
        public static void Save(MenusPlan plan)
        {
            try
            {
                if (plan.Id == -1)
                    MenusPlanDB.Insert(plan);              
                else
                    MenusPlanDB.Update(plan);                          

                foreach (MealModel model in plan.DayModel.MealModels)
                {
                    Save(plan.Id, model);
                }
            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Save a meal model into the DB or update it if it already exists.
        /// </summary>
        /// <param name="planId"></param>
        /// <param name="model"></param>
        public static void Save(int planId, MealModel model)
        {
            try
            {
                if (model.Id == -1)
                    MenusPlanDB.Insert(planId, model);
                else
                    MenusPlanDB.Update(planId, model);
                
            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Delete a menu plan and all its day units from the DB.
        /// </summary>
        /// <param name="plan"></param>
        public static void Delete(MenusPlan plan)
        {
            try
            {
                foreach (MealModel model in plan.DayModel.MealModels)
                {
                    Delete(model);
                }

                DayUnit[] dayUnits = GetDayUnits(plan);

                foreach (DayUnit dayUnit in dayUnits)
                {
                    Delete(dayUnit);
                }                             

                MenusPlanDB.Delete(plan);

            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Delete a day unit from the DB.
        /// </summary>
        /// <param name="model"></param>
        public static void Delete(DayUnit dayUnit)
        {
            try
            {
                if (dayUnit.Id == -1)
                    return;
                else
                {
                    foreach(Meal meal in dayUnit.Meals)
                    {
                        Delete(meal);
                    }

                    MenusPlanDB.Delete(dayUnit);
                }
                    

            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Delete a meal from the DB.
        /// </summary>
        /// <param name="model"></param>
        public static void Delete(Meal meal)
        {
            try
            {
                if (meal == null || meal.Id == -1)
                    return;
                else
                {
                    MenusPlanDB.RefreshMealRecipes(meal);
                    MenusPlanDB.Delete(meal);
                }
                    

            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
            }

        }
        /// <summary>
        /// Delete a meal model from the DB.
        /// </summary>
        /// <param name="model"></param>
        public static void Delete(MealModel model)
        {
            try
            {
                if (model.Id == -1)
                    return;
                else
                    MenusPlanDB.Delete(model);

            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
            }
        }
    }
}
