using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MyGame
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        private static List<BaseObject> _objs;
        private static Asteroid[] _asteroids;
        private static Bullet _bullets;
        
        public static void Load()
        {
            Random rnd = new Random();

            _objs = new List<BaseObject>();
            for (int i = 1; i <= 4; i++)
                _objs.Add(new Sputnik(new Point(-50, i * 150), new Point(i * 2, i), new Size(30, 30)));
            
            _objs.Add(new Moon(new Point(10, 50), new Point(-1, -1), new Size(100, 100)));
            
            _objs.Add(new Saturn(new Point(Game.Width, Game.Height - 200), new Point(-5, -1), new Size(120, 70)));
            
            for (int i = 20; i >= 1; i--)
                _objs.Add(new Stars(new Point(Game.Width, Game.Height - (i * i * 2)), new Point(-i, 0), new Size(5, 5)));
           
            for (int i = 0; i <= 20; i++)
                _objs.Add(new Stars1(new Point(Game.Width, i * 50), new Point(-i * 2, 0), new Size(5, 5)));

            _asteroids = new Asteroid[10];
            for (int i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(5, 40);
                _asteroids[i] = new Asteroid(new Point(Game.Width, rnd.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r, r));
            }

            _bullets = new Bullet(new Point(0, Game.Height/2), new Point(25, 0), new Size(10, 1));
        }

        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {

        }

        public static void Init(Form form)
        {
            //Графическое устройство для вывода графики
            Graphics g;

            //Предоставляем доступ к главному буферу графического 
            //контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

            //Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            //Проверка на задание размера экрана
            if (Width < 0 || Width > 1000 || Height < 0 || Height > 1000)
            {
                throw new ArgumentOutOfRangeException("Не соответствует размер экрана!");
            }

            //Связываем буфер в памяти с графическим объектом для рисования
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer { Interval = 150 };
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
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroid obj in _asteroids)
                obj.Draw();
            _bullets.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
            foreach (Asteroid a in _asteroids)
            {
                a.Update();
                if (a.Collision(_bullets)) { System.Media.SystemSounds.Hand.Play(); }
            }
            _bullets.Update();
        }
    }
}
