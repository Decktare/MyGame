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
        Image newImage;
        public RazlomPlanet(Point pos, Point dir, Size size):base(pos,dir,size)
        {
            newImage = Image.FromFile("razlom_1.png");
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y);
        }
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
