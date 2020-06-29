using BattleshipGame.Classes;
using BattleshipGame.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BattleshipGame
{
    public partial class GameWindow : Form
    {
        //Grid
        private const int gridColumns = 10;
        private const int gridRows = 10;
        private int tileWidth { get { return tileButtonTablePanel.Width / gridColumns; } }
        private int tileHeight { get { return tileButtonTablePanel.Width / gridRows; } }

        //Player Fields
        private const int PlayerCount = 2;
        private List<Player> Players;
        private Player CurrentPlayer { get; set; }
        private Player FirstPlayer
        {
            get { return Players[0]; }
        }
        private Player LastPlayer
        {
            get { return Players[Players.Count - 1]; }
        }
        private Player NextPlayer
        {
            get { return Players[(Players.IndexOf(CurrentPlayer) + 1) % Players.Count]; }
        }
        private ButtonGrid ButtonGrid { get; set; }

        //GameState
        private enum GameState { Initializing, Placement, InPlay, GameOver }
        private GameState gameState;

        public GameWindow()
        {
            InitializeComponent();
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            InitializeButtonGridGroupBox();
            InitializeNewGame();
        }
        private void InitializeButtonGridGroupBox()
        {
            gridGroupBox.Parent = this;
            gridGroupBox.Dock = DockStyle.Fill;

            InitializeTileButtonTablePanel();
        }

        private void InitializeTileButtonTablePanel()
        {
            tileButtonTablePanel.ColumnCount = gridColumns;
            tileButtonTablePanel.RowCount = gridRows;

            tileButtonTablePanel.ColumnStyles.Clear();
            tileButtonTablePanel.RowStyles.Clear();

            for (int i = 0; i < gridColumns; i++)
            {
                tileButtonTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / gridColumns));
            }
            for (int i = 0; i < gridRows; i++)
            {
                tileButtonTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / gridRows));
            }

            //Populate 
            ButtonGrid = new ButtonGrid(gridColumns, gridRows);
            ButtonGrid.ButtonClicked += ButtonGrid_ButtonClicked;

            for (int column = 0; column < ButtonGrid.ColumnCount; column++)
            {
                for (int row = 0; row < ButtonGrid.RowCount; row++)
                {
                    var position = new IntVector2D(row, column);
                    var button = ButtonGrid.GetCellAt(position);
                    tileButtonTablePanel.Controls.Add(button);
                    button.Width = tileWidth;
                    button.Height = tileHeight;
                    button.Text = position.ToString();
                    button.Dock = DockStyle.Fill;
                }

            }
        }

        private void ButtonGrid_ButtonClicked(object sender, ButtonGridClickedArgs args)
        {
            // Determine state of game and handle accordingly.
            switch (gameState)
            {
                case GameState.Placement:
                    HandlePlacementPhaseTileClick(tilePosition: args.ButtonPosition);
                    break;
                case GameState.InPlay:
                    HandleInPlayTileClick(tilePosition: args.ButtonPosition);
                    break;
            }
            UpdateVisuals();
        }

        private void InitializeNewGame()
        {
            // Set Gamestate
            gameState = GameState.Initializing;

            //Create player loadouts
            List<IShip> playerLoadout = new List<IShip>();
            AddBattleshipsToLoadout(1, playerLoadout);
            AddCarriersToLoadout(1, playerLoadout);
            AddCruisersToLoadout(1, playerLoadout);
            AddDestroyersToLoadout(1, playerLoadout);
            AddSubmarinesToLoadout(1, playerLoadout);

            // Instantiate Players
            Players = new List<Player>();

            for (int i = 0; i < PlayerCount; i++)
            {
                var newSecretGrid = GenerateTileGrid();
                var newPublicGrid = GenerateTileGrid();
                var newLoadout = new List<IShip>(playerLoadout);
                var playerName = "player" + (i + 1);
                var newPlayer = new Player(playerName, newLoadout, newPublicGrid, newSecretGrid);
                Players.Add(newPlayer);
            }

            CurrentPlayer = FirstPlayer;

            //Start the placement phase.
            gameState = GameState.Placement;
        }

        private IGrid<ITile> GenerateTileGrid()
        {
            return new TileGrid(gridColumns, gridRows);
        }

        private void HandlePlacementPhaseTileClick(IVector2D<int> tilePosition)
        {
            IShip ship = CurrentPlayer.ShipsToBePlaced[0];

            //Attempt to place the ship
            var placementResult = PlaceShip(ship, tilePosition, Direction.East, CurrentPlayer.SecretGrid);

            if (placementResult == ShipPlacementResult.ShipWasPlaced)
            {
                CurrentPlayer.ShipsToBePlaced.Remove(ship);
                DecidePhaseAfterPlacement();
            }
        }

        public ShipPlacementResult PlaceShip(IShip ship, IVector2D<int> position, Direction direction, IGrid<ITile> grid)
        {
            //Check if one end of the ship if out of bounds.
            if (grid.PositionIsOutOfBounds(position)) return ShipPlacementResult.ShipWasNotPlaced;

            //Check if the other end of the ship if out of bounds.
            IVector2D<int> shipVector = direction.ToIntVector(ship.Size);
            IVector2D<int> shipVectorOffset = position.Clone().Add(shipVector);
            if (grid.PositionIsOutOfBounds(shipVectorOffset)) return ShipPlacementResult.ShipWasNotPlaced;

            //List of tiles that the ship is going to occupy.
            List<ITile> checkedTiles = new List<ITile>();
            IVector2D<int> shipNormalVector = direction.ToIntVector();

            //Check if any tile along the given direction in the magnitude of the ships length is occupied.
            for (int i = 0; i < ship.Size; i++)
            {
                IVector2D<int> interpolatedShipVector = shipNormalVector.Clone().Mul(i);
                IVector2D<int> tilePosition = position.Clone();
                tilePosition.Add(interpolatedShipVector);

                if (grid.PositionIsOutOfBounds(tilePosition)) return ShipPlacementResult.ShipWasNotPlaced;
                ITile tile = grid.GetCellAt(tilePosition);

                //If any tile in the magnitude of the ship is occupied then cancel placement.
                if (tile.IsOccupied) return ShipPlacementResult.ShipWasNotPlaced;

                //Add tile for later assignment.
                checkedTiles.Add(tile);
            }

            foreach (ITile tile in checkedTiles)
            {
                tile.Occupant = ship;
            }

            //Ship placement was successful.
            return ShipPlacementResult.ShipWasPlaced;
        }

        private void HandleInPlayTileClick(IVector2D<int> tilePosition)
        {

        }

        private void DecidePhaseAfterPlacement()
        {
            if (CurrentPlayer.ShipsToBePlaced.Count == 0)
            {
                if (CurrentPlayer == LastPlayer)
                {
                    SwitchToInPlayPhase();
                    return;
                }
                CurrentPlayer = NextPlayer;
            }
        }

        private void SwitchToInPlayPhase()
        {
            CurrentPlayer = Players[0];
            gameState = GameState.InPlay;
        }

        private void NewGameBtn_Click(object sender, EventArgs e)
        {
            InitializeNewGame();
        }

        private void UpdateVisuals()
        {
            gridGroupBox.Text = CurrentPlayer.Name;
            var gridToRender = CurrentPlayer.SecretGrid;



            ProjectTileGridToButtonGrid(gridToRender, ButtonGrid);
        }

        private Color GenerateColorFromTileState(ITile tile)
        {
            if (tile.IsOccupied) return Color.Red;
            return Color.Wheat;
        }

        private void ProjectTileGridToButtonGrid(IGrid<ITile> tileGrid, IGrid<Button> buttonGrid)
        {
            //Check if the two grids have the same dimensions.
            if (tileGrid.ColumnCount != buttonGrid.ColumnCount || tileGrid.RowCount != buttonGrid.RowCount)
            {
                throw new Exception("The two grids differ dimensionally, and can therefore not be projected upon another.");
            }

            for (int column = 0; column < buttonGrid.ColumnCount; column++)
            {
                for (int row = 0; row < buttonGrid.RowCount; row++)
                {
                    var position = new IntVector2D(column, row);
                    var tile = tileGrid.GetCellAt(position);
                    var buttonColor = GenerateColorFromTileState(tile);
                    buttonGrid.GetCellAt(position).BackColor = buttonColor;
                }
            }
        }
        private void AddCarriersToLoadout(int amount, List<IShip> shipsList)
        {
            for (int i = 0; i < amount; i++)
            {
                shipsList.Add(new Carrier());
            }
        }
        private void AddBattleshipsToLoadout(int amount, List<IShip> shipsList)
        {
            for (int i = 0; i < amount; i++)
            {
                shipsList.Add(new Battleship());
            }
        }
        private void AddCruisersToLoadout(int amount, List<IShip> shipsList)
        {
            // 1 carrier per player
            for (int i = 0; i < amount; i++)
            {
                shipsList.Add(new Cruiser());
            }
        }
        private void AddSubmarinesToLoadout(int amount, List<IShip> shipsList)
        {
            // 1 carrier per player
            for (int i = 0; i < amount; i++)
            {
                shipsList.Add(new Submarine());
            }
        }
        private void AddDestroyersToLoadout(int amount, List<IShip> shipsList)
        {
            for (int i = 0; i < amount; i++)
            {
                shipsList.Add(new Destroyer());
            }
        }
    }
}
