using BattleshipGame.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// COMMENT WARNING: 
/// I'm not sure about the validity of the way I write "-wise", regarding what I mean,
/// but I am confident that the reader will understand what substitute word I ment to write, 
/// and perhaps send me feedback if they are wiser.
/// </summary>

namespace BattleshipGame.Interfaces
{
    public interface IGrid<T>
    {
        /// <summary>
        /// The amount of columns in the grid.
        /// </summary>
        int ColumnCount { get; }

        /// <summary>
        /// The amount of rows in the grid.
        /// </summary>
        int RowCount { get; }

        /// <summary>
        /// The amount of cells in the grid.
        /// </summary>
        int CellCount { get; }

        /// <summary>
        /// Gets the cell at a given position.
        /// </summary>
        /// <param name="position">The position of the cell to get.</param>
        /// <returns>The object stored in the cell.</returns>
        T GetCellAt(IVector2D<int> position);

        /// <summary>
        /// Sets the object of the cell at a given position.
        /// </summary>
        /// <param name="position">The position of the cell to set.</param>
        /// <param name="obj">The object to pass into the cell.</param>
        void SetCellAt(IVector2D<int> position, T obj);

        /// <summary>
        /// Computes whether a given position is out of the grids boundaries.
        /// </summary>
        /// <param name="position">The position to check.</param>
        /// <returns>Returns true if the given position is out of the grid boundaries.</returns>
        bool PositionIsOutOfBounds(IVector2D<int> position);
    }

    public static class GridUtils
    {
        /// <summary>
        /// Calculates the index of a grid cell based on its 2D vector position.
        /// </summary>
        /// <typeparam name="T">The type of objects stored in the grid.</typeparam>
        /// <param name="position">The 2D vector position of the cell.</param>
        /// <param name="contextGrid">The grid object that contains the cell.</param>
        /// <returns></returns>
        public static int ConvertCoordinatesToIndex<T>(IVector2D<int> position, IGrid<T> contextGrid)
        {
            return position.X + (position.Y * contextGrid.ColumnCount);
        }

        public static IVector2D<int> ConvertIndexToCoordinates<T>(int index, IGrid<T> contextGrid)
        {
            int x = index % contextGrid.ColumnCount;
            int y = index / contextGrid.ColumnCount;
            return new IntVector2D(x, y);
        }

        public static bool PositionIsOutOfBoundsLeft(int x)
        {
            return x < 0;
        }
        public static bool PositionIsOutOfBoundsRight<T>(int x, IGrid<T> contextGrid)
        {
            return x >= contextGrid.ColumnCount;
        }
        public static bool PositionIsOutOfBoundsUp<T>(int y, IGrid<T> contextGrid)
        {
            return y >= contextGrid.RowCount;
        }
        public static bool PositionIsOutOfBoundsDown(int y)
        {
            return y < 0;
        }
        public static bool PositionIsOutOfBounds<T>(IVector2D<int> position, IGrid<T> contextGrid)
        {
            return PositionIsOutOfBoundsLeft(position.X)
                || PositionIsOutOfBoundsRight(position.X, contextGrid)
                || PositionIsOutOfBoundsUp(position.Y, contextGrid)
                || PositionIsOutOfBoundsDown(position.Y);
        }

        /// <summary>
        /// Get the position of an object in a grid.
        /// </summary>
        /// <typeparam name="T">Type of the object inside the grid.</typeparam>
        /// <param name="obj">The object to search for.</param>
        /// <param name="grid">The grid to search.</param>
        /// <returns>Return true if the object was found in the grid. Else return false.</returns>
        public static bool TryGetPositionOf<T>(T obj, IGrid<T> grid, out IVector2D<int> result)
        {
            var position = new IntVector2D();
            for (position.X = 0; position.X < grid.ColumnCount; position.X++)
            {
                for (position.Y = 0; position.Y < grid.RowCount; position.Y++)
                {

                    if (obj.Equals(grid.GetCellAt(position)))
                    {
                        result = position;
                        return true;
                    }
                }
            }

            result = null;
            return false;
        }
    }
}
