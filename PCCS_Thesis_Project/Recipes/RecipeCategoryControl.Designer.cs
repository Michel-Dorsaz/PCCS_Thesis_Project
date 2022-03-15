namespace UI.Recipes
{
    partial class RecipeCategoryControl
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
            this.panelReliure = new System.Windows.Forms.Panel();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelLine = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelCategoryText = new System.Windows.Forms.Label();
            this.labelWPP = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.numericUpDownWPP = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWPP)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel.Controls.Add(this.panelReliure, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelCategory, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.labelName, 2, 4);
            this.tableLayoutPanel.Controls.Add(this.labelLine, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.labelTitle, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelCategoryText, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.labelWPP, 2, 7);
            this.tableLayoutPanel.Controls.Add(this.textBoxName, 2, 5);
            this.tableLayoutPanel.Controls.Add(this.numericUpDownWPP, 2, 8);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 10;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(765, 422);
            this.tableLayoutPanel.TabIndex = 0;
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
            this.panelReliure.Size = new System.Drawing.Size(32, 416);
            this.panelReliure.TabIndex = 7;
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCategory.Location = new System.Drawing.Point(79, 41);
            this.labelCategory.MinimumSize = new System.Drawing.Size(100, 25);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(683, 25);
            this.labelCategory.TabIndex = 1;
            this.labelCategory.Text = "Category";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelName.Location = new System.Drawing.Point(79, 83);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(683, 21);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            // 
            // labelLine
            // 
            this.labelLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel.SetColumnSpan(this.labelLine, 2);
            this.labelLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelLine.Location = new System.Drawing.Point(41, 39);
            this.labelLine.Name = "labelLine";
            this.labelLine.Size = new System.Drawing.Size(721, 2);
            this.labelLine.TabIndex = 6;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.labelTitle, 2);
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.Location = new System.Drawing.Point(41, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(721, 29);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "Category";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labelCategoryText
            // 
            this.labelCategoryText.AutoSize = true;
            this.labelCategoryText.BackColor = System.Drawing.SystemColors.Window;
            this.labelCategoryText.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCategoryText.Location = new System.Drawing.Point(79, 62);
            this.labelCategoryText.Name = "labelCategoryText";
            this.labelCategoryText.Size = new System.Drawing.Size(683, 21);
            this.labelCategoryText.TabIndex = 7;
            // 
            // labelWPP
            // 
            this.labelWPP.AutoSize = true;
            this.labelWPP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelWPP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelWPP.Location = new System.Drawing.Point(79, 146);
            this.labelWPP.Name = "labelWPP";
            this.labelWPP.Size = new System.Drawing.Size(683, 21);
            this.labelWPP.TabIndex = 8;
            this.labelWPP.Text = "WPP";
            // 
            // textBoxName
            // 
            this.textBoxName.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxName.Font = new System.Drawing.Font("Bradley Hand ITC", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxName.Location = new System.Drawing.Point(79, 107);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(683, 30);
            this.textBoxName.TabIndex = 2;
            this.textBoxName.TextChanged += new System.EventHandler(this.TextBoxName_TextChanged);
            // 
            // numericUpDownWPP
            // 
            this.numericUpDownWPP.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.numericUpDownWPP.Location = new System.Drawing.Point(79, 170);
            this.numericUpDownWPP.Name = "numericUpDownWPP";
            this.numericUpDownWPP.Size = new System.Drawing.Size(180, 31);
            this.numericUpDownWPP.TabIndex = 9;
            this.numericUpDownWPP.ValueChanged += new System.EventHandler(this.NumericUpDownWPP_ValueChanged);
            // 
            // RecipeCategoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "RecipeCategoryControl";
            this.Size = new System.Drawing.Size(765, 422);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWPP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private Label labelName;
        private Label labelCategory;
        private Panel panelReliure;
        private Label labelTitle;
        private TextBox textBoxName;
        private Label labelLine;
        private Label labelCategoryText;
        private Label labelWPP;
        private NumericUpDown numericUpDownWPP;
    }
}
