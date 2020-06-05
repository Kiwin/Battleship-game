using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.Classes
{
    public class Destroyer : IShip
    {
        public int shipSize { get; set; }
        public Destroyer()
        {
            this.shipSize = 2;
        }
    }
}
