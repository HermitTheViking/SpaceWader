using System;

namespace SpaceWader
{
    class Hero
    {
        protected static bool returnBool;

        public static Coordinate HeroCord { get; set; }

        public static Coordinate NewHero (int x, int y)
        {
            Coordinate newHero = new Coordinate()
            {
                X = HeroCord.X + x,
                Y = HeroCord.Y + y
            };

            return newHero;
        }

        public static void MoveHero(int x, int y)
        {
            Coordinate newHero = NewHero(x, y);

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

        public static bool CanMove(Coordinate c)
        {
            returnBool = true;
            if (c.X < 0 || c.X > 24) returnBool = false;
            else if (c.Y < 1 || c.Y > 10) returnBool = false;
            return returnBool;
        }
    }
}
