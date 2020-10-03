using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class Moon: BaseObject
    {
        public Moon(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            img = new Bitmap(@"image\moon.png");
        }

        Bitmap img;
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < -Size.Width) Pos.X = Game.Width;
        }
    }
}
