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
    public partial class PlanPage : Form
    {
        public PlanPage(MenusPlan plan)
        {
            InitializeComponent();

            LoadData(plan);
        }

        private void LoadData(MenusPlan plan)
        {
            List<DayUnit> dayUnitList = new List<DayUnit>();
            dayUnitList.Add(new DayUnit(0, new DateTime(2022, 03, 15)));
            dayUnitList.Add(new DayUnit(0, new DateTime(2022, 03, 16)));
            dayUnitList.Add(new DayUnit(0, new DateTime(2022, 03, 17)));

            // Table layout setup
            int nbColumns = plan.DayModel.MealModels.Count + 1;
            int nbRows = 8;

            TableLayoutPanel panel = tableLayoutPanelWeekSchedule;

            panel.Controls.Clear();

            panel.ColumnCount = nbColumns;
            panel.RowCount = nbRows;
            panel.ColumnStyles.RemoveAt(0);

            for (int i = 0; i < nbColumns; i++)
            {
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F/nbColumns));
            }

            panel.ColumnStyles.RemoveAt(0);

            for (int i = 0; i < nbRows; i++)
            {
                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F/8));
            }


            // Add buttons
            panel.Controls.Add(new Button() { 
                Text = "/\\",
                Dock = DockStyle.Bottom,
            }, 0, 0);
            panel.Controls.Add(new Button() { 
                Text = "\\/",
                Dock = DockStyle.Bottom,
            }, 0, 8);


            for (int i = 0; i < plan.DayModel.MealModels.Count; i++)
            {
                panel.Controls.Add(new Label()
                {
                    Text = plan.DayModel.MealModels[i].Name,
                    Font = new Font(this.Font, FontStyle.Bold),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle
                }, i+1, 0); ;
            }

            string[] days =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            for (int i = 0; i < 7; i++)
            {
                panel.Controls.Add(new Label()
                {
                    Text = days[i],
                    Font = new Font(this.Font, FontStyle.Bold),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle

                }, 0, i+1); ;
            }

            panel.Controls.Add(new Label()
            {
                Text = "Beef with pasta",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter

            }, 1, 1); ;
            panel.Controls.Add(new Label()
            {
                Text = "Chicken nuggets",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            }, 1, 2); 

            panel.Controls.Add(new Label()
            {
                Text = "Polenta",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            }, 2, 2); 

            panel.Controls.Add(new Label()
            {
            Text = "Sandwitch",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            }, 3, 2); 


        }
    }
}
