using System;
using System.Timers;

namespace SpaceWader
{
    class Timers
    {
        private static Timer aTimer;

        private static void SetTimer(int time)
        {
            aTimer = new Timer(time);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        public static void TimerSet(int time)
        {
            SetTimer(time);
        }

        public static void TimerStop()
        {
            aTimer.Stop();
        }

        public static void TimerStart()
        {
            aTimer.Start();
        }

        public static void TimerDispose()
        {
            aTimer.Dispose();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                Hero.MoveHero(0, 1);
            }
            catch (ArgumentException ae)
            {
                World.EndGame(ae);
            }        
        }
    }
}
