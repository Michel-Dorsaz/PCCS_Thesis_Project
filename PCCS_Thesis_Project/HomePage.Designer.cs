using UI;

namespace PCCS_Thesis_Project
{
    partial class HomePage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.tableLayoutPanel = new UI.TableLayoutPaintImproved();
            this.labelInfo = new System.Windows.Forms.Label();
            this.buttonIngredient = new System.Windows.Forms.Button();
            this.buttonRecipe = new System.Windows.Forms.Button();
            this.buttonPlans = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel.Controls.Add(this.labelInfo, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.buttonIngredient, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.buttonRecipe, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.buttonPlans, 1, 5);
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 7;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(716, 389);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel.SetColumnSpan(this.labelInfo, 3);
            this.labelInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelInfo.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelInfo.Location = new System.Drawing.Point(3, 364);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(710, 25);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "Welcome !";
            // 
            // buttonIngredient
            // 
            this.buttonIngredient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonIngredient.BackColor = System.Drawing.Color.Transparent;
            this.buttonIngredient.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonIngredient.BackgroundImage")));
            this.buttonIngredient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonIngredient.FlatAppearance.BorderSize = 0;
            this.buttonIngredient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.buttonIngredient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIngredient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonIngredient.Location = new System.Drawing.Point(289, 80);
            this.buttonIngredient.MinimumSize = new System.Drawing.Size(100, 35);
            this.buttonIngredient.Name = "buttonIngredient";
            this.buttonIngredient.Size = new System.Drawing.Size(137, 52);
            this.buttonIngredient.TabIndex = 1;
            this.buttonIngredient.UseVisualStyleBackColor = false;
            this.buttonIngredient.Click += new System.EventHandler(this.ButtonIngredient_Click);
            // 
            // buttonRecipe
            // 
            this.buttonRecipe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRecipe.BackColor = System.Drawing.Color.Transparent;
            this.buttonRecipe.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRecipe.BackgroundImage")));
            this.buttonRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRecipe.FlatAppearance.BorderSize = 0;
            this.buttonRecipe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.buttonRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRecipe.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonRecipe.Location = new System.Drawing.Point(289, 176);
            this.buttonRecipe.MinimumSize = new System.Drawing.Size(100, 35);
            this.buttonRecipe.Name = "buttonRecipe";
            this.buttonRecipe.Size = new System.Drawing.Size(137, 52);
            this.buttonRecipe.TabIndex = 2;
            this.buttonRecipe.UseVisualStyleBackColor = false;
            this.buttonRecipe.Click += new System.EventHandler(this.buttonRecipe_Click);
            // 
            // buttonPlans
            // 
            this.buttonPlans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlans.BackColor = System.Drawing.Color.Transparent;
            this.buttonPlans.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPlans.BackgroundImage")));
            this.buttonPlans.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPlans.FlatAppearance.BorderSize = 0;
            this.buttonPlans.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.buttonPlans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlans.Location = new System.Drawing.Point(289, 272);
            this.buttonPlans.MinimumSize = new System.Drawing.Size(100, 35);
            this.buttonPlans.Name = "buttonPlans";
            this.buttonPlans.Size = new System.Drawing.Size(137, 52);
            this.buttonPlans.TabIndex = 3;
            this.buttonPlans.UseVisualStyleBackColor = false;
            this.buttonPlans.Click += new System.EventHandler(this.ButtonPlans_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(174)))), ((int)(((byte)(122)))));
            this.BackgroundImage = global::UI.Properties.Resources.Background_kitchen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(716, 389);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(220, 220);
            this.Name = "HomePage";
            this.Text = "Thesis project";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Label labelInfo;
        private Button buttonIngredient;
        private Button buttonRecipe;
        private Button buttonPlans;
        private TableLayoutPaintImproved tableLayoutPanel;
    }
}