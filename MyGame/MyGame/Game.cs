using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyGame
{
    class Game
    {
        public static BaseObject[] _objs;
        private static Bullet _bullet;
        private static Asteroid[] _asteroids;
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {

        }
        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

            Width = form.Width;
            Height = form.Height;

            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
            form.KeyDown += Form_KeyDown;

        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroid obj in _asteroids)
                obj.Draw();
            _bullet.Draw();
            Buffer.Render();
        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
            foreach (Asteroid a in _asteroids)
            {
                a.Update();
                if (a.Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    a.Collision();                    
                }
            }
                
            _bullet.Update();
        }
        
        public static void Load()
        {
            Random random = new Random();
            _objs = new BaseObject[40];
            _asteroids = new Asteroid[20];


            for (int i = 0; i < 35; i++)
            {                
                _objs[i] = new Star(new Point(random.Next(0, Width - 50), random.Next(0, Height - 50)), new Point(5 + i, 5 + i), new Size(0, 0));
            }
            _objs[35] = new HellPlanet(new Point(random.Next(0, Width - 120), random.Next(0, Height - 120)), new Point(3, 3), new Size(0, 0));
            _objs[36] = new Planet(new Point(random.Next(0, Width - 120), random.Next(0, Height - 120)), new Point(4, 4), new Size(0, 0));
            _objs[37] = new Planet(new Point(random.Next(0, Width - 120), random.Next(0, Height - 120)), new Point(4, 4), new Size(0, 0));
            _objs[38] = new RazlomPlanet(new Point(random.Next(0, Width- 120), random.Next(0, Height- 120)), new Point(3, 3), new Size(0, 0));
            _objs[39] = new KolcaPlanet(new Point(random.Next(0, Width - 120), random.Next(0, Height - 120)), new Point(2, 2), new Size(0, 0));
            //_bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(50, 45));
            for (var i = 0; i < _asteroids.Length; i++)
            {                
                _asteroids[i] = new Asteroid(new Point(random.Next(0, 750), 200), new Point(10, 10), new Size(5, 45));
            }

        }
        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }
    }
}
