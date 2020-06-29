using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }
        IGrid<ITile> SecretGrid { get; }
        IGrid<ITile> PublicGrid { get; }
        List<IShip> ShipsToBePlaced { get; }

    }
}
