using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleshipGame.Classes
{
    // Maybe pass in button instead of pos variable
    class Tile
    {
        // Position on the 10x10 grid for example "a1"
        // public int gridPos;

        // If tile is occupied by part of a ship
        public bool isOccupied;
        // Button object (tile)
        private Button _button;
        public Tile(Button button/*int position*/)
        {
            //this.gridPos = position;

            this._button = button;
            this.isOccupied = false;
        }
        
        // Occupy tile with part of ship
        public void Occupy()
        {
            this.isOccupied = true;
        }

        // Red is hit
        public void Hit()
        {
            this._button.BackColor = Color.Red;
        }
        // Blue is miss
        public void Miss()
        {
            this._button.BackColor = Color.Blue;
        }

        public void Place()
        {
            // Set tile to occupied and change color of button object to blue
            this.isOccupied = true;
            this._button.BackColor = Color.Blue;
        }

        // Determine whether action is a hit or a miss
        public void DetermineHitOrMiss()
        {
            if(this.isOccupied == true)
            {
                Hit();
            }
            else if(this.isOccupied == false)
            {
                Miss();
            }
        }
    }
}
