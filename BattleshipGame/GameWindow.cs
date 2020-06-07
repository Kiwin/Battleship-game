using BattleshipGame.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleshipGame
{
    public partial class GameWindow : Form
    {
        // Grids
        private Grid player1SecretGrid;
        private Grid player2SecretGrid;
        private Grid player1PublicGrid;
        private Grid player2PublicGrid;
        // Players
        private Player player1;
        private Player player2;
        // Game state enum. Creation is ship placement. InPlay is ship targeting
        private enum State { Creation, InPlay}
        private State gameState;
        // Current player
        private Player curPlayer;
        public GameWindow()
        {
            InitializeComponent();
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            // Debug
            // Assign the groupboxes parents to this window instead of eachother
            // This is done because the grouping in the designer makes it so each GroupBox after the first one is a child of the first one
            player1SecretGridGroupBox.Parent = this;
            player2SecretGridGroupBox.Parent = this;
            player1PublicGridGroupBox.Parent = this;
            player2PublicGridGroupBox.Parent = this;
        }
        // Event handler for Click event on tiles on grids
        void tileBtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            // Tile is set to the tile in the players public grid which corresponds to the button that is clicked
            Tile tile = curPlayer.publicGrid.tiles.Where(t => t._button.Name == button.Name).FirstOrDefault();
            // Index of the tile
            int index = curPlayer.publicGrid.tiles.IndexOf(tile);

            // Determine state of game
            switch (gameState)
            {
                case State.Creation:
                    break;
                case State.InPlay:
                    // Player 1's turn
                    if(curPlayer == player1)
                    {
                        // Does the other player have any occupied tiles left ie. any ships left.
                        if (player2.secretGrid.occupiedTilesCount != 0)
                        {
                            // Determine hit or miss
                            tile.DetermineHitOrMiss(player2.secretGrid, index);
                            // End turn
                            endTurnBtn.PerformClick();
                        }
                        // Game over
                        else
                        {
                            Console.WriteLine("Game over");
                        }
                    }
                    // Player 2's turn
                    else if(curPlayer == player2)
                    {
                        // Does the other player have any occupied tiles left ie. any ships left.
                        if (player1.secretGrid.occupiedTilesCount != 0)
                        {
                            // Determine hit or miss
                            tile.DetermineHitOrMiss(player1.secretGrid, index);
                            // End turn
                            endTurnBtn.PerformClick();
                        }
                        // Game over
                        else
                        {
                            Console.WriteLine("Game over");
                        }
                    }

                    break;
                default:
                    break;
            }
        }

        private void newGameBtn_Click(object sender, EventArgs e)
        {
            Reset();

            // Create Grid objects with GroupBox control
            player1SecretGrid = new Grid(player1SecretGridGroupBox);
            player2SecretGrid = new Grid(player2SecretGridGroupBox);
            player1PublicGrid = new Grid(player1PublicGridGroupBox);
            player2PublicGrid = new Grid(player2PublicGridGroupBox);

            // Set Gamestate
            gameState = State.Creation;

            // Instantiate Players
            player1 = new Player();
            player2 = new Player();

            // Set the players' grids
            player1.secretGrid = player1SecretGrid;
            player2.secretGrid = player2SecretGrid;
            player1.publicGrid = player1PublicGrid;
            player2.publicGrid = player2PublicGrid;

            // Set current player to player1
            curPlayer = player1;

            // Place ships for current player
            PlaceShips(curPlayer);

            // Attach event handler to each button (tile) in the GroupBox (grid)
            foreach (Control control in this.player1PublicGridGroupBox.Controls)
            {
                if (control is Button)
                {
                    // Make every button clickable
                    control.Enabled = true;

                    // Attach event handler
                    control.Click += new EventHandler(tileBtn_Click);
                }
            }

            // Attach event handler to each button (tile) in the GroupBox (grid)
            foreach (Control control in this.player2PublicGridGroupBox.Controls)
            {
                if (control is Button)
                {
                    // Make every button clickable
                    control.Enabled = true;

                    // Attach event handler
                    control.Click += new EventHandler(tileBtn_Click);
                }
            }
        }

        // Function to PlaceShips
        void PlaceShips(Player curPlayer)
        {
            // 1 carrier
            int carriersLeft = 1;
            if (carriersLeft != 0)
            {
                foreach (Carrier carrier in curPlayer.carriers)
                {
                    // PlaceShip function is called on the current player's secret grid. The carrier's shipSize is passed in as parameter
                    curPlayer.secretGrid.PlaceShip(carrier.shipSize);
                    // Decrement carriersLeft
                    carriersLeft--;
                }
                // Clear the carriers list on the current player
                curPlayer.carriers.Clear();
            }
            int battleshipsLeft = 2;
            if (battleshipsLeft != 0)
            {
                foreach (Battleship btlShip in curPlayer.battleships)
                {
                    curPlayer.secretGrid.PlaceShip(btlShip.shipSize);
                    battleshipsLeft--;
                }
                curPlayer.battleships.Clear();
            }
            int cruisersLeft = 3;
            if (cruisersLeft != 0)
            {
                foreach (Cruiser cruiser in curPlayer.cruisers)
                {
                    curPlayer.secretGrid.PlaceShip(cruiser.shipSize);
                    cruisersLeft--;
                }
                curPlayer.cruisers.Clear();
            }
            int submarinesLeft = 4;
            if (submarinesLeft != 0)
            {
                foreach (Submarine submarine in curPlayer.submarines)
                {
                    curPlayer.secretGrid.PlaceShip(submarine.shipSize);
                    submarinesLeft--;
                }
                curPlayer.submarines.Clear();
            }
            int destroyersLeft = 5;
            if (destroyersLeft != 0)
            {
                foreach (Destroyer destroyer in curPlayer.destroyers)
                {
                    curPlayer.secretGrid.PlaceShip(destroyer.shipSize);
                    destroyersLeft--;
                }
                curPlayer.destroyers.Clear();
            }
        }

        private void endTurnBtn_Click(object sender, EventArgs e)
        {
            switch (gameState)
            {
                case State.Creation:
                    // Check whose turn it is by checking which player's grid is visible
                    // Player 1's turn
                    if(curPlayer == player1)
                    {
                        // Set player 1's grid to invisible
                        player1.secretGrid.playerGroupBox.Visible = false;
                        // Set player 2's grid to visible
                        player2.secretGrid.playerGroupBox.Visible = true;
                        // Set the current player to player2
                        curPlayer = player2;
                        // Place player 2's ships
                        PlaceShips(curPlayer);

                    }
                    // Player 2's turn
                    else if (curPlayer == player2)
                    {
                        // Set player 2's grid to invisible
                        player2.secretGrid.playerGroupBox.Visible = false;

                        // Set player 1's grid to visible
                        player1.publicGrid.playerGroupBox.Visible = true;

                        // Set the current player to player1
                        curPlayer = player1;
                        // Set gamestate to inplay
                        gameState = State.InPlay;
                    }
                    break;
                case State.InPlay:
                    // Player 1's turn
                    if (curPlayer == player1)
                    {
                        // Set the current player to player 2
                        curPlayer = player2;
                        // Set player1's groupbox to invisible
                        player1.publicGrid.playerGroupBox.Visible = false;
                        // Set player2's groupbox to visible
                        player2.publicGrid.playerGroupBox.Visible = true;
                    }
                    // Player 2's turn
                    else if (curPlayer == player2)
                    {
                        // Set player to player1
                        curPlayer = player1;
                        // Set player2's groupbox to invisible
                        player2.publicGrid.playerGroupBox.Visible = false;
                        // Set player1's groupbox to visible
                        player1.publicGrid.playerGroupBox.Visible = true;
                    }
                    break;
                default:
                    break;
            }
        }

        //  Reset game
        private void Reset()
        {
            GameWindow_Load(this, null);
        }
        // TODO: Make curPlayer variable
        // TODO: Place placecarrier function in a smart place (Event handler for button click after placecarrier button has been clicked)
        // TODO: find a way to start the game
        // TODO: Determine which player's turn it is
    }
}
