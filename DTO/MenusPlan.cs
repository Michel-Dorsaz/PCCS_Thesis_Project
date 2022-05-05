
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
            DaysNumber = endDate.Subtract(startDate).Days+1;
            DayModel = new DayModel();
        }

        public MenusPlan()
        {
            Id = -1;
            Name = "";
            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddDays(1);
            DaysNumber = EndDate.Subtract(StartDate).Days+1;
            DayModel = new DayModel();
        }


    }
}
