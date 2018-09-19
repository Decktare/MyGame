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
            
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }
        
        public static void Load()
        {
            Random random = new Random();
            _objs = new BaseObject[21];
            
            //for (int i = 0; i < _objs.Length / 2; i++)
            //{
            //    int size = random.Next(5, 25);
            //    _objs[i] = new BaseObject(new Point(random.Next(0, 750), random.Next(0, 550)), new Point(2 + i, 2 + i), new Size(size, size));
            //}

            for (int i = 0; i < 15; i++)
            {
                int size = random.Next(5, 25);
                _objs[i] = new Star(new Point(random.Next(0, 750), random.Next(0, 550)), new Point(5 + i, 5 + i), new Size(size, size));
            }
            _objs[15] = new HellPlanet(new Point(random.Next(0, 750), random.Next(0, 400)), new Point(3, 3), new Size(0, 0));
            _objs[16] = new Planet(new Point(random.Next(0, 750), random.Next(0, 400)), new Point(4, 4), new Size(0, 0));
            _objs[17] = new Planet(new Point(random.Next(0, 750), random.Next(0, 400)), new Point(4, 4), new Size(0, 0));
            _objs[18] = new RazlomPlanet(new Point(random.Next(0, 750), random.Next(0, 400)), new Point(3, 3), new Size(0, 0));
            _objs[19] = new KolcaPlanet(new Point(random.Next(0, 750), random.Next(0, 400)), new Point(2, 2), new Size(0, 0));
            _objs[20] = new Ship(new Point(200, 200), new Point(2, 2), new Size(0, 0));


        }

    }
}
