using BattleshipGame.Interfaces;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace BattleshipGame.Classes
{
    /// <summary>
    /// Class representing a vector in the domain of integer numbers.
    /// </summary>
    public class IntVector2D : IVector2D<int>
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="x">x-axis parameter of the vector.</param>
        /// <param name="y">y-axis parameter of the vector.</param>
        public IntVector2D(int x = 0, int y = 0)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public IVector2D<int> Clone()
        {
            return new IntVector2D(X, Y);
        }
        public IVector2D<int> Add(IVector2D<int> addend)
        {
            this.X += addend.X;
            this.Y += addend.Y;
            return this;
        }

        public IVector2D<int> Sub(IVector2D<int> subtrahend)
        {
            this.X -= subtrahend.X;
            this.Y -= subtrahend.Y;
            return this;
        }

        public IVector2D<int> Mul(IVector2D<int> factor)
        {
            this.Y *= factor.Y;
            this.X *= factor.X;
            return this;
        }

        public IVector2D<int> Mul(int factor)
        {
            this.Y *= factor;
            this.X *= factor;
            return this;
        }

        public IVector2D<int> Div(IVector2D<int> divisor)
        {
            this.X /= divisor.X;
            this.Y /= divisor.Y;
            return this;
        }

        public IVector2D<int> Div(int divisor)
        {
            this.X /= divisor;
            this.Y /= divisor;
            return this;
        }

        public override string ToString()
        {
            return X+","+Y;
        }
    }

    public static class IntVectorUtils
    {
        /// <summary>
        /// Converts this vector to a Point object.
        /// </summary>
        /// <param name="vector">An IntVector object.</param>
        /// <returns></returns>
        public static Point ToPoint(this IntVector2D vector)
        {
            return new Point(vector.X, vector.Y);
        }
    }
}
