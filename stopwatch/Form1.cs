﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace stopwatch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Countdown Timer

        TaskbarManager taskbar = TaskbarManager.Instance;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(stopwatch.Resource1.beep);
        int hours = 0, minutes = 0, seconds = 0, time = 0;       
        int[,] timeArr = { { 0,0 }, { 0,0 }, { 0,0 } };
        bool mute = false;

        public void shift(int number)
        {
            timeArr[2, 1] = timeArr[2, 0];
            timeArr[2, 0] = timeArr[1, 1];
            timeArr[1, 1] = timeArr[1, 0];
            timeArr[1, 0] = timeArr[0, 1];
            timeArr[0, 1] = timeArr[0, 0];
            timeArr[0, 0] = number;

            update();
        }

        public void update()
        {
            secondsLbl.Text = System.Convert.ToString(timeArr[0, 1]) + System.Convert.ToString(timeArr[0, 0]);
            minutesLbl.Text = System.Convert.ToString(timeArr[1, 1]) + System.Convert.ToString(timeArr[1, 0]);
            hoursLbl.Text = System.Convert.ToString(timeArr[2, 1]) + System.Convert.ToString(timeArr[2, 0]);
        }

        public void addZero()
        {
            if (seconds < 10)
            {
                secondsLbl.Text = "0" + System.Convert.ToString(seconds);
            }
            else
            {
                secondsLbl.Text = System.Convert.ToString(seconds);
            }

            if (minutes < 10)
            {
                minutesLbl.Text = "0" + System.Convert.ToString(minutes);
            }
            else
            {
                minutesLbl.Text = System.Convert.ToString(minutes);
            }

            if (hours < 10)
            {
                hoursLbl.Text = "0" + System.Convert.ToString(hours);
            }
            else
            {
                hoursLbl.Text = System.Convert.ToString(hours);
            }
        }

        public void updateTime()
        {
            secondsLbl.Text = System.Convert.ToString(seconds);
            minutesLbl.Text = System.Convert.ToString(minutes);
            hoursLbl.Text = System.Convert.ToString(hours);
        }

        public bool timeToSeconds()
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


            if (hours < 0)
            {
                if (!mute) player.Play();                
                return false;                
            }            

            return true;
        }

        public async void startCountdown()
        {
            do
            {
                seconds--;
                progressBar1.PerformStep();
                updateTime();
                addZero();
                timeToSeconds();
                taskbar.SetProgressValue(progressBar1.Value, time);
                await Task.Delay(1000);
                
            } while (timeToSeconds());
        }

        private void startBtn_Click_1(object sender, EventArgs e)
        {
            seconds = System.Convert.ToInt32(secondsLbl.Text);
            minutes = System.Convert.ToInt32(minutesLbl.Text);
            hours = System.Convert.ToInt32(hoursLbl.Text);

            if (seconds > 59)
            {
                minutes++;
                seconds -= 59;
            }

            if (minutes > 59)
            {
                hours++;
                minutes -= 59;
            }           
            
            hoursLbl.Text = System.Convert.ToString(hours);

            if (hours > 0)
            {
                if (minutes <= 0)
                {
                    if (seconds <= 0)
                    {
                        hours--;
                        minutes = 59;
                        seconds = 60;
                    }
                }
            }

            if (minutes > 0)
            {
                if (seconds <= 0)
                {
                    minutes--;
                    seconds = 60;
                }
            }

            if (seconds != 0 || minutes != 0 || hours != 0)
            {
                btn1.Enabled = false;
                btn2.Enabled = false;
                btn3.Enabled = false;
                btn4.Enabled = false;
                btn5.Enabled = false;
                btn6.Enabled = false;
                btn7.Enabled = false;
                btn8.Enabled = false;
                btn9.Enabled = false;
                btn0.Enabled = false;
                startBtn.Enabled = false;

                closeBtn.Text = "Stop";

                if (hours == 0)
                {
                    hoursLbl.Visible = false;
                    label1.Visible = false;
                }

                time += hours * 3600;
                time += minutes * 60;
                time += seconds;

                progressBar1.Minimum = 0;
                progressBar1.Maximum = time;
                progressBar1.Step = 1;                
                addZero();
                startCountdown();
            }

            else
            {
                hoursLbl.Text = "00";
            }

            buttonAdd1.Enabled = true;            
        }

        private void btn1_Click_1(object sender, EventArgs e)
        {
            shift(1);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            shift(0);
        }

        private void btn2_Click_1(object sender, EventArgs e)
        {
            shift(2);
        }

        private void btn3_Click_1(object sender, EventArgs e)
        {
            shift(3);
        }

        private void btn4_Click_1(object sender, EventArgs e)
        {
            shift(4);
        }

        private void btn5_Click_1(object sender, EventArgs e)
        {
            shift(5);
        }

        private void btn6_Click_1(object sender, EventArgs e)
        {
            shift(6);
        }

        private void btn7_Click_1(object sender, EventArgs e)
        {
            shift(7);
        }

        private void btn8_Click_1(object sender, EventArgs e)
        {
            shift(8);
        }

        private void btn9_Click_1(object sender, EventArgs e)
        {
            shift(9);            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
 
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAdd1_Click(object sender, EventArgs e)
        {
            if (timeToSeconds())
            {                
                time += 60;
                minutes++;
                progressBar1.Maximum = time;
            }
        }

        private void beepBox_CheckedChanged(object sender, EventArgs e)
        {
            if (beepBox.Checked) mute = false;
            else mute = true;
        }

        #endregion

        #region Stopwatch

        int hours2 = 0, minutes2 = 0, seconds2 = 0, tempSeconds1, tempSeconds2, lapCount = 0;
        bool stopwatchRunning = false, sixty = false;

        public async void startMs()
        {
            do
            {
                tempSeconds1 = DateTime.Now.Second;

                if (tempSeconds1 == tempSeconds2)
                {
                    seconds2++;
                    tempSeconds2 = tempSeconds1 + 1;
                }               

                if (tempSeconds1 == 0 && !sixty)
                {
                    seconds2++;
                    tempSeconds2 = 1;
                    sixty = true;
                }

                if (seconds2 == 10) sixty = false;

                if (seconds2 > 59)
                {
                    seconds2 = 0;
                    minutes2++;
                }

                if (minutes > 59)
                {
                    minutes2 = 0;
                    hours2++;
                }
                
                msLbl.Text = System.Convert.ToString(DateTime.Now.Millisecond);
                seconds2Lbl.Text = System.Convert.ToString(seconds2);
                minutes2Lbl.Text = System.Convert.ToString(minutes2);
                                
                if (DateTime.Now.Millisecond < 10) msLbl.Text = "00" + System.Convert.ToString(DateTime.Now.Millisecond);
                if (DateTime.Now.Millisecond > 10 && DateTime.Now.Millisecond < 100) msLbl.Text = "0" + System.Convert.ToString(DateTime.Now.Millisecond);
                if (seconds2 < 10) seconds2Lbl.Text = "0" + System.Convert.ToString(seconds2);
                if (minutes2 < 10) minutes2Lbl.Text = "0" + System.Convert.ToString(minutes2);
                if (hours2 < 10) hours2Lbl.Text = "0" + System.Convert.ToString(hours2);

                await Task.Delay(33);
            } while (stopwatchRunning);
        }

        private void start2Btn_Click(object sender, EventArgs e)
        {
            start2Btn.Enabled = false;
            lapBtn.Enabled = true;
            resetBtn.Enabled = true;
            stopwatchRunning = true;
            tempSeconds1 = DateTime.Now.Second;
            tempSeconds2 = tempSeconds1 + 1; 
            startMs();            
        }        

        private void lapBtn_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            lapCount++;

            if (lapCount < 10) listBox1.Items.Add("# 0" + lapCount + "  " + hours2 + ":" + minutes2 + ":" + seconds2 + "." + DateTime.Now.Millisecond);
            else listBox1.Items.Add("# " + lapCount);
        }

        private void close2Btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

    }
}
