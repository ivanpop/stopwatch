using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
                
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(stopwatch.Resource1.beep);
        int hours = 0, minutes = 0, seconds = 0, time = 0;       
        int[,] timeArr = { { 0,0 }, { 0,0 }, { 0,0 } };

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
                minutes--;
                seconds = 60;

                if (minutes <= 0)
                {
                    hours--;
                    minutes = 59;                   
                }
            }


            if (seconds < 0 || hours < 0)
            {
                player.Play();                
                return false;                
            }            

            return true;
        }

        public async void startTimer()
        {
            do
            {
                seconds--;
                progressBar1.PerformStep();
                updateTime();
                addZero();
                timeToSeconds();
                await Task.Delay(1000);
                
            } while (timeToSeconds());
        }

        private void startBtn_Click(object sender, EventArgs e)
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
                startTimer();
            }

            else
            {
                hoursLbl.Text = "00";
            }
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            shift(1);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            shift(0);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            shift(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            shift(3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            shift(4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            shift(5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            shift(6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            shift(7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            shift(8);
        }

        private void btn9_Click(object sender, EventArgs e)
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
    }
}
