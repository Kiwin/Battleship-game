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
    public class Grid
    {
        // 2D Tile array to make up the grid
        public List<Tile> tiles = new List<Tile>(100);
        
        // Enum State used to determine which phase the grid is currently on
        public enum State { Creation, InPlay}
        public State state;

        public GroupBox playerGroupBox;

        public Grid(GroupBox groupBox)
        {
            this.playerGroupBox = groupBox;
            Populate();
        }

        public void PlaceCarrier(Tile tile)
        {
            //Console.WriteLine("In Placecarrier");
            tiles[0].Debug();
            // Find what tile has been clicked first
            // Disable all buttons that would cause an illegal ship placement based on the first button clicked
            // Find what tile has been clicked as the 2nd selection.
            // Autofill the ship
            if (this.tiles.Contains(tile))
            {
                //Console.WriteLine("Tile is in");
                
                // Get index of clicked button within the GroupBox
                int tileIndex = this.tiles.IndexOf(tile);
                
                //Console.WriteLine(tileIndex.ToString());

                Tile selectedTile = tiles[tileIndex];
                List<Tile> rightTiles = new List<Tile>();
                List<Tile> leftTiles = new List<Tile>();
                List<Tile> upTiles = new List<Tile>();
                List<Tile> downTiles = new List<Tile>();

                if (rightTiles.Contains(tiles.Where(t => t._button.Name == tile._button.Name).FirstOrDefault()))
                {
                    Console.WriteLine(rightTiles.Count);
                    foreach (Tile rightTile in rightTiles)
                    {
                        rightTile.Place();
                        
                    }
                }
                else
                {
                    // Find all controls that are adjacent + 4 to ctrl (selection)
                    for (int i = 1; i < 5; i++)
                    {
                        // Check that placement isn't on rightmost tile
                        if (tiles.IndexOf(tile) % 10 != 9)
                        {
                            rightTiles.Add(tiles[tileIndex + i]);
                            // Debug
                            // Console.WriteLine(rightTiles.IndexOf(rightTiles[i -1]));

                            // If tiles index of element in rightTiles modulus 10 is not 0 we are not exceeding right side of grid
                            if (tiles.IndexOf(rightTiles[i - 1]) % 10 != 0)
                            {
                                //Console.WriteLine(tiles.IndexOf(rightTiles[i - 1]));

                                // IF last element
                                if (i == 4)
                                {
                                    rightTiles[i - 1].Highlight();
                                }
                            }
                            else
                            {
                                rightTiles.Clear();
                            }
                        }

                        // Check that placement isn't on leftmost tile
                        if (tiles.IndexOf(tile) % 10 != 0)
                        {
                            // Add all tiles to left of selection corresponding with length of ship
                            leftTiles.Add(tiles[tileIndex - i]);
                            // We check if tiles index of any of the leftTiles is under the index of selectedTile rounded down to nearest ten ie. if any leftTiles go over left side of grid
                            if (!(tiles.IndexOf(leftTiles[i - 1]) < (10 * (tiles.IndexOf(selectedTile) / 10))))
                            {
                                // Debug
                                //Console.WriteLine(tiles.IndexOf(leftTiles[i - 1]));
                                // Last element
                                if (i == 4)
                                {

                                    leftTiles[i - 1].Highlight();
                                }
                            }
                            else
                            {
                                // Clear all left tiles since the placement to the left is not valid as determined by above if statement
                                leftTiles.Clear();
                            }
                        }
                        // If all tiles to be added are within range of list
                        if ((tiles.IndexOf(tile) - (10 * i)) > 0)
                        {
                            // Add all tiles up from selection corresponding with length of ship
                            upTiles.Add(tiles[tileIndex - (10 * i)]);

                            // If no tiles indices in uptiles are over 90 then placement is valid
                            if (!(tiles.IndexOf(upTiles[i - 1]) > 90))
                            {
                                // Last tile
                                if (i == 4)
                                {
                                    // Highlight last tile
                                    upTiles[i - 1].Highlight();
                                }
                            }
                            else
                            {
                                upTiles.Clear();
                            }


                        }

                        if ((tiles.IndexOf(tile) + (10 * i) < 99))
                        {
                            // Add all tiles down from selection corresponding to length of ship
                            downTiles.Add(tiles[tileIndex + (10 * i)]);

                            // If no tiles indices in downtiles are under ten then placement is valid
                            if (!(tiles.IndexOf(downTiles[i - 1]) < 10))
                            {
                                // Last tile
                                if (i == 4)
                                {
                                    // Highlight last tile
                                    downTiles[i - 1].Highlight();
                                }
                            }
                            else
                            {
                                downTiles.Clear();
                            }
                        }
                    }
                }
                // Disable all other buttons in groupbox
                foreach (Tile nonvalidTile in tiles)
                {
                    if (nonvalidTile.isPlacementValid == false)
                    {
                        nonvalidTile.Disable();
                    }
                }

            }
        }

        // Populate the tiles array to make up the grid
        private void Populate()
        {
            // Populate tiles with buttons from the GroupBox associated with this grid object
            foreach(Control control in this.playerGroupBox.Controls)
            {
                tiles.Add(new Tile((Button)control));
            }

            // Reverse the order of tiles list to get around weird indexing in GroupBox
            tiles.Reverse();
        }
    }
}
