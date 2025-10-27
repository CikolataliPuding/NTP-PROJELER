using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace FaceRecognition
{
    public partial class Form1 : Form
    {
        private VideoCapture kamera;
        private CascadeClassifier yuzAlgilayici;
        private LBPHFaceRecognizer taniyici;
        private bool egitimTamamlandi = false;
        private SpeechSynthesizer ses = new SpeechSynthesizer();

        public Form1()
        {
            InitializeComponent();

            // Cascade dosyasýný projenin çalýþma dizininden al
            string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "haarcascade_frontalface_alt2.xml");

            // Dosya var mý kontrolü
            if (!File.Exists(xmlPath))
            {
                MessageBox.Show("Cascade dosyasý bulunamadý!\n\nBeklenen konum:\n" + xmlPath,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ýlk satýrý kontrol edelim
            string firstLine = File.ReadLines(xmlPath).FirstOrDefault() ?? "BOÞ DOSYA!";
            if (!firstLine.Contains("<?xml"))
            {
                MessageBox.Show("XML dosyasý bozuk görünüyor. Ýlk satýr:\n" + firstLine,
                    "Geçersiz XML", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cascade baþlat
            yuzAlgilayici = new CascadeClassifier(xmlPath);

            // Tanýyýcýyý oluþtur
            taniyici = new LBPHFaceRecognizer(1, 8, 8, 8, 100);
        }

        private void btnKameraBaslat_Click(object sender, EventArgs e)
        {
            try
            {
                kamera = new VideoCapture();
                kamera.ImageGrabbed += Kamera_ImageGrabbed;
                kamera.Start();
                lblDurum.Text = "Kamera baþlatýldý.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kamera baþlatýlamadý: " + ex.Message);
            }
        }

        private void Kamera_ImageGrabbed(object sender, EventArgs e)
        {
            Mat frame = new Mat();
        }
    }
}
