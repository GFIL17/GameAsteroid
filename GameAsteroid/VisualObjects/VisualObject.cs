﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameAsteroid.VisualObjects
{
    internal abstract class VisualObject
    {
        protected Point _Position;
        protected Point _Direction;
        protected Size _Size;



        protected VisualObject(Point Position, Point Direction, Size Size)
        {
            _Position = Position;
            _Direction = Direction;
            _Size = Size;
        }

        public abstract void Draw(Graphics g);        

        public virtual void Update()
        {
            _Position.X += _Direction.X;
            _Position.Y += _Direction.Y;

            if (_Position.X < 0)
                _Direction.X *= -1;
            if (_Position.Y < 0)
                _Direction.Y *= -1;

            if (_Position.X > Game.Width)
                _Direction.X *= -1;
            if (_Position.Y > Game.Width)
                _Direction.Y *= -1;
        }
    }

}
