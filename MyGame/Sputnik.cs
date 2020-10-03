using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class Sputnik: BaseObject
    {
        public Sputnik(Point pos, Point dir, Size size): base(pos, dir, size)
        {
            img = new Bitmap(@"image\sputnik.png");
        }

        Bitmap img;
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
           
            Pos.X = Pos.X + Dir.X;
            if (Pos.X > Game.Width) Pos.X = -50;
            Pos.Y = Pos.Y - Dir.Y;
            if (Pos.Y < -50) Pos.Y = Game.Height;

        }
    }
}
