namespace UI.Plans
{
    partial class PlanPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelSchedule = new System.Windows.Forms.Label();
            this.tableLayoutPanelWeekSchedule = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.listViewSchedule = new System.Windows.Forms.ListView();
            this.buttonAutoGenerate = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.tableLayoutPanelWeekSchedule.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel.Controls.Add(this.labelSchedule, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.listViewSchedule, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanelWeekSchedule, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.buttonAutoGenerate, 2, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.27013F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.398927F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(997, 579);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // labelSchedule
            // 
            this.labelSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSchedule.AutoSize = true;
            this.labelSchedule.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSchedule.Location = new System.Drawing.Point(3, 83);
            this.labelSchedule.Name = "labelSchedule";
            this.labelSchedule.Size = new System.Drawing.Size(193, 19);
            this.labelSchedule.TabIndex = 4;
            this.labelSchedule.Text = "Schedule";
            // 
            // tableLayoutPanelWeekSchedule
            // 
            this.tableLayoutPanelWeekSchedule.ColumnCount = 1;
            this.tableLayoutPanelWeekSchedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelWeekSchedule.Controls.Add(this.buttonDown, 0, 7);
            this.tableLayoutPanelWeekSchedule.Controls.Add(this.buttonUp, 0, 0);
            this.tableLayoutPanelWeekSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelWeekSchedule.Location = new System.Drawing.Point(251, 86);
            this.tableLayoutPanelWeekSchedule.Name = "tableLayoutPanelWeekSchedule";
            this.tableLayoutPanelWeekSchedule.RowCount = 9;
            this.tableLayoutPanel.SetRowSpan(this.tableLayoutPanelWeekSchedule, 3);
            this.tableLayoutPanelWeekSchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.25F));
            this.tableLayoutPanelWeekSchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.25F));
            this.tableLayoutPanelWeekSchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.25F));
            this.tableLayoutPanelWeekSchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.25F));
            this.tableLayoutPanelWeekSchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.25F));
            this.tableLayoutPanelWeekSchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.25F));
            this.tableLayoutPanelWeekSchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.25F));
            this.tableLayoutPanelWeekSchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.25F));
            this.tableLayoutPanelWeekSchedule.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelWeekSchedule.Size = new System.Drawing.Size(743, 461);
            this.tableLayoutPanelWeekSchedule.TabIndex = 5;
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(3, 360);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(112, 34);
            this.buttonDown.TabIndex = 3;
            this.buttonDown.Text = "\\/";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.ButtonDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUp.Location = new System.Drawing.Point(3, 14);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(112, 34);
            this.buttonUp.TabIndex = 2;
            this.buttonUp.Text = "/\\";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.ButtonUp_Click);
            // 
            // listViewSchedule
            // 
            this.listViewSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSchedule.Location = new System.Drawing.Point(3, 105);
            this.listViewSchedule.MultiSelect = false;
            this.listViewSchedule.Name = "listViewSchedule";
            this.tableLayoutPanel.SetRowSpan(this.listViewSchedule, 2);
            this.listViewSchedule.Size = new System.Drawing.Size(193, 442);
            this.listViewSchedule.TabIndex = 6;
            this.listViewSchedule.UseCompatibleStateImageBehavior = false;
            this.listViewSchedule.SelectedIndexChanged += new System.EventHandler(this.ListViewSchedule_SelectedIndexChanged);
            // 
            // buttonAutoGenerate
            // 
            this.buttonAutoGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAutoGenerate.Location = new System.Drawing.Point(857, 23);
            this.buttonAutoGenerate.Name = "buttonAutoGenerate";
            this.buttonAutoGenerate.Size = new System.Drawing.Size(137, 57);
            this.buttonAutoGenerate.TabIndex = 7;
            this.buttonAutoGenerate.Text = "Auto-generate meals";
            this.buttonAutoGenerate.UseVisualStyleBackColor = true;
            this.buttonAutoGenerate.Click += new System.EventHandler(this.ButtonAutoGenerate_Click);
            // 
            // PlanPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 579);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "PlanPage";
            this.Text = "PlansPage";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.tableLayoutPanelWeekSchedule.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private Button buttonUp;
        private Button buttonDown;
        private Label labelSchedule;
        private TableLayoutPanel tableLayoutPanelWeekSchedule;
        private ListView listViewSchedule;
        private Button buttonAutoGenerate;
    }
}