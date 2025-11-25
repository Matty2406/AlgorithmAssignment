using AlgorithmAssignment.Core;

namespace AlgorithmAssignment
{
    public partial class UIForm : Form
    {
        public UIForm()
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
                        TerrainMap map = LoadTerrainFromFile(ofd.FileName);
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

        private TerrainMap LoadTerrainFromFile(string filePath)
        {
            // Dummy implementation
            int[,] map = new int[,]
            {
                { 0, 1 },
                { 2, 3 }
            };

            Coordinates start = new Coordinates(0, 0);
            Coordinates goal = new Coordinates(3, 3);

            return new TerrainMap(map, start, goal);
        }
    }
}
