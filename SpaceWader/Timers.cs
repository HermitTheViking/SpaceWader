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

        public static void TimerEnd()
        {
            aTimer.Stop();
            aTimer.Dispose();
        }

        static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Hero.MoveHero(0, 1);
        }
    }
}
