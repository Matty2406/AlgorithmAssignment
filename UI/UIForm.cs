using AlgorithmAssignment.Core;

namespace AlgorithmAssignment
{
    public partial class UIForm : Form
    {
        private TerrainMap? CurrentMap;

        private string CurrentMapFileName = "";

        public UIForm()
        {
            InitializeComponent();

            AlgoDropdown.Items.Add("Breadth-First Search");
            AlgoDropdown.Items.Add("Depth-First Search");
            AlgoDropdown.Items.Add("Hill Climbing Search");
            AlgoDropdown.Items.Add("Best-First Search");
            AlgoDropdown.Items.Add("Dijkstra's Algorithm");
            AlgoDropdown.Items.Add("A* Search");
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
                        CurrentMapFileName = Path.GetFileNameWithoutExtension(ofd.FileName);

                        TerrainMap map = LoadTerrainFromFile(ofd.FileName);
                        CurrentMap = map;
                        TerrainGrid.ClearPath();
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

        private static TerrainMap LoadTerrainFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            // Line 1: Dimensions (rows, columns)
            var dimensions = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Check dimensions
            if (dimensions.Length != 2)
            {
                throw new Exception("Invalid dimensions line.");
            }

            int rows = int.Parse(dimensions[0]);
            int columns = int.Parse(dimensions[1]);

            // Line 2: Start coordinates (row, column)
            var startCoords = lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (startCoords.Length != 2)
            {
                throw new Exception("Invalid start coordinates line.");
            }

            Coordinates start = new Coordinates(int.Parse(startCoords[0]), int.Parse(startCoords[1]));

            // Line 3: Goal coordinates (row, column)
            var goalCoords = lines[2].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (goalCoords.Length != 2)
            {
                throw new Exception("Invalid goal coordinates line.");
            }

            Coordinates goal = new Coordinates(int.Parse(goalCoords[0]), int.Parse(goalCoords[1]));

            // Remaining lines: Terrain grid
            int[,] grid = new int[rows, columns];

            for (int r = 0; r < rows; r++)
            {
                var rowParts = lines[r + 3].Split(' ', StringSplitOptions.RemoveEmptyEntries); // You did that on purpose, Nick, I know you did

                if (rowParts.Length != 12)
                {
                    throw new Exception($"Invalid number of columns in row {r}. Is: {rowParts.Length}");
                }

                for (int c = 0; c < columns; c++)
                {
                    grid[r, c] = int.Parse(rowParts[c]);
                }
            }

            return new TerrainMap(grid, start, goal);
        }

        // ----------------------------------------

        private void RunButton_Click(object sender, EventArgs e)
        {
            if (CurrentMap == null)
            {
                MessageBox.Show("Please load a map first");
                return;
            }

            try
            {
                // Get selected algorithm
                AlgorithmType algorithmType = GetSelectedAlgorithm();

                // Create pathfinder
                IPathFinder pathFinder = AlgorithmFactory.Create(algorithmType);

                // Run pathfinder
                var path = pathFinder.Run(CurrentMap);

                // Display path
                TerrainGrid.Path = path;

                // Write path to file
                WriteToFile(path, CurrentMapFileName, pathFinder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                    "Failed to run pathfinding algorithm: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private AlgorithmType GetSelectedAlgorithm()
        {
            return AlgoDropdown.SelectedIndex switch
            {
                0 => AlgorithmType.BreadthFirst,
                1 => AlgorithmType.DepthFirst,
                2 => AlgorithmType.HillClimbing,
                3 => AlgorithmType.BestFirst,
                4 => AlgorithmType.Dijkstras,
                5 => AlgorithmType.AStar,
                _ => throw new Exception("No algorithm selected.")
            };
        }

        private static void WriteToFile(List<Coordinates> path, string mapName, IPathFinder pathFinder)
        {
            if (path == null || path.Count == 0)
            {
                MessageBox.Show("No path found to write to file.");
                return;
            }

            // Create output file name
            string algorithmName = pathFinder.GetType().Name.ToLower();

            string fileName = $"{mapName}Path_{algorithmName}.txt";
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write each coordinate in the path to the file
                foreach (var step in path)
                {
                    writer.WriteLine(step.ToString());
                }

                // For A*, write number of sorts
                if (pathFinder is Algorithms.AStar aStar)
                {
                    writer.WriteLine(aStar.SortCounts);
                }
            }

            MessageBox.Show($"Path written to file: {filePath}");
        }
    }
}