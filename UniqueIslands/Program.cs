using System;
using System.Diagnostics;
using System.Globalization;

namespace UniqueIslands
{

    class Program
    {
        static int origin_row = -1;

        static int origin_col = -1;

        static int uniqueIslands = 0;

        static int index = 0;


        public static void checkLoop(List<List<int>> gridAdj,int[, ,] grid, int row, int col,int column)
        {
            
            gridAdj[index].Add((row * column) + col);

            if (grid[row, col, 0] == -1 && grid[row, col, 1] == -1)
            {
                return;
            }
            if (grid[row,col,0] == origin_row && grid[row, col, 1] == origin_col)
            {
                gridAdj[index].Add(grid[row, col, 0] * 7 + grid[row, col, 1]);
                grid[row, col, 0] = -1;
                grid[row, col, 1] = -1;
                uniqueIslands++;
                return;
            }
            

            checkLoop(gridAdj,grid, grid[row,col,0], grid[row, col, 1], col);

            return;
        }
        public static void Main(string[] args)
        {


            int[,,] grid = new int[4, 4, 2]
            {
                { { -1,-1},{-1,-1 },{0,3 },{0,2 } },
                { {-1,-1 }, {-1,-1 }, {-1,-1 }, {-1,-1 } },
                { {-1,-1 }, {-1,-1 }, {-1,-1 }, {-1,-1} },
                { { -1,-1}, {-1,-1 }, {-1, -1 }, {-1,-1 } }

            };

            int row = 4;
            int column = 4;

            //int[,,] grid = new int[5, 7, 2]
            //{
            //    { {-1,-1}, {-1,-1}, {0,3}, {-1,-1}, {-1,-1},{-1,-1},{-1,-1} },
            //    { {-1,-1}, {3,0}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {4,6} },
            //    { {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1} },
            //    { {4,1}, {1,1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1} },
            //    { {-1,-1}, {3,1}, {-1,-1}, {-1,-1}, {-1,-1}, {1,6}, {4,5} }

            //};



            List<List<int>> gridAdj = new List<List<int>>();

            for(int i = 0; i < (row * column); i++)
            {
                gridAdj.Add(new List<int>());
            }


            
            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j < column; j++)
                {
                    if (grid[i,j,0] == -1 && grid[i,j,1] == -1)
                    {
                        gridAdj[index].Add(0);
                        index++;
                    }
                    else
                    {
                        origin_row = i;
                        origin_col = j;
                        checkLoop(gridAdj,grid, grid[i,j,0], grid[i,j,1], column);
                        index++;
                    }
                }
            }

            for(int i = 0; i < gridAdj.Count; i++)
            {
                Console.WriteLine($"Node {i}-> " + string.Join("->", gridAdj[i]));
            }




















            //            int[,,] grid = new int[6, 8, 2]
            //{
            //    { {-1,-1}, {-1,-1}, {1,5}, {-1,-1}, {2,0}, {-1,-1}, {-1,-1}, {-1,-1} },
            //    { {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {3,2}, {-1,-1}, {-1,-1} },
            //    { {4,1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1} },
            //    { {-1,-1}, {-1,-1}, {4,4}, {-1,-1}, {-1,-1}, {-1,-1}, {5,0}, {-1,-1} },
            //    { {-1,-1}, {0,4}, {-1,-1}, {-1,-1}, {0,2}, {-1,-1}, {5,6}, {-1,-1} },
            //    { {5,6}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {3,6}, {-1,-1} }
            //};


            //            int[,,] grid = new int[10, 10, 2]
            //{
            //    // Row 0
            //    { {-1,-1}, {-1,-1}, {1,4}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1} },
            //    // Row 1
            //    { {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {2,2}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1} },
            //    // Row 2
            //    { {-1,-1}, {-1,-1}, {3,1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1} },
            //    // Row 3
            //    { {-1,-1}, {0,2}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1} },

            //    // Row 4
            //    { {-1,-1}, {-1,-1}, {-1,-1}, {5,5}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1} },
            //    // Row 5
            //    { {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {6,3}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1} },
            //    // Row 6
            //    { {-1,-1}, {-1,-1}, {-1,-1}, {4,3}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1} },

            //    // Row 7
            //    { {8,7}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1} },
            //    // Row 8
            //    { {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {9,0}, {-1,-1}, {-1,-1} },
            //    // Row 9
            //    { {7,0}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1}, {-1,-1} }
            //};




            //List<List<int>> gridAdj = new List<List<int>>();

            //Console.WriteLine(gridAdj.Capacity);


            //for (int i = 0; i < grid.GetLength(0); i++)
            //{
            //    for (int j = 0; j < grid.GetLength(1); j++)
            //    {
            //        if (grid[i, j, 0] != -1 && grid[i, j, 1] != -1)
            //        {
            //            origin_row = i;
            //            origin_col = j;
            //            checkLoop(grid, grid[i, j, 0], grid[i, j, 1]);
            //        }
            //    }
            //}

            //for (int i = 0; i < grid.GetLength(0); i++)
            //{
            //    for (int j = 0; j < grid.GetLength(1); j++)
            //    {
            //        Console.Write($"({grid[i, j, 0]},{grid[i, j, 1]}) ");
            //    }
            //    Console.WriteLine();
            //}

            Console.WriteLine("Unique Islands: " + uniqueIslands);

        }

    }

}

       
        

       