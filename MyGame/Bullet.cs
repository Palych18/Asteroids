using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.Yellow, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y);
        }
        public override void Update()
        {

            Pos.X = Pos.X + 5;
            if (Pos.X > Game.Width) Pos.X = 0;
        }
    }
}
