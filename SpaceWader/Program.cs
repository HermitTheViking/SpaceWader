using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        static void InitGame()
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

        static void RemoveHero()
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

        static void Main(string[] args)
        {
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
                        MoveHero(1, 0);
                        break;

                    case ConsoleKey.LeftArrow:
                        MoveHero(-1, 0);
                        break;

                    case ConsoleKey.DownArrow:
                        MoveHero(0, 1);
                        break;
                }

                if (Hero.Y > 10 | Hero.X > 10)
                {
                    RemoveHero();
                    break;
                }
            }
        }
    }
}
