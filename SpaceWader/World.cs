using System;

namespace SpaceWader
{
    class World
    {
        public static void InitGame()
        {
            Borders();

            Hero.HeroCord = new Coordinate()
            {
                X = 0,
                Y = 1
            };

            Hero.MoveHero(0, 0);

            Timers.TimerSet(700);
        }

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

        private static void Borders()
        {
            string border = "+-+-+-+-+-+-+-+-+-+-+-+-+";

            WriteAt(border, 0, 0);
            WriteAt(border, 0, 11);
        }

        public static void EndGame(ArgumentException ae)
        {
            Hero.RemoveHero();
            Timers.TimerStop();
            Timers.TimerDispose();

            if (ae.Message == "On map? False")
            {
                WriteAt("You have hit the border", 0, 12);
                WriteAt("Press any key to exit", 0, 13);
            }
            else
            {
                WriteAt("You have hit the ESC key", 0, 12);
                WriteAt("Press any key to exit", 0, 13);
            }
        }
    }

}
