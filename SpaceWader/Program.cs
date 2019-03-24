using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SpaceWader
{
    class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class Program
    {
        protected static void WriteAt(string s, int x, int y)
        {
            int origRow = 0;
            int origCol = 0;

            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        protected static Coordinate Hero { get; set; }

        private static void InitGame()
        {
            Hero = new Coordinate()
            {
                X = 0,
                Y = 1
            };

            MoveHero(0, 0);
        }
        
        static void MoveHero(int x, int y)
        {
            Coordinate newHero = new Coordinate()
            {
                X = Hero.X + x,
                Y = Hero.Y + y
            };

            if (CanMove(newHero))
            {
                RemoveHero();

                Console.SetCursorPosition(newHero.X, newHero.Y);
                Console.Write("x");
                
                Hero = newHero;
            }
        }

        private static void RemoveHero()
        {
            Console.SetCursorPosition(Hero.X, Hero.Y);
            Console.Write(" ");
        }

        static bool CanMove(Coordinate c)
        {
            if (c.X < 0 || c.X >= Console.WindowWidth) return false;
            if (c.Y < 0 || c.Y >= Console.WindowHeight) return false;
            return true;
        }

        private static Timer aTimer;

        private static void SetTimer()
        {
            aTimer = new Timer(700);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            MoveHero(0, 1);
        }

        static bool CheckXY(int x, int y)
        {
            return y > 10 | x > 24 ? true : false;
        }

        static void Main(string[] args)
        {
            SetTimer();

            string border = "+-+-+-+-+-+-+-+-+-+-+-+-+";

            WriteAt(border, 0, 0);
            WriteAt(border, 0, 11);

            InitGame();

            ConsoleKeyInfo keyInfo;

            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        aTimer.Stop();
                        MoveHero(1, 0);
                        aTimer.Start();
                        break;

                    case ConsoleKey.LeftArrow:
                        aTimer.Stop();
                        MoveHero(-1, 0);
                        aTimer.Start();
                        break;

                    case ConsoleKey.DownArrow:
                        aTimer.Stop();
                        MoveHero(0, 1);
                        aTimer.Start();
                        break;
                }

                if (CheckXY(Hero.X, Hero.Y))
                {
                    break;
                }
            }

            RemoveHero();
            aTimer.Stop();
            aTimer.Dispose();

            if (Hero.Y > 10 | Hero.X > 24)
            {
                WriteAt("You have hit the border", 0, 12);
                WriteAt("Press any key to exit", 0, 13);
            }
            else
            {
                WriteAt("You have hit the ESC key", 0, 12);
                WriteAt("Press any key to exit", 0, 13);
            }

            Console.ReadKey();
        }
    }
}
