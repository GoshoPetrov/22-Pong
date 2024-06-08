using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Ball
    {
        private readonly char _tile;
        private readonly int _initialX;
        private readonly int _initialY;

        private int _x;
        private int _y;
        private int _dx;
        private int _dy;

        public Ball(int x, int y, char tile = '0')
        {
            this._tile = tile;

            this._x = this._initialX = x;
            this._y = this._initialY = y;

            this._dx = 1;
            this._dy = 1;
        }

        public int Y => this._y;
        public int X => this._x;

        public void Draw(Field field)
        {
            field.Set(row: this._x, col: this._y, this._tile);
        }

        public void CalculateTrajectory(Field field, char racketTile)
        {
            field.Set(row: this._x, col: this._y, ' ');

            char place = field.Get(row: this._x + this._dx, col: this._y + this._dy);
            if (place == field.Tile)
            {
                this._dx *= -1;
            }

            if (place == racketTile)
            {
                this._dy *= -1;
            }

            this._x += this._dx;
            this._y += this._dy;

            this.Draw(field);

        }

        public void Reset(Field field)
        {
            field.Set(row: this._x, col: this._y, value: ' ');
            this._x = this._initialX;
            this._y = this._initialY;
            this.Draw(field);
        }
    }
}
