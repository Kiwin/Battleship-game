using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.Classes
{
    public abstract class Ship : IShip
    {
        public int Size { get; }
        public abstract string Name { get; }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="size">Size of the ship.</param>
        public Ship(int size)
        {
            this.Size = size;
        }
    }
    public sealed class NullShip : Ship
    {
        private static readonly Ship instance = new NullShip();

        static NullShip() { }
        public NullShip() : base(0)
        {
        }

        public static Ship Instance
        {
            get { return instance; }
        }

        public override string Name => "NullShip";
    }
}
