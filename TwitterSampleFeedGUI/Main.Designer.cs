namespace Jasonphos.TwitterSampleFeedGUI {
    partial class Main {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cfg_ServiceEndpointBase = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cfg_MaxGUILogLengthChars = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cfg_ProcessorThreads = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cfg_FormRefreshPeriodInSeconds = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cfg_TwitterAPIBearerToken = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.cfg_ProcessorBatchSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cfg_ServiceEndpointBase
            // 
            this.cfg_ServiceEndpointBase.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cfg_ServiceEndpointBase.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cfg_ServiceEndpointBase.Location = new System.Drawing.Point(12, 143);
            this.cfg_ServiceEndpointBase.Name = "cfg_ServiceEndpointBase";
            this.cfg_ServiceEndpointBase.Size = new System.Drawing.Size(663, 29);
            this.cfg_ServiceEndpointBase.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(12, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 44);
            this.label8.TabIndex = 21;
            this.label8.Text = "Service\r\nEndpoint";
            // 
            // cfg_MaxGUILogLengthChars
            // 
            this.cfg_MaxGUILogLengthChars.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cfg_MaxGUILogLengthChars.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cfg_MaxGUILogLengthChars.Location = new System.Drawing.Point(459, 58);
            this.cfg_MaxGUILogLengthChars.Name = "cfg_MaxGUILogLengthChars";
            this.cfg_MaxGUILogLengthChars.Size = new System.Drawing.Size(124, 29);
            this.cfg_MaxGUILogLengthChars.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(459, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 44);
            this.label6.TabIndex = 19;
            this.label6.Text = "Max Displayed\r\nLog Length";
            // 
            // cfg_ProcessorThreads
            // 
            this.cfg_ProcessorThreads.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cfg_ProcessorThreads.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cfg_ProcessorThreads.Location = new System.Drawing.Point(175, 58);
            this.cfg_ProcessorThreads.Name = "cfg_ProcessorThreads";
            this.cfg_ProcessorThreads.Size = new System.Drawing.Size(84, 29);
            this.cfg_ProcessorThreads.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(175, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 44);
            this.label4.TabIndex = 17;
            this.label4.Text = "Processor\r\n# Threads";
            // 
            // cfg_FormRefreshPeriodInSeconds
            // 
            this.cfg_FormRefreshPeriodInSeconds.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cfg_FormRefreshPeriodInSeconds.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cfg_FormRefreshPeriodInSeconds.Location = new System.Drawing.Point(9, 58);
            this.cfg_FormRefreshPeriodInSeconds.Name = "cfg_FormRefreshPeriodInSeconds";
            this.cfg_FormRefreshPeriodInSeconds.Size = new System.Drawing.Size(109, 29);
            this.cfg_FormRefreshPeriodInSeconds.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 44);
            this.label1.TabIndex = 15;
            this.label1.Text = "Form Refresh \r\nin Seconds";
            // 
            // cfg_TwitterAPIBearerToken
            // 
            this.cfg_TwitterAPIBearerToken.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cfg_TwitterAPIBearerToken.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cfg_TwitterAPIBearerToken.Location = new System.Drawing.Point(12, 242);
            this.cfg_TwitterAPIBearerToken.Name = "cfg_TwitterAPIBearerToken";
            this.cfg_TwitterAPIBearerToken.PasswordChar = '*';
            this.cfg_TwitterAPIBearerToken.Size = new System.Drawing.Size(951, 29);
            this.cfg_TwitterAPIBearerToken.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 44);
            this.label2.TabIndex = 23;
            this.label2.Text = "Twitter API\r\nBearer Token";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStart.Location = new System.Drawing.Point(289, 349);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(445, 103);
            this.btnStart.TabIndex = 25;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            // 
            // cfg_ProcessorBatchSize
            // 
            this.cfg_ProcessorBatchSize.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cfg_ProcessorBatchSize.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cfg_ProcessorBatchSize.Location = new System.Drawing.Point(289, 59);
            this.cfg_ProcessorBatchSize.Name = "cfg_ProcessorBatchSize";
            this.cfg_ProcessorBatchSize.Size = new System.Drawing.Size(84, 29);
            this.cfg_ProcessorBatchSize.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(289, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 26;
            this.label3.Text = "Batch Size";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 497);
            this.Controls.Add(this.cfg_ProcessorBatchSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cfg_TwitterAPIBearerToken);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cfg_ServiceEndpointBase);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cfg_MaxGUILogLengthChars);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cfg_ProcessorThreads);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cfg_FormRefreshPeriodInSeconds);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox cfg_ServiceEndpointBase;
        private Label label8;
        private TextBox cfg_MaxGUILogLengthChars;
        private Label label6;
        private TextBox cfg_ProcessorThreads;
        private Label label4;
        private TextBox cfg_FormRefreshPeriodInSeconds;
        private Label label1;
        private TextBox cfg_TwitterAPIBearerToken;
        private Label label2;
        private Button btnStart;
        private TextBox cfg_ProcessorBatchSize;
        private Label label3;
    }
}