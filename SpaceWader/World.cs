using System;

namespace SpaceWader
{
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

        public static void Borders()
        {
            string border = "+-+-+-+-+-+-+-+-+-+-+-+-+";

            WriteAt(border, 0, 0);
            WriteAt(border, 0, 11);
        }
    }

}
