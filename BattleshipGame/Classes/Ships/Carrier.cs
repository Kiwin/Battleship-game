using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.Classes
{
    public class Carrier : Ship
    {

        public Carrier() : base(5)
        {
        }
        public override string Name => "Carrier";
    }
}
