using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.Classes
{
    public class Cruiser : Ship
    {
        public Cruiser() : base(3)
        {
        }
        public override string Name => "Cruiser";
    }
}
