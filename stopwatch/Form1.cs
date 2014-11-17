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
using System.IO;

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
        int hours = 0, minutes = 0, seconds = 0, time = 0, tempSeconds3, tempSeconds4;
        int[,] timeArr = { { 0,0 }, { 0,0 }, { 0,0 } };
        bool mute = false, CTstarted = false, minusMinutes = false, sixty2 = false;        

        public void shift(int number)
        {
            timeArr[2, 1] = timeArr[2, 0];
            timeArr[2, 0] = timeArr[1, 1];
            timeArr[1, 1] = timeArr[1, 0];
            timeArr[1, 0] = timeArr[0, 1];
            timeArr[0, 1] = timeArr[0, 0];
            timeArr[0, 0] = number;
            updateInput();
            startBtn.Enabled = true;
            btn0.Enabled = true;
        }

        public void updateInput()
        {
            ctSecondsLbl.Text = System.Convert.ToString(timeArr[0, 1]) + System.Convert.ToString(timeArr[0, 0]);
            ctMinutesLbl.Text = System.Convert.ToString(timeArr[1, 1]) + System.Convert.ToString(timeArr[1, 0]);
            ctHoursLbl.Text = System.Convert.ToString(timeArr[2, 1]) + System.Convert.ToString(timeArr[2, 0]);
        }

        public void updateTime()
        {
            ctSecondsLbl.Text = System.Convert.ToString(seconds);
            ctMinutesLbl.Text = System.Convert.ToString(minutes);
            ctHoursLbl.Text = System.Convert.ToString(hours);
        }

        public void addZero()
        {
            if (seconds < 10)
            {
                ctSecondsLbl.Text = "0" + System.Convert.ToString(seconds);
            }
            else
            {
                ctSecondsLbl.Text = System.Convert.ToString(seconds);
            }

            if (minutes < 10)
            {
                ctMinutesLbl.Text = "0" + System.Convert.ToString(minutes);
            }
            else
            {
                ctMinutesLbl.Text = System.Convert.ToString(minutes);
            }

            if (hours < 10)
            {
                ctHoursLbl.Text = "0" + System.Convert.ToString(hours);
            }
            else
            {
                ctHoursLbl.Text = System.Convert.ToString(hours);
            }
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
                if (!mute)
                {
                    player.Play();
                }
                ctHLabel.ForeColor = ctMLabel.ForeColor = ctSLabel.ForeColor = ctHoursLbl.ForeColor = ctMinutesLbl.ForeColor = ctSecondsLbl.ForeColor = System.Drawing.Color.Red;
                startBtn.Text = "Stop";
                startBtn.Enabled = true;
                CTstarted = false;
                tempSeconds3 = DateTime.Now.Second;
                tempSeconds4 = tempSeconds3 + 1;
                timeFromEnd();
                return false;                
            }
            return true;
        }

        public void addTime(int i)
        {
            if (timeToSeconds())
            {
                time += i * 60;
                minutes += i;
                progressBar1.Maximum = time;
            }
            if (minutes > 59)
            {
                minutes -= 60;
                hours++;
                ctHoursLbl.Visible = true;
                ctHLabel.Visible = true;
            }
        }

        public void removeTime(int i)
        {            
                time -= i * 60;
                minutes -= i;
                progressBar1.Maximum = time;            
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
                checkMinutes();                              
                await Task.Delay(1000);                
            } while (timeToSeconds() && CTstarted);
        }

        public void checkMinutes()
        {
            if (minutes < 1 && hours == 0 && minusMinutes)
            {
                buttonAdd1.Enabled = false;
            }
            else
            {
                buttonAdd1.Enabled = true;
            }
            if (minutes < 5 && hours == 0 && minusMinutes)
            {
                buttonAdd5.Enabled = false;
            }
            else
            {
                buttonAdd5.Enabled = true;
            }
            if (minutes < 10 && hours == 0 && minusMinutes)
            {
                buttonAdd10.Enabled = false;
            }
            else
            {
                buttonAdd10.Enabled = true;
            }
            if (minutes < 30 && hours == 0 && minusMinutes)
            {
                buttonAdd30.Enabled = false;
            }
            else
            {
                buttonAdd30.Enabled = true;
            }
        }

        private void startBtn_Click_1(object sender, EventArgs e)
        {            
            seconds = System.Convert.ToInt32(ctSecondsLbl.Text);
            minutes = System.Convert.ToInt32(ctMinutesLbl.Text);
            hours = System.Convert.ToInt32(ctHoursLbl.Text);
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
            ctHoursLbl.Text = System.Convert.ToString(hours);
            if (hours > 0 && minutes <= 0 && seconds <= 0)
            {                
                hours--;
                minutes = 59;
                seconds = 60;                
            }
            if (minutes > 0 && seconds <= 0)
            {                
                minutes--;
                seconds = 60;                
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
                buttonAdd1.Enabled = true;
                buttonAdd5.Enabled = true;
                buttonAdd10.Enabled = true;
                buttonAdd30.Enabled = true;
                plusMinusBtn.Enabled = true;
                pauseBtn1.Enabled = true;
                closeBtn.Text = "Stop";
                if (hours == 0)
                {
                    ctHoursLbl.Visible = false;
                    ctHLabel.Visible = false;
                }
                time += hours * 3600;
                time += minutes * 60;
                time += seconds;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = time;
                progressBar1.Step = 1;
                startCountdown();
            }
            else
            {
                ctHoursLbl.Text = "00";
            }
            CTstarted = true;
            closeBtn.Text = "Exit";
            buttonAdd1.Text = "+1'";
            buttonAdd5.Text = "+5'";
            buttonAdd10.Text = "+10'";
            buttonAdd30.Text = "+30'";
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
            if (!minusMinutes)
            {
                if (CTstarted)
                {
                    addTime(1);
                }
                else
                {
                    timeArr[1, 0] = 1;
                    updateInput();
                    startBtn.Enabled = true;
                }
            }
            else
            {
                removeTime(1);
            }
        }

        private void buttonAdd5_Click(object sender, EventArgs e)
        {
            if (!minusMinutes)
            {
                if (CTstarted)
                {
                    addTime(5);
                }
                else
                {
                    timeArr[1, 0] = 5;
                    updateInput();
                    startBtn.Enabled = true;
                }
            }
            else
            {
                removeTime(5);
            }
        }

        private void buttonAdd10_Click(object sender, EventArgs e)
        {
            if (!minusMinutes)
            {
                if (CTstarted)
                {
                    addTime(10);
                }
                else
                {
                    timeArr[1, 1] = 1;
                    updateInput();
                    startBtn.Enabled = true;
                }
            }
            else
            {
                removeTime(10);
            }
        }

        private void buttonAdd30_Click(object sender, EventArgs e)
        {
            if (!minusMinutes)
            {
                if (CTstarted)
                {
                    addTime(30);
                }
                else
                {
                    timeArr[1, 1] = 3;
                    updateInput();
                    startBtn.Enabled = true;
                }
            }
            else
            {
                removeTime(30);
            }
        }

        private void beepBox_CheckedChanged(object sender, EventArgs e)
        {
            if (beepBox.Checked) mute = false;
            else mute = true;
        }

        private void plusMinusBtn_Click(object sender, EventArgs e)
        {
            if (!minusMinutes)
            {
                buttonAdd1.Text = "-1'";
                buttonAdd5.Text = "-5'";
                buttonAdd10.Text = "-10'";
                buttonAdd30.Text = "-30'";
                minusMinutes = true;
            }
            else
            {
                buttonAdd1.Text = "+1'";
                buttonAdd5.Text = "+5'";
                buttonAdd10.Text = "+10'";
                buttonAdd30.Text = "+30'";
                minusMinutes = false;
            }
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad1:                    
                case Keys.D1:                    
                    btn1.PerformClick();
                    break;
                case Keys.NumPad2:
                case Keys.D2:                    
                    btn2.PerformClick();
                    break;
                case Keys.NumPad3:
                case Keys.D3:
                    btn3.PerformClick();
                    break;
                case Keys.NumPad4:
                case Keys.D4:                    
                    btn4.PerformClick();
                    break;
                case Keys.NumPad5:
                case Keys.D5:                    
                    btn5.PerformClick();
                    break;
                case Keys.NumPad6:
                case Keys.D6:                    
                    btn6.PerformClick();
                    break;
                case Keys.NumPad7:
                case Keys.D7:                    
                    btn7.PerformClick();
                    break;
                case Keys.NumPad8:
                case Keys.D8:
                    btn8.PerformClick();
                    break;
                case Keys.NumPad9:
                case Keys.D9:
                    btn9.PerformClick();
                    break;
                case Keys.NumPad0:
                case Keys.D0:
                    btn0.PerformClick();
                    break;
            }
        }

        private void pauseBtn1_Click(object sender, EventArgs e)
        {
            if (CTstarted)
            {
                CTstarted = false;
            }
            else
            {
                CTstarted = true;
                startCountdown();
            }
        }

        public async void timeFromEnd()
        {
            do
            {
                tempSeconds3 = DateTime.Now.Second;
                if (tempSeconds3 == tempSeconds4)
                {
                    seconds++;                    
                    tempSeconds4 = tempSeconds3 + 1;
                }
                if (tempSeconds3 == 0 && !sixty2)
                {
                    seconds++;
                    tempSeconds4 = 1;
                    sixty2 = true;
                }
                if (seconds == 10)
                {
                    sixty2 = false;
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
                if (seconds < 10)
                {
                    ctSecondsLbl.Text = "0" + System.Convert.ToString(seconds);
                }
                else
                {
                    ctSecondsLbl.Text = System.Convert.ToString(seconds);
                }
                if (minutes < 10)
                {
                    ctMinutesLbl.Text = "0" + System.Convert.ToString(minutes);
                }
                else
                {
                    ctMinutesLbl.Text = System.Convert.ToString(minutes);
                }
                if (hours2 < 10)
                {
                    ctHoursLbl.Text = "0" + System.Convert.ToString(hours);
                }
                else
                {
                    ctHoursLbl.Text = System.Convert.ToString(hours);
                }
                await Task.Delay(1000);
            } while (startBtn.Text == "Stop");
        }

        #endregion

        #region Stopwatch

        int hours2 = 0, minutes2 = 0, seconds2 = 0, tempSeconds1, tempSeconds2, lapCount = 0, lapHours, lapMinutes, lapSeconds;
        bool stopwatchRunning = false, sixty = false;
        String results;
        SaveFileDialog sfd = new SaveFileDialog();

        public async void startMs()
        {
            do
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
                {
                    sixty = false;
                }
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
                if (DateTime.Now.Millisecond < 10)
                {
                    msLbl.Text = "00" + System.Convert.ToString(DateTime.Now.Millisecond);
                }
                else if (DateTime.Now.Millisecond > 10 && DateTime.Now.Millisecond < 100)
                {
                    msLbl.Text = "0" + System.Convert.ToString(DateTime.Now.Millisecond);
                }
                else
                {
                    msLbl.Text = System.Convert.ToString(DateTime.Now.Millisecond);
                }
                if (seconds2 < 10)
                {
                    seconds2Lbl.Text = "0" + System.Convert.ToString(seconds2);
                }
                else 
                {
                    seconds2Lbl.Text = System.Convert.ToString(seconds2);
                }
                if (minutes2 < 10)
                {
                    minutes2Lbl.Text = "0" + System.Convert.ToString(minutes2);
                }
                else
                {
                    minutes2Lbl.Text = System.Convert.ToString(minutes2);
                }
                if (hours2 < 10)
                {
                    hours2Lbl.Text = "0" + System.Convert.ToString(hours2);
                }
                else
                {
                    hours2Lbl.Text = System.Convert.ToString(hours2);
                }
                await Task.Delay(33);
            } while (stopwatchRunning);
        }

        private void start2Btn_Click(object sender, EventArgs e)
        {
            if (start2Btn.Text == "Stop")
            {
                start2Btn.Text = "Start";
                lapBtn.Enabled = false;
                stopwatchRunning = false;
                pauseBtn2.Enabled = false;
                hours2 = minutes2 = seconds2 = 0;
                hours2 = minutes2 = seconds2 = 0;
                hours2 = minutes2 = seconds2 = 0;
                lapSeconds = lapMinutes = lapHours = 0;
                seconds2Lbl.Text = minutes2Lbl.Text = hours2Lbl.Text = "00";
                msLbl.Text = "000";
                if (listBox1.Items.Count > 0)
                {
                    saveBtn.Enabled = true;
                }
            }
            else
            {
                start2Btn.Text = "Stop";
                lapBtn.Enabled = true;
                pauseBtn2.Enabled = true;
                stopwatchRunning = true;
                saveBtn.Enabled = false;
                listBox1.Items.Clear();
                tempSeconds1 = DateTime.Now.Second;
                tempSeconds2 = tempSeconds1 + 1;
                startMs();
            }
        }

        private void lapBtn_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            lapCount++;
            if (lapCount < 10)
            {
                listBox1.Items.Add("# 0" + lapCount + "  " + hours2 + ":" + minutes2 + ":" + seconds2 + "." + DateTime.Now.Millisecond + "   " + lapHours + ":" + lapMinutes + ":" + lapSeconds);
            }
            else
            {
                listBox1.Items.Add("# " + lapCount + "  " + hours2 + ":" + minutes2 + ":" + seconds2 + "." + DateTime.Now.Millisecond + "   " + lapHours + ":" + lapMinutes + ":" + lapSeconds);
            }
            results += listBox1.GetItemText(listBox1.SelectedItem) + System.Environment.NewLine;
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            lapSeconds = lapMinutes = lapHours = 0;            
        }

        private void close2Btn_Click(object sender, EventArgs e)
        {            
            Application.Exit();
        }

        private void pauseBtn2_Click(object sender, EventArgs e)
        {
            if (stopwatchRunning)
            {
                stopwatchRunning = false;
            }
            else
            {
                stopwatchRunning = true;
                startMs();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
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
        #endregion       
        }
}
