using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleshipGame.Classes
{
    public class Grid
    {
        // 2D Tile array to make up the grid
        //public Tile[,] tiles = new Tile[10, 10];
        
        // Enum State used to determine which phase the grid is currently on
        public enum State { Creation, InPlay}
        public State state;

        public GroupBox playerGroupBox;

        public Grid(GroupBox groupBox)
        {
            //Populate();
            
            this.playerGroupBox = groupBox;
        }

        // Populate the tiles array to make up the grid
        /*private void Populate()
        {
            for(int row = 0; row < tiles.Length; row++)
            {
                for(int col; col < tiles[row].Length)
            }
        }*/
    }
}
