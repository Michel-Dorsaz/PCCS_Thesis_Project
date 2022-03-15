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
        public PlanSelectionPage()
        {
            InitializeComponent();

            Show();

            LoadData();
        }

        public void LoadData()
        {
            dataGridView.CellDoubleClick += DataGridView_RowClick;
            dataGridView.CellContentClick += DataGridView_CellClick;

            dataGridView.AutoGenerateColumns = false;

            // Get data
            List<MenusPlan> r = new List<MenusPlan>();
            var list = new BindingList<MenusPlan>(r);

            Button btnEdit = new Button()
            {
                Text = "Edit"
            };
            Button btnDelete = new Button()
            {
                Text = "Delete"
            };

            list.Add(new MenusPlan(1, "January", new DateTime(2022, 1, 1), new DateTime(2022, 1, 31)));
            list.Add(new MenusPlan(1, "February", new DateTime(2022, 2, 1), new DateTime(2022, 2, 28)));

            dataGridView.DataSource = list;

            dataGridView.Columns[0].DataPropertyName = "Name";
            dataGridView.Columns[1].DataPropertyName = "StartDate";
            dataGridView.Columns[2].DataPropertyName = "EndDate";
            dataGridView.Columns[3].DataPropertyName = "DaysNumber";
            dataGridView.Columns[3].DataPropertyName = "Edit";

            for (int i = 0; i < list.Count; i++)
            {
                dataGridView.Rows[i].Cells[4].Value = "Edit";
                dataGridView.Rows[i].Cells[5].Value = "Delete";              
            }
        }

        private void DataGridView_RowClick(object? sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1)
                return;


            MenusPlan menuPlan = (MenusPlan)dataGridView.CurrentRow.DataBoundItem;

            new PlanPage(menuPlan).Show();
        }

        private void DataGridView_CellClick(object? sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1)
                return;

            MenusPlan menuPlan = (MenusPlan) dataGridView.Rows[e.RowIndex].DataBoundItem;

            if (e.ColumnIndex == 4)
            {

            }
            else if(e.ColumnIndex == 5)
            {
                dataGridView.Rows.RemoveAt(e.RowIndex);

                PlansManager.Delete(menuPlan);
            }
        }
    }
}
