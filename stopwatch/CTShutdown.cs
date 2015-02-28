using System;
using System.Diagnostics;

namespace stopwatch
{
    class CTShutdown
    {
        public static byte interval = 11;

        public static string callShutdown()
        {
            if (interval > 0)
            {
                interval--;
                return "Shutdown in " + interval;
            }
            else return "Shutting down!";
        }

        public static string callSleep()
        {
            if (interval > 0)
            {
                interval--;
                return "Sleep in " + interval;
            }
            else return "Falling asleep!";
        }
    }
}
