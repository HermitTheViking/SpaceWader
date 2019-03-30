using System;

namespace SpaceWader
{
    class Program
    {
        static void Main(string[] args)
        {           
            World.InitGame();

            ConsoleKeyInfo keyInfo;

            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                try
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.RightArrow:
                            Hero.MoveHero(1, 0);
                            break;

                        case ConsoleKey.LeftArrow:
                            Hero.MoveHero(-1, 0);
                            break;

                        case ConsoleKey.DownArrow:
                            Timers.TimerStop();
                            Hero.MoveHero(0, 1);
                            Timers.TimerStart();
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    World.EndGame(ae);
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
