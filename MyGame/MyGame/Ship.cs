using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace MyGame
{

    class Ship : BaseObject
    {
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {

            Random random = new Random();
            Image newImage = Image.FromFile("ship.png"); Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y);
        }
        public override void Update()
        {
            Press_Key();
        }
        private void Press_Key(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                Pos.X = Pos.X - Dir.X;
                if (Pos.X < 0) Pos.X = 0;
            }
            else if (e.KeyCode == Keys.Right)
            {
                Pos.X = Pos.X + Dir.X;
                if (Pos.X > Game.Width + Size.Width) Pos.X = Game.Width + Size.Width;
            }
            else if (e.KeyCode == Keys.Down)
            {
                Pos.Y = Pos.Y + Dir.Y;
                if (Pos.Y > Game.Height + Size.Height) Pos.Y = Game.Height + Size.Height;
            }
            else if (e.KeyCode == Keys.Up)
            {
                Pos.Y = Pos.Y - Dir.Y;
                if (Pos.Y < 0) Pos.Y = 0;
            }
        }

        //Pos.X = Pos.X - Dir.X;
        //if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
    }
}

