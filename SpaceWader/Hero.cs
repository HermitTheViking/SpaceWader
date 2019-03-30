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

                World.WriteAt("x", newHero.X, newHero.Y);

                HeroCord = newHero;
            }
            else if (!CanMove(newHero))
            {
                throw new ArgumentException("On map? " + CanMove(newHero));
            }
        }

        public static void RemoveHero()
        {
            World.WriteAt(" ", HeroCord.X, HeroCord.Y);
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
