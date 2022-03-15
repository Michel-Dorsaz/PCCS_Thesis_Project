using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MealModel
    {

        public string Name { get; set; }
        public int Soaps { get; set; }
        public int MainCourses { get; set; }
        public int Desserts { get; set; }
        public int Snacks { get; set; }
        public int Others { get; set; }


        public MealModel(string name)
        {
            Name = name;
            Soaps = 1;
            MainCourses = 1;
            Desserts = 1;
            Snacks = 1;
            Others = 1;
        }
    }
}
