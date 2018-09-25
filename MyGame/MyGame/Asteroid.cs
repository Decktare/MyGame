using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class Asteroid: BaseObject, ICloneable
    {
        public int Power { get; set; }
        Image newImage;
        public Asteroid(Point pos, Point dir, Size size): base(pos,dir,size)
        {
            Power = 1;
            newImage = Image.FromFile("meteor.png");
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
        public void Collision()
        {
            Random random = new Random();
            Pos.X = Game.Width + Size.Width;
            Pos.Y = random.Next(0, Game.Height - 20);
        }
        public object Clone()
        {
            Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y), new Size(Size.Width, Size.Height));
            asteroid.Power = Power;
            return asteroid;
        }
    }
}
