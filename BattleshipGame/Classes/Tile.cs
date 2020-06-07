using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleshipGame.Classes
{
    public class Tile
    {
        // If tile is occupied by part of a ship
        public bool isOccupied;
        public bool isPlacementValid;
        // Button object (tile)
        public Button _button;
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
            this._button.BackColor = Color.LightBlue;
        }

        public void Place()
        {
            // Set tile to occupied and change color of button object to blue
            this.isPlacementValid = true;
            this.isOccupied = true;
            this._button.BackColor = Color.Blue;
        }

        public void Highlight()
        {
            this.isPlacementValid = true;
            this._button.BackColor = Color.LightBlue;
        }

        public void Disable()
        {
            this._button.Enabled = false;
            this._button.BackColor = Color.Red;
        }

        // Determine whether action is a hit or a miss
        public void DetermineHitOrMiss(Grid secretGrid, int chosenTileIndex)
        {
            if (secretGrid.tiles[chosenTileIndex].isOccupied)
            { 
                Console.WriteLine("Tile is occupied");
                this.Hit();
                secretGrid.occupiedTilesCount--;
            }
            else
            {
                this.Miss();
                Console.WriteLine("Tile is not occupied");
            }
        }

        public void Debug()
        {
            Console.WriteLine(this._button.Name);
        }
    }
}
