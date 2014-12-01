using System;
using System.Windows.Forms;
class Stopwatch
{
    public static int hours2 = 0, minutes2 = 0, seconds2 = 0, tempSeconds1, tempSeconds2, lapCount = 0, lapHours, lapMinutes, lapSeconds;
    public static bool stopwatchRunning = false, sixty = false;
    public static String results;
    public static SaveFileDialog sfd = new SaveFileDialog();
}