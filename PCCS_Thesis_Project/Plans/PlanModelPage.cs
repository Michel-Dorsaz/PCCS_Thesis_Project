using DTO;
using System;
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
    public partial class PlanModelPage : Form
    {
        public MenusPlan Plan;

        private List<MealModel> MealModels;
        private int RowIndex;

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


        private void DataGridView_CellMouseUp(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                RowIndex = e.RowIndex;

                dataGridView.Rows[RowIndex].Selected = true;           
                dataGridView.CurrentCell = dataGridView.Rows[RowIndex].Cells[1];
                contextMenuStrip.Show(dataGridView, e.Location);
                contextMenuStrip.Show(Cursor.Position);
            }
        }

        private void ContextMenuStrip_Click(object? sender, EventArgs e)
        {
            if (!dataGridView.Rows[RowIndex].IsNewRow)
            {
                dataGridView.Rows.RemoveAt(RowIndex);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Plan = new MenusPlan(-1, textBoxName.Text, dateTimePickerStart.Value, dateTimePickerEnd.Value);
            Plan.DayModel = new DayModel(MealModels);

            DialogResult = DialogResult.Continue;
            Close();
        }

    }
}
