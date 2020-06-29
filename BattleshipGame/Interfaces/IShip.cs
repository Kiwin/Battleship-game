using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    public interface IShip
    {
        /// <summary>
        /// Size of the ship.
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Name of the ship type.
        /// </summary>
        string Name { get; }

    }
}
