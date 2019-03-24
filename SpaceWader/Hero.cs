using System;

namespace SpaceWader
{
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

        private static bool CanMove(Coordinate c)
        {
            if (c.X < 0 || c.X > 25) return false;
            if (c.Y < 1 || c.Y > 11) return false;
            return true;
        }
    }
}
