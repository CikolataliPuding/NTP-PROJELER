using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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

            // Cascade dosyasını projenin çalışma dizininden al
            string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "haarcascade_frontalface_default.xml");

            // Dosya var mı kontrolü
            if (!File.Exists(xmlPath))
            {
                MessageBox.Show("Cascade dosyası bulunamadı!\n\nBeklenen konum:\n" + xmlPath,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // İlk satırı kontrol edelim
            string firstLine = File.ReadLines(xmlPath).FirstOrDefault() ?? "BOŞ DOSYA!";
            if (!firstLine.Contains("<?xml"))
            {
                MessageBox.Show("XML dosyası bozuk görünüyor. İlk satır:\n" + firstLine,
                    "Geçersiz XML", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cascade başlat
            yuzAlgilayici = new CascadeClassifier(xmlPath);

            // Tanıyıcıyı oluştur
            taniyici = new LBPHFaceRecognizer(1, 8, 8, 8, 100);

            // Var olan model dosyasını yükle (varsa)
            try
            {
                if (File.Exists("egemen.yml"))
                {
                    taniyici.Read("egemen.yml");
                    egitimTamamlandi = true;
                }
            }
            catch { /* modele erişilemezse sessiz geç */ }
        }

        private void btnKameraBaslat_Click(object sender, EventArgs e)
        {
            try
            {
                kamera = new VideoCapture();
                kamera.ImageGrabbed += Kamera_ImageGrabbed;
                kamera.Start();
                lblDurum.Text = "Kamera ba�lat�ld�.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kamera ba�lat�lamad�: " + ex.Message);
            }
        }

        private void Kamera_ImageGrabbed(object sender, EventArgs e)
        {
            Mat frame = new Mat();
            try
            {
                kamera.Retrieve(frame);
                if (frame.IsEmpty)
                    return;

                var img = frame.ToImage<Bgr, byte>();
                var gri = img.Convert<Gray, byte>();

                var yuzler = yuzAlgilayici.DetectMultiScale(
                    gri,
                    1.2,
                    6,
                    new Size(60, 60));

                foreach (var rect in yuzler)
                {
                    CvInvoke.Rectangle(img, rect, new MCvScalar(0, 255, 0), 2);

                    if (egitimTamamlandi)
                    {
                        using var yuz = gri.Copy(rect).Resize(100, 100, Inter.Cubic);
                        var result = taniyici.Predict(yuz);
                        string text = $"ID:{result.Label} conf:{result.Distance:0.0}";
                        CvInvoke.PutText(img, text, new Point(rect.X, rect.Y - 8),
                            FontFace.HersheySimplex, 0.6, new MCvScalar(0, 255, 0), 2);
                    }
                }

                // UI thread'e güvenli şekilde görüntü aktar
                if (pictureBox1.InvokeRequired)
                {
                    pictureBox1.BeginInvoke(new Action(() =>
                    {
                        pictureBox1.Image?.Dispose();
                        pictureBox1.Image = img.ToBitmap();
                    }));
                }
                else
                {
                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = img.ToBitmap();
                }
            }
            catch
            {
                // kare okunamadıysa sessiz geç
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Bu olay PictureBox'a t�klan�nca tetiklenir
            // �imdilik bo� b�rakabiliriz
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (kamera == null)
            {
                MessageBox.Show("Kamera açık değil!");
                return;
            }

            Mat frame = new Mat();
            kamera.Retrieve(frame);
            var img = frame.ToImage<Bgr, byte>();
            var gri = img.Convert<Gray, byte>();
            var yuzler = yuzAlgilayici.DetectMultiScale(gri, 1.2, 6, new Size(60, 60));

            if (yuzler.Length > 0)
            {
                var yuz = gri.Copy(yuzler[0]).Resize(100, 100, Inter.Cubic);
                Directory.CreateDirectory("faces");
                // benzersiz dosya adı
                string fileName = $"egemen_{DateTime.Now:yyyyMMdd_HHmmss}.jpg";
                string fullPath = Path.Combine("faces", fileName);
                yuz.Save(fullPath);
                lblDurum.Text = "Yüz kaydedildi!";
            }
            else
            {
                lblDurum.Text = "Yüz algılanamadı!";
            }
        }

        private void btnTani_Click(object sender, EventArgs e)
        {
            // en az bir görüntü gerekli
            if (!Directory.Exists("faces") || Directory.GetFiles("faces", "*.jpg").Length == 0)
            {
                MessageBox.Show("Eğitim için kayıtlı yüz bulunamadı!");
                return;
            }

            var images = new List<Image<Gray, byte>>();
            var labels = new List<int>();
            foreach (var path in Directory.GetFiles("faces", "*.jpg"))
            {
                images.Add(new Image<Gray, byte>(path));
                labels.Add(1); // tek kişi için aynı etiket
            }

            using (var imageArray = new Emgu.CV.Util.VectorOfMat())
            {
                foreach (var img in images)
                {
                    imageArray.Push(img.Mat);
                }

                using (var labelsMat = new Mat(labels.Count, 1, DepthType.Cv32S, 1))
                {
                    for (int i = 0; i < labels.Count; i++)
                    {
                        var value = new int[] { labels[i] };
                        using (var valueMat = new Mat(1, 1, DepthType.Cv32S, 1))
                        {
                            valueMat.SetTo(value);
                            valueMat.CopyTo(new Mat(labelsMat, new Rectangle(0, i, 1, 1)));
                        }
                    }

                    taniyici.Train(imageArray, labelsMat);
                    taniyici.Write("egemen.yml");
                    egitimTamamlandi = true;
                    lblDurum.Text = "Eğitim tamamlandı!";
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                if (kamera != null)
                {
                    kamera.ImageGrabbed -= Kamera_ImageGrabbed;
                    if (kamera.IsOpened)
                        kamera.Stop();
                    kamera.Dispose();
                    kamera = null;
                }
            }
            catch { }
            base.OnFormClosing(e);
        }


    }
}
