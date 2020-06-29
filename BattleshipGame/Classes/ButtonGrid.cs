using BattleshipGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BattleshipGame.Classes
{
    public class ButtonGrid : AbstractGrid<Button>, IButtonGrid
    {
        public event EventHandler<ButtonGridClickedArgs> ButtonClicked;
        public ButtonGrid(int columns, int rows) : base(columns, rows)
        {
            PopulateCells();
        }

        private void PopulateCells()
        {

            for (int i = 0; i < ColumnCount; i++)
            {
                for (int j = 0; j < RowCount; j++)
                {
                    var newButton = new Button();
                    Cells[i, j] = newButton;
                    newButton.Click += HandleButtonClick;
                }
            }
        }

        private void HandleButtonClick(object sender, EventArgs e)
        {

            IVector2D<int> buttonPosition;
            var positionWasFound = GridUtils.TryGetPositionOf(sender as Button, this, out buttonPosition);
            if (!positionWasFound) throw new IndexOutOfRangeException("The button was not found in the grid.");
            
            var args = new ButtonGridClickedArgs(buttonPosition);
            ButtonClicked.Invoke(sender, args);
        }

    }
}
