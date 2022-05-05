using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MenusPlansManager
    {

        public static List<MenusPlan>? GetMenusPlans()
        {
            try
            {
                return MenusPlanDB.GetAllMenusPlans();
            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
                return null;
            }
        }

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
                            meal.Recipes = MenusPlanDB.getMealRecipes(meal.Id);
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

        public static void Save(MenusPlan plan)
        {
            try
            {
                if (plan.Id == -1)
                {
                    MenusPlanDB.Insert(plan);
                    //MenusPlanDB.Insert()
                }
                else
                {
                    MenusPlanDB.Update(plan);
                }                   
            }
            catch (Exception ex)
            {
                MessagesManager.WarningMessage(ex.Message, MessageBoxButtons.OK);
            }
        }
    }
}
