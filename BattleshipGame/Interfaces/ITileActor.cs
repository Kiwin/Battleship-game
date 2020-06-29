using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.Interfaces
{
    public interface ITileActor
    {
        bool Name { get; }
        Color BackColor { get; set; }
        void Highlight();
        void Disable();
    }
}
