namespace FaceRecognition
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            lblDurum = new Label();
            btnKameraBaslat = new Button();
            btnKaydet = new Button();
            btnTani = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(10, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(640, 480);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
            // 
            // lblDurum
            // 
            lblDurum.AutoSize = true;
            lblDurum.Location = new Point(10, 500);
            lblDurum.Name = "lblDurum";
            lblDurum.Size = new Size(67, 20);
            lblDurum.TabIndex = 1;
            lblDurum.Text = "Durum: -";
            // 
            // btnKameraBaslat
            // 
            btnKameraBaslat.Location = new Point(700, 30);
            btnKameraBaslat.Name = "btnKameraBaslat";
            btnKameraBaslat.Size = new Size(94, 29);
            btnKameraBaslat.TabIndex = 2;
            btnKameraBaslat.Text = "Kamera Başlat";
            btnKameraBaslat.UseVisualStyleBackColor = true;
            btnKameraBaslat.Click += new EventHandler(this.btnKameraBaslat_Click);
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(700, 80);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(94, 29);
            btnKaydet.TabIndex = 3;
            btnKaydet.Text = "Yüz Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += new EventHandler(this.btnKaydet_Click);
            // 
            // btnTani
            // 
            btnTani.Location = new Point(700, 130);
            btnTani.Name = "btnTani";
            btnTani.Size = new Size(94, 29);
            btnTani.TabIndex = 4;
            btnTani.Text = "Eğit / Tanı";
            btnTani.UseVisualStyleBackColor = true;
            btnTani.Click += new EventHandler(this.btnTani_Click);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 540);
            Controls.Add(btnTani);
            Controls.Add(btnKaydet);
            Controls.Add(btnKameraBaslat);
            Controls.Add(lblDurum);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Face Recognition";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private PictureBox pictureBox1;
        private Label lblDurum;
        private Button btnKameraBaslat;
        private Button btnKaydet;
        private Button btnTani;
    }
}
