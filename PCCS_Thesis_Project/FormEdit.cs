
namespace UI
{
    /// <summary>
    /// A container form with 2 panels to display other forms, mainly used
    /// to display edition of data with one panel been the list of all data 
    /// and the other one is the selected data.
    /// </summary>
    public partial class FormEdit : Form
    {

        /// <summary>
        /// This constructor initialize the form as maximized and use the Shown method directly.
        /// </summary>
        /// <param name="title"></param>
        public FormEdit(string title)
        {
            InitializeComponent();
            Text = title;           
            WindowState = FormWindowState.Maximized;

            Show();
        }

        /// <summary>
        /// The right panel that can be used to display data
        /// </summary>
        /// <returns></returns>
        public Panel GetRightPanel()
        {
            return panelRight;
        }

        /// <summary>
        /// The left panel that can be used to display data
        /// </summary>
        /// <returns></returns>
        public Panel GetLeftPanel()
        {
            return panelLeft;
        }

        /// <summary>
        /// The label used to display information
        /// </summary>
        /// <returns></returns>
        public Label GetInfoLabel()
        {
            return labelInfo;
        }
    }
}


