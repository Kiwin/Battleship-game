using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.Classes
{
    public class Battleship : Ship
    {
        public Battleship() : base (4)
        {
        }
        public override string Name => "Battleship";
    }
}
