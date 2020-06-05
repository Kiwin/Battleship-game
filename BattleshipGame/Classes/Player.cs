using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.Classes
{
    public class Player
    {
        public Grid secretGrid;
        public Grid publicGrid;
        private List<Carrier> carriers { get; set; }
        private List<Battleship> battleships { get; set; }
        private List<Cruiser> cruisers { get; set; }
        public List<Destroyer> destroyers { get; set; }
        public List<Submarine> submarines { get; set; } 

        public Player()
        {

        }
    }
}
