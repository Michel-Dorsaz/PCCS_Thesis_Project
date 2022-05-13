using BLL;
using DTO;
using System.ComponentModel;

namespace UI.Plans
{
    /// <summary>
    /// This form allows user to select a plan, to create a new one, delete or edit an existing one.
    /// </summary>
    public partial class PlanSelectionPage : Form
    {

        /// <summary>
        /// Row index of user-selected row
        /// </summary>
        private int RowIndex;

        private List<MenusPlan> MenusPlans = new List<MenusPlan>();

        /// <summary>
        /// Initialize the component and load the data. The Show() method is directly used here.
        /// </summary>
        public PlanSelectionPage()
        {
            InitializeComponent();

            Show();

            LoadData();


            // Setup events handlers

            dataGridView.CellMouseUp += new DataGridViewCellMouseEventHandler(DataGridView_CellMouseUp);
            dataGridView.CellContentDoubleClick += new DataGridViewCellEventHandler(DataGridView_CellDoubleClick);
            dataGridView.CellEndEdit += new DataGridViewCellEventHandler(DataGridView_CellEndEdit);
            deleteToolStripMenuItem.Click += new EventHandler(DeleteMenuItem_Click);
            editToolStripMenuItem.Click += new EventHandler(EditMenuItem_Click);
        }

        /// <summary>
        /// Get all the existing menus plans and add them to this form's datagridview.
        /// </summary>
        public void LoadData()
        {

            dataGridView.AutoGenerateColumns = false;          

            // Get data
            List<MenusPlan>? data = MenusPlansManager.GetMenusPlans();

            if (data == null)
                data = new List<MenusPlan>();

            MenusPlans = data;

            dataGridView.DataSource = new BindingList<MenusPlan>(MenusPlans);

            dataGridView.Columns[0].DataPropertyName = "Name";
            dataGridView.Columns[1].DataPropertyName = "StartDate";
            dataGridView.Columns[2].DataPropertyName = "EndDate";
            dataGridView.Columns[3].DataPropertyName = "DaysNumber";

        }

        /// <summary>
        /// This event is raised at the end of the edition of a cell content and save the modified data to the DB.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {

            RowIndex = e.RowIndex;

            if (!dataGridView.Rows[RowIndex].IsNewRow)
            {             
                MenusPlan menuplan = (MenusPlan)dataGridView.Rows[RowIndex].DataBoundItem;
                menuplan.DaysNumber = menuplan.EndDate.Subtract(menuplan.StartDate).Days + 1;
                MenusPlansManager.Save(menuplan); // We don't use the class Save method here because we don't need to refresh the datasource
            }
        }

        /// <summary>
        /// This event is raised when the user double clic on the datagridview and it open the 
        /// plan coresponding to the clicked row.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            RowIndex = e.RowIndex;

            if (!dataGridView.Rows[RowIndex].IsNewRow)
            {
                MenusPlan menuplan = (MenusPlan)dataGridView.Rows[RowIndex].DataBoundItem;
                OpenPlanPage(menuplan);

                Save(menuplan);
            }
        }

        /// <summary>
        /// This event is raised when the user unleash a mouse clic on the datagridview.
        /// If the click was a right click on a row, the context menustrip wit edit and delete option
        /// appears at the click location.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_CellMouseUp(object? sender, DataGridViewCellMouseEventArgs e)
        {

            RowIndex = e.RowIndex;

            if (e.Button == MouseButtons.Right && RowIndex != -1)
            {
                dataGridView.Rows[RowIndex].Selected = true;
                dataGridView.CurrentCell = dataGridView.Rows[RowIndex].Cells[1];
                contextMenuStrip.Show(dataGridView, e.Location);
                contextMenuStrip.Show(Cursor.Position);
            }
        }

        /// <summary>
        /// This event is raised when the user click on the delete option from the context menu strip.
        /// It delete the corresponding menu plan from the grid and from the DB.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteMenuItem_Click(object? sender, EventArgs e)
        {         

            if (!dataGridView.Rows[RowIndex].IsNewRow)
            {
                MenusPlan menuplan = (MenusPlan)dataGridView.Rows[RowIndex].DataBoundItem;

                dataGridView.Rows.RemoveAt(RowIndex);

                MenusPlansManager.Delete(menuplan);
            }
        }

        /// <summary>
        /// This event is raised when the user click on the edit option of the context menustrip.
        /// It open the corresponding menu plan for edition.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditMenuItem_Click(object? sender, EventArgs e)
        {
            if (!dataGridView.Rows[RowIndex].IsNewRow)
            {
                MenusPlan menuplan = (MenusPlan)dataGridView.Rows[RowIndex].DataBoundItem;

                OpenPlanPage(menuplan);
            }
        }

        /// <summary>
        /// This event is raised when the new plan button is clicked and it open the page for plan creation.
        /// The created plan is saved to the DB and added to the grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewPlan_Click(object? sender, EventArgs e)
        {

            PlanModelPage modelPage = new PlanModelPage(new MenusPlan());

            if (modelPage.ShowDialog() == DialogResult.Continue)
            {
                MenusPlan plan = modelPage.Plan;

                MenusPlans.Add(plan);

                Save(plan);            
                
            }
        }

        /// <summary>
        /// This method open the menus plan page for plan edition.
        /// </summary>
        /// <param name="plan"></param>
        private void OpenPlanPage(MenusPlan plan)
        {

            using (PlanPage planPage = new PlanPage(plan))
            {
                planPage.ShowDialog();
            }
        }

        /// <summary>
        /// This method add to the datagridview and save the parameter plan.
        /// </summary>
        /// <param name="plan"></param>
        private void Save(MenusPlan plan)
        {

            dataGridView.DataSource = new BindingList<MenusPlan>(MenusPlans);

            MenusPlansManager.Save(plan);          
        }
    }
}
