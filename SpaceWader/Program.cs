using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWader
{
    class Program
    {
        protected static int origRow;
        protected static int origCol;

        protected static void WriteAt(string s, int x, int y)
        {
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

        protected static void ClearCurrentConsoleLine(int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(' ');
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        static void Main(string[] args)
        {
            for (int i = 1; i < 11; i++)
            {
                string border = "+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+";
                WriteAt(border, 0, 0);
                WriteAt(border, 0, 11);

                string invader = "x";
                WriteAt(invader, 0, i);

                ClearCurrentConsoleLine(0, i-1);

                System.Threading.Thread.Sleep(500);
            }
            
            Console.ReadKey(true);
        }
    }
}
