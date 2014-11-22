using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stopwatch
{
    class CountdownTimer
    {
        public static int[,] timeArr = { { 0, 0 }, { 0, 0 }, { 0, 0 } };

        public static string addZero(string time = "hours")
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
            else if (time == "minutes")
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
            else
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
        }
                
        public static string updateInput(string time = "hours")
        {
            if (timeArr[2, 0] == 10)
            {
                timeArr[2, 0] = 0;
                timeArr[2, 1]++;
            }
            if(time == "seconds")
            {
                return System.Convert.ToString(timeArr[0, 1]) + System.Convert.ToString(timeArr[0, 0]);
            }
            else if(time == "minutes")
            {
                return System.Convert.ToString(timeArr[1, 1]) + System.Convert.ToString(timeArr[1, 0]);
            }
            else
            {
               return System.Convert.ToString(timeArr[2, 1]) + System.Convert.ToString(timeArr[2, 0]);
            }            
        }        
    }
}
