using System.Drawing;

namespace GameAsteroid.VisualObjects
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
}
