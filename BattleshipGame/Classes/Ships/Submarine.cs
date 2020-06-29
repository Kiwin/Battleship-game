using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.Classes
{
    public class Submarine : Ship
    {
        public Submarine() : base(3)
        {
        }
        public override string Name => "Submarine";
    }
}
