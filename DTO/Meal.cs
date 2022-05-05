using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Meal
    {
        public int Id { get; set; }

        public int DayUnitId { get; set; }
        public List<Recipe> Recipes { get; set; }

        public Meal(int id, int dayUnitId)
        {
            Id = id;
            DayUnitId = dayUnitId;
            Recipes = new List<Recipe>();
        }
    }
}
