namespace UI.Ingredients
{
    partial class IngredientsTreeviewControl
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.groupBoxDnDArea = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelDnD = new System.Windows.Forms.TableLayoutPanel();
            this.buttonNewIngredient = new System.Windows.Forms.Button();
            this.buttonNewCategory = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAbcSearch = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.groupBoxDnDArea.SuspendLayout();
            this.tableLayoutPanelDnD.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.Maroon;
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Controls.Add(this.treeView, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.groupBoxDnDArea, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.buttonAbcSearch, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(677, 448);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(3, 47);
            this.treeView.Name = "treeView";
            this.treeView.ShowNodeToolTips = true;
            this.treeView.Size = new System.Drawing.Size(671, 262);
            this.treeView.TabIndex = 1;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            // 
            // groupBoxDnDArea
            // 
            this.groupBoxDnDArea.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxDnDArea.Controls.Add(this.tableLayoutPanelDnD);
            this.groupBoxDnDArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDnDArea.Location = new System.Drawing.Point(3, 315);
            this.groupBoxDnDArea.MaximumSize = new System.Drawing.Size(0, 200);
            this.groupBoxDnDArea.MinimumSize = new System.Drawing.Size(220, 100);
            this.groupBoxDnDArea.Name = "groupBoxDnDArea";
            this.groupBoxDnDArea.Size = new System.Drawing.Size(671, 130);
            this.groupBoxDnDArea.TabIndex = 2;
            this.groupBoxDnDArea.TabStop = false;
            this.groupBoxDnDArea.Text = "Drag and drop area";
            // 
            // tableLayoutPanelDnD
            // 
            this.tableLayoutPanelDnD.ColumnCount = 2;
            this.tableLayoutPanelDnD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDnD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDnD.Controls.Add(this.buttonNewIngredient, 0, 0);
            this.tableLayoutPanelDnD.Controls.Add(this.buttonNewCategory, 0, 2);
            this.tableLayoutPanelDnD.Controls.Add(this.buttonDelete, 1, 0);
            this.tableLayoutPanelDnD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDnD.Location = new System.Drawing.Point(3, 27);
            this.tableLayoutPanelDnD.Name = "tableLayoutPanelDnD";
            this.tableLayoutPanelDnD.RowCount = 3;
            this.tableLayoutPanelDnD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanelDnD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelDnD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanelDnD.Size = new System.Drawing.Size(665, 100);
            this.tableLayoutPanelDnD.TabIndex = 0;
            // 
            // buttonNewIngredient
            // 
            this.buttonNewIngredient.BackColor = System.Drawing.SystemColors.Window;
            this.buttonNewIngredient.BackgroundImage = global::UI.Properties.Resources.button_newIngredient;
            this.buttonNewIngredient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNewIngredient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNewIngredient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNewIngredient.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonNewIngredient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNewIngredient.Location = new System.Drawing.Point(3, 3);
            this.buttonNewIngredient.Name = "buttonNewIngredient";
            this.buttonNewIngredient.Size = new System.Drawing.Size(326, 39);
            this.buttonNewIngredient.TabIndex = 0;
            this.buttonNewIngredient.UseVisualStyleBackColor = false;
            // 
            // buttonNewCategory
            // 
            this.buttonNewCategory.BackColor = System.Drawing.SystemColors.Window;
            this.buttonNewCategory.BackgroundImage = global::UI.Properties.Resources.button_newCategory;
            this.buttonNewCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNewCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNewCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNewCategory.Location = new System.Drawing.Point(3, 58);
            this.buttonNewCategory.Name = "buttonNewCategory";
            this.buttonNewCategory.Size = new System.Drawing.Size(326, 39);
            this.buttonNewCategory.TabIndex = 1;
            this.buttonNewCategory.UseVisualStyleBackColor = false;
            // 
            // buttonDelete
            // 
            this.buttonDelete.AllowDrop = true;
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.BackgroundImage = global::UI.Properties.Resources.delete;
            this.buttonDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDelete.Location = new System.Drawing.Point(550, 3);
            this.buttonDelete.Name = "buttonDelete";
            this.tableLayoutPanelDnD.SetRowSpan(this.buttonDelete, 3);
            this.buttonDelete.Size = new System.Drawing.Size(112, 94);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonAbcSearch
            // 
            this.buttonAbcSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAbcSearch.BackgroundImage = global::UI.Properties.Resources.Abc_search;
            this.buttonAbcSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAbcSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAbcSearch.Location = new System.Drawing.Point(562, 3);
            this.buttonAbcSearch.Name = "buttonAbcSearch";
            this.buttonAbcSearch.Size = new System.Drawing.Size(112, 38);
            this.buttonAbcSearch.TabIndex = 0;
            this.buttonAbcSearch.UseVisualStyleBackColor = true;
            // 
            // IngredientsTreeviewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "IngredientsTreeviewControl";
            this.Size = new System.Drawing.Size(677, 448);
            this.tableLayoutPanel.ResumeLayout(false);
            this.groupBoxDnDArea.ResumeLayout(false);
            this.tableLayoutPanelDnD.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private Button buttonAbcSearch;
        private TreeView treeView;
        private GroupBox groupBoxDnDArea;
        private TableLayoutPanel tableLayoutPanelDnD;
        private Button buttonNewIngredient;
        private Button buttonNewCategory;
        private Button buttonDelete;
    }
}
