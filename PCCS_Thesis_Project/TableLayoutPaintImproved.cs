namespace UI
{
    /// <summary>
    /// This class add an additional layer to the TableLayoutPanel control which override the OnPaintBackground method
    /// to prevent flickering during panel painting.
    /// The constructor parametrize the SetStyle to only show the painting once at the end of the rendering.
    /// </summary>
    public class TableLayoutPaintImproved : TableLayoutPanel
    {
        /// <summary>
        /// This constructor uses the SetStyle method to make the painting of the panel
        /// happens only once on background painting.
        /// </summary>
        public TableLayoutPaintImproved()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }
    }
}