using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stopwatch
{
    class CountdownTimer
    {
        public static TaskbarManager taskbar = TaskbarManager.Instance;
        public static System.Media.SoundPlayer player = new System.Media.SoundPlayer(stopwatch.Resource1.beep);
        public static sbyte hours = 0, minutes = 0, seconds = 0, tempSeconds1, tempSeconds2;
        public static short time = 0;
        public static byte[,] timeArr = { { 0, 0 }, { 0, 0 }, { 0, 0 } };
        public static bool CTstarted = false, CTended = false, minusMinutes = false, sixty = false;

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

        public static void shift(byte number)
        {
            timeArr[2, 1] = timeArr[2, 0];
            timeArr[2, 0] = timeArr[1, 1];
            timeArr[1, 1] = timeArr[1, 0];
            timeArr[1, 0] = timeArr[0, 1];
            timeArr[0, 1] = timeArr[0, 0];
            timeArr[0, 0] = number;
        }

        public static void setTime(byte precision = 0)
        {
            switch (precision)
            {
                case 2: time = (short)(timeArr[1, 1] * 10 + timeArr[1, 0]);
                    break;
                case 3: time = (short)(timeArr[2, 0] * 100 + timeArr[1, 1] * 10 + timeArr[1, 0]);
                    break;
                case 4: time = (short)(timeArr[2, 1] * 1000 + timeArr[2, 0] * 100 + timeArr[1, 1] * 10 + timeArr[1, 0]);
                    break;
                case 6: time = (short)(timeArr[2, 1] * 100000 + timeArr[2, 0] * 10000 + timeArr[1, 1] * 1000 + timeArr[1, 0] * 100 + timeArr[0, 1] * 10 + timeArr[0, 0]);
                    break;
            }            
        }

        public static void timeFromEnd()
        {
            tempSeconds1 = (sbyte)(DateTime.Now.Second);
            if (tempSeconds1 == tempSeconds2)
            {
                seconds++;
                tempSeconds2 = (sbyte)(tempSeconds1 + 1);
            }
            if (tempSeconds1 == 0 && !sixty)
            {
                seconds++;
                tempSeconds2 = 1;
                sixty = true;
            }
            if (seconds == 10)
            {
                sixty = false;
            }
            if (seconds > 59)
            {
                seconds = 0;
                minutes++;
            }
            if (minutes > 59)
            {
                minutes = 0;
                hours++;
            }
        }

        public static void timeToSeconds ()
        {
            if (seconds == 0)
            {
                seconds = 60;
                minutes--;
                if (minutes < 0)
                {
                    hours--;
                    minutes = 59;
                }
            }
            if (CountdownTimer.hours < 0 && !CountdownTimer.CTended)
            {
                Array.Clear(CountdownTimer.timeArr, 0, CountdownTimer.timeArr.Length);
                CountdownTimer.tempSeconds1 = (sbyte)(DateTime.Now.Second);
                CountdownTimer.tempSeconds2 = (sbyte)(CountdownTimer.tempSeconds1 + 1);
                CountdownTimer.time = 0;
            }
        }

        public static void addTime(sbyte i)
        {
            time += (short)(i * 60);
            minutes += i;
            if (minutes > 59)
            {
                minutes -= 60;
                hours++;
            }
        }
    }
}
