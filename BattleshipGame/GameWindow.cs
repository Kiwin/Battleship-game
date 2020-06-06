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
        private Grid player1SecretGrid;
        private Grid player2SecretGrid;
        private Player player1;
        private Player player2;
        private enum State { Creation, InPlay}
        private State gameState;
        public GameWindow()
        {
            InitializeComponent();
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            // Debug
            player1SecretGridGroupBox.Parent = this;
            player2SecretGridGroupBox.Parent = this;
            //player1PublicGridGroupBox.Parent = this;
            //player2PublicGridGroupBox.Parent = this;

            // Make every button in GroupBox control unclickable
            foreach (Control control in this.player1SecretGridGroupBox.Controls)
            {
                if (control is Button)
                {
                    control.Enabled = false;
                }
            }
        }

        void tileBtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Tile tile = new Tile(button);

            // Determine state of grid
            switch (gameState)
            {
                case State.Creation:
                    // Place ship on tile

                    tile.Place();
                    break;
                case State.InPlay:
                    // Determine hit or miss
                    tile.DetermineHitOrMiss();
                    break;
                default:
                    break;
            }
        }

        private void newGameBtn_Click(object sender, EventArgs e)
        {
            Reset();

            // Create Grid object with GroupBox control
            player1SecretGrid = new Grid(player1SecretGridGroupBox);
            player2SecretGrid = new Grid(player2SecretGridGroupBox);

            // Set Gamestate
            gameState = State.Creation;

            // Instantiate Players
            player1 = new Player();
            player2 = new Player();

            player1.secretGrid = player1SecretGrid;
            player2.secretGrid = player2SecretGrid;

            // Attach event handler to each button (tile) in the GroupBox (grid)
            foreach (Control control in this.player1SecretGridGroupBox.Controls)
            {
                if (control is Button)
                {
                    // Make every button clickable
                    //control.Enabled = true;

                    // Attach event handler
                    control.Click += new EventHandler(tileBtn_Click);
                }
            }

            // Attach event handler to each button (tile) in the GroupBox (grid)
            foreach (Control control in this.player2SecretGridGroupBox.Controls)
            {
                if (control is Button)
                {
                    // Make every button clickable
                    //control.Enabled = true;

                    // Attach event handler
                    control.Click += new EventHandler(tileBtn_Click);
                }
            }
        }

        private void endTurnBtn_Click(object sender, EventArgs e)
        {
            switch (gameState)
            {
                case State.Creation:
                    // Check whose turn it is by checking which player's grid is visible
                    // Player 1's turn
                    if(player1.secretGrid.playerGroupBox.Visible == true)
                    {
                        // Set player 1's grid to invisible
                        player1.secretGrid.playerGroupBox.Visible = false;
                        // Set player 2's grid to visible
                        player2.secretGrid.playerGroupBox.Visible = true;

                    }
                    // Player 2's turn
                    else if (player2.secretGrid.playerGroupBox.Visible == true)
                    {
                        // Set player 2's grid to invisible
                        player2.secretGrid.playerGroupBox.Visible = false;

                        // Set player 1's grid to visible
                        player1.publicGrid.playerGroupBox.Visible = true;

                        // Set gamestate to inplay
                        gameState = State.InPlay;
                    }
                    break;
                case State.InPlay:
                    // Player 1's turn
                    if (player1.publicGrid.playerGroupBox.Visible == true)
                    {

                    }
                    // Player 2's turn
                    else if (player2.publicGrid.playerGroupBox.Visible == true)
                    {

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

        private void placeCarrierBtn_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.player1SecretGridGroupBox.Controls)
            {
                if (control is Button)
                {
                    // Make every button clickable
                    control.Enabled = true;
                    control.Click += new EventHandler(placeCarrierOnTile_Click);
                }
            }

            foreach (Control control in this.player2SecretGridGroupBox.Controls)
            {
                if (control is Button)
                {
                    // Make every button clickable
                    control.Enabled = true;
                }
            }
        }

        void placeCarrierOnTile_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Tile tile = player1.secretGrid.tiles.Where(t => t._button.Name == button.Name).FirstOrDefault();
            player1.secretGrid.PlaceCarrier(tile);  
            tile.isOccupied = true;
        }
        // TODO: Make curPlayer variable
        // TODO: Place placecarrier function in a smart place (Event handler for button click after placecarrier button has been clicked)
        // TODO: find a way to start the game
        // TODO: Determine which player's turn it is
    }
}
