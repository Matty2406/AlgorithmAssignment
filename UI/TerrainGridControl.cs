using System.Drawing;
using System.Windows.Forms;

namespace AlgorithmAssignment.UI
{
    public class TerrainGridControl : Control
    {
        private int[,] terrainMap;

        private readonly Dictionary<int, Color> terrainColor;

        public int[,] TerrainMap
        {
            get => terrainMap;
            set
            {
                terrainMap = value;
                Invalidate(); // Trigger repaint
            }
        }

        public TerrainGridControl()
        {
            ResizeRedraw = true;

            terrainColor = new Dictionary<int, Color>()
            {
                { 0, Color.Black }, // 0: Wall
                { 1, Color.White }, // 1: Clear
                { 2, Color.Green }, // 2: Wood
                { 3, Color.LightBlue }, // 3: Water
            };

            // Dummy grid
            terrainMap = new int[,]
            {
                { 0, 1, 2, 3 },
                { 1, 2, 3, 0 },
                { 2, 3, 0, 1 },
                { 3, 0, 1, 2 },
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Call the base class OnPaint
            base.OnPaint(e);

            // Check if terrainMap is empty, don't draw anything
            if (terrainMap == null) return;

            // Define the rows and columns
            int rows = terrainMap.GetLength(0);
            int cols = terrainMap.GetLength(1);

            // If there are no rows or columns, don't draw anything
            if (rows == 0 || cols == 0) return;

            // Work with client size (without borders)
            int width = ClientSize.Width;
            int height = ClientSize.Height;

            // If width or height is non-positive, don't draw anything
            if (width <= 0 || height <= 0) return;

            // Size of each cell so that the grid fits
            int cellWidth = width / cols;
            int cellHeight = height / rows;
            int cellSize = Math.Min(cellWidth, cellHeight);

            // Don't draw if cell size is non-positive
            if (cellSize <= 0) return;

            // Draw each cell with the appropriate color

            using (var pen = new Pen(Color.Black))
            {
                // Loop through each cell in the terrain map
                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < cols; x++)
                    {
                        int terrainValue = terrainMap[y, x];

                        if (!terrainColor.TryGetValue(terrainValue, out Color color))
                        {
                            color = Color.Magenta; // Unknown terrain type
                        }

                        int px = x * cellSize;
                        int py = y * cellSize;

                        var rect = new Rectangle(px, py, cellSize, cellSize);

                        using (var brush = new SolidBrush(color))
                        {
                            e.Graphics.FillRectangle(brush, rect);
                        }

                        e.Graphics.DrawRectangle(pen, rect);
                    }
                }
            }
        }
    }
}
