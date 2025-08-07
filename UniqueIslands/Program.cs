using System;
using System.Globalization;

namespace UniqueIslands
{
    class Program
    {
        static int origin_row = -1;

        static int origin_col = -1;

        static int uniqueIslands = 0;


        public static void checkLoop(int[][] grid, int row, int col)
        {
            
            if (grid[row][col] == -1)
            {
                return ;
            }
            if ((grid[row][col]/10) == origin_row && grid[row][col]%10 == origin_col)
            {
                grid[row][col] = -1;
                uniqueIslands++;
                return ;
            }
            
            checkLoop(grid, grid[row][col]/10,grid[row][col] % 10);

            return ;
        }
        public static void Main(string[] args)
        {



            //int[][] grid = new int[4][] {
            //    new int[] { -1, -1, 03, 02 },
            //    new int[] { -1, -1, -1, -1 },
            //    new int[] { -1, -1, -1, -1 },
            //    new int[] { -1, -1, -1, -1 }
            //};

            int[][] grid = new int[5][]
            {


                new int[] { -1, -1, 03, -1, -1, -1, -1 },
                new int[] { -1, 30, -1, -1, -1, -1, 46},
                new int[] { -1, -1, -1, -1, -1, -1, -1 },
                new int[] { 41, 11, -1, -1, -1, -1, -1 },
                new int[] { -1, 31, -1, -1, -1, 16, 45 }

            };

            for (int i = 0; i < grid.Length; i++)
            {
                for(int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] != -1)
                    {
                        
                        origin_row = i;
                        origin_col = j;
                        Console.WriteLine("Origin: " + origin_row + ", " + origin_col);
                        int num = grid[i][j];
                        int column = num % 10;
                        int row = num / 10;

                        checkLoop(grid, row, column);
                    }
                    
                }
            }
            Console.WriteLine("Unique Islands: " + uniqueIslands);

        }

    }

}
