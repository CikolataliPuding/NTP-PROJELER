namespace SpeechToTextApp
{
    partial class AzureSpeechForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnTestMic = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblAudioLevel = new System.Windows.Forms.Label();
            this.pnlAudioLevel = new System.Windows.Forms.Panel();
            this.pnlAudioContainer = new System.Windows.Forms.Panel();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lblAzureInfo = new System.Windows.Forms.Label();
            this.btnSetupAzure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "☁️ Azure Speech to Text Pro";
            // 
            // btnStartStop
            // 
            this.btnStartStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnStartStop.FlatAppearance.BorderSize = 0;
            this.btnStartStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartStop.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStartStop.ForeColor = System.Drawing.Color.White;
            this.btnStartStop.Location = new System.Drawing.Point(20, 80);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(150, 60);
            this.btnStartStop.TabIndex = 1;
            this.btnStartStop.Text = "START";
            this.btnStartStop.UseVisualStyleBackColor = false;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(190, 80);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 60);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnTestMic
            // 
            this.btnTestMic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnTestMic.FlatAppearance.BorderSize = 0;
            this.btnTestMic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestMic.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTestMic.ForeColor = System.Drawing.Color.White;
            this.btnTestMic.Location = new System.Drawing.Point(330, 80);
            this.btnTestMic.Name = "btnTestMic";
            this.btnTestMic.Size = new System.Drawing.Size(140, 60);
            this.btnTestMic.TabIndex = 3;
            this.btnTestMic.Text = "TEST AZURE";
            this.btnTestMic.UseVisualStyleBackColor = false;
            this.btnTestMic.Click += new System.EventHandler(this.btnTestMic_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOutput.Location = new System.Drawing.Point(20, 200);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(750, 300);
            this.txtOutput.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.lblStatus.Location = new System.Drawing.Point(20, 170);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(200, 21);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Azure Speech Service Ready";
            // 
            // lblAudioLevel
            // 
            this.lblAudioLevel.AutoSize = true;
            this.lblAudioLevel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAudioLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblAudioLevel.Location = new System.Drawing.Point(500, 100);
            this.lblAudioLevel.Name = "lblAudioLevel";
            this.lblAudioLevel.Size = new System.Drawing.Size(80, 19);
            this.lblAudioLevel.TabIndex = 6;
            this.lblAudioLevel.Text = "Audio Level:";
            // 
            // pnlAudioLevel
            // 
            this.pnlAudioLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.pnlAudioLevel.Location = new System.Drawing.Point(0, 0);
            this.pnlAudioLevel.Name = "pnlAudioLevel";
            this.pnlAudioLevel.Size = new System.Drawing.Size(0, 20);
            this.pnlAudioLevel.TabIndex = 7;
            // 
            // pnlAudioContainer
            // 
            this.pnlAudioContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.pnlAudioContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAudioContainer.Controls.Add(this.pnlAudioLevel);
            this.pnlAudioContainer.Location = new System.Drawing.Point(500, 120);
            this.pnlAudioContainer.Name = "pnlAudioContainer";
            this.pnlAudioContainer.Size = new System.Drawing.Size(200, 22);
            this.pnlAudioContainer.TabIndex = 8;
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInstructions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblInstructions.Location = new System.Drawing.Point(20, 520);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(500, 19);
            this.lblInstructions.TabIndex = 9;
            this.lblInstructions.Text = "☁️ Powered by Microsoft Azure Cognitive Services - Superior accuracy!";
            // 
            // lblAzureInfo
            // 
            this.lblAzureInfo.AutoSize = true;
            this.lblAzureInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAzureInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblAzureInfo.Location = new System.Drawing.Point(20, 550);
            this.lblAzureInfo.Name = "lblAzureInfo";
            this.lblAzureInfo.Size = new System.Drawing.Size(400, 15);
            this.lblAzureInfo.TabIndex = 10;
            this.lblAzureInfo.Text = "Requires Azure Speech Service subscription. Click Setup Azure to configure.";
            // 
            // btnSetupAzure
            // 
            this.btnSetupAzure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnSetupAzure.FlatAppearance.BorderSize = 0;
            this.btnSetupAzure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetupAzure.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSetupAzure.ForeColor = System.Drawing.Color.White;
            this.btnSetupAzure.Location = new System.Drawing.Point(490, 80);
            this.btnSetupAzure.Name = "btnSetupAzure";
            this.btnSetupAzure.Size = new System.Drawing.Size(120, 60);
            this.btnSetupAzure.TabIndex = 11;
            this.btnSetupAzure.Text = "SETUP AZURE";
            this.btnSetupAzure.UseVisualStyleBackColor = false;
            this.btnSetupAzure.Click += new System.EventHandler(this.btnSetupAzure_Click);
            // 
            // AzureSpeechForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 580);
            this.Controls.Add(this.btnSetupAzure);
            this.Controls.Add(this.lblAzureInfo);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.pnlAudioContainer);
            this.Controls.Add(this.lblAudioLevel);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnTestMic);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AzureSpeechForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Azure Speech to Text Pro - Cloud-Powered Recognition";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnTestMic;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblAudioLevel;
        private System.Windows.Forms.Panel pnlAudioLevel;
        private System.Windows.Forms.Panel pnlAudioContainer;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblAzureInfo;
        private System.Windows.Forms.Button btnSetupAzure;
    }
}
