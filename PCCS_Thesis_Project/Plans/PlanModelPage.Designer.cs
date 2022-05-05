namespace UI.Plans
{
    partial class PlanModelPage
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.mealModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soapsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainCoursesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dessertsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.snacksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.othersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mealModelBindingSource)).BeginInit();
            this.tableLayoutPanelButtons.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 7;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.Controls.Add(this.labelStartDate, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.labelName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelEndDate, 5, 0);
            this.tableLayoutPanel.Controls.Add(this.textBoxName, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.dateTimePickerStart, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.dateTimePickerEnd, 5, 1);
            this.tableLayoutPanel.Controls.Add(this.dataGridView, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanelButtons, 3, 3);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1070, 603);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // labelStartDate
            // 
            this.labelStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelStartDate.Location = new System.Drawing.Point(387, 35);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(97, 25);
            this.labelStartDate.TabIndex = 8;
            this.labelStartDate.Text = "Start date";
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelName.Location = new System.Drawing.Point(56, 35);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(62, 25);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Name";
            // 
            // labelEndDate
            // 
            this.labelEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEndDate.Location = new System.Drawing.Point(718, 35);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(87, 25);
            this.labelEndDate.TabIndex = 9;
            this.labelEndDate.Text = "End date";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Font = new System.Drawing.Font("Bradley Hand ITC", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxName.Location = new System.Drawing.Point(56, 63);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(293, 30);
            this.textBoxName.TabIndex = 5;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(387, 63);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(293, 31);
            this.dateTimePickerStart.TabIndex = 6;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(718, 63);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(293, 31);
            this.dateTimePickerEnd.TabIndex = 7;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.soapsDataGridViewTextBoxColumn,
            this.mainCoursesDataGridViewTextBoxColumn,
            this.dessertsDataGridViewTextBoxColumn,
            this.snacksDataGridViewTextBoxColumn,
            this.othersDataGridViewTextBoxColumn});
            this.tableLayoutPanel.SetColumnSpan(this.dataGridView, 5);
            this.dataGridView.DataSource = this.mealModelBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(56, 123);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 33;
            this.dataGridView.Size = new System.Drawing.Size(955, 401);
            this.dataGridView.TabIndex = 3;
            // 
            // mealModelBindingSource
            // 
            this.mealModelBindingSource.DataSource = typeof(DTO.MealModel);
            // 
            // tableLayoutPanelButtons
            // 
            this.tableLayoutPanelButtons.ColumnCount = 2;
            this.tableLayoutPanel.SetColumnSpan(this.tableLayoutPanelButtons, 3);
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.70513F));
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.29487F));
            this.tableLayoutPanelButtons.Controls.Add(this.buttonCancel, 0, 0);
            this.tableLayoutPanelButtons.Controls.Add(this.buttonSave, 1, 0);
            this.tableLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelButtons.Location = new System.Drawing.Point(387, 545);
            this.tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            this.tableLayoutPanelButtons.RowCount = 1;
            this.tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelButtons.Size = new System.Drawing.Size(624, 55);
            this.tableLayoutPanelButtons.TabIndex = 10;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(295, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 34);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(509, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(112, 34);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(135, 36);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(134, 32);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Meal name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // soapsDataGridViewTextBoxColumn
            // 
            this.soapsDataGridViewTextBoxColumn.DataPropertyName = "Soaps";
            this.soapsDataGridViewTextBoxColumn.HeaderText = "Soaps";
            this.soapsDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.soapsDataGridViewTextBoxColumn.Name = "soapsDataGridViewTextBoxColumn";
            this.soapsDataGridViewTextBoxColumn.Width = 150;
            // 
            // mainCoursesDataGridViewTextBoxColumn
            // 
            this.mainCoursesDataGridViewTextBoxColumn.DataPropertyName = "MainCourses";
            this.mainCoursesDataGridViewTextBoxColumn.HeaderText = "MainCourses";
            this.mainCoursesDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.mainCoursesDataGridViewTextBoxColumn.Name = "mainCoursesDataGridViewTextBoxColumn";
            this.mainCoursesDataGridViewTextBoxColumn.Width = 150;
            // 
            // dessertsDataGridViewTextBoxColumn
            // 
            this.dessertsDataGridViewTextBoxColumn.DataPropertyName = "Desserts";
            this.dessertsDataGridViewTextBoxColumn.HeaderText = "Desserts";
            this.dessertsDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.dessertsDataGridViewTextBoxColumn.Name = "dessertsDataGridViewTextBoxColumn";
            this.dessertsDataGridViewTextBoxColumn.Width = 150;
            // 
            // snacksDataGridViewTextBoxColumn
            // 
            this.snacksDataGridViewTextBoxColumn.DataPropertyName = "Snacks";
            this.snacksDataGridViewTextBoxColumn.HeaderText = "Snacks";
            this.snacksDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.snacksDataGridViewTextBoxColumn.Name = "snacksDataGridViewTextBoxColumn";
            this.snacksDataGridViewTextBoxColumn.Width = 150;
            // 
            // othersDataGridViewTextBoxColumn
            // 
            this.othersDataGridViewTextBoxColumn.DataPropertyName = "Others";
            this.othersDataGridViewTextBoxColumn.HeaderText = "Others";
            this.othersDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.othersDataGridViewTextBoxColumn.Name = "othersDataGridViewTextBoxColumn";
            this.othersDataGridViewTextBoxColumn.Width = 150;
            // 
            // PlanModelPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 603);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "PlanModelPage";
            this.Text = "PlanModelPage";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mealModelBindingSource)).EndInit();
            this.tableLayoutPanelButtons.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private Button buttonSave;
        private Button buttonCancel;
        private DataGridView dataGridView;
        private BindingSource mealModelBindingSource;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private Label labelName;
        private TextBox textBoxName;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private Label labelStartDate;
        private Label labelEndDate;
        private TableLayoutPanel tableLayoutPanelButtons;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn soapsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mainCoursesDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dessertsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn snacksDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn othersDataGridViewTextBoxColumn;
    }
}