using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class Stars1: BaseObject
    {
        public Stars1(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.Green, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.Green, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.Green, Pos.X, Pos.Y+Size.Height / 2, Pos.X + Size.Width, Pos.Y + Size.Height / 2);
            Game.Buffer.Graphics.DrawLine(Pens.Green, Pos.X + Size.Width / 2, Pos.Y, Pos.X + Size.Width / 2, Pos.Y + Size.Width);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
