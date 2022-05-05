namespace UI.Recipes
{
    partial class QuantitiesSelectionForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonValidate = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeasureColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.quantityTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanelNutriments = new System.Windows.Forms.TableLayoutPanel();
            this.labelGlucid = new System.Windows.Forms.Label();
            this.labelLipid = new System.Windows.Forms.Label();
            this.labelProtein = new System.Windows.Forms.Label();
            this.labelGlucidValue = new System.Windows.Forms.Label();
            this.labelLipidValue = new System.Windows.Forms.Label();
            this.labelProteinValue = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityTypeBindingSource)).BeginInit();
            this.tableLayoutPanelNutriments.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.buttonValidate, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelNutriments, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // buttonValidate
            // 
            this.buttonValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonValidate.BackColor = System.Drawing.SystemColors.Window;
            this.buttonValidate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonValidate.Location = new System.Drawing.Point(627, 392);
            this.buttonValidate.Name = "buttonValidate";
            this.buttonValidate.Size = new System.Drawing.Size(111, 34);
            this.buttonValidate.TabIndex = 1;
            this.buttonValidate.Text = "Continue";
            this.buttonValidate.UseVisualStyleBackColor = false;
            this.buttonValidate.Click += new System.EventHandler(this.ButtonValue_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.IngredientColumn,
            this.QuantityColumn,
            this.MeasureColumn});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView, 2);
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(42, 70);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 33;
            this.dataGridView.Size = new System.Drawing.Size(696, 316);
            this.dataGridView.TabIndex = 2;
            // 
            // IdColumn
            // 
            this.IdColumn.HeaderText = "Index number";
            this.IdColumn.MinimumWidth = 8;
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            this.IdColumn.Width = 150;
            // 
            // IngredientColumn
            // 
            this.IngredientColumn.HeaderText = "Ingredient";
            this.IngredientColumn.MinimumWidth = 8;
            this.IngredientColumn.Name = "IngredientColumn";
            this.IngredientColumn.ReadOnly = true;
            this.IngredientColumn.Width = 150;
            // 
            // QuantityColumn
            // 
            this.QuantityColumn.HeaderText = "Quantity";
            this.QuantityColumn.MinimumWidth = 8;
            this.QuantityColumn.Name = "QuantityColumn";
            this.QuantityColumn.Width = 150;
            // 
            // MeasureColumn
            // 
            this.MeasureColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.MeasureColumn.HeaderText = "Measure";
            this.MeasureColumn.MinimumWidth = 8;
            this.MeasureColumn.Name = "MeasureColumn";
            this.MeasureColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MeasureColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MeasureColumn.Width = 150;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.BackColor = System.Drawing.SystemColors.Window;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCancel.Location = new System.Drawing.Point(509, 392);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 34);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Return";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // quantityTypeBindingSource
            // 
            this.quantityTypeBindingSource.DataSource = typeof(DTO.QuantityType);
            // 
            // tableLayoutPanelNutriments
            // 
            this.tableLayoutPanelNutriments.ColumnCount = 4;
            this.tableLayoutPanelNutriments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelNutriments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelNutriments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelNutriments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelNutriments.Controls.Add(this.labelGlucid, 1, 0);
            this.tableLayoutPanelNutriments.Controls.Add(this.labelLipid, 2, 0);
            this.tableLayoutPanelNutriments.Controls.Add(this.labelProtein, 3, 0);
            this.tableLayoutPanelNutriments.Controls.Add(this.labelGlucidValue, 1, 1);
            this.tableLayoutPanelNutriments.Controls.Add(this.labelLipidValue, 2, 1);
            this.tableLayoutPanelNutriments.Controls.Add(this.labelProteinValue, 3, 1);
            this.tableLayoutPanelNutriments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelNutriments.Location = new System.Drawing.Point(42, 23);
            this.tableLayoutPanelNutriments.Name = "tableLayoutPanelNutriments";
            this.tableLayoutPanelNutriments.RowCount = 2;
            this.tableLayoutPanelNutriments.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelNutriments.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelNutriments.Size = new System.Drawing.Size(579, 41);
            this.tableLayoutPanelNutriments.TabIndex = 4;
            // 
            // labelGlucid
            // 
            this.labelGlucid.AutoSize = true;
            this.labelGlucid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelGlucid.Location = new System.Drawing.Point(60, 0);
            this.labelGlucid.Name = "labelGlucid";
            this.labelGlucid.Size = new System.Drawing.Size(87, 20);
            this.labelGlucid.TabIndex = 0;
            this.labelGlucid.Text = "Glucid %";
            // 
            // labelLipid
            // 
            this.labelLipid.AutoSize = true;
            this.labelLipid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLipid.Location = new System.Drawing.Point(233, 0);
            this.labelLipid.Name = "labelLipid";
            this.labelLipid.Size = new System.Drawing.Size(74, 20);
            this.labelLipid.TabIndex = 1;
            this.labelLipid.Text = "Lipid %";
            // 
            // labelProtein
            // 
            this.labelProtein.AutoSize = true;
            this.labelProtein.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelProtein.Location = new System.Drawing.Point(406, 0);
            this.labelProtein.Name = "labelProtein";
            this.labelProtein.Size = new System.Drawing.Size(95, 20);
            this.labelProtein.TabIndex = 2;
            this.labelProtein.Text = "Protein %";
            // 
            // labelGlucidValue
            // 
            this.labelGlucidValue.AutoSize = true;
            this.labelGlucidValue.Location = new System.Drawing.Point(60, 20);
            this.labelGlucidValue.Name = "labelGlucidValue";
            this.labelGlucidValue.Size = new System.Drawing.Size(59, 21);
            this.labelGlucidValue.TabIndex = 3;
            this.labelGlucidValue.Text = "label4";
            // 
            // labelLipidValue
            // 
            this.labelLipidValue.AutoSize = true;
            this.labelLipidValue.Location = new System.Drawing.Point(233, 20);
            this.labelLipidValue.Name = "labelLipidValue";
            this.labelLipidValue.Size = new System.Drawing.Size(59, 21);
            this.labelLipidValue.TabIndex = 4;
            this.labelLipidValue.Text = "label5";
            // 
            // labelProteinValue
            // 
            this.labelProteinValue.AutoSize = true;
            this.labelProteinValue.Location = new System.Drawing.Point(406, 20);
            this.labelProteinValue.Name = "labelProteinValue";
            this.labelProteinValue.Size = new System.Drawing.Size(59, 21);
            this.labelProteinValue.TabIndex = 5;
            this.labelProteinValue.Text = "label6";
            // 
            // QuantitiesSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "QuantitiesSelectionForm";
            this.Text = "Quantities selection";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityTypeBindingSource)).EndInit();
            this.tableLayoutPanelNutriments.ResumeLayout(false);
            this.tableLayoutPanelNutriments.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private Button buttonValidate;
        private DataGridView dataGridView;
        private BindingSource quantityTypeBindingSource;
        private Button buttonCancel;
        private DataGridViewTextBoxColumn IdColumn;
        private DataGridViewTextBoxColumn IngredientColumn;
        private DataGridViewTextBoxColumn QuantityColumn;
        private DataGridViewComboBoxColumn MeasureColumn;
        private TableLayoutPanel tableLayoutPanelNutriments;
        private Label labelGlucid;
        private Label labelLipid;
        private Label labelProtein;
        private Label labelGlucidValue;
        private Label labelLipidValue;
        private Label labelProteinValue;
    }
}