using System;
using System.Windows.Forms;
class Stopwatch
{
    public static int hours2 = 0, minutes2 = 0, seconds2 = 0, tempSeconds1, tempSeconds2, lapCount = 0, lapHours, lapMinutes, lapSeconds;
    public static bool stopwatchRunning = false, sixty = false;
    public static String results;
    public static SaveFileDialog sfd = new SaveFileDialog();

    public static void startMs()
    {
        tempSeconds1 = DateTime.Now.Second;
        if (lapCount == 0)
        {
            lapSeconds = seconds2;
            lapMinutes = minutes2;
            lapHours = hours2;
        }
        if (tempSeconds1 == tempSeconds2)
        {
            seconds2++;
            lapSeconds++;
            tempSeconds2 = tempSeconds1 + 1;
        }
        if (tempSeconds1 == 0 && !sixty)
        {
            seconds2++;
            tempSeconds2 = 1;
            sixty = true;
        }
        if (seconds2 == 10)
            sixty = false;
        if (seconds2 > 59)
        {
            seconds2 = 0;
            minutes2++;
            lapMinutes++;
        }
        if (minutes2 > 59)
        {
            minutes2 = 0;
            hours2++;
            lapHours++;
        }
    }
}