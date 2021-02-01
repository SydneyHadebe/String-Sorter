using System;

namespace ConwayGameOfLife
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int rows = 5, columns = 5;

            int[,] grid = {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }

            };

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    Console.Write(grid[i, j] == 0 ? "." : "*");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            NextGeneration(grid, rows, columns);
        }

        public static void NextGeneration(int[,] grid, int m, int n)
        {
            var future = new int[m, n];

            for (var y = 1; y < m - 1; y++)
            {
                for (var x = 1; x < n - 1; x++)
                {
                    var neighbours = 0;
                    for (var i = -1; i <= 1; i++)
                        for (var j = -1; j <= 1; j++)
                            neighbours += grid[y + i, x + j];

                    neighbours -= grid[y, x];
                    switch (grid[y, x])
                    {
                        case 1 when (neighbours < 2):
                        case 1 when (neighbours > 3):
                            future[y, x] = 0;
                            break;
                        case 0 when (neighbours == 3):
                            future[y, x] = 1;
                            break;
                        default:
                            future[y, x] = grid[y, x];
                            break;
                    }
                }
            }

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    Console.Write(future[i, j] == 0 ? "." : "#");
                }
                Console.WriteLine();
            }
        }
    }
}