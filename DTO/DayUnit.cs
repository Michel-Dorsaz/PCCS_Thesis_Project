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
        public Meal[] Meals { get; set; }

        public DayUnit(int id, DateTime date)
        {
            Id = id;
            Date = date;
            Meals = new Meal[1];
        }
    }
}
