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
        public static int Count = 0;
        //private static Bullet _bullet;
        private static List<Bullet> _bullets = new List<Bullet>();
        private static Asteroid[] _asteroids;
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        private static Timer _timer = new Timer();
        public static Random Rnd = new Random();
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

            _timer.Interval = 100;
            _timer.Start();
            _timer.Tick += Timer_Tick;
            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;

        }
        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs) obj.Draw();
            foreach (Asteroid a in _asteroids) { a?.Draw(); }
            foreach (Bullet b in _bullets) b.Draw();
            _ship?.Draw();
            _heal?.Draw();
            
            if (_ship != null)
                Buffer.Graphics.DrawString("Energy: " + _ship.Energy + " Counts of asteroids: " + Count, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            Buffer.Render();
        }
        public static void Update()
        {
            Random random = new Random();
            foreach (BaseObject obj in _objs) obj.Update();
            foreach (Bullet b in _bullets) b.Update();
            if (_ship.Collision(_heal)) { _ship.EnergyHigh(Rnd.Next(1, 50)); _heal.Update(); }
            for (var i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();
                for (int j = 0; j < _bullets.Count; j++)
                    if (_asteroids[i] != null && _bullets[j].Collision(_asteroids[i]))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        _asteroids[i] = null;
                        _asteroids[i] = new Asteroid(new Point(Width - 120, random.Next(0, Height - 120)), new Point(10, 10), new Size(5, 45));
                        Count++;
                        _bullets.RemoveAt(j);
                        j--;
                    }
                if (_asteroids[i] == null || !_ship.Collision(_asteroids[i])) continue;
                _ship.EnergyLow(Rnd.Next(1, 10));

                System.Media.SystemSounds.Asterisk.Play();
                if (_ship.Energy <= 0) _ship.Die();
            }
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
                _asteroids[i] = new Asteroid(new Point(random.Next(0, Width - 120), random.Next(0, Height - 120)), new Point(10, 10), new Size(5, 45));
            }            

        }
        private static Ship _ship = new Ship(new Point(10, 400), new Point(0, 0), new Size(50, 50));
        private static Heal _heal = new Heal(new Point(10, 400), new Point(0, 0), new Size(50, 50));
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _bullets.Add(new Bullet(new Point(_ship.Rect.X + 20, _ship.Rect.Y), new Point(4, 0), new Size(15, 45)));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
            if (e.KeyCode == Keys.Left) _ship.Left();
            if (e.KeyCode == Keys.Right) _ship.Right();
        }
    }
}
