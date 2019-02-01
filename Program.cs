using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * RULES:
 * Scenario 0: No interactions - When there are no live cells then on the next step there are still no live cells
 * Scenario 1: Underpopulation - When a live cell has fewer than two neighbours then this cell dies
 * Scenario 2: Overcrowding - When a live cell has more than three neighbours then this cell dies
 * Scenario 3: Survival - When a live cell has two or three neighbours then this cell stays alive
 * Scenario 4: Creation of Life - When an empty position has exactly three neighbouring cells then a cell is created in this position
 * Neal Nisbet - Game Of Life
 */

namespace NealNisbet_GameOfLife
{
    class Program
    {
        /// <summary>
        /// setting for max width & height for the grid as a two dimensional array to hold the cells
        /// </summary>
        private static int maxWidth = 60;
        private static int maxHeight = 30;
        private static int[,] grid = new int[maxWidth, maxHeight];

        /// <summary>
        /// create a new grid based on the settings defined above 
        /// </summary>
        static void createGrid()
        {
            //set inital cursor to top left corner of the window
            Console.CursorLeft = 0;
            Console.CursorTop = 0;

            //loop through the height & width filling the grid
            for (int h = 0; h < maxHeight; h++)
            {
                for (int w = 0; w < maxWidth; w++)
                {
                    //write out the grid replaceing alive 1's with 'A' & dead 0's with '-'
                    Console.Write(grid[w, h] == 1 ? 'A' : '-');
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {

            //use the random & datetime functions to fill the cells
            Random r = new Random((int)DateTime.Now.Ticks);

            for (int w = 0; w < maxHeight; w++)
            {
                for (int h = 0; h < maxHeight; h++)
                {
                    //fill the grid with the random time function
                    grid[w, h] = r.Next(0, 1 + 1);
                }
            }

            //apply the rules for the life & death of a cell
            Rules rules = new GOL(grid, maxWidth, maxHeight);

            for (int i = 0; i < 3000; i++)
            {
                createGrid();
                rules.Run();
            }
        }
    }
}
