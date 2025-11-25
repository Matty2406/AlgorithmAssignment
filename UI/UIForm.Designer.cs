using AlgorithmAssignment.UI;

namespace AlgorithmAssignment
{
    partial class UIForm
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
            TerrainGrid = new TerrainGridControl();
            LoadButton = new Button();
            Table = new TableLayoutPanel();
            Table.SuspendLayout();
            SuspendLayout();
            // 
            // TerrainGrid
            // 
            TerrainGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TerrainGrid.Location = new Point(0, 0);
            TerrainGrid.Margin = new Padding(0);
            TerrainGrid.Name = "TerrainGrid";
            TerrainGrid.Size = new Size(394, 338);
            TerrainGrid.TabIndex = 0;
            TerrainGrid.Text = "Terrain Grid";
            // 
            // LoadButton
            // 
            LoadButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            LoadButton.Location = new Point(394, 149);
            LoadButton.Margin = new Padding(0);
            LoadButton.Name = "LoadButton";
            LoadButton.Size = new Size(306, 40);
            LoadButton.TabIndex = 1;
            LoadButton.Text = "Load Map";
            LoadButton.UseVisualStyleBackColor = true;
            LoadButton.Click += LoadButton_Click;
            // 
            // Table
            // 
            Table.ColumnCount = 2;
            Table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56.2857132F));
            Table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43.7142868F));
            Table.Controls.Add(TerrainGrid, 0, 0);
            Table.Controls.Add(LoadButton, 1, 0);
            Table.Dock = DockStyle.Fill;
            Table.Location = new Point(0, 0);
            Table.Name = "Table";
            Table.RowCount = 2;
            Table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            Table.RowStyles.Add(new RowStyle());
            Table.Size = new Size(700, 338);
            Table.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(Table);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Table.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TerrainGridControl TerrainGrid;
        private Button LoadButton;
        private TableLayoutPanel Table;
    }
}
