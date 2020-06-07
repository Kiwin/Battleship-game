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
        public enum State { Creation, InPlay }
        public State state;

        public GroupBox playerGroupBox;
        public int occupiedTilesCount;
        public Grid(GroupBox groupBox)
        {
            this.playerGroupBox = groupBox;
            Populate();
        }

        public void PlaceShip(int shipLength)
        {
            // Find all tiles that are not occupied 
            List<Tile> nonOccupiedTiles = this.tiles.Where(t => t.isOccupied == false).ToList();

            // Random
            Random random = new Random();

            // The starting tile is random index in the list of non-occupied tiles
            Tile startingTile = nonOccupiedTiles[random.Next(nonOccupiedTiles.Count)];

            // Call the place function on the starting tile
            startingTile.Place();

            if (this.tiles.Contains(startingTile))
            {
                //Console.WriteLine("Tile is in");

                // Get index of clicked button within the GroupBox
                int tileIndex = this.tiles.IndexOf(startingTile);

                //Console.WriteLine(tileIndex.ToString());
                // Selected tile in this objects tiles list
                Tile selectedTile = tiles[tileIndex];
                // Direction tiles
                List<Tile> rightTiles = new List<Tile>();
                List<Tile> leftTiles = new List<Tile>();
                List<Tile> upTiles = new List<Tile>();
                List<Tile> downTiles = new List<Tile>();

                // Clear all direction tile lists
                if (upTiles.Count != 0)
                {
                    upTiles.Clear();
                }

                if (downTiles.Count != 0)
                {
                    downTiles.Clear();
                }

                if (upTiles.Count != 0)
                {
                    rightTiles.Clear();
                }

                if (upTiles.Count != 0)
                {
                    leftTiles.Clear();
                }

                // Find all tiles that are adjacent + shipsize to tile (selection)
                for (int i = 1; i < shipLength; i++)
                {
                    // Check that placement isn't on rightmost tile
                    if (tileIndex % 10 != 9)
                    {
                        rightTiles.Add(tiles[tileIndex + i]);
                        // Debug

                        // If tiles index of element in rightTiles modulus 10 is not 0 we are not exceeding right side of grid
                        if (rightTiles.Count == i && tiles.IndexOf(rightTiles[i - 1]) % 10 != 0)
                        {
                            // Tiles adjacent to the left
                            if (tiles.IndexOf(rightTiles[i - 1]) % 10 != 0)
                            {
                                tiles[tiles.IndexOf(rightTiles[i - 1]) - 1].isOccupied = true;
                            }

                            // Tiles adjacent to the right
                            if (tiles.IndexOf(rightTiles[i - 1]) % 10 != 9)
                            {
                                tiles[tiles.IndexOf(rightTiles[i - 1]) + 1].isOccupied = true;
                            }

                            // Tiles adjacent upwards
                            if (!(tiles.IndexOf(rightTiles[i - 1]) < 10))
                            {
                                tiles[tiles.IndexOf(rightTiles[i - 1]) - 10].isOccupied = true;
                            }

                            // Tiles adjacent downwards
                            if (!(tiles.IndexOf(rightTiles[i - 1]) >= 90))
                            {
                                tiles[tiles.IndexOf(rightTiles[i - 1]) + 10].isOccupied = true;
                            }
                        }
                        // placement not valid
                        else
                        {
                            rightTiles.Clear();
                        }
                    }
                    // Left tiles
                    // Check that placement isn't on leftmost tile
                    if (tileIndex % 10 != 0)
                    {


                        // Add all tiles to left of selection corresponding with length of ship
                        leftTiles.Add(tiles[tileIndex - i]);
                        // We check if tiles index of any of the leftTiles is under the index of selectedTile rounded down to nearest ten ie. if any leftTiles go over left side of grid
                        if (leftTiles.Count == i && tiles.IndexOf(leftTiles[i - 1]) % 10 != 9)
                        {
                            // Tiles adjacent to the left
                            if (tiles.IndexOf(leftTiles[i - 1]) % 10 != 0)
                            {
                                tiles[tiles.IndexOf(leftTiles[i - 1]) - 1].isOccupied = true;
                            }

                            // Tiles adjacent to the right
                            if (tiles.IndexOf(leftTiles[i - 1]) % 10 != 9)
                            {
                                tiles[tiles.IndexOf(leftTiles[i - 1]) + 1].isOccupied = true;
                            }

                            // Tiles adjacent upwards
                            if (!(tiles.IndexOf(leftTiles[i - 1]) < 10))
                            {
                                tiles[tiles.IndexOf(leftTiles[i - 1]) - 10].isOccupied = true;
                            }

                            // Tiles adjacent downwards
                            if (!(tiles.IndexOf(leftTiles[i - 1]) >= 90))
                            {
                                tiles[tiles.IndexOf(leftTiles[i - 1]) + 10].isOccupied = true;
                            }
                        }
                        else
                        {
                            // Clear all left tiles since the placement to the left is not valid as determined by above if statement
                            leftTiles.Clear();
                        }
                    }
                    /*// If all tiles to be added are within range of list // uptiles
                    if ((tileIndex - (10 * i)) > 0)
                    {
                        // If not over top edge
                        if (!(tiles.IndexOf(upTiles[i - 1]) > 90))
                        {
                            // Tiles adjacent to the left
                            if (tiles.IndexOf(upTiles[i - 1]) % 10 != 0)
                            {
                                tiles[tiles.IndexOf(upTiles[i - 1]) - 1].isOccupied = true;
                            }

                            // Tiles adjacent to the right
                            if (tiles.IndexOf(upTiles[i - 1]) % 10 != 9)
                            {
                                tiles[tiles.IndexOf(upTiles[i - 1]) + 1].isOccupied = true;
                            }

                            // Tiles adjacent upwards
                            if (!(tiles.IndexOf(upTiles[i - 1]) < 10))
                            {
                                tiles[tiles.IndexOf(upTiles[i - 1]) - 10].isOccupied = true;
                            }

                            // Tiles adjacent downwards
                            if (!(tiles.IndexOf(upTiles[i - 1]) >= 90))
                            {
                                tiles[tiles.IndexOf(upTiles[i - 1]) + 10].isOccupied = true;
                            }
                        }
                        else
                        {
                            upTiles.Clear();
                        }
                    }*/

                    // Downtiles
                    if ((tileIndex + (10 * i) < 99))
                    {
                        // Add all tiles down from selection corresponding to length of ship
                        downTiles.Add(tiles[tileIndex + (10 * i)]);

                        // If no tiles indices in downtiles are under ten then placement is valid
                        if (!(tiles.IndexOf(downTiles[i - 1]) < 10))
                        {
                            // Tiles adjacent to the left
                            if (tiles.IndexOf(downTiles[i - 1]) % 10 != 0)
                            {
                                tiles[tiles.IndexOf(downTiles[i - 1]) - 1].isOccupied = true;
                            }

                            // Tiles adjacent to the right
                            if (tiles.IndexOf(downTiles[i - 1]) % 10 != 9)
                            {
                                tiles[tiles.IndexOf(downTiles[i - 1]) + 1].isOccupied = true;
                            }

                            // Tiles adjacent upwards
                            if (!(tiles.IndexOf(downTiles[i - 1]) < 10))
                            {
                                tiles[tiles.IndexOf(downTiles[i - 1]) - 10].isOccupied = true;
                            }

                            // Tiles adjacent downwards
                            if (!(tiles.IndexOf(downTiles[i - 1]) >= 90))
                            {
                                tiles[tiles.IndexOf(downTiles[i - 1]) + 10].isOccupied = true;
                            }
                        }
                        // Placement not valid
                        else
                        {
                            downTiles.Clear();
                        }
                    }
                }

                // Place all righttiles
                if (rightTiles.Count != 0)
                {
                    foreach (Tile rightTile in rightTiles)
                    {
                        rightTile.Place();
                        this.occupiedTilesCount++;
                    }
                }
                // Lefttiles
                else if (leftTiles.Count != 0)
                {
                    foreach (Tile leftTile in leftTiles)
                    {
                        leftTile.Place();
                        this.occupiedTilesCount++;
                    }
                }
                // uptiles
                else if (upTiles.Count != 0)
                {
                    foreach (Tile upTile in upTiles)
                    {
                        upTile.Place();
                        this.occupiedTilesCount++;
                    }
                }
                // downtiles
                else if (downTiles.Count != 0)
                {
                    foreach (Tile downTile in downTiles)
                    {
                        downTile.Place();
                        this.occupiedTilesCount++;
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
            foreach (Control control in this.playerGroupBox.Controls)
            {
                tiles.Add(new Tile((Button)control));
            }

            // Reverse the order of tiles list to get around weird indexing in GroupBox
            tiles.Reverse();
        }
    }
}
