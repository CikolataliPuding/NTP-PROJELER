namespace SpeechToTextApp
{
    partial class MainForm
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
            lblTitle = new Label();
            btnStartStop = new Button();
            btnClear = new Button();
            btnTestMic = new Button();
            txtOutput = new TextBox();
            lblStatus = new Label();
            lblAudioLevel = new Label();
            pnlAudioLevel = new Panel();
            pnlAudioContainer = new Panel();
            lblInstructions = new Label();
            pnlAudioContainer.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(23, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(274, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🎤 Speech to Text";
            lblTitle.Click += lblTitle_Click;
            // 
            // btnStartStop
            // 
            btnStartStop.BackColor = Color.FromArgb(40, 167, 69);
            btnStartStop.FlatAppearance.BorderSize = 0;
            btnStartStop.FlatStyle = FlatStyle.Flat;
            btnStartStop.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnStartStop.ForeColor = Color.White;
            btnStartStop.Location = new Point(23, 107);
            btnStartStop.Margin = new Padding(3, 4, 3, 4);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new Size(171, 80);
            btnStartStop.TabIndex = 1;
            btnStartStop.Text = "START";
            btnStartStop.UseVisualStyleBackColor = false;
            btnStartStop.Click += btnStartStop_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(108, 117, 125);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(217, 107);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(137, 80);
            btnClear.TabIndex = 2;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnTestMic
            // 
            btnTestMic.BackColor = Color.FromArgb(0, 123, 255);
            btnTestMic.FlatAppearance.BorderSize = 0;
            btnTestMic.FlatStyle = FlatStyle.Flat;
            btnTestMic.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnTestMic.ForeColor = Color.White;
            btnTestMic.Location = new Point(377, 107);
            btnTestMic.Margin = new Padding(3, 4, 3, 4);
            btnTestMic.Name = "btnTestMic";
            btnTestMic.Size = new Size(160, 80);
            btnTestMic.TabIndex = 3;
            btnTestMic.Text = "TEST MIC";
            btnTestMic.UseVisualStyleBackColor = false;
            btnTestMic.Click += btnTestMic_Click;
            // 
            // txtOutput
            // 
            txtOutput.BackColor = Color.FromArgb(248, 249, 250);
            txtOutput.BorderStyle = BorderStyle.FixedSingle;
            txtOutput.Font = new Font("Segoe UI", 12F);
            txtOutput.Location = new Point(23, 267);
            txtOutput.Margin = new Padding(3, 4, 3, 4);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(857, 399);
            txtOutput.TabIndex = 4;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F);
            lblStatus.ForeColor = Color.FromArgb(40, 167, 69);
            lblStatus.Location = new Point(23, 227);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(140, 28);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Ready to listen";
            // 
            // lblAudioLevel
            // 
            lblAudioLevel.AutoSize = true;
            lblAudioLevel.Font = new Font("Segoe UI", 10F);
            lblAudioLevel.ForeColor = Color.FromArgb(108, 117, 125);
            lblAudioLevel.Location = new Point(571, 133);
            lblAudioLevel.Name = "lblAudioLevel";
            lblAudioLevel.Size = new Size(102, 23);
            lblAudioLevel.TabIndex = 6;
            lblAudioLevel.Text = "Audio Level:";
            // 
            // pnlAudioLevel
            // 
            pnlAudioLevel.BackColor = Color.FromArgb(220, 53, 69);
            pnlAudioLevel.Location = new Point(0, 0);
            pnlAudioLevel.Margin = new Padding(3, 4, 3, 4);
            pnlAudioLevel.Name = "pnlAudioLevel";
            pnlAudioLevel.Size = new Size(0, 27);
            pnlAudioLevel.TabIndex = 7;
            // 
            // pnlAudioContainer
            // 
            pnlAudioContainer.BackColor = Color.FromArgb(233, 236, 239);
            pnlAudioContainer.BorderStyle = BorderStyle.FixedSingle;
            pnlAudioContainer.Controls.Add(pnlAudioLevel);
            pnlAudioContainer.Location = new Point(571, 160);
            pnlAudioContainer.Margin = new Padding(3, 4, 3, 4);
            pnlAudioContainer.Name = "pnlAudioContainer";
            pnlAudioContainer.Size = new Size(228, 29);
            pnlAudioContainer.TabIndex = 8;
            // 
            // lblInstructions
            // 
            lblInstructions.AutoSize = true;
            lblInstructions.Font = new Font("Segoe UI", 10F);
            lblInstructions.ForeColor = Color.FromArgb(108, 117, 125);
            lblInstructions.Location = new Point(23, 693);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(423, 23);
            lblInstructions.TabIndex = 9;
            lblInstructions.Text = "💡 Speak clearly in English for best recognition results";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(914, 747);
            Controls.Add(lblInstructions);
            Controls.Add(pnlAudioContainer);
            Controls.Add(lblAudioLevel);
            Controls.Add(lblStatus);
            Controls.Add(txtOutput);
            Controls.Add(btnTestMic);
            Controls.Add(btnClear);
            Controls.Add(btnStartStop);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Speech to Text Pro - English Recognition";
            pnlAudioContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
    }
}
