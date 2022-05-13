using DTO;
using System.ComponentModel;

namespace UI.Plans
{
    /// <summary>
    /// This form allows the user to create a model for the menus plan.
    /// </summary>
    public partial class PlanModelPage : Form
    {
        public MenusPlan Plan;

        private List<MealModel> MealModels;
        private int RowIndex;

        /// <summary>
        /// This constructor initialize the components and the data.
        /// </summary>
        /// <param name="plan"></param>
        public PlanModelPage(MenusPlan plan)
        {
            InitializeComponent();

            Plan = plan;

            RowIndex = 0;

            textBoxName.Text = plan.Name;
            dateTimePickerStart.Value = plan.StartDate;
            dateTimePickerEnd.Value = plan.EndDate;

            MealModels = Plan.DayModel.MealModels;

            BindingList<MealModel> bindingList = new BindingList<MealModel>(MealModels);

            dataGridView.DataSource = bindingList;
            dataGridView.CellMouseUp += new DataGridViewCellMouseEventHandler(DataGridView_CellMouseUp);
            contextMenuStrip.Click += new EventHandler(ContextMenuStrip_Click);
        }

        /// <summary>
        /// This event is raised when the user unleash the mouse. It display a context menustrip at the mouseup location.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_CellMouseUp(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                RowIndex = e.RowIndex;

                if (RowIndex == -1)
                    return;

                dataGridView.Rows[RowIndex].Selected = true;           
                dataGridView.CurrentCell = dataGridView.Rows[RowIndex].Cells[1];
                contextMenuStrip.Show(dataGridView, e.Location);
                contextMenuStrip.Show(Cursor.Position);
            }
        }

        /// <summary>
        /// This event is raised when the delete button of the context menu stip is clicked. It delete the corresponding
        /// row from the gridview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip_Click(object? sender, EventArgs e)
        {
            if (!dataGridView.Rows[RowIndex].IsNewRow)
            {
                dataGridView.Rows.RemoveAt(RowIndex);
            }
        }

        /// <summary>
        /// This event is raised when the user click on the cancel button. It closes the form with cancel dialog result.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// This event is raised when the user click on the save button. It closes the form with continue dialog result.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Plan = new MenusPlan(-1, textBoxName.Text, dateTimePickerStart.Value, dateTimePickerEnd.Value);
            Plan.DayModel = new DayModel(MealModels);

            DialogResult = DialogResult.Continue;
            Close();
        }
    }
}
