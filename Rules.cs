using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NealNisbet_GameOfLife
{
    public abstract class Rules
    {
        /// <summary>
        /// protected variables for use in rules class
        /// </summary>
        protected int rMaxW = 0;
        protected int rMaxH = 0;
        protected int[,] rGrid;

        /// <summary>
        /// create rules passing in the grid, width & height
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        public Rules(int[,] grid, int maxWidth, int maxHeight)
        {
            rGrid = grid;
            rMaxW = maxWidth;
            rMaxH = maxHeight;
        }

        /// <summary>
        /// check the cell in relation to each cell roundabout it to determine if it is alive or dead
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <returns>number of neighbours for a cell</returns>
        protected int GetNumNeighbours(int w, int h)
        {
            //inital neighbour state set to 0 as they will be generated as the game evolves
            int neighbours = 0;

            if (w + 1 < rMaxW && rGrid[w + 1,h] == 1)
            {
                neighbours++;
            }

            if (w - 1 >= 0 && rGrid[w - 1, h] == 1)
            {
                neighbours++;
            }

            if (h + 1 < rMaxH && rGrid[w, h + 1] ==1)
            {
                neighbours++;
            }

            if (h - 1 >= 0 && rGrid[w, h -1] ==1)
            {
                neighbours++;
            }

            if (w + 1 < rMaxW && h + 1 < rMaxH && rGrid[w + 1, h + 1] ==1)
            {
                neighbours++;
            }

            if (w + 1 < rMaxW && h - 1 >= 0 && rGrid[w + 1, h - 1] ==1)
            {
                neighbours++;
            }

            if (w - 1 >= 0 && h + 1 < rMaxH && rGrid[w - 1, h + 1] ==1)
            {
                neighbours++;
            }

            if (w - 1 >= 0 && h - 1 >= 0 && rGrid[w - 1, h - 1] ==1)
            {
                neighbours++;
            }

            return neighbours;
        }

        /// <summary>
        /// run the game one generation causing the cells to live or die
        /// </summary>
        public void Run()
        {
            int[,] grid2 = RunGame();

            //creates a copy the current grid & saves it in a new array
            Array.Copy(grid2, rGrid, grid2.Length);
        }

        /// <summary>
        /// creates a new array to store the current game array for comparison of the next generation
        /// </summary>
        /// <returns>int[,] new grid</returns>
        protected abstract int[,] RunGame();
    }
}
