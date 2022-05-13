
namespace DTO
{
    /// <summary>
    /// This class represents a menus plan
    /// </summary>
    public class MenusPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DaysNumber { get; set; }
        public DayModel DayModel { get; set; } // The day models for the meals

        /// <summary>
        /// THe construcotr wit parameters
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public MenusPlan(int id, string name, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            DaysNumber = endDate.Subtract(startDate).Days+1;
            DayModel = new DayModel();
        }

        /// <summary>
        /// The empty constructor initialisze the menus plan with default parameters.
        /// To create a menus plan with parameters see constructor MenusPlan(int id, string name, DateTime startDate, DateTime endDate)
        /// </summary>
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
