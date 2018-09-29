using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class Heal:BaseObject
    {
        Image newImage;
        public Heal(Point pos, Point dir, Size size):base(pos,dir,size)
        {
            newImage = Image.FromFile("heal.png");
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y);
        }
        public override void Update()
        {
            Random random = new Random();
            Pos.X = random.Next(0, Game.Width - 100);
            Pos.Y = random.Next(0, Game.Height - 100);
        }
    }
}
