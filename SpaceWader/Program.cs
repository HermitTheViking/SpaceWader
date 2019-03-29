using System;

namespace SpaceWader
{
    class Program
    {
        private static void InitGame()
        {
            Hero.HeroCord = new Coordinate()
            {
                X = 0,
                Y = 1
            };

            Hero.MoveHero(0, 0);
        }

        static void Main(string[] args)
        {
            Timers.TimerSet(700);
            
            World.Borders();

            InitGame();

            ConsoleKeyInfo keyInfo;

            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        Timers.TimerStop();
                        Hero.MoveHero(1, 0);
                        Timers.TimerStart();
                        break;

                    case ConsoleKey.LeftArrow:
                        Timers.TimerStop();
                        Hero.MoveHero(-1, 0);
                        Timers.TimerStart();
                        break;

                    case ConsoleKey.DownArrow:
                        Timers.TimerStop();
                        Hero.MoveHero(0, 1);
                        Timers.TimerStart();
                        break;
                }

                if (!Hero.CanMove(Hero.NewHero(1, 1)))
                {
                    break;
                }
            }

            Hero.RemoveHero();
            Timers.TimerEnd();

            if (!Hero.CanMove(Hero.NewHero(1, 1)))
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
