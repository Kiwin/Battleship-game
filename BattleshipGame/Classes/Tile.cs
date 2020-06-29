using BattleshipGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleshipGame.Classes
{
    public class Tile : ITile
    {
        public string Name { get; set; }

        //If the tile is occupied by a ship.
        public bool IsOccupied
        {
            get { return Occupant != null; }
        }
        public IShip Occupant { get; set; }

        public Tile()
        {
        }
    }
}
