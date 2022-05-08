namespace Jasonphos.TwitterSampleFeedGUI {
    partial class Dashboard {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.txtStartTimestamp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalTweetsReceived = new System.Windows.Forms.TextBox();
            this.txtTweetsReceivedPerMin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLastReceivedTimestamp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCurrentDateTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEndTimestamp = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalTweetsProcessed = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start\r\nTimeStamp ";
            // 
            // txtStartTimestamp
            // 
            this.txtStartTimestamp.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtStartTimestamp.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtStartTimestamp.Location = new System.Drawing.Point(12, 64);
            this.txtStartTimestamp.Name = "txtStartTimestamp";
            this.txtStartTimestamp.Size = new System.Drawing.Size(216, 29);
            this.txtStartTimestamp.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(258, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tweets Received:";
            // 
            // txtTotalTweetsReceived
            // 
            this.txtTotalTweetsReceived.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtTotalTweetsReceived.Location = new System.Drawing.Point(431, 144);
            this.txtTotalTweetsReceived.Name = "txtTotalTweetsReceived";
            this.txtTotalTweetsReceived.Size = new System.Drawing.Size(109, 23);
            this.txtTotalTweetsReceived.TabIndex = 3;
            // 
            // txtTweetsReceivedPerMin
            // 
            this.txtTweetsReceivedPerMin.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtTweetsReceivedPerMin.Location = new System.Drawing.Point(749, 144);
            this.txtTweetsReceivedPerMin.Name = "txtTweetsReceivedPerMin";
            this.txtTweetsReceivedPerMin.Size = new System.Drawing.Size(109, 23);
            this.txtTweetsReceivedPerMin.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(576, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Avg Tweets/Minute:";
            // 
            // txtLastReceivedTimestamp
            // 
            this.txtLastReceivedTimestamp.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtLastReceivedTimestamp.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLastReceivedTimestamp.Location = new System.Drawing.Point(556, 64);
            this.txtLastReceivedTimestamp.Name = "txtLastReceivedTimestamp";
            this.txtLastReceivedTimestamp.Size = new System.Drawing.Size(148, 29);
            this.txtLastReceivedTimestamp.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(556, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 44);
            this.label4.TabIndex = 6;
            this.label4.Text = "Last Received \r\nTimeStamp";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(7, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "Log: ";
            // 
            // txtCurrentDateTime
            // 
            this.txtCurrentDateTime.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtCurrentDateTime.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCurrentDateTime.Location = new System.Drawing.Point(731, 64);
            this.txtCurrentDateTime.Name = "txtCurrentDateTime";
            this.txtCurrentDateTime.Size = new System.Drawing.Size(148, 29);
            this.txtCurrentDateTime.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(731, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 44);
            this.label6.TabIndex = 9;
            this.label6.Text = "Current\r\nDate/Time";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(7, 310);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(1104, 362);
            this.txtLog.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(12, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1115, 2);
            this.label7.TabIndex = 12;
            // 
            // txtEndTimestamp
            // 
            this.txtEndTimestamp.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtEndTimestamp.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEndTimestamp.Location = new System.Drawing.Point(266, 64);
            this.txtEndTimestamp.Name = "txtEndTimestamp";
            this.txtEndTimestamp.Size = new System.Drawing.Size(208, 29);
            this.txtEndTimestamp.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(266, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 44);
            this.label8.TabIndex = 13;
            this.label8.Text = "End\r\nTimeStamp";
            // 
            // txtTotalTweetsProcessed
            // 
            this.txtTotalTweetsProcessed.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtTotalTweetsProcessed.Location = new System.Drawing.Point(431, 183);
            this.txtTotalTweetsProcessed.Name = "txtTotalTweetsProcessed";
            this.txtTotalTweetsProcessed.Size = new System.Drawing.Size(109, 23);
            this.txtTotalTweetsProcessed.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(258, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(174, 22);
            this.label9.TabIndex = 15;
            this.label9.Text = "Tweets Processed:";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStop.Location = new System.Drawing.Point(349, 227);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(355, 77);
            this.btnStop.TabIndex = 26;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 684);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.txtTotalTweetsProcessed);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtEndTimestamp);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtCurrentDateTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLastReceivedTimestamp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTweetsReceivedPerMin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotalTweetsReceived);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStartTimestamp);
            this.Controls.Add(this.label1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtStartTimestamp;
        private Label label2;
        private TextBox txtTotalTweetsReceived;
        private TextBox txtTweetsReceivedPerMin;
        private Label label3;
        private TextBox txtLastReceivedTimestamp;
        private Label label4;
        private Label label5;
        private TextBox txtCurrentDateTime;
        private Label label6;
        private TextBox txtLog;
        private Label label7;
        private TextBox txtEndTimestamp;
        private Label label8;
        private TextBox txtTotalTweetsProcessed;
        private Label label9;
        private Button btnStop;
    }
}