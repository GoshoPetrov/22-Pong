using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Racket
    {
        private readonly int _y;
        private readonly int _length;

        private readonly int _initialX;

        private int _x;

        public Racket(int x, int y, int length = 5, char tile = '|')
        {
            this._x = this._initialX = x;
            this._y = y;
            this._length = length;
            this.Tile = tile;
        }
        public char Tile { get; }

        public void Draw(Field field)
        {
            for (int i = 0; i < this._length; i++)
            {
                field.Set(row: i + this._x, col: this._y, this.Tile);
            }
        }

        public void MoveUp(Field field)
        {
            if (field.Get(row: this._x -1, col: this._y) == field.Tile)
            {
                return;
            }
            field.Set(row: this._x + (this._length - 1), col: this._y, value: ' ');
            this._x -= 1;
            field.Set(row: this._x, col: this._y, value: this.Tile);
        }

        public void MoveDown(Field field)
        {
            if (field.Get(row: this._x + this._length, col: this._y) == field.Tile)
            {
                return;
            }
            field.Set(row: this._x, col: this._y, value: ' ');
            this._x += 1;
            field.Set(row: this._x + (this._length - 1), col: this._y, value: this.Tile);
        }

        public void Reset(Field field)
        {
            for (int i=0; i<this._length; i++)
            {
                field.Set(row: i + this._x, col: this._y, value: ' ');
            }

            this._x = this._initialX;
            this.Draw(field);
        }
    }
}
