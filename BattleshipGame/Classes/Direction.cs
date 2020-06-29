using BattleshipGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.Classes
{
    public enum Direction
    {
        North, South, East, West
    }
    public static class DirectionUtils
    {
        public static IVector2D<int> ToIntVector(this Direction direction, int magnitude = 1)
        {

            int x = 0, y = 0;

            switch (direction)
            {
                case Direction.North:
                    y = 1;
                    break;
                case Direction.South:
                    y = -1;
                    break;
                case Direction.East:
                    x = 1;
                    break;
                case Direction.West:
                    x = -1;
                    break;
            }

            return new IntVector2D(x, y).Mul(magnitude);
        }
    }
}
