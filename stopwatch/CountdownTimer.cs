using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stopwatch
{
    class CountdownTimer
    {
        public static string addZero(string time)
        {
            if (time == "seconds")
            {
                if (Form1.seconds < 10)
                {
                    return "0" + System.Convert.ToString(Form1.seconds);
                }
                else
                {
                    return System.Convert.ToString(Form1.seconds);
                }
            }
            if (time == "minutes")
            {
                if (Form1.minutes < 10)
                {
                    return "0" + System.Convert.ToString(Form1.minutes);
                }
                else
                {
                    return System.Convert.ToString(Form1.minutes);
                }
            } 
            if (time == "hours")
            {
                if (Form1.hours < 10)
                {
                    return "0" + System.Convert.ToString(Form1.hours);
                }
                else
                {
                    return System.Convert.ToString(Form1.hours);
                }
            }                       
            return "";
        }
    }
}
