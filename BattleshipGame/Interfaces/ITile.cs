using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleshipGame.Interfaces
{
    public interface ITile
    {
        bool IsOccupied { get; }
        IShip Occupant { get; set; }
        string Name { get; set; }
    }
}
