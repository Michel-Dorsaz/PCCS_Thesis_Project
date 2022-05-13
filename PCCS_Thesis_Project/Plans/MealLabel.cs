
namespace UI.Plans
{

    /// <summary>
    /// This class implements a custom label with the indexes references for the meal matrix.
    /// </summary>
    public class MealLabel : Label
    {
        public int DayIndex { get; set; }
        public int MealIndex { get; set; }
    }
}
