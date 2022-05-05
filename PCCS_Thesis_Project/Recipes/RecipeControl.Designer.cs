namespace UI.Recipes
{
    partial class RecipeControl
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelLine = new System.Windows.Forms.Label();
            this.tableLayoutPanelProperties = new System.Windows.Forms.TableLayoutPanel();
            this.labelName = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelCategoryText = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelWPP = new System.Windows.Forms.Label();
            this.labelPortions = new System.Windows.Forms.Label();
            this.numericUpDownPortions = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWPP = new System.Windows.Forms.NumericUpDown();
            this.groupBoxIngredients = new System.Windows.Forms.GroupBox();
            this.richTextBoxIngredients = new System.Windows.Forms.RichTextBox();
            this.groupBoxPreparations = new System.Windows.Forms.GroupBox();
            this.richTextBoxPreparations = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel.SuspendLayout();
            this.tableLayoutPanelProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPortions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWPP)).BeginInit();
            this.groupBoxIngredients.SuspendLayout();
            this.groupBoxPreparations.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.99673F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.99673F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.0058F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.000741F));
            this.tableLayoutPanel.Controls.Add(this.panelReliure, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelTitle, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelLine, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanelProperties, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.groupBoxIngredients, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.groupBoxPreparations, 2, 4);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1471, 772);
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
            this.tableLayoutPanel.SetRowSpan(this.panelReliure, 6);
            this.panelReliure.Size = new System.Drawing.Size(67, 766);
            this.panelReliure.TabIndex = 7;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.labelTitle, 3);
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.ForeColor = System.Drawing.Color.SaddleBrown;
            this.labelTitle.Location = new System.Drawing.Point(76, 14);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(1392, 32);
            this.labelTitle.TabIndex = 8;
            this.labelTitle.Text = "Recipe";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labelLine
            // 
            this.labelLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelLine.Location = new System.Drawing.Point(149, 67);
            this.labelLine.Name = "labelLine";
            this.labelLine.Size = new System.Drawing.Size(1244, 2);
            this.labelLine.TabIndex = 9;
            // 
            // tableLayoutPanelProperties
            // 
            this.tableLayoutPanelProperties.ColumnCount = 2;
            this.tableLayoutPanelProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelProperties.Controls.Add(this.labelName, 0, 2);
            this.tableLayoutPanelProperties.Controls.Add(this.labelCategory, 0, 0);
            this.tableLayoutPanelProperties.Controls.Add(this.labelCategoryText, 0, 1);
            this.tableLayoutPanelProperties.Controls.Add(this.textBoxName, 0, 3);
            this.tableLayoutPanelProperties.Controls.Add(this.labelWPP, 1, 4);
            this.tableLayoutPanelProperties.Controls.Add(this.labelPortions, 0, 4);
            this.tableLayoutPanelProperties.Controls.Add(this.numericUpDownPortions, 0, 5);
            this.tableLayoutPanelProperties.Controls.Add(this.numericUpDownWPP, 1, 5);
            this.tableLayoutPanelProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelProperties.Location = new System.Drawing.Point(149, 72);
            this.tableLayoutPanelProperties.MinimumSize = new System.Drawing.Size(0, 200);
            this.tableLayoutPanelProperties.Name = "tableLayoutPanelProperties";
            this.tableLayoutPanelProperties.RowCount = 6;
            this.tableLayoutPanelProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanelProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanelProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanelProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanelProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanelProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanelProperties.Size = new System.Drawing.Size(1244, 241);
            this.tableLayoutPanelProperties.TabIndex = 13;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelName.Location = new System.Drawing.Point(3, 94);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(616, 25);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name";
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCategory.Location = new System.Drawing.Point(3, 18);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(616, 25);
            this.labelCategory.TabIndex = 2;
            this.labelCategory.Text = "Category";
            // 
            // labelCategoryText
            // 
            this.labelCategoryText.AutoSize = true;
            this.labelCategoryText.BackColor = System.Drawing.SystemColors.Window;
            this.labelCategoryText.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCategoryText.Location = new System.Drawing.Point(3, 43);
            this.labelCategoryText.Name = "labelCategoryText";
            this.labelCategoryText.Size = new System.Drawing.Size(616, 25);
            this.labelCategoryText.TabIndex = 10;
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxName.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxName.Font = new System.Drawing.Font("Bradley Hand ITC", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxName.Location = new System.Drawing.Point(3, 122);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(616, 30);
            this.textBoxName.TabIndex = 4;
            this.textBoxName.TextChanged += new System.EventHandler(this.TextBoxName_TextChanged);
            // 
            // labelWPP
            // 
            this.labelWPP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelWPP.AutoSize = true;
            this.labelWPP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelWPP.Location = new System.Drawing.Point(625, 170);
            this.labelWPP.Name = "labelWPP";
            this.labelWPP.Size = new System.Drawing.Size(82, 25);
            this.labelWPP.TabIndex = 6;
            this.labelWPP.Text = "WPP (g)";
            // 
            // labelPortions
            // 
            this.labelPortions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPortions.AutoSize = true;
            this.labelPortions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPortions.Location = new System.Drawing.Point(3, 170);
            this.labelPortions.Name = "labelPortions";
            this.labelPortions.Size = new System.Drawing.Size(83, 25);
            this.labelPortions.TabIndex = 11;
            this.labelPortions.Text = "Portions";
            // 
            // numericUpDownPortions
            // 
            this.numericUpDownPortions.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.numericUpDownPortions.Location = new System.Drawing.Point(3, 198);
            this.numericUpDownPortions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPortions.Name = "numericUpDownPortions";
            this.numericUpDownPortions.Size = new System.Drawing.Size(96, 31);
            this.numericUpDownPortions.TabIndex = 12;
            this.numericUpDownPortions.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPortions.ValueChanged += new System.EventHandler(this.NumericUpDownPortions_ValueChanged);
            // 
            // numericUpDownWPP
            // 
            this.numericUpDownWPP.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.numericUpDownWPP.Location = new System.Drawing.Point(625, 198);
            this.numericUpDownWPP.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownWPP.Name = "numericUpDownWPP";
            this.numericUpDownWPP.Size = new System.Drawing.Size(117, 31);
            this.numericUpDownWPP.TabIndex = 9;
            this.numericUpDownWPP.ValueChanged += new System.EventHandler(this.NumericUpDownWPP_ValueChanged);
            // 
            // groupBoxIngredients
            // 
            this.groupBoxIngredients.Controls.Add(this.richTextBoxIngredients);
            this.groupBoxIngredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxIngredients.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxIngredients.Location = new System.Drawing.Point(149, 319);
            this.groupBoxIngredients.Name = "groupBoxIngredients";
            this.groupBoxIngredients.Size = new System.Drawing.Size(1244, 210);
            this.groupBoxIngredients.TabIndex = 6;
            this.groupBoxIngredients.TabStop = false;
            this.groupBoxIngredients.Text = "Ingredients :";
            // 
            // richTextBoxIngredients
            // 
            this.richTextBoxIngredients.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxIngredients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxIngredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxIngredients.Font = new System.Drawing.Font("Bradley Hand ITC", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.richTextBoxIngredients.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.richTextBoxIngredients.Location = new System.Drawing.Point(3, 27);
            this.richTextBoxIngredients.Name = "richTextBoxIngredients";
            this.richTextBoxIngredients.ReadOnly = true;
            this.richTextBoxIngredients.Size = new System.Drawing.Size(1238, 180);
            this.richTextBoxIngredients.TabIndex = 0;
            this.richTextBoxIngredients.Text = "Click here to add ingredients !\n";
            // 
            // groupBoxPreparations
            // 
            this.groupBoxPreparations.Controls.Add(this.richTextBoxPreparations);
            this.groupBoxPreparations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPreparations.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxPreparations.Location = new System.Drawing.Point(149, 535);
            this.groupBoxPreparations.Name = "groupBoxPreparations";
            this.groupBoxPreparations.Size = new System.Drawing.Size(1244, 210);
            this.groupBoxPreparations.TabIndex = 7;
            this.groupBoxPreparations.TabStop = false;
            this.groupBoxPreparations.Text = "Preparations :";
            // 
            // richTextBoxPreparations
            // 
            this.richTextBoxPreparations.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxPreparations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxPreparations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxPreparations.Font = new System.Drawing.Font("Bradley Hand ITC", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.richTextBoxPreparations.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.richTextBoxPreparations.Location = new System.Drawing.Point(3, 27);
            this.richTextBoxPreparations.Name = "richTextBoxPreparations";
            this.richTextBoxPreparations.Size = new System.Drawing.Size(1238, 180);
            this.richTextBoxPreparations.TabIndex = 0;
            this.richTextBoxPreparations.Text = "";
            // 
            // RecipeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "RecipeControl";
            this.Size = new System.Drawing.Size(1471, 772);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.tableLayoutPanelProperties.ResumeLayout(false);
            this.tableLayoutPanelProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPortions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWPP)).EndInit();
            this.groupBoxIngredients.ResumeLayout(false);
            this.groupBoxPreparations.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private Label labelName;
        private Label labelCategory;
        private TextBox textBoxName;
        private GroupBox groupBoxIngredients;
        private NumericUpDown numericUpDownWPP;
        private Label labelWPP;
        private Panel panelReliure;
        private Label labelTitle;
        private Label labelLine;
        private Label labelCategoryText;
        private RichTextBox richTextBoxIngredients;
        private GroupBox groupBoxPreparations;
        private RichTextBox richTextBoxPreparations;
        private Label labelPortions;
        private NumericUpDown numericUpDownPortions;
        private TableLayoutPanel tableLayoutPanelProperties;
    }
}
