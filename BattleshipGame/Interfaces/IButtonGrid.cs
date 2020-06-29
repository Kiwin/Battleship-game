using BattleshipGame.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleshipGame.Interfaces
{
    public interface IButtonGrid
    {
        /// <summary>
        /// Event for handling if a button in the grid is clicked.
        /// </summary>
        event EventHandler<ButtonGridClickedArgs> ButtonClicked;
    }

    /// <summary>
    /// Providing event details regarding an event invoked by a button click.
    /// </summary>
    public class ButtonGridClickedArgs : EventArgs
    {
        public IVector2D<int> ButtonPosition;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="buttonPosition">The cell position of the button pressed.</param>
        public ButtonGridClickedArgs(IVector2D<int> buttonPosition)
        {
            this.ButtonPosition = buttonPosition;
        }
    }
}
