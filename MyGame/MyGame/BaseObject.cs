using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        public virtual void Draw()
        {
            //Random random = new Random();
            //Image newImage;
            //switch (random.Next(0,5))
            //{
            //    case 0: newImage = Image.FromFile("kolca_1.jpg"); Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y); break;
            //    case 1: newImage = Image.FromFile("kolca_2.jpg"); Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y); break;
            //    case 2: newImage = Image.FromFile("razlom_1.jpg"); Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y); break;
            //    case 3: newImage = Image.FromFile("razlom_2.jpg"); Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y); break;
            //    case 4: newImage = Image.FromFile("razlom_3.jpg"); Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y); break;
            //}

            //Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y,Size.Width, Size.Height);

            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }
        public virtual void Update()
        {
            //Pos.X = Pos.X + Dir.X;
            //Pos.Y = Pos.Y + Dir.Y;
            //if (Pos.X < 0) Dir.X = Game.Width + Size.Width;
            //if (Pos.X > Game.Width) Dir.X = -Dir.X;

            //if (Pos.X < 0) Dir.Y = Game.Height + Size.Height;
            //if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;

            Pos.X = Pos.X - Dir.X;
            //Pos.Y = Pos.Y + Dir.Y;
            //if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
            //if (Pos.Y < 0) Dir.Y = -Dir.Y;
            //if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
    }
}
