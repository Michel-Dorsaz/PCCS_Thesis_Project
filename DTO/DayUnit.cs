using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DayUnit
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int MenusPlanId { get; set; }
        public Meal[] Meals { get; set; }

        public DayUnit(int id, DateTime date, int menusPlanId, int mealsNumber)
        {
            Id = id;
            Date = date;
            MenusPlanId = menusPlanId;
            Meals = new Meal[mealsNumber];
        }

        public DayUnit(DateTime date, int menusPlanId, int mealsNumber)
        {
            Id = -1;
            Date = date;
            MenusPlanId = menusPlanId;
            Meals = new Meal[mealsNumber];
        }
    }
}
