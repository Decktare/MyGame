using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class RazlomPlanet: BaseObject
    {
        public RazlomPlanet(Point pos, Point dir, Size size):base(pos,dir,size)
        {
        }
        public override void Draw()
        {

            Random random = new Random();
            Image newImage = Image.FromFile("razlom_1.png"); Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y);

            //Random random = new Random();
            //int rnd = random.Next(0, 2);
            //if(rnd == 0)
            //{
            //    Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            //    Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
            //    Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width / 2, Pos.Y, Pos.X + Size.Width / 2, Pos.Y + Size.Height);
            //    Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y + Size.Height / 2, Pos.X + Size.Width, Pos.Y + Size.Height / 2);
            //}
            //else
            //{
            //    Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width / 2, Pos.Y, Pos.X + Size.Width / 2, Pos.Y + Size.Height);
            //    Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y + Size.Height / 2, Pos.X + Size.Width, Pos.Y + Size.Height / 2);
            //}

        }
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
