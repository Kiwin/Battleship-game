using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.Classes
{
    class Grid
    {
        // 2D Tile array to make up the grid
        public Tile[,] tiles = new Tile[10, 10];

        public Grid()
        {
            Populate();
        }

        // Populate the tiles array to make up the grid
        private void Populate()
        {
            for(int row = 0; row < tiles.Length; row++)
            {
                for(int col; col < tiles[row].Length)
            }
        }
    }
}
