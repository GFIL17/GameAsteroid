﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAsteroid.VisualObjects
{
    internal class Bullet : VisualObject
    {
        private const int _BulletSizeX = 20;
        private const int _BulletSizeY = 5;
        public Bullet(int Position)
            : base(new Point(0, Position), Point.Empty, new Size(_BulletSizeX, _BulletSizeY))
        {
        }

        public override void Draw(Graphics g)
        {
            var rect = new Rectangle(_Position, _Size);
            g.FillEllipse(Brushes.Red, rect);
            g.DrawEllipse(Pens.White, rect);
        }

        public override void Update()
        {
            _Position = new Point(_Position.X + 20, _Position.Y);
        }
    }
}
