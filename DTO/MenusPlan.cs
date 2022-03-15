
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MenusPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DaysNumber { get; set; }
        public DayModel DayModel { get; set; }

        public MenusPlan(int id, string name, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            DaysNumber = endDate.Day - startDate.Day + 1;
            DayModel = new DayModel();
        }

        
    }
}
