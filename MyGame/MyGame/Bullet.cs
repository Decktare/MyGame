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
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Image newImage = Image.FromFile("Shoot.png"); Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y);
        }
        public override void Update()
        {
            Pos.X = Pos.X + 10;
        }
    }
}
