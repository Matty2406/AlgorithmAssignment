namespace AlgorithmAssignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            // Open file dialog to select terrain file
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Select terrain map";
                ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        int[,] map = LoadTerrainFromFile(ofd.FileName);
                        TerrainGrid.TerrainMap = map;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this,
                            "Failed to load terrain map: " + ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private int[,] LoadTerrainFromFile(string filePath)
        {
            // Dummy implementation
            int[,] map = new int[,]
            {
                { 0, 1 },
                { 2, 3 }
            };

            return map;
        }
    }
}
