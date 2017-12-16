namespace ModbusEmulator
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
            this.pulsarTB = new System.Windows.Forms.RichTextBox();
            this.tracemodeTB = new System.Windows.Forms.RichTextBox();
            this.toPulsarLB = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.timeout = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.lblStopBits = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.lblDataBits = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkRTS = new System.Windows.Forms.CheckBox();
            this.traceModeComOpen = new System.Windows.Forms.Button();
            this.pulsarComOpen = new System.Windows.Forms.Button();
            this.tracemodeComCB = new System.Windows.Forms.ComboBox();
            this.pulsarComCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pulsarComLB = new System.Windows.Forms.Label();
            this.pulsarTextClear = new System.Windows.Forms.Button();
            this.traceModeTextClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pulsarTB
            // 
            this.pulsarTB.Location = new System.Drawing.Point(19, 341);
            this.pulsarTB.Name = "pulsarTB";
            this.pulsarTB.Size = new System.Drawing.Size(483, 103);
            this.pulsarTB.TabIndex = 0;
            this.pulsarTB.Text = "";
            // 
            // tracemodeTB
            // 
            this.tracemodeTB.Location = new System.Drawing.Point(19, 212);
            this.tracemodeTB.Name = "tracemodeTB";
            this.tracemodeTB.Size = new System.Drawing.Size(483, 103);
            this.tracemodeTB.TabIndex = 1;
            this.tracemodeTB.Text = "";
            // 
            // toPulsarLB
            // 
            this.toPulsarLB.AutoSize = true;
            this.toPulsarLB.Location = new System.Drawing.Point(16, 325);
            this.toPulsarLB.Name = "toPulsarLB";
            this.toPulsarLB.Size = new System.Drawing.Size(96, 13);
            this.toPulsarLB.TabIndex = 2;
            this.toPulsarLB.Text = "Обмен с Пульсар";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Обмен с TraceMode";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.timeout);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.cmbBaudRate);
            this.groupBox1.Controls.Add(this.cmbStopBits);
            this.groupBox1.Controls.Add(this.cmbParity);
            this.groupBox1.Controls.Add(this.cmbDataBits);
            this.groupBox1.Controls.Add(this.lblStopBits);
            this.groupBox1.Controls.Add(this.lblBaudRate);
            this.groupBox1.Controls.Add(this.lblDataBits);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkRTS);
            this.groupBox1.Controls.Add(this.traceModeComOpen);
            this.groupBox1.Controls.Add(this.pulsarComOpen);
            this.groupBox1.Controls.Add(this.tracemodeComCB);
            this.groupBox1.Controls.Add(this.pulsarComCB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pulsarComLB);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 178);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(165, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "мс";
            // 
            // timeout
            // 
            this.timeout.Location = new System.Drawing.Point(63, 141);
            this.timeout.Name = "timeout";
            this.timeout.Size = new System.Drawing.Size(100, 20);
            this.timeout.TabIndex = 23;
            this.timeout.Text = "1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "COM-порт";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "COM-порт";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(202, 144);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(179, 17);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "Четный паритет при отправке";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbBaudRate.Location = new System.Drawing.Point(104, 114);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(69, 21);
            this.cmbBaudRate.TabIndex = 13;
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBits.FormattingEnabled = true;
            this.cmbStopBits.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbStopBits.Location = new System.Drawing.Point(310, 114);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(54, 21);
            this.cmbStopBits.TabIndex = 19;
            // 
            // cmbParity
            // 
            this.cmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.cmbParity.Location = new System.Drawing.Point(178, 114);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(60, 21);
            this.cmbParity.TabIndex = 15;
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cmbDataBits.Location = new System.Drawing.Point(244, 114);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(60, 21);
            this.cmbDataBits.TabIndex = 17;
            // 
            // lblStopBits
            // 
            this.lblStopBits.AutoSize = true;
            this.lblStopBits.Location = new System.Drawing.Point(314, 97);
            this.lblStopBits.Name = "lblStopBits";
            this.lblStopBits.Size = new System.Drawing.Size(54, 13);
            this.lblStopBits.TabIndex = 18;
            this.lblStopBits.Text = "Стоп-бит:";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(111, 96);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(58, 13);
            this.lblBaudRate.TabIndex = 12;
            this.lblBaudRate.Text = "Скорость:";
            // 
            // lblDataBits
            // 
            this.lblDataBits.AutoSize = true;
            this.lblDataBits.Location = new System.Drawing.Point(237, 96);
            this.lblDataBits.Name = "lblDataBits";
            this.lblDataBits.Size = new System.Drawing.Size(76, 13);
            this.lblDataBits.TabIndex = 16;
            this.lblDataBits.Text = "Биты данных:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Четность:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // chkRTS
            // 
            this.chkRTS.AutoSize = true;
            this.chkRTS.Location = new System.Drawing.Point(9, 144);
            this.chkRTS.Name = "chkRTS";
            this.chkRTS.Size = new System.Drawing.Size(48, 17);
            this.chkRTS.TabIndex = 11;
            this.chkRTS.Text = "RTS";
            this.chkRTS.UseVisualStyleBackColor = true;
            // 
            // traceModeComOpen
            // 
            this.traceModeComOpen.Location = new System.Drawing.Point(372, 19);
            this.traceModeComOpen.Name = "traceModeComOpen";
            this.traceModeComOpen.Size = new System.Drawing.Size(118, 47);
            this.traceModeComOpen.TabIndex = 10;
            this.traceModeComOpen.Text = "Открыть";
            this.traceModeComOpen.UseVisualStyleBackColor = true;
            this.traceModeComOpen.Click += new System.EventHandler(this.traceModeComOpen_Click);
            // 
            // pulsarComOpen
            // 
            this.pulsarComOpen.Location = new System.Drawing.Point(374, 93);
            this.pulsarComOpen.Name = "pulsarComOpen";
            this.pulsarComOpen.Size = new System.Drawing.Size(116, 42);
            this.pulsarComOpen.TabIndex = 9;
            this.pulsarComOpen.Text = "Открыть";
            this.pulsarComOpen.UseVisualStyleBackColor = true;
            this.pulsarComOpen.Click += new System.EventHandler(this.pulsarComOpen_Click);
            // 
            // tracemodeComCB
            // 
            this.tracemodeComCB.FormattingEnabled = true;
            this.tracemodeComCB.Location = new System.Drawing.Point(220, 45);
            this.tracemodeComCB.Name = "tracemodeComCB";
            this.tracemodeComCB.Size = new System.Drawing.Size(121, 21);
            this.tracemodeComCB.TabIndex = 8;
            // 
            // pulsarComCB
            // 
            this.pulsarComCB.FormattingEnabled = true;
            this.pulsarComCB.Location = new System.Drawing.Point(7, 114);
            this.pulsarComCB.Name = "pulsarComCB";
            this.pulsarComCB.Size = new System.Drawing.Size(93, 21);
            this.pulsarComCB.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Обмен с TraceMode (9600-N-8-1):";
            // 
            // pulsarComLB
            // 
            this.pulsarComLB.AutoSize = true;
            this.pulsarComLB.Location = new System.Drawing.Point(6, 74);
            this.pulsarComLB.Name = "pulsarComLB";
            this.pulsarComLB.Size = new System.Drawing.Size(168, 13);
            this.pulsarComLB.TabIndex = 5;
            this.pulsarComLB.Text = "Com порт Пульсар  (1200-N-8-1):";
            // 
            // pulsarTextClear
            // 
            this.pulsarTextClear.Location = new System.Drawing.Point(381, 320);
            this.pulsarTextClear.Name = "pulsarTextClear";
            this.pulsarTextClear.Size = new System.Drawing.Size(121, 22);
            this.pulsarTextClear.TabIndex = 11;
            this.pulsarTextClear.Text = "Очистить";
            this.pulsarTextClear.UseVisualStyleBackColor = true;
            this.pulsarTextClear.Click += new System.EventHandler(this.pulsarTextClear_Click);
            // 
            // traceModeTextClear
            // 
            this.traceModeTextClear.Location = new System.Drawing.Point(381, 191);
            this.traceModeTextClear.Name = "traceModeTextClear";
            this.traceModeTextClear.Size = new System.Drawing.Size(121, 22);
            this.traceModeTextClear.TabIndex = 12;
            this.traceModeTextClear.Text = "Очистить";
            this.traceModeTextClear.UseVisualStyleBackColor = true;
            this.traceModeTextClear.Click += new System.EventHandler(this.traceModeTextClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 461);
            this.Controls.Add(this.traceModeTextClear);
            this.Controls.Add(this.pulsarTextClear);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toPulsarLB);
            this.Controls.Add(this.tracemodeTB);
            this.Controls.Add(this.pulsarTB);
            this.Name = "Form1";
            this.Text = "Эмулятор Modbus";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox pulsarTB;
        private System.Windows.Forms.RichTextBox tracemodeTB;
        private System.Windows.Forms.Label toPulsarLB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button traceModeComOpen;
        private System.Windows.Forms.Button pulsarComOpen;
        private System.Windows.Forms.ComboBox tracemodeComCB;
        private System.Windows.Forms.ComboBox pulsarComCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label pulsarComLB;
        private System.Windows.Forms.Button pulsarTextClear;
        private System.Windows.Forms.Button traceModeTextClear;
        private System.Windows.Forms.CheckBox chkRTS;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.ComboBox cmbDataBits;
        private System.Windows.Forms.Label lblStopBits;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.Label lblDataBits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox timeout;
        private System.Windows.Forms.Label label6;
    }
}

