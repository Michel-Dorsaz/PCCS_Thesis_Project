namespace UI.Ingredients
{
    partial class IngredientControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.panelReliure = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelLine = new System.Windows.Forms.Label();
            this.labelCategoryText = new System.Windows.Forms.Label();
            this.groupBoxNutrients = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelNutrients = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownProtein = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownGlucid = new System.Windows.Forms.NumericUpDown();
            this.labelProtein = new System.Windows.Forms.Label();
            this.labelLipid = new System.Windows.Forms.Label();
            this.labelGlucid = new System.Windows.Forms.Label();
            this.numericUpDownLipid = new System.Windows.Forms.NumericUpDown();
            this.labelQuantityType = new System.Windows.Forms.Label();
            this.comboBoxQuantityType = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel.SuspendLayout();
            this.groupBoxNutrients.SuspendLayout();
            this.tableLayoutPanelNutrients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProtein)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGlucid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLipid)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.Controls.Add(this.labelCategory, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.labelName, 2, 4);
            this.tableLayoutPanel.Controls.Add(this.textBoxName, 2, 5);
            this.tableLayoutPanel.Controls.Add(this.panelReliure, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelTitle, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelLine, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.labelCategoryText, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.groupBoxNutrients, 2, 8);
            this.tableLayoutPanel.Controls.Add(this.labelQuantityType, 2, 6);
            this.tableLayoutPanel.Controls.Add(this.comboBoxQuantityType, 2, 7);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 10;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(627, 431);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCategory.Location = new System.Drawing.Point(65, 42);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(526, 21);
            this.labelCategory.TabIndex = 2;
            this.labelCategory.Text = "Category";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelName.Location = new System.Drawing.Point(65, 84);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(526, 21);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxName.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxName.Font = new System.Drawing.Font("Bradley Hand ITC", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxName.Location = new System.Drawing.Point(65, 108);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(526, 30);
            this.textBoxName.TabIndex = 4;
            this.textBoxName.TextChanged += new System.EventHandler(this.TextBoxName_TextChanged);
            // 
            // panelReliure
            // 
            this.panelReliure.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelReliure.BackgroundImage = global::UI.Properties.Resources.Reliure;
            this.panelReliure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelReliure.Location = new System.Drawing.Point(3, 3);
            this.panelReliure.Name = "panelReliure";
            this.tableLayoutPanel.SetRowSpan(this.panelReliure, 10);
            this.panelReliure.Size = new System.Drawing.Size(25, 425);
            this.panelReliure.TabIndex = 7;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.labelTitle, 2);
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.ForeColor = System.Drawing.Color.SaddleBrown;
            this.labelTitle.Location = new System.Drawing.Point(34, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(557, 30);
            this.labelTitle.TabIndex = 8;
            this.labelTitle.Text = "Ingredient";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labelLine
            // 
            this.labelLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel.SetColumnSpan(this.labelLine, 2);
            this.labelLine.Location = new System.Drawing.Point(34, 40);
            this.labelLine.Name = "labelLine";
            this.labelLine.Size = new System.Drawing.Size(557, 2);
            this.labelLine.TabIndex = 9;
            // 
            // labelCategoryText
            // 
            this.labelCategoryText.AutoSize = true;
            this.labelCategoryText.BackColor = System.Drawing.SystemColors.Window;
            this.labelCategoryText.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCategoryText.Location = new System.Drawing.Point(65, 63);
            this.labelCategoryText.Name = "labelCategoryText";
            this.labelCategoryText.Size = new System.Drawing.Size(526, 21);
            this.labelCategoryText.TabIndex = 10;
            // 
            // groupBoxNutrients
            // 
            this.groupBoxNutrients.Controls.Add(this.tableLayoutPanelNutrients);
            this.groupBoxNutrients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxNutrients.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxNutrients.Location = new System.Drawing.Point(65, 215);
            this.groupBoxNutrients.Name = "groupBoxNutrients";
            this.groupBoxNutrients.Size = new System.Drawing.Size(526, 166);
            this.groupBoxNutrients.TabIndex = 6;
            this.groupBoxNutrients.TabStop = false;
            this.groupBoxNutrients.Text = "Nutrients :";
            // 
            // tableLayoutPanelNutrients
            // 
            this.tableLayoutPanelNutrients.ColumnCount = 2;
            this.tableLayoutPanelNutrients.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelNutrients.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelNutrients.Controls.Add(this.numericUpDownProtein, 1, 3);
            this.tableLayoutPanelNutrients.Controls.Add(this.numericUpDownGlucid, 1, 2);
            this.tableLayoutPanelNutrients.Controls.Add(this.labelProtein, 0, 3);
            this.tableLayoutPanelNutrients.Controls.Add(this.labelLipid, 0, 1);
            this.tableLayoutPanelNutrients.Controls.Add(this.labelGlucid, 0, 2);
            this.tableLayoutPanelNutrients.Controls.Add(this.numericUpDownLipid, 1, 1);
            this.tableLayoutPanelNutrients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelNutrients.Location = new System.Drawing.Point(3, 27);
            this.tableLayoutPanelNutrients.Name = "tableLayoutPanelNutrients";
            this.tableLayoutPanelNutrients.RowCount = 4;
            this.tableLayoutPanelNutrients.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelNutrients.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelNutrients.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelNutrients.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelNutrients.Size = new System.Drawing.Size(520, 136);
            this.tableLayoutPanelNutrients.TabIndex = 0;
            // 
            // numericUpDownProtein
            // 
            this.numericUpDownProtein.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.numericUpDownProtein.Location = new System.Drawing.Point(159, 105);
            this.numericUpDownProtein.Name = "numericUpDownProtein";
            this.numericUpDownProtein.Size = new System.Drawing.Size(180, 31);
            this.numericUpDownProtein.TabIndex = 10;
            // 
            // numericUpDownGlucid
            // 
            this.numericUpDownGlucid.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.numericUpDownGlucid.Location = new System.Drawing.Point(159, 71);
            this.numericUpDownGlucid.Name = "numericUpDownGlucid";
            this.numericUpDownGlucid.Size = new System.Drawing.Size(180, 31);
            this.numericUpDownGlucid.TabIndex = 9;
            // 
            // labelProtein
            // 
            this.labelProtein.AutoSize = true;
            this.labelProtein.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelProtein.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelProtein.Location = new System.Drawing.Point(3, 102);
            this.labelProtein.Name = "labelProtein";
            this.labelProtein.Size = new System.Drawing.Size(150, 25);
            this.labelProtein.TabIndex = 7;
            this.labelProtein.Text = "Protein";
            // 
            // labelLipid
            // 
            this.labelLipid.AutoSize = true;
            this.labelLipid.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLipid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLipid.Location = new System.Drawing.Point(3, 34);
            this.labelLipid.Name = "labelLipid";
            this.labelLipid.Size = new System.Drawing.Size(150, 25);
            this.labelLipid.TabIndex = 4;
            this.labelLipid.Text = "Lipid";
            // 
            // labelGlucid
            // 
            this.labelGlucid.AutoSize = true;
            this.labelGlucid.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGlucid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelGlucid.Location = new System.Drawing.Point(3, 68);
            this.labelGlucid.Name = "labelGlucid";
            this.labelGlucid.Size = new System.Drawing.Size(150, 25);
            this.labelGlucid.TabIndex = 6;
            this.labelGlucid.Text = "Glucid";
            // 
            // numericUpDownLipid
            // 
            this.numericUpDownLipid.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.numericUpDownLipid.Location = new System.Drawing.Point(159, 37);
            this.numericUpDownLipid.Name = "numericUpDownLipid";
            this.numericUpDownLipid.Size = new System.Drawing.Size(180, 31);
            this.numericUpDownLipid.TabIndex = 8;
            // 
            // labelQuantityType
            // 
            this.labelQuantityType.AutoSize = true;
            this.labelQuantityType.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelQuantityType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelQuantityType.Location = new System.Drawing.Point(65, 148);
            this.labelQuantityType.Name = "labelQuantityType";
            this.labelQuantityType.Size = new System.Drawing.Size(526, 21);
            this.labelQuantityType.TabIndex = 11;
            this.labelQuantityType.Text = "Quantity Type";
            // 
            // comboBoxQuantityType
            // 
            this.comboBoxQuantityType.FormattingEnabled = true;
            this.comboBoxQuantityType.Location = new System.Drawing.Point(65, 172);
            this.comboBoxQuantityType.Name = "comboBoxQuantityType";
            this.comboBoxQuantityType.Size = new System.Drawing.Size(182, 33);
            this.comboBoxQuantityType.TabIndex = 12;
            // 
            // IngredientControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "IngredientControl";
            this.Size = new System.Drawing.Size(627, 431);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.groupBoxNutrients.ResumeLayout(false);
            this.tableLayoutPanelNutrients.ResumeLayout(false);
            this.tableLayoutPanelNutrients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProtein)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGlucid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLipid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private Label labelName;
        private Label labelCategory;
        private TextBox textBoxName;
        private GroupBox groupBoxNutrients;
        private TableLayoutPanel tableLayoutPanelNutrients;
        private NumericUpDown numericUpDownProtein;
        private NumericUpDown numericUpDownGlucid;
        private Label labelProtein;
        private Label labelLipid;
        private Label labelGlucid;
        private NumericUpDown numericUpDownLipid;
        private Panel panelReliure;
        private Label labelTitle;
        private Label labelLine;
        private Label labelCategoryText;
        private Label labelQuantityType;
        private ComboBox comboBoxQuantityType;
    }
}
