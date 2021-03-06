﻿using System;
using System.IO;
using System.Windows.Forms;

class Stopwatch
{
    public static byte hours = 0, minutes = 0, seconds = 0, tempSeconds1, tempSeconds2, lapCount = 0, lapHours, lapMinutes, lapSeconds;
    public static int beepInterval;
    public static bool stopwatchRunning = false, sixty = false, readInterval, startInterval = false, startIntervalRunning = false;
    public static String results;
    public static SaveFileDialog sfd = new SaveFileDialog();

    public static void startMs()
    {
        tempSeconds1 = (byte)DateTime.Now.Second;
        if (lapCount == 0)
        {
            lapSeconds = seconds;
            lapMinutes = minutes;
            lapHours = hours;
        }
        if (tempSeconds1 == tempSeconds2)
        {
            seconds++;
            lapSeconds++;
            tempSeconds2 = (byte)(tempSeconds1 + 1);
        }
        if (tempSeconds1 == 0 && !sixty)
        {
            seconds++;
            tempSeconds2 = 1;
            sixty = true;
        }
        if (seconds == 10) sixty = false;
        if (seconds > 59)
        {
            seconds = 0;
            minutes++;
            lapMinutes++;
        }
        if (minutes > 59)
        {
            minutes = 0;
            hours++;
            lapHours++;
        }
    }

    public static string updateDisplay(string time)
    {
        if (time == "ms")
            if (DateTime.Now.Millisecond < 10) return "00" + System.Convert.ToString(DateTime.Now.Millisecond);
            else if (DateTime.Now.Millisecond > 10 && DateTime.Now.Millisecond < 100) return "0" + System.Convert.ToString(DateTime.Now.Millisecond);
            else return System.Convert.ToString(DateTime.Now.Millisecond);
        else if (time == "seconds")
            if (Stopwatch.seconds < 10) return "0" + System.Convert.ToString(Stopwatch.seconds);
            else return System.Convert.ToString(Stopwatch.seconds);
        else if (time == "minutes")
            if (Stopwatch.minutes < 10) return "0" + System.Convert.ToString(Stopwatch.minutes);
            else return System.Convert.ToString(Stopwatch.minutes);
        else
            if (Stopwatch.hours < 10) return "0" + System.Convert.ToString(Stopwatch.hours);
            else return System.Convert.ToString(Stopwatch.hours);
    }

    public static string getLapText(byte lapCount = 0)
    {
        if (lapCount < 10) return "# 0" + lapCount + "  " + hours + ":" + minutes + ":" + seconds + "." + DateTime.Now.Millisecond + "   " + lapHours + ":" + lapMinutes + ":" + lapSeconds;
        else return "# " + lapCount + "  " + hours + ":" + minutes + ":" + seconds + "." + DateTime.Now.Millisecond + "   " + lapHours + ":" + lapMinutes + ":" + lapSeconds;
    }

    public static void saveResults()
    {
        results += System.Environment.NewLine + System.DateTime.Now + System.Environment.NewLine + "Stopwatch by Ivanpop.";
        sfd.Filter = "Text File|*.txt";
        sfd.FileName = "Results";
        sfd.Title = "Save Results File";
        if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            string path = sfd.FileName;
            BinaryWriter bw = new BinaryWriter(File.Create(path));
            bw.Write(results);
            bw.Dispose();
        }
    }    
}