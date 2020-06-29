
using BattleshipGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleshipGame.Classes
{
    public enum ShipPlacementResult
    {
        ShipWasPlaced, ShipWasNotPlaced
    }
    public class TileGrid : AbstractGrid<ITile>
    {
        public TileGrid(int columns, int rows) : base(columns, rows)
        {
            PopulateCells();
        }

        private void PopulateCells()
        {
            for (int i = 0; i < ColumnCount; i++)
            {
                for (int j = 0; j < RowCount; j++)
                {
                    var newTile = new Tile();
                    Cells[i, j] = newTile;
                }
            }
        }

    }
}
