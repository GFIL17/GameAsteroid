using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAsteroid
{
    internal abstract class ImageObejct : VisualObject
    {
        private readonly Image _Image;
        protected ImageObejct(Point Position, Point Direction, Size Size, Image Image) 
            : base(Position, Direction, Size)
        {
            _Image = Image;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(_Image, _Position.X, _Position.Y, _Size.Height, _Size.Width);
        }
    }

    internal class Asteroid : ImageObejct
    {
        private static readonly Image __Image = Image.FromFile("src\\miscellaneous.png");
        public Asteroid(Point Position, Point Direction, int ImageSize) 
            //: base(Position, Direction, new Size(ImageSize, ImageSize), __Image)
            : base(Position, Direction, new Size(ImageSize, ImageSize),Properties.Resources.miscellaneous)
        {

        }

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
