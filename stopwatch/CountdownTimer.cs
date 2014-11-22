﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stopwatch
{
    class CountdownTimer
    {
        public static int hours = 0, minutes = 0, seconds = 0, time = 0;
        public static int[,] timeArr = { { 0, 0 }, { 0, 0 }, { 0, 0 } };

        public static string addZero(string time = "hours")
        {
            if (time == "seconds")
            {
                if (seconds < 10)
                {
                    return "0" + System.Convert.ToString(seconds);
                }
                else
                {
                    return System.Convert.ToString(seconds);
                }
            }
            else if (time == "minutes")
            {
                if (minutes < 10)
                {
                    return "0" + System.Convert.ToString(minutes);
                }
                else
                {
                    return System.Convert.ToString(minutes);
                }
            } 
            else
            {
                if (hours < 10)
                {
                    return "0" + System.Convert.ToString(hours);
                }
                else
                {
                    return System.Convert.ToString(hours);
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

        public static void shift(int number)
        {
            timeArr[2, 1] = timeArr[2, 0];
            timeArr[2, 0] = timeArr[1, 1];
            timeArr[1, 1] = timeArr[1, 0];
            timeArr[1, 0] = timeArr[0, 1];
            timeArr[0, 1] = timeArr[0, 0];
            timeArr[0, 0] = number;
        }
    }
}
