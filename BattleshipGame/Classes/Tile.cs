using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.Classes
{
    class Tile
    {
        // Position on the 10x10 grid for example "a1"
        public int gridPos;
        // If tile is occupied by part of a ship
        public bool isOccupied;
        public Tile(int position)
        {
            this.gridPos = position;
            this.isOccupied = false;
        }
        
        // Occupy tile with part of ship
        public void Occupy()
        {
            this.isOccupied = true;
        }
    }
}
