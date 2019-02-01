using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NealNisbet_GameOfLife
{
    class GOL : Rules
    {
        /// <summary>
        /// empty constructor passing in the inherited variables from ruules
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        public GOL(int[,] grid, int maxWidth, int maxHeight) : base(grid, maxWidth, maxHeight)
        {
        }

        /// <summary>
        /// runs the game based on the current rule set and saves it to new grid
        /// </summary>
        /// <returns>grid2</returns>
        protected override int[,] RunGame()
        {
            //declare new array, grid2, to store the current game for the set rules
            int[,] grid2 = new int[rMaxW, rMaxH];

            for (int h = 0; h < rMaxH; h++)
            {
                for (int w = 0; w < rMaxW; w++)
                {
                    //get the number of neighbours for a cell
                    int neighbours = GetNumNeighbours(w, h);
                    //if there are 3 neighbours alive
                    if (neighbours == 3)
                    {
                        //create new cell
                        grid2[w, h] = 1;
                        continue;//break terminates loop
                    }

                    //there are 2 or 3 neighbours
                    if (neighbours == 2 || neighbours == 3)
                    {
                        //cell lives
                        grid2[w, h] = rGrid[w, h];
                        continue;
                    }

                    //if none of these are met cell dies
                    grid2[w, h] = 0;
                }
            }
            return grid2;
        }
    }
}
