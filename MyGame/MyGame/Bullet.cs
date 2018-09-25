using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Bullet : BaseObject
    {
        Image newImage;
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            newImage = Image.FromFile("Shoot.png");
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y);
        }
        public override void Update()
        {
            Pos.X = Pos.X + 10;
        }
    }
}
