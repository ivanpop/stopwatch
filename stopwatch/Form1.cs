using System;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (!CountdownTimer.CTstarted)
            {
                CountdownTimer.setTime(6);
                buttonAdd5.Enabled = CountdownTimer.time >= 500 && CountdownTimer.minusMinutes ? true : false;
                buttonAdd10.Enabled = CountdownTimer.time >= 1000 && CountdownTimer.minusMinutes ? true : false;
                buttonAdd30.Enabled = CountdownTimer.time >= 3000 && CountdownTimer.minusMinutes ? true : false;
            }
            if (CountdownTimer.time < 60 && CountdownTimer.minusMinutes)
            {
                buttonAdd1.Enabled = clearBtn.Enabled = false;
                plusMinusBtn.PerformClick();
                plusMinusBtn.Enabled = false;
            }            
            if (CountdownTimer.time == 0)
                btn0.Enabled = startBtn.Enabled = false;
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
                startBtn.Enabled = btn0.Enabled = clearBtn.Enabled = false;
            else
                startBtn.Enabled = btn0.Enabled = clearBtn.Enabled = true;
            if (ctHoursLbl.Text == "00" && ctMinutesLbl.Text == "00" && plusMinusBtn.Enabled)
                plusMinusBtn.Enabled = false;            
            plusMinusBtn.Enabled = ctHoursLbl.Text != "00" || ctMinutesLbl.Text != "00" ? true : false;                          
        }

        public bool timeToSeconds()
        {
            CountdownTimer.timeToSeconds();
            if (CountdownTimer.hours < 0 && beepBox.Checked)
                CountdownTimer.player.Play();
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
            if (CountdownTimer.hours > 0)
                ctHoursLbl.Visible = ctHLabel.Visible = true;
        }

        public async void startCountdown()
        {
            doCountdownStep();
            do {
                updateTime(); 
                checkMinutes();                              
                await Task.Delay(100);                
            } while (CountdownTimer.CTstarted);
        }

        public async void doCountdownStep()
        {
            do {
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
                plusMinusBtn.Enabled = false;
            else
                buttonAdd1.Enabled = true;
            buttonAdd5.Enabled = CountdownTimer.minutes < 5 && CountdownTimer.hours == 0 && CountdownTimer.minusMinutes ? false : true;
            buttonAdd10.Enabled = CountdownTimer.minutes < 10 && CountdownTimer.hours == 0 && CountdownTimer.minusMinutes ? false : true;
            buttonAdd30.Enabled = CountdownTimer.minutes < 30 && CountdownTimer.hours == 0 && CountdownTimer.minusMinutes ? false : true;
        }

        public void buttonChangeTime(sbyte i)
        {
            plusMinusBtn.Enabled = true;
            if (!CountdownTimer.minusMinutes)
            {
                if (CountdownTimer.CTstarted)
                    addTime(i);
                else
                {
                    CountdownTimer.buttonChangeTime(i);
                    ctSecondsLbl.Text = CountdownTimer.updateInput("seconds");
                    ctMinutesLbl.Text =  CountdownTimer.updateInput("minutes");
                    ctHoursLbl.Text = CountdownTimer.updateInput();
                    startBtn.Enabled = clearBtn.Enabled = btn0.Enabled = true;
                }
            }
            else
            {
                CountdownTimer.buttonChangeTime(i);
                if (CountdownTimer.CTstarted)
                {                    
                    progressBar1.Maximum = CountdownTimer.time;
                    progressBar1.Value = 0;
                }
                else
                {                    
                    ctSecondsLbl.Text = CountdownTimer.updateInput("seconds");
                    ctMinutesLbl.Text = CountdownTimer.updateInput("minutes");
                    ctHoursLbl.Text = CountdownTimer.updateInput();
                    updateMinusBtnStates();
                }
            }
        }

        public void clear()
        {
            CountdownTimer.clear();
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
                CountdownTimer.startBtn();
                buttonAdd1.Enabled = buttonAdd5.Enabled = buttonAdd10.Enabled = buttonAdd30.Enabled = pauseBtn1.Enabled = CountdownTimer.CTstarted = plusMinusBtn.Enabled = true;
                btn1.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = btn5.Enabled = btn6.Enabled = btn7.Enabled = btn8.Enabled = btn9.Enabled = btn0.Enabled = CountdownTimer.CTended = clearBtn.Enabled = false;
                progressBar1.Value = progressBar1.Minimum = 0;
                progressBar1.Maximum = CountdownTimer.time;
                progressBar1.Step = 1;
                startCountdown();
                updateMinusBtnStates();
                if (CountdownTimer.hours == 0)
                    ctHoursLbl.Visible = ctHLabel.Visible = false;
            }
            else
            {
                if (CountdownTimer.CTended)
                {
                    ctHLabel.ForeColor = ctMLabel.ForeColor = ctSLabel.ForeColor = ctHoursLbl.ForeColor = ctMinutesLbl.ForeColor = ctSecondsLbl.ForeColor = beepBox.ForeColor = System.Drawing.Color.Black;
                    CountdownTimer.player.Stop();
                    buttonAdd1.Enabled = buttonAdd5.Enabled = buttonAdd10.Enabled = buttonAdd30.Enabled = true;                    
                }
                else
                {
                    CountdownTimer.CTstarted = false;                    
                    Array.Clear(CountdownTimer.timeArr, 0, CountdownTimer.timeArr.Length);
                }
                progressBar1.Value = CountdownTimer.time = 0;
                CountdownTimer.taskbar.SetProgressValue(progressBar1.Value, progressBar1.Maximum);                
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
                case Keys.Enter:
                    if (tabControl1.SelectedIndex == 0)
                        startBtn.PerformClick();
                    else start2Btn.PerformClick();                    
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
            do {
                CountdownTimer.timeFromEnd();
                if (CountdownTimer.seconds > 59 && beepBox.Checked)
                    CountdownTimer.player.Play();
                if (CountdownTimer.hours > 0)
                    ctHoursLbl.Enabled = ctHLabel.Enabled = true;
                updateTime();
                await Task.Delay(1000);
            } while (startBtn.Text == "Stop");
        }

        #endregion
        #region Stopwatch
        public async void startMs()
        {
            do {
                Stopwatch.startMs();
                msLbl.Text = Stopwatch.updateDisplay("ms");
                seconds2Lbl.Text = Stopwatch.updateDisplay("seconds");
                minutes2Lbl.Text = Stopwatch.updateDisplay("minutes");
                hours2Lbl.Text = Stopwatch.updateDisplay("hours");                
                await Task.Delay(33);
            } while (Stopwatch.stopwatchRunning);
        }

        private void start2Btn_Click(object sender, EventArgs e)
        {
            if (start2Btn.Text == "Stop")
            {
                start2Btn.Text = "Start";
                lapBtn.Enabled = Stopwatch.stopwatchRunning = pauseBtn2.Enabled = false;
                Stopwatch.hours = Stopwatch.minutes = Stopwatch.seconds = Stopwatch.lapSeconds = Stopwatch.lapMinutes = Stopwatch.lapHours = 0;
                seconds2Lbl.Text = minutes2Lbl.Text = hours2Lbl.Text = "00";
                msLbl.Text = "000";
                if (listBox1.Items.Count > 0)
                    saveBtn.Enabled = true;
            }
            else
            {
                start2Btn.Text = "Stop";
                lapBtn.Enabled = pauseBtn2.Enabled = Stopwatch.stopwatchRunning = true;
                saveBtn.Enabled = false;
                listBox1.Items.Clear();
                Stopwatch.tempSeconds1 = DateTime.Now.Second;
                Stopwatch.tempSeconds2 = Stopwatch.tempSeconds1 + 1;
                startMs();
            }
        }

        private void lapBtn_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            Stopwatch.lapCount++;
            if (Stopwatch.lapCount < 10)
                listBox1.Items.Add(Stopwatch.getLapText());
            else
                listBox1.Items.Add(Stopwatch.getLapText(1));
            Stopwatch.results += listBox1.GetItemText(listBox1.SelectedItem) + System.Environment.NewLine;
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            Stopwatch.lapSeconds = Stopwatch.lapMinutes = Stopwatch.lapHours = 0;
        }

        private void close2Btn_Click(object sender, EventArgs e)
        {            
            Application.Exit();
        }

        private void pauseBtn2_Click(object sender, EventArgs e)
        {
            if (Stopwatch.stopwatchRunning)
                Stopwatch.stopwatchRunning = false;
            else
            {
                Stopwatch.stopwatchRunning = true;
                startMs();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Stopwatch.saveResults();
        }

        #endregion 
        }
}