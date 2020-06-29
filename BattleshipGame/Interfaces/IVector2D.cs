using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.Interfaces
{
    /// <summary>
    /// Providing simple 2D vector functionality and operations.
    /// </summary>
    /// <typeparam name="T">The value type the vector axis are confined to.</typeparam>
    public interface IVector2D<T> where T : struct
    {
        /// <summary>
        /// x-axis parameter of the vector.
        /// </summary>
        T X { get; set; }

        /// <summary>
        /// y-axis parameter of the vector.
        /// </summary>
        T Y { get; set; }

        /// <summary>
        /// Method for cloning this vector.
        /// </summary>
        /// <returns>A new vector with the same parameter configuration as this vector.</returns>
        IVector2D<T> Clone();

        /// <summary>
        /// Method for adding two vectors axis-wise.
        /// </summary>
        /// <param name="addend">The vector to add to this vector axis-wise</param>
        /// <returns>This vector summed with the addend axis-wise.</returns>
        IVector2D<T> Add(IVector2D<T> addend);

        /// <summary>
        /// Method for subtracting two vectors axis-wise.
        /// </summary>
        /// <param name="subtrahend">The vector to subtract from this vector axis-wise</param>
        /// <returns>This vector subtracted by the subtrahend axis-wise.</returns>
        IVector2D<T> Sub(IVector2D<T> subtrahend);

        /// <summary>
        /// Method for multiplying two vectors axis-wise.
        /// </summary>
        /// <param name="factor">The vector to multiply this vector by axis-wise.</param>
        /// <returns>This vector multiplied by the factor axis-wise.</returns>
        IVector2D<T> Mul(IVector2D<T> factor);

        /// <summary>
        /// Method for multiplying this vector by a factor.
        /// </summary>
        /// <param name="factor">The value to multiply this vector's parameters by.</param>
        /// <returns>This vector multiplied by the factor axis-wise.</returns>
        IVector2D<T> Mul(T factor);

        /// <summary>
        /// Method for dividing two vector axis-wise.
        /// </summary>
        /// <param name="divisor">The vector to divide this vector by axis-wise.</param>
        /// <returns>This vector divided by the divisor axis-wise.</returns>
        IVector2D<T> Div(IVector2D<T> divisor);

        /// <summary>
        /// Method for dividing this vector by a divisor.
        /// </summary>
        /// <param name="divisor">The value to divide this vector's parameters by.</param>
        /// <returns>This vector divided by the divisor axis-wise.</returns>
        IVector2D<T> Div(T divisor);
    }
}
