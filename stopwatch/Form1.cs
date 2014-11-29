using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public void shift(byte number)
        {
            CountdownTimer.shift(number);
            updateInput();            
        }

        public void updateMinusBtnStates()
        {
            CountdownTimer.updateMinusBtnStates();            
            if (CountdownTimer.time < 3000)
            {
                buttonAdd30.Enabled = false;
            }
            else
            {
                buttonAdd30.Enabled = true;
            }
            if (CountdownTimer.time < 1000)
            {
                buttonAdd10.Enabled = false;
            }
            else
            {
                buttonAdd10.Enabled = true;
            }
            if (CountdownTimer.time < 500)
            {
                buttonAdd5.Enabled = false;
            }
            else
            {
                buttonAdd5.Enabled = true;
            }
            if (CountdownTimer.time < 60)
            {
                buttonAdd1.Enabled = clearBtn.Enabled = false;                
                plusMinusBtn.PerformClick();
                plusMinusBtn.Enabled = false;
            }
            else
            {
                buttonAdd1.Enabled = true;
            }
            if (CountdownTimer.time == 0)
            { 
                btn0.Enabled = false;
            }
        }
        
        public void updateTime()
        {
            ctSecondsLbl.Text = CountdownTimer.addZero("seconds");
            ctMinutesLbl.Text = CountdownTimer.addZero("minutes");
            ctHoursLbl.Text = CountdownTimer.addZero();
        }     

        public void updateInput()
        {
            ctSecondsLbl.Text = CountdownTimer.updateInput("seconds");
            ctMinutesLbl.Text = CountdownTimer.updateInput("minutes");
            ctHoursLbl.Text = CountdownTimer.updateInput();
            if (ctHoursLbl.Text == "00" && ctMinutesLbl.Text == "00" && ctSecondsLbl.Text == "00")
            {
                startBtn.Enabled = btn0.Enabled = clearBtn.Enabled = false;
            }
            else
            {
                startBtn.Enabled = btn0.Enabled = clearBtn.Enabled = true;
            }
            if (ctHoursLbl.Text == "00" && ctMinutesLbl.Text == "00" && plusMinusBtn.Enabled)
            {
                plusMinusBtn.Enabled = false;
            }
        }

        public bool timeToSeconds()
        {
            CountdownTimer.timeToSeconds();
            if (CountdownTimer.hours < 0 && beepBox.Checked)
            {
                CountdownTimer.player.Play();
            }
            if (CountdownTimer.hours < 0 && !CountdownTimer.CTended)
            {                
                ctHLabel.ForeColor = ctMLabel.ForeColor = ctSLabel.ForeColor = ctHoursLbl.ForeColor = ctMinutesLbl.ForeColor = ctSecondsLbl.ForeColor = beepBox.ForeColor = System.Drawing.Color.Red;
                startBtn.Text = "Stop";                
                startBtn.Enabled = CountdownTimer.CTended = true;
                pauseBtn1.Enabled = CountdownTimer.CTstarted = buttonAdd1.Enabled = buttonAdd5.Enabled = buttonAdd10.Enabled = buttonAdd30.Enabled = false; 
                timeFromEnd();                              
                return false;                
            }
            return true;
        }

        public void addTime(sbyte i)
        {
            if (timeToSeconds())
            {
                CountdownTimer.addTime(i);                
                progressBar1.Maximum = (int)CountdownTimer.time;
                progressBar1.Value = 0;
            }
            if (CountdownTimer.minutes > 59)
            {                
                ctHoursLbl.Visible = ctHLabel.Visible = true;                
            }
        }

        public async void startCountdown()
        {
            doCountdownStep();
            do
            {
                updateTime(); 
                checkMinutes();                              
                await Task.Delay(100);                
            } while (CountdownTimer.CTstarted);
        }

        public async void doCountdownStep()
        {
            do
            {
                progressBar1.PerformStep();
                timeToSeconds();
                CountdownTimer.taskbar.SetProgressValue(progressBar1.Value, progressBar1.Maximum);                
                CountdownTimer.seconds--;
                CountdownTimer.time--;
                await Task.Delay(1000);
            } while (CountdownTimer.CTstarted);
        }

        public void checkMinutes()
        {            
            if (CountdownTimer.minutes < 1 && CountdownTimer.hours == 0 && CountdownTimer.minusMinutes)
            {
                buttonAdd1.Enabled = false;
                plusMinusBtn.PerformClick();
                plusMinusBtn.Enabled = false;
            }
            else if (CountdownTimer.minutes < 1 && CountdownTimer.hours == 0 && !CountdownTimer.minusMinutes)
            {
                plusMinusBtn.Enabled = false;
            }
            else
            {
                buttonAdd1.Enabled = true;                
            }
            if (CountdownTimer.minutes < 5 && CountdownTimer.hours == 0 && CountdownTimer.minusMinutes)
            {
                buttonAdd5.Enabled = false;
            }
            else
            {
                buttonAdd5.Enabled = true;
            }
            if (CountdownTimer.minutes < 10 && CountdownTimer.hours == 0 && CountdownTimer.minusMinutes)
            {
                buttonAdd10.Enabled = false;
            }
            else
            {
                buttonAdd10.Enabled = true;
            }
            if (CountdownTimer.minutes < 30 && CountdownTimer.hours == 0 && CountdownTimer.minusMinutes)
            {
                buttonAdd30.Enabled = false;
            }
            else
            {
                buttonAdd30.Enabled = true;
            }
        }

        public void buttonChangeTime(sbyte i)
        {
            plusMinusBtn.Enabled = true;
            if (!CountdownTimer.minusMinutes)
            {
                if (CountdownTimer.CTstarted)
                {
                    addTime(i);
                }
                else
                {
                    if (i < 10)
                    {
                        CountdownTimer.timeArr[1, 0] += (byte)i;                        
                    }
                    else
                    {
                        CountdownTimer.timeArr[1, 1] += (byte)(i / 10);
                    }
                    if (CountdownTimer.timeArr[1, 0] > 9)
                    {
                        CountdownTimer.timeArr[1, 0] -= 10;
                        CountdownTimer.timeArr[1, 1]++;
                    }
                    if (CountdownTimer.timeArr[1, 1] > 5)
                    {
                        CountdownTimer.timeArr[1, 1] -= 6;
                        CountdownTimer.timeArr[2, 0]++;
                    }
                    ctSecondsLbl.Text = CountdownTimer.updateInput("seconds");
                    ctMinutesLbl.Text =  CountdownTimer.updateInput("minutes");
                    ctHoursLbl.Text = CountdownTimer.updateInput();
                    startBtn.Enabled = clearBtn.Enabled = btn0.Enabled = true;
                }
            }
            else
            {
                if (CountdownTimer.CTstarted)
                {
                    CountdownTimer.time -= (short)(i * 60);
                    CountdownTimer.minutes -= i;
                    progressBar1.Maximum = (int)CountdownTimer.time;
                    progressBar1.Value = 0;
                }
                else
                {
                    if (CountdownTimer.timeArr[2, 1] == 0 && CountdownTimer.timeArr[2, 0] == 0)
                    {
                        CountdownTimer.setTime(2);
                        if (CountdownTimer.time >= i)
                        {
                            CountdownTimer.time -= i;
                        }
                        if (CountdownTimer.time >= 10)
                        {
                            CountdownTimer.timeArr[1, 1] = (byte)(CountdownTimer.time / 10);
                            CountdownTimer.timeArr[1, 0] = (byte)(CountdownTimer.time % 10);
                        }
                        else
                        {
                            CountdownTimer.timeArr[1, 1] = 0;
                            CountdownTimer.timeArr[1, 0] = (byte)CountdownTimer.time;
                        }
                    }
                    if (CountdownTimer.timeArr[2, 1] == 0 && CountdownTimer.timeArr[2, 0] > 0)
                    {
                        CountdownTimer.setTime(3);
                        if (CountdownTimer.time >= i)
                        {
                            CountdownTimer.time -= i;
                        }
                        if (CountdownTimer.time >= 100)
                        {
                            CountdownTimer.timeArr[2, 0] = (byte)(CountdownTimer.time / 100);                            
                        }
                        if (CountdownTimer.time >= 10 && CountdownTimer.time < 100)
                        {
                            CountdownTimer.timeArr[2, 0]--;                            
                        }                        
                    }
                    if (CountdownTimer.timeArr[2, 1] > 0)
                    {
                        CountdownTimer.setTime(4);
                        if (CountdownTimer.time >= i)
                        {
                            CountdownTimer.time -= i;
                        }
                        if (CountdownTimer.time >= 1000)
                        {
                            CountdownTimer.timeArr[2, 1] = (byte)(CountdownTimer.time / 1000);
                            CountdownTimer.timeArr[2, 0] = (byte)((CountdownTimer.time - CountdownTimer.timeArr[2, 1] * 1000) / 100);
                            CountdownTimer.timeArr[1, 1] = (byte)((CountdownTimer.time - CountdownTimer.timeArr[2, 1] * 1000 - CountdownTimer.timeArr[2, 0] * 100) / 10);
                            CountdownTimer.timeArr[1, 0] = (byte)(CountdownTimer.time - CountdownTimer.timeArr[2, 1] * 1000 - CountdownTimer.timeArr[2, 0] * 100 - CountdownTimer.timeArr[1, 1] * 10);
                        }
                        if (CountdownTimer.time >= 100 && CountdownTimer.time < 1000)
                        {
                            CountdownTimer.timeArr[2, 1]--;
                            CountdownTimer.timeArr[2, 0] = 9;
                            CountdownTimer.timeArr[1, 1] = 5;                            
                        }
                    }
                    switch (((int)CountdownTimer.time / 10) % 10)
                    {
                        case 9: CountdownTimer.timeArr[1, 1] = 5;
                            break;
                        case 8: CountdownTimer.timeArr[1, 1] = 4;
                            break;
                        case 7: CountdownTimer.timeArr[1, 1] = 3;
                            break;
                        case 6: CountdownTimer.timeArr[1, 1] = 2;
                            break;
                        default: CountdownTimer.timeArr[1, 1] = (byte)((CountdownTimer.time / 10) % 10);
                            break;
                    }
                    CountdownTimer.timeArr[1, 0] = (byte)(CountdownTimer.time % 10);
                    ctSecondsLbl.Text = CountdownTimer.updateInput("seconds");
                    ctMinutesLbl.Text = CountdownTimer.updateInput("minutes");
                    ctHoursLbl.Text = CountdownTimer.updateInput();
                    updateMinusBtnStates();
                }
            }
        }

        public void clear()
        {
            CountdownTimer.timeArr[0, 0] = CountdownTimer.timeArr[0, 1];
            CountdownTimer.timeArr[0, 1] = CountdownTimer.timeArr[1, 0];
            CountdownTimer.timeArr[1, 0] = CountdownTimer.timeArr[1, 1];
            CountdownTimer.timeArr[1, 1] = CountdownTimer.timeArr[2, 0];
            CountdownTimer.timeArr[2, 0] = CountdownTimer.timeArr[2, 1];
            CountdownTimer.timeArr[2, 1] = 0;
            updateInput();
        }

        private void startBtn_Click_1(object sender, EventArgs e)
        {
            if (startBtn.Text == "Start")
            {
                startBtn.Text = "Stop";
                closeBtn.Text = "Exit";
                buttonAdd1.Text = "+1'";
                buttonAdd5.Text = "+5'";
                buttonAdd10.Text = "+10'";
                buttonAdd30.Text = "+30'";
                CountdownTimer.seconds = (sbyte)(System.Convert.ToInt32(ctSecondsLbl.Text));
                CountdownTimer.minutes = (sbyte)(System.Convert.ToInt32(ctMinutesLbl.Text));
                CountdownTimer.hours = (sbyte)(System.Convert.ToInt32(ctHoursLbl.Text));
                ctHoursLbl.Text = System.Convert.ToString(CountdownTimer.hours);
                if (CountdownTimer.seconds > 59)
                {
                    CountdownTimer.minutes++;
                    CountdownTimer.seconds -= 59;
                }
                if (CountdownTimer.minutes > 59)
                {
                    CountdownTimer.hours++;
                    CountdownTimer.minutes -= 59;
                }
                if (CountdownTimer.hours > 0 && CountdownTimer.minutes <= 0 && CountdownTimer.seconds <= 0)
                {
                    CountdownTimer.hours--;
                    CountdownTimer.minutes = 59;
                    CountdownTimer.seconds = 60;
                }
                if (CountdownTimer.minutes > 0 && CountdownTimer.seconds <= 0)
                {
                    CountdownTimer.minutes--;
                    CountdownTimer.seconds = 60;
                }
                buttonAdd1.Enabled = buttonAdd5.Enabled = buttonAdd10.Enabled = buttonAdd30.Enabled = pauseBtn1.Enabled = CountdownTimer.CTstarted = plusMinusBtn.Enabled = true;
                btn1.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = btn5.Enabled = btn6.Enabled = btn7.Enabled = btn8.Enabled = btn9.Enabled = btn0.Enabled = CountdownTimer.CTended = clearBtn.Enabled = false;
                CountdownTimer.time += (short)((CountdownTimer.hours * 3600) + (CountdownTimer.minutes * 60) + CountdownTimer.seconds);
                progressBar1.Value = progressBar1.Minimum = 0;
                progressBar1.Maximum = CountdownTimer.time;
                progressBar1.Step = 1;
                startCountdown();
                updateMinusBtnStates();
                if (CountdownTimer.hours == 0)
                {
                    ctHoursLbl.Visible = ctHLabel.Visible = false;                        
                }                                             
            }
            else
            {
                if (CountdownTimer.CTended)
                {
                    ctHLabel.ForeColor = ctMLabel.ForeColor = ctSLabel.ForeColor = ctHoursLbl.ForeColor = ctMinutesLbl.ForeColor = ctSecondsLbl.ForeColor = System.Drawing.Color.Black;
                    CountdownTimer.player.Stop();
                    buttonAdd1.Enabled = buttonAdd5.Enabled = buttonAdd10.Enabled = buttonAdd30.Enabled = true;
                }
                else
                {
                    CountdownTimer.CTstarted = false;
                    progressBar1.Value = 0;
                    CountdownTimer.time = 0;
                    Array.Clear(CountdownTimer.timeArr, 0, CountdownTimer.timeArr.Length);
                }
                startBtn.Text = "Start";
                ctHoursLbl.Text = ctSecondsLbl.Text = ctMinutesLbl.Text = "00";                
                btn1.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = btn5.Enabled = btn6.Enabled = btn7.Enabled = btn8.Enabled = btn9.Enabled = ctHLabel.Visible = ctHoursLbl.Visible = true;
                startBtn.Enabled = pauseBtn1.Enabled = plusMinusBtn.Enabled = btn0.Enabled = false;
            }
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

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }        

        private void buttonAdd1_Click(object sender, EventArgs e)
        {
            buttonChangeTime(1);
        }

        private void buttonAdd5_Click(object sender, EventArgs e)
        {
            buttonChangeTime(5);
        }

        private void buttonAdd10_Click(object sender, EventArgs e)
        {
            buttonChangeTime(10);
        }

        private void buttonAdd30_Click(object sender, EventArgs e)
        {
            buttonChangeTime(30);
        }

        private void plusMinusBtn_Click(object sender, EventArgs e)
        {
            if (!CountdownTimer.minusMinutes)
            {
                buttonAdd1.Text = "-1'";
                buttonAdd5.Text = "-5'";
                buttonAdd10.Text = "-10'";
                buttonAdd30.Text = "-30'";
                CountdownTimer.minusMinutes = true;
                updateMinusBtnStates();
            }
            else
            {
                buttonAdd1.Text = "+1'";
                buttonAdd5.Text = "+5'";
                buttonAdd10.Text = "+10'";
                buttonAdd30.Text = "+30'";
                buttonAdd1.Enabled = buttonAdd5.Enabled = buttonAdd10.Enabled = buttonAdd30.Enabled = true;
                CountdownTimer.minusMinutes = false;
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
                case Keys.Back:
                    clearBtn.PerformClick();
                    break;
            }
        }

        private void pauseBtn1_Click(object sender, EventArgs e)
        {
            if (CountdownTimer.CTstarted)
            {
                CountdownTimer.CTstarted = false;
                pauseBtn1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                CountdownTimer.CTstarted = true;
                pauseBtn1.ForeColor = System.Drawing.Color.Black;
                startCountdown();
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            clear();
        }

        public async void timeFromEnd()
        {
            do
            {
                CountdownTimer.timeFromEnd();
                if (CountdownTimer.seconds > 59 && beepBox.Checked)
                {
                    CountdownTimer.player.Play();
                }
                if (CountdownTimer.hours > 0)
                {
                    ctHoursLbl.Enabled = ctHLabel.Enabled = true;
                }
                updateTime();
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
                lapBtn.Enabled = stopwatchRunning = pauseBtn2.Enabled = false;
                hours2 = minutes2 = seconds2 = lapSeconds = lapMinutes = lapHours = 0;
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
                lapBtn.Enabled = pauseBtn2.Enabled = stopwatchRunning = true;
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