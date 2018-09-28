using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class Ship: BaseObject
    {
        private int _energy = 100;
        public int Energy => _energy;
        Image newImage;
        public void EnergyLow(int n)
        {
            _energy -= n;
        }
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            newImage = Image.FromFile("TShip.png");
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y);
        }
        public override void Update()
        {
        }
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - 10;
        }
        public void Down()
        {
            if (Pos.Y < Game.Height - Size.Height) Pos.Y = Pos.Y + 10;
        }
        public void Left()
        {
            if (Pos.X > 0) Pos.X = Pos.X - 10;
        }
        public void Right()
        {
            if (Pos.X < Game.Width - Size.Width) Pos.X = Pos.X + 10;
        }
        public static event Message MessageDie;
        public void Die()
        {
            MessageDie?.Invoke();
        }
    }
}
