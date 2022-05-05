using BLL;
using DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Plans
{
    public partial class PlanSelectionPage : Form
    {

        private int RowIndex;

        private List<MenusPlan> MenusPlans = new List<MenusPlan>();

        public PlanSelectionPage()
        {
            InitializeComponent();

            Show();

            LoadData();

            dataGridView.CellMouseUp += new DataGridViewCellMouseEventHandler(DataGridView_CellMouseUp);
            dataGridView.CellContentDoubleClick += new DataGridViewCellEventHandler(DataGridView_CellDoubleClick);
            deleteToolStripMenuItem.Click += new EventHandler(DeleteMenuItem_Click);
            editToolStripMenuItem.Click += new EventHandler(EditMenuItem_Click);

        }

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

        

        private void DataGridView_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            RowIndex = e.RowIndex;

            if (!dataGridView.Rows[RowIndex].IsNewRow)
            {
                MenusPlan menuplan = (MenusPlan)dataGridView.Rows[RowIndex].DataBoundItem;
                OpenPlanPage(menuplan);
            }
        }
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

        private void DeleteMenuItem_Click(object? sender, EventArgs e)
        {         

            if (!dataGridView.Rows[RowIndex].IsNewRow)
            {
                dataGridView.Rows.RemoveAt(RowIndex);
            }

            //Save DB
        }

        private void EditMenuItem_Click(object? sender, EventArgs e)
        {
            if (!dataGridView.Rows[RowIndex].IsNewRow)
            {
                MenusPlan menuplan = (MenusPlan)dataGridView.Rows[RowIndex].DataBoundItem;

                //PlanModelPage modelPage = new PlanModelPage(menuplan);

                OpenPlanPage(menuplan);

                //sync data grid plan

            }
        }

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


        private void OpenPlanPage(MenusPlan plan)
        {
            PlanPage planPage = new PlanPage(plan);

            if (planPage.ShowDialog() == DialogResult.Continue)
            {
                //MenusPlan plan = modelPage.Plan;
            }
        }

        private void Save(MenusPlan plan)
        {
            dataGridView.DataSource = new BindingList<MenusPlan>(MenusPlans);

            MenusPlansManager.Save(plan);          
        }


    }
}
