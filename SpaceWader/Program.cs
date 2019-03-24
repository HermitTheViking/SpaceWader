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

    class Hero
    {
        public static Coordinate HeroCord { get; set; }

        public static void MoveHero(int x, int y)
        {
            Coordinate newHero = new Coordinate()
            {
                X = HeroCord.X + x,
                Y = HeroCord.Y + y
            };

            if (CanMove(newHero))
            {
                RemoveHero();

                Console.SetCursorPosition(newHero.X, newHero.Y);
                Console.Write("x");

                HeroCord = newHero;
            }
        }

        public static void RemoveHero()
        {
            Console.SetCursorPosition(HeroCord.X, HeroCord.Y);
            Console.Write(" ");
        }

        static bool CanMove(Coordinate c)
        {
            if (c.X < 0 || c.X > 24) return false;
            if (c.Y < 0 || c.Y > 10) return false;
            return true;
        }

        private static Timer aTimer;

        public static void SetTimer()
        {
            aTimer = new Timer(700);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        public static void TODOTimer(string todo)
        {
            if (todo == "Stop")
            {
                aTimer.Stop();
            }
            else if (todo == "Start")
            {
                aTimer.Start();
            }
            else if (todo == "Dispose")
            {
                aTimer.Dispose();
            }
        }

        static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            MoveHero(0, 1);
        }
    }

    class World
    {
        public static void WriteAt(string s, int x, int y)
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
    }

    class Program
    {
        private static void InitGame()
        {
            Hero = new Coordinate()
            {
                X = 0,
                Y = 1
            };

            MoveHero(0, 0);
        }

        static void Main(string[] args)
        {
            Hero.SetTimer();

            string border = "+-+-+-+-+-+-+-+-+-+-+-+-+";

            World.WriteAt(border, 0, 0);
            World.WriteAt(border, 0, 11);

            InitGame();

            ConsoleKeyInfo keyInfo;

            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        Hero.TODOTimer("Stop");
                        Hero.MoveHero(1, 0);
                        Hero.TODOTimer("Start");
                        break;

                    case ConsoleKey.LeftArrow:
                        Hero.TODOTimer("Stop");
                        Hero.MoveHero(-1, 0);
                        Hero.TODOTimer("Start");
                        break;

                    case ConsoleKey.DownArrow:
                        Hero.TODOTimer("Stop");
                        Hero.MoveHero(0, 1);
                        Hero.TODOTimer("Start");
                        break;
                }

                if (Hero.)
                {

                }
            }

            Hero.RemoveHero();
            Hero.TODOTimer("Stop");
            Hero.TODOTimer("Dispose");

            if (Hero.HeroCord.Y > 10 | Hero.HeroCord.X > 24)
            {
                World.WriteAt("You have hit the border", 0, 12);
                World.WriteAt("Press any key to exit", 0, 13);
            }
            else
            {
                World.WriteAt("You have hit the ESC key", 0, 12);
                World.WriteAt("Press any key to exit", 0, 13);
            }

            Console.ReadKey();
        }
    }
}
