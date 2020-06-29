using BattleshipGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.Classes
{
    public abstract class AbstractGrid<T> : IGrid<T>
    {
        public int ColumnCount { get; }

        public int RowCount { get; }

        public int CellCount => ColumnCount * RowCount;

        public T[,] Cells { get; }

        /// <summary>
        /// Abstract class constructor.
        /// </summary>
        /// <param name="columns">Amount of columns in the grid.</param>
        /// <param name="rows">Amount of rows in the grid.</param>
        public AbstractGrid(int columns, int rows) {
            this.ColumnCount = columns;
            this.RowCount = rows;
            this.Cells = new T[ColumnCount, RowCount];
        }

        public T GetCellAt(IVector2D<int> position)
        {
            if (PositionIsOutOfBounds(position)) 
                throw new IndexOutOfRangeException("The given position is outside of grid boundaries.");
            return Cells[position.X, position.Y];
        }

        public void SetCellAt(IVector2D<int> position, T obj)
        {
            if (PositionIsOutOfBounds(position)) 
                throw new IndexOutOfRangeException("The given position is outside of grid boundaries.");
            Cells[position.X, position.Y] = obj;
        }

        public bool PositionIsOutOfBounds(IVector2D<int> position)
        {
            return GridUtils.PositionIsOutOfBounds(position, this);
        }
    }
}
