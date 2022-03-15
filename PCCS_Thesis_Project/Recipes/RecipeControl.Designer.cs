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
            this.numericUpDownWPP = new System.Windows.Forms.NumericUpDown();
            this.labelWPP = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.panelReliure = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelLine = new System.Windows.Forms.Label();
            this.labelCategoryText = new System.Windows.Forms.Label();
            this.groupBoxIngredients = new System.Windows.Forms.GroupBox();
            this.richTextBoxIngredients = new System.Windows.Forms.RichTextBox();
            this.groupBoxPreparations = new System.Windows.Forms.GroupBox();
            this.richTextBoxPreparations = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWPP)).BeginInit();
            this.groupBoxIngredients.SuspendLayout();
            this.groupBoxPreparations.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel.Controls.Add(this.numericUpDownWPP, 2, 7);
            this.tableLayoutPanel.Controls.Add(this.labelWPP, 2, 6);
            this.tableLayoutPanel.Controls.Add(this.labelCategory, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.labelName, 2, 4);
            this.tableLayoutPanel.Controls.Add(this.textBoxName, 2, 5);
            this.tableLayoutPanel.Controls.Add(this.panelReliure, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelTitle, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelLine, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.labelCategoryText, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.groupBoxIngredients, 2, 8);
            this.tableLayoutPanel.Controls.Add(this.groupBoxPreparations, 2, 9);
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
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(627, 431);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // numericUpDownWPP
            // 
            this.numericUpDownWPP.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.numericUpDownWPP.Location = new System.Drawing.Point(65, 172);
            this.numericUpDownWPP.Name = "numericUpDownWPP";
            this.numericUpDownWPP.Size = new System.Drawing.Size(180, 31);
            this.numericUpDownWPP.TabIndex = 9;
            this.numericUpDownWPP.ValueChanged += new System.EventHandler(this.NumericUpDownWPP_ValueChanged);
            // 
            // labelWPP
            // 
            this.labelWPP.AutoSize = true;
            this.labelWPP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelWPP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelWPP.Location = new System.Drawing.Point(65, 148);
            this.labelWPP.Name = "labelWPP";
            this.labelWPP.Size = new System.Drawing.Size(559, 21);
            this.labelWPP.TabIndex = 6;
            this.labelWPP.Text = "WPP";
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCategory.Location = new System.Drawing.Point(65, 42);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(559, 21);
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
            this.labelName.Size = new System.Drawing.Size(559, 21);
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
            this.textBoxName.Size = new System.Drawing.Size(559, 30);
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
            this.labelTitle.Size = new System.Drawing.Size(590, 30);
            this.labelTitle.TabIndex = 8;
            this.labelTitle.Text = "Recipe";
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
            this.labelLine.Size = new System.Drawing.Size(590, 2);
            this.labelLine.TabIndex = 9;
            // 
            // labelCategoryText
            // 
            this.labelCategoryText.AutoSize = true;
            this.labelCategoryText.BackColor = System.Drawing.SystemColors.Window;
            this.labelCategoryText.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCategoryText.Location = new System.Drawing.Point(65, 63);
            this.labelCategoryText.Name = "labelCategoryText";
            this.labelCategoryText.Size = new System.Drawing.Size(559, 21);
            this.labelCategoryText.TabIndex = 10;
            // 
            // groupBoxIngredients
            // 
            this.groupBoxIngredients.Controls.Add(this.richTextBoxIngredients);
            this.groupBoxIngredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxIngredients.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxIngredients.Location = new System.Drawing.Point(65, 215);
            this.groupBoxIngredients.Name = "groupBoxIngredients";
            this.groupBoxIngredients.Size = new System.Drawing.Size(559, 101);
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
            this.richTextBoxIngredients.Size = new System.Drawing.Size(553, 71);
            this.richTextBoxIngredients.TabIndex = 0;
            this.richTextBoxIngredients.Text = "Click here to add ingredients !\n";
            // 
            // groupBoxPreparations
            // 
            this.groupBoxPreparations.Controls.Add(this.richTextBoxPreparations);
            this.groupBoxPreparations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPreparations.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxPreparations.Location = new System.Drawing.Point(65, 322);
            this.groupBoxPreparations.Name = "groupBoxPreparations";
            this.groupBoxPreparations.Size = new System.Drawing.Size(559, 106);
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
            this.richTextBoxPreparations.Size = new System.Drawing.Size(553, 76);
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
            this.Size = new System.Drawing.Size(627, 431);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
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
    }
}
