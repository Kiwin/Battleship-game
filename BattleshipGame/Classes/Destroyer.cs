using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.Classes
{
    class Destroyer : IShip
    {
        public int shipSize { get; set; }
        public Destroyer()
        {
            shipSize = 2;
        }
    }
}
