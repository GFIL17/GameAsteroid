﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAsteroid.VisualObjects
{
    
    internal class Asteroid : ImageObejct, ICollision
    {
        // private static readonly Image __Image = Image.FromFile("src\\miscellaneous.png");

        public int Power { get; set; } = 3;

        public Asteroid(Point Position, Point Direction, int ImageSize) 
            //: base(Position, Direction, new Size(ImageSize, ImageSize), __Image)
            : base(Position, Direction, new Size(ImageSize, ImageSize),Properties.Resources.miscellaneous)
        {

        }

        public Rectangle Rect => new Rectangle(_Position, _Size);

        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);
    }
}
