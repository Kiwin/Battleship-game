using BattleshipGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.Classes
{
    public class Player
    {
        // Player's secret grid
        public readonly IGrid<ITile> SecretGrid;

        // Player's public grid
        public readonly IGrid<ITile> PublicGrid;

        // Ships
        public IList<IShip> ShipsToBePlaced;

        public string Name { get; internal set; }

        public Player(string name, IList<IShip> shipsToBePlaced, IGrid<ITile> publicGrid, IGrid<ITile> secretGrid)
        {
            this.Name = name;
            this.PublicGrid = publicGrid;
            this.SecretGrid = secretGrid;
            this.ShipsToBePlaced = shipsToBePlaced;
        }

    }
}
