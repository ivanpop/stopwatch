namespace stopwatch
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.clearBtn = new System.Windows.Forms.Button();
            this.pauseBtn1 = new System.Windows.Forms.Button();
            this.plusMinusBtn = new System.Windows.Forms.Button();
            this.buttonAdd30 = new System.Windows.Forms.Button();
            this.buttonAdd10 = new System.Windows.Forms.Button();
            this.buttonAdd5 = new System.Windows.Forms.Button();
            this.beepBox = new System.Windows.Forms.CheckBox();
            this.buttonAdd1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.closeBtn = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.ctSLabel = new System.Windows.Forms.Label();
            this.ctMLabel = new System.Windows.Forms.Label();
            this.ctHLabel = new System.Windows.Forms.Label();
            this.ctSecondsLbl = new System.Windows.Forms.Label();
            this.ctMinutesLbl = new System.Windows.Forms.Label();
            this.ctHoursLbl = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.saveBtn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.swMSLabel = new System.Windows.Forms.Label();
            this.msLbl = new System.Windows.Forms.Label();
            this.lapBtn = new System.Windows.Forms.Button();
            this.start2Btn = new System.Windows.Forms.Button();
            this.close2Btn = new System.Windows.Forms.Button();
            this.pauseBtn2 = new System.Windows.Forms.Button();
            this.swSLabel = new System.Windows.Forms.Label();
            this.swMLabel = new System.Windows.Forms.Label();
            this.stHLabel = new System.Windows.Forms.Label();
            this.seconds2Lbl = new System.Windows.Forms.Label();
            this.minutes2Lbl = new System.Windows.Forms.Label();
            this.hours2Lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-4, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(308, 367);
            this.tabControl1.TabIndex = 20;
            this.tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabControl1_KeyDown);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.clearBtn);
            this.tabPage1.Controls.Add(this.pauseBtn1);
            this.tabPage1.Controls.Add(this.plusMinusBtn);
            this.tabPage1.Controls.Add(this.buttonAdd30);
            this.tabPage1.Controls.Add(this.buttonAdd10);
            this.tabPage1.Controls.Add(this.buttonAdd5);
            this.tabPage1.Controls.Add(this.beepBox);
            this.tabPage1.Controls.Add(this.buttonAdd1);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.closeBtn);
            this.tabPage1.Controls.Add(this.btn2);
            this.tabPage1.Controls.Add(this.btn3);
            this.tabPage1.Controls.Add(this.btn8);
            this.tabPage1.Controls.Add(this.btn9);
            this.tabPage1.Controls.Add(this.btn0);
            this.tabPage1.Controls.Add(this.btn7);
            this.tabPage1.Controls.Add(this.btn6);
            this.tabPage1.Controls.Add(this.btn4);
            this.tabPage1.Controls.Add(this.btn5);
            this.tabPage1.Controls.Add(this.btn1);
            this.tabPage1.Controls.Add(this.ctSLabel);
            this.tabPage1.Controls.Add(this.ctMLabel);
            this.tabPage1.Controls.Add(this.ctHLabel);
            this.tabPage1.Controls.Add(this.ctSecondsLbl);
            this.tabPage1.Controls.Add(this.ctMinutesLbl);
            this.tabPage1.Controls.Add(this.ctHoursLbl);
            this.tabPage1.Controls.Add(this.startBtn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(300, 341);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Countdown timer";
            // 
            // clearBtn
            // 
            this.clearBtn.Enabled = false;
            this.clearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.Location = new System.Drawing.Point(61, 259);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(86, 40);
            this.clearBtn.TabIndex = 47;
            this.clearBtn.Text = "C";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // pauseBtn1
            // 
            this.pauseBtn1.Enabled = false;
            this.pauseBtn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseBtn1.Location = new System.Drawing.Point(107, 59);
            this.pauseBtn1.Name = "pauseBtn1";
            this.pauseBtn1.Size = new System.Drawing.Size(86, 40);
            this.pauseBtn1.TabIndex = 46;
            this.pauseBtn1.Text = "Pause";
            this.pauseBtn1.UseVisualStyleBackColor = true;
            this.pauseBtn1.Click += new System.EventHandler(this.pauseBtn1_Click);
            // 
            // plusMinusBtn
            // 
            this.plusMinusBtn.Enabled = false;
            this.plusMinusBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plusMinusBtn.Location = new System.Drawing.Point(176, 213);
            this.plusMinusBtn.Name = "plusMinusBtn";
            this.plusMinusBtn.Size = new System.Drawing.Size(109, 40);
            this.plusMinusBtn.TabIndex = 45;
            this.plusMinusBtn.Text = "+/-";
            this.plusMinusBtn.UseVisualStyleBackColor = true;
            this.plusMinusBtn.Click += new System.EventHandler(this.plusMinusBtn_Click);
            // 
            // buttonAdd30
            // 
            this.buttonAdd30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd30.Location = new System.Drawing.Point(236, 167);
            this.buttonAdd30.Name = "buttonAdd30";
            this.buttonAdd30.Size = new System.Drawing.Size(49, 40);
            this.buttonAdd30.TabIndex = 44;
            this.buttonAdd30.Text = "+30\'";
            this.buttonAdd30.UseVisualStyleBackColor = true;
            this.buttonAdd30.Click += new System.EventHandler(this.buttonAdd30_Click);
            // 
            // buttonAdd10
            // 
            this.buttonAdd10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd10.Location = new System.Drawing.Point(176, 167);
            this.buttonAdd10.Name = "buttonAdd10";
            this.buttonAdd10.Size = new System.Drawing.Size(49, 40);
            this.buttonAdd10.TabIndex = 43;
            this.buttonAdd10.Text = "+10\'";
            this.buttonAdd10.UseVisualStyleBackColor = true;
            this.buttonAdd10.Click += new System.EventHandler(this.buttonAdd10_Click);
            // 
            // buttonAdd5
            // 
            this.buttonAdd5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd5.Location = new System.Drawing.Point(236, 122);
            this.buttonAdd5.Name = "buttonAdd5";
            this.buttonAdd5.Size = new System.Drawing.Size(49, 40);
            this.buttonAdd5.TabIndex = 42;
            this.buttonAdd5.Text = "+5\'";
            this.buttonAdd5.UseVisualStyleBackColor = true;
            this.buttonAdd5.Click += new System.EventHandler(this.buttonAdd5_Click);
            // 
            // beepBox
            // 
            this.beepBox.AutoSize = true;
            this.beepBox.Checked = true;
            this.beepBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.beepBox.Location = new System.Drawing.Point(203, 273);
            this.beepBox.Name = "beepBox";
            this.beepBox.Size = new System.Drawing.Size(51, 17);
            this.beepBox.TabIndex = 41;
            this.beepBox.Text = "Beep";
            this.beepBox.UseVisualStyleBackColor = true;
            // 
            // buttonAdd1
            // 
            this.buttonAdd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd1.Location = new System.Drawing.Point(176, 122);
            this.buttonAdd1.Name = "buttonAdd1";
            this.buttonAdd1.Size = new System.Drawing.Size(49, 40);
            this.buttonAdd1.TabIndex = 40;
            this.buttonAdd1.Text = "+1\'";
            this.buttonAdd1.UseVisualStyleBackColor = true;
            this.buttonAdd1.Click += new System.EventHandler(this.buttonAdd1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 305);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(270, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 39;
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Location = new System.Drawing.Point(199, 59);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(86, 40);
            this.closeBtn.TabIndex = 37;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // btn2
            // 
            this.btn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.Location = new System.Drawing.Point(61, 121);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(40, 40);
            this.btn2.TabIndex = 36;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click_1);
            // 
            // btn3
            // 
            this.btn3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.Location = new System.Drawing.Point(107, 121);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(40, 40);
            this.btn3.TabIndex = 35;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click_1);
            // 
            // btn8
            // 
            this.btn8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn8.Location = new System.Drawing.Point(61, 213);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(40, 40);
            this.btn8.TabIndex = 34;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.btn8_Click_1);
            // 
            // btn9
            // 
            this.btn9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn9.Location = new System.Drawing.Point(107, 213);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(40, 40);
            this.btn9.TabIndex = 33;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.btn9_Click_1);
            // 
            // btn0
            // 
            this.btn0.Enabled = false;
            this.btn0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn0.Location = new System.Drawing.Point(15, 259);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(40, 40);
            this.btn0.TabIndex = 32;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.btn0_Click);
            // 
            // btn7
            // 
            this.btn7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7.Location = new System.Drawing.Point(15, 213);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(40, 40);
            this.btn7.TabIndex = 31;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.btn7_Click_1);
            // 
            // btn6
            // 
            this.btn6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn6.Location = new System.Drawing.Point(107, 168);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(40, 40);
            this.btn6.TabIndex = 30;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btn6_Click_1);
            // 
            // btn4
            // 
            this.btn4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.Location = new System.Drawing.Point(15, 168);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(40, 40);
            this.btn4.TabIndex = 29;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn4_Click_1);
            // 
            // btn5
            // 
            this.btn5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.Location = new System.Drawing.Point(61, 168);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(40, 40);
            this.btn5.TabIndex = 28;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btn5_Click_1);
            // 
            // btn1
            // 
            this.btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Location = new System.Drawing.Point(15, 121);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(40, 40);
            this.btn1.TabIndex = 27;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click_1);
            // 
            // ctSLabel
            // 
            this.ctSLabel.AutoSize = true;
            this.ctSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctSLabel.Location = new System.Drawing.Point(257, 34);
            this.ctSLabel.Name = "ctSLabel";
            this.ctSLabel.Size = new System.Drawing.Size(15, 13);
            this.ctSLabel.TabIndex = 26;
            this.ctSLabel.Text = "S";
            // 
            // ctMLabel
            // 
            this.ctMLabel.AutoSize = true;
            this.ctMLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctMLabel.Location = new System.Drawing.Point(171, 34);
            this.ctMLabel.Name = "ctMLabel";
            this.ctMLabel.Size = new System.Drawing.Size(17, 13);
            this.ctMLabel.TabIndex = 25;
            this.ctMLabel.Text = "M";
            // 
            // ctHLabel
            // 
            this.ctHLabel.AutoSize = true;
            this.ctHLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctHLabel.Location = new System.Drawing.Point(85, 34);
            this.ctHLabel.Name = "ctHLabel";
            this.ctHLabel.Size = new System.Drawing.Size(16, 13);
            this.ctHLabel.TabIndex = 24;
            this.ctHLabel.Text = "H";
            // 
            // ctSecondsLbl
            // 
            this.ctSecondsLbl.AutoSize = true;
            this.ctSecondsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctSecondsLbl.Location = new System.Drawing.Point(193, 1);
            this.ctSecondsLbl.Name = "ctSecondsLbl";
            this.ctSecondsLbl.Size = new System.Drawing.Size(80, 55);
            this.ctSecondsLbl.TabIndex = 23;
            this.ctSecondsLbl.Text = "00";
            // 
            // ctMinutesLbl
            // 
            this.ctMinutesLbl.AutoSize = true;
            this.ctMinutesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctMinutesLbl.Location = new System.Drawing.Point(107, 1);
            this.ctMinutesLbl.Name = "ctMinutesLbl";
            this.ctMinutesLbl.Size = new System.Drawing.Size(80, 55);
            this.ctMinutesLbl.TabIndex = 22;
            this.ctMinutesLbl.Text = "00";
            // 
            // ctHoursLbl
            // 
            this.ctHoursLbl.AutoSize = true;
            this.ctHoursLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctHoursLbl.Location = new System.Drawing.Point(21, 1);
            this.ctHoursLbl.Name = "ctHoursLbl";
            this.ctHoursLbl.Size = new System.Drawing.Size(80, 55);
            this.ctHoursLbl.TabIndex = 21;
            this.ctHoursLbl.Text = "00";
            // 
            // startBtn
            // 
            this.startBtn.Enabled = false;
            this.startBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.Location = new System.Drawing.Point(15, 59);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(86, 40);
            this.startBtn.TabIndex = 20;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click_1);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.saveBtn);
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Controls.Add(this.swMSLabel);
            this.tabPage2.Controls.Add(this.msLbl);
            this.tabPage2.Controls.Add(this.lapBtn);
            this.tabPage2.Controls.Add(this.start2Btn);
            this.tabPage2.Controls.Add(this.close2Btn);
            this.tabPage2.Controls.Add(this.pauseBtn2);
            this.tabPage2.Controls.Add(this.swSLabel);
            this.tabPage2.Controls.Add(this.swMLabel);
            this.tabPage2.Controls.Add(this.stHLabel);
            this.tabPage2.Controls.Add(this.seconds2Lbl);
            this.tabPage2.Controls.Add(this.minutes2Lbl);
            this.tabPage2.Controls.Add(this.hours2Lbl);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(300, 341);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Stopwatch";
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(13, 95);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(88, 40);
            this.saveBtn.TabIndex = 45;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 144);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(273, 186);
            this.listBox1.TabIndex = 44;
            // 
            // swMSLabel
            // 
            this.swMSLabel.AutoSize = true;
            this.swMSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swMSLabel.Location = new System.Drawing.Point(257, 20);
            this.swMSLabel.Name = "swMSLabel";
            this.swMSLabel.Size = new System.Drawing.Size(25, 13);
            this.swMSLabel.TabIndex = 43;
            this.swMSLabel.Text = "MS";
            // 
            // msLbl
            // 
            this.msLbl.AutoSize = true;
            this.msLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.msLbl.Location = new System.Drawing.Point(198, 3);
            this.msLbl.Name = "msLbl";
            this.msLbl.Size = new System.Drawing.Size(69, 36);
            this.msLbl.TabIndex = 42;
            this.msLbl.Text = "000";
            // 
            // lapBtn
            // 
            this.lapBtn.Enabled = false;
            this.lapBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lapBtn.Location = new System.Drawing.Point(107, 49);
            this.lapBtn.Name = "lapBtn";
            this.lapBtn.Size = new System.Drawing.Size(85, 40);
            this.lapBtn.TabIndex = 41;
            this.lapBtn.Text = "Lap";
            this.lapBtn.UseVisualStyleBackColor = true;
            this.lapBtn.Click += new System.EventHandler(this.lapBtn_Click);
            // 
            // start2Btn
            // 
            this.start2Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start2Btn.Location = new System.Drawing.Point(13, 49);
            this.start2Btn.Name = "start2Btn";
            this.start2Btn.Size = new System.Drawing.Size(88, 40);
            this.start2Btn.TabIndex = 40;
            this.start2Btn.Text = "Start";
            this.start2Btn.UseVisualStyleBackColor = true;
            this.start2Btn.Click += new System.EventHandler(this.start2Btn_Click);
            // 
            // close2Btn
            // 
            this.close2Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close2Btn.Location = new System.Drawing.Point(107, 95);
            this.close2Btn.Name = "close2Btn";
            this.close2Btn.Size = new System.Drawing.Size(179, 40);
            this.close2Btn.TabIndex = 39;
            this.close2Btn.Text = "Close";
            this.close2Btn.UseVisualStyleBackColor = true;
            this.close2Btn.Click += new System.EventHandler(this.close2Btn_Click);
            // 
            // pauseBtn2
            // 
            this.pauseBtn2.Enabled = false;
            this.pauseBtn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseBtn2.Location = new System.Drawing.Point(198, 49);
            this.pauseBtn2.Name = "pauseBtn2";
            this.pauseBtn2.Size = new System.Drawing.Size(88, 40);
            this.pauseBtn2.TabIndex = 38;
            this.pauseBtn2.Text = "Pause";
            this.pauseBtn2.UseVisualStyleBackColor = true;
            this.pauseBtn2.Click += new System.EventHandler(this.pauseBtn2_Click);
            // 
            // swSLabel
            // 
            this.swSLabel.AutoSize = true;
            this.swSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swSLabel.Location = new System.Drawing.Point(182, 20);
            this.swSLabel.Name = "swSLabel";
            this.swSLabel.Size = new System.Drawing.Size(15, 13);
            this.swSLabel.TabIndex = 32;
            this.swSLabel.Text = "S";
            // 
            // swMLabel
            // 
            this.swMLabel.AutoSize = true;
            this.swMLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swMLabel.Location = new System.Drawing.Point(118, 20);
            this.swMLabel.Name = "swMLabel";
            this.swMLabel.Size = new System.Drawing.Size(17, 13);
            this.swMLabel.TabIndex = 31;
            this.swMLabel.Text = "M";
            // 
            // stHLabel
            // 
            this.stHLabel.AutoSize = true;
            this.stHLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stHLabel.Location = new System.Drawing.Point(55, 20);
            this.stHLabel.Name = "stHLabel";
            this.stHLabel.Size = new System.Drawing.Size(16, 13);
            this.stHLabel.TabIndex = 30;
            this.stHLabel.Text = "H";
            // 
            // seconds2Lbl
            // 
            this.seconds2Lbl.AutoSize = true;
            this.seconds2Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.seconds2Lbl.Location = new System.Drawing.Point(141, 3);
            this.seconds2Lbl.Name = "seconds2Lbl";
            this.seconds2Lbl.Size = new System.Drawing.Size(51, 36);
            this.seconds2Lbl.TabIndex = 29;
            this.seconds2Lbl.Text = "00";
            // 
            // minutes2Lbl
            // 
            this.minutes2Lbl.AutoSize = true;
            this.minutes2Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.minutes2Lbl.Location = new System.Drawing.Point(77, 3);
            this.minutes2Lbl.Name = "minutes2Lbl";
            this.minutes2Lbl.Size = new System.Drawing.Size(51, 36);
            this.minutes2Lbl.TabIndex = 28;
            this.minutes2Lbl.Text = "00";
            // 
            // hours2Lbl
            // 
            this.hours2Lbl.AutoSize = true;
            this.hours2Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.hours2Lbl.Location = new System.Drawing.Point(14, 3);
            this.hours2Lbl.Name = "hours2Lbl";
            this.hours2Lbl.Size = new System.Drawing.Size(51, 36);
            this.hours2Lbl.TabIndex = 27;
            this.hours2Lbl.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 363);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Countdown Timer";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Label ctSLabel;
        private System.Windows.Forms.Label ctMLabel;
        private System.Windows.Forms.Label ctHLabel;
        private System.Windows.Forms.Label ctSecondsLbl;
        private System.Windows.Forms.Label ctMinutesLbl;
        private System.Windows.Forms.Label ctHoursLbl;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button buttonAdd1;
        private System.Windows.Forms.Label swSLabel;
        private System.Windows.Forms.Label swMLabel;
        private System.Windows.Forms.Label stHLabel;
        private System.Windows.Forms.Label seconds2Lbl;
        private System.Windows.Forms.Label minutes2Lbl;
        private System.Windows.Forms.Label hours2Lbl;
        private System.Windows.Forms.Button lapBtn;
        private System.Windows.Forms.Button start2Btn;
        private System.Windows.Forms.Button close2Btn;
        private System.Windows.Forms.Button pauseBtn2;
        private System.Windows.Forms.Label swMSLabel;
        private System.Windows.Forms.Label msLbl;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox beepBox;
        private System.Windows.Forms.Button buttonAdd30;
        private System.Windows.Forms.Button buttonAdd10;
        private System.Windows.Forms.Button buttonAdd5;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button plusMinusBtn;
        private System.Windows.Forms.Button pauseBtn1;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Label label1;

    }
}
