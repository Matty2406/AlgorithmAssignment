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
            Label Label;
            TerrainGrid = new TerrainGridControl();
            RightTable = new TableLayoutPanel();
            FlowLayout = new FlowLayoutPanel();
            LoadButton = new Button();
            AlgoDropdown = new ComboBox();
            RunButton = new Button();
            Label = new Label();
            RightTable.SuspendLayout();
            FlowLayout.SuspendLayout();
            SuspendLayout();
            // 
            // Label
            // 
            Label.Anchor = AnchorStyles.Top;
            Label.AutoSize = true;
            Label.Location = new Point(100, 51);
            Label.Name = "Label";
            Label.Size = new Size(107, 15);
            Label.TabIndex = 1;
            Label.Text = "Choose Algorithm:";
            // 
            // TerrainGrid
            // 
            TerrainGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TerrainGrid.Location = new Point(0, 0);
            TerrainGrid.Margin = new Padding(0);
            TerrainGrid.Name = "TerrainGrid";
            TerrainGrid.Path = null;
            TerrainGrid.Size = new Size(394, 338);
            TerrainGrid.TabIndex = 0;
            TerrainGrid.TerrainMap = null;
            TerrainGrid.Text = "Terrain Grid";
            // 
            // RightTable
            // 
            RightTable.ColumnCount = 2;
            RightTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56.2857132F));
            RightTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43.7142868F));
            RightTable.Controls.Add(TerrainGrid, 0, 0);
            RightTable.Controls.Add(FlowLayout, 1, 0);
            RightTable.Dock = DockStyle.Fill;
            RightTable.Location = new Point(0, 0);
            RightTable.Name = "RightTable";
            RightTable.RowCount = 2;
            RightTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            RightTable.RowStyles.Add(new RowStyle());
            RightTable.Size = new Size(700, 338);
            RightTable.TabIndex = 2;
            // 
            // FlowLayout
            // 
            FlowLayout.Anchor = AnchorStyles.None;
            FlowLayout.AutoSize = true;
            FlowLayout.Controls.Add(LoadButton);
            FlowLayout.Controls.Add(Label);
            FlowLayout.Controls.Add(AlgoDropdown);
            FlowLayout.Controls.Add(RunButton);
            FlowLayout.FlowDirection = FlowDirection.TopDown;
            FlowLayout.Location = new Point(394, 100);
            FlowLayout.Margin = new Padding(0);
            FlowLayout.Name = "FlowLayout";
            FlowLayout.Padding = new Padding(10);
            FlowLayout.Size = new Size(306, 138);
            FlowLayout.TabIndex = 1;
            FlowLayout.WrapContents = false;
            // 
            // LoadButton
            // 
            LoadButton.Location = new Point(13, 13);
            LoadButton.Name = "LoadButton";
            LoadButton.Size = new Size(281, 35);
            LoadButton.TabIndex = 0;
            LoadButton.Text = "Load Map";
            LoadButton.UseVisualStyleBackColor = true;
            LoadButton.Click += LoadButton_Click;
            // 
            // AlgoDropdown
            // 
            AlgoDropdown.Anchor = AnchorStyles.Top;
            AlgoDropdown.FormattingEnabled = true;
            AlgoDropdown.Location = new Point(62, 69);
            AlgoDropdown.Name = "AlgoDropdown";
            AlgoDropdown.Size = new Size(182, 23);
            AlgoDropdown.TabIndex = 2;
            // 
            // RunButton
            // 
            RunButton.Anchor = AnchorStyles.Top;
            RunButton.Location = new Point(117, 98);
            RunButton.Name = "RunButton";
            RunButton.Size = new Size(73, 27);
            RunButton.TabIndex = 3;
            RunButton.Text = "Run";
            RunButton.UseVisualStyleBackColor = true;
            RunButton.Click += RunButton_Click;
            // 
            // UIForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(RightTable);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UIForm";
            Text = "Form1";
            RightTable.ResumeLayout(false);
            RightTable.PerformLayout();
            FlowLayout.ResumeLayout(false);
            FlowLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TerrainGridControl TerrainGrid;
        private TableLayoutPanel RightTable;
        private FlowLayoutPanel FlowLayout;
        private Button LoadButton;
        private ComboBox AlgoDropdown;
        private Button RunButton;
    }
}
