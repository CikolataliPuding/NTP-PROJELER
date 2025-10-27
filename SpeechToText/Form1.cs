using System;
using System.Drawing;
using System.Globalization;
using System.Speech.Recognition;
using System.Threading;
using System.Windows.Forms;

namespace SpeechToTextApp
{
    public partial class MainForm : Form
    {
        private SpeechRecognitionEngine speechEngine;
        private bool isListening = false;
        private System.Windows.Forms.Timer statusTimer;
        private int audioLevel = 0;

        public MainForm()
        {
            InitializeComponent();
            InitializeSpeechEngine();
            SetupStatusTimer();
        }

        private void InitializeSpeechEngine()
        {
            try
            {
                // İngilizce için optimize edilmiş ayarlar
                var culture = new CultureInfo("en-US");
                speechEngine = new SpeechRecognitionEngine(culture);

                // Mikrofonu ayarla
                speechEngine.SetInputToDefaultAudioDevice();

                // Çok agresif timeout ayarları - daha hızlı tepki için
                speechEngine.InitialSilenceTimeout = TimeSpan.FromSeconds(1);
                speechEngine.BabbleTimeout = TimeSpan.FromSeconds(1);
                speechEngine.EndSilenceTimeout = TimeSpan.FromMilliseconds(500);
                speechEngine.EndSilenceTimeoutAmbiguous = TimeSpan.FromMilliseconds(800);

                // Çoklu gramer yükleme - daha iyi tanıma için
                speechEngine.LoadGrammar(new DictationGrammar());

                // Basit kelimeler için ek gramer
                var simpleGrammar = new GrammarBuilder();
                simpleGrammar.AppendWildcard();
                speechEngine.LoadGrammar(new Grammar(simpleGrammar));

                // Event handler'ları ayarla
                speechEngine.SpeechDetected += OnSpeechDetected;
                speechEngine.SpeechRecognized += OnSpeechRecognized;
                speechEngine.SpeechRecognitionRejected += OnSpeechRejected;
                speechEngine.RecognizeCompleted += OnRecognizeCompleted;

                UpdateStatus("Ready to listen", Color.Green);
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error: {ex.Message}", Color.Red);
                MessageBox.Show($"Speech engine initialization failed:\n{ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupStatusTimer()
        {
            statusTimer = new System.Windows.Forms.Timer();
            statusTimer.Interval = 100; // 100ms
            statusTimer.Tick += (s, e) =>
            {
                if (speechEngine != null && isListening)
                {
                    audioLevel = speechEngine.AudioLevel;
                    UpdateAudioLevel();
                }
            };
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (!isListening)
            {
                StartListening();
            }
            else
            {
                StopListening();
            }
        }

        private void StartListening()
        {
            try
            {
                if (speechEngine == null) return;

                // Çok agresif dinleme modu - sürekli dinle
                speechEngine.RecognizeAsync(RecognizeMode.Multiple);
                isListening = true;
                statusTimer.Start();

                btnStartStop.Text = "STOP";
                btnStartStop.BackColor = Color.FromArgb(220, 53, 69); // Kırmızı
                btnStartStop.ForeColor = Color.White;

                UpdateStatus("Aggressive listening mode...", Color.Blue);
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error: {ex.Message}", Color.Red);
            }
        }

        private void StopListening()
        {
            try
            {
                if (speechEngine == null) return;

                speechEngine.RecognizeAsyncStop();
                isListening = false;
                statusTimer.Stop();

                btnStartStop.Text = "START";
                btnStartStop.BackColor = Color.FromArgb(40, 167, 69); // Yeşil
                btnStartStop.ForeColor = Color.White;

                UpdateStatus("Stopped", Color.Orange);
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error: {ex.Message}", Color.Red);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
            UpdateStatus("Text cleared", Color.Gray);
        }

        private void btnTestMic_Click(object sender, EventArgs e)
        {
            TestMicrophone();
        }

        private void TestMicrophone()
        {
            try
            {
                UpdateStatus("Testing microphone...", Color.Blue);

                if (speechEngine == null)
                {
                    UpdateStatus("Speech engine not initialized", Color.Red);
                    return;
                }

                var level = speechEngine.AudioLevel;
                var format = speechEngine.AudioFormat;

                string result = $"Microphone Test Results:\n\n";
                result += $"Audio Level: {level}\n";
                result += $"Audio Format: {format?.EncodingFormat}\n";
                result += $"Sample Rate: {format?.SamplesPerSecond} Hz\n";
                result += $"Channels: {format?.ChannelCount}\n\n";

                if (level > 0)
                {
                    result += "✅ Microphone is working!";
                    UpdateStatus($"Mic OK (Level: {level})", Color.Green);
                }
                else
                {
                    result += "❌ No audio input detected.\n\n";
                    result += "Troubleshooting:\n";
                    result += "• Check microphone connection\n";
                    result += "• Verify Windows microphone permissions\n";
                    result += "• Try a different USB port\n";
                    result += "• Run as administrator";
                    UpdateStatus("No audio input", Color.Red);
                }

                MessageBox.Show(result, "Microphone Test", MessageBoxButtons.OK,
                              level > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                UpdateStatus($"Test failed: {ex.Message}", Color.Red);
                MessageBox.Show($"Microphone test failed:\n{ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnSpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                UpdateStatus("Speech detected, processing...", Color.Purple);
            });
        }

        private void OnSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                string text = e.Result.Text;
                float confidence = e.Result.Confidence;

                // Çok düşük güven skoru bile kabul et - %20'nin üzerinde
                if (confidence > 0.2f)
                {
                    txtOutput.AppendText(text + " ");
                    txtOutput.ScrollToCaret();

                    // Güven skoruna göre renk değiştir
                    if (confidence > 0.7f)
                        UpdateStatus($"Excellent (Confidence: {confidence:P0})", Color.Green);
                    else if (confidence > 0.5f)
                        UpdateStatus($"Good (Confidence: {confidence:P0})", Color.Blue);
                    else
                        UpdateStatus($"Acceptable (Confidence: {confidence:P0})", Color.Orange);
                }
                else
                {
                    UpdateStatus($"Very low confidence: {confidence:P0}", Color.Red);
                }
            });
        }

        private void OnSpeechRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                UpdateStatus("Speech not recognized", Color.Red);
            });
        }

        private void OnRecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (isListening)
                {
                    UpdateStatus("Listening...", Color.Blue);
                }
            });
        }

        private void UpdateStatus(string message, Color color)
        {
            lblStatus.Text = message;
            lblStatus.ForeColor = color;
        }

        private void UpdateAudioLevel()
        {
            // Ses seviyesi çubuğunu güncelle
            int barWidth = Math.Min(200, audioLevel * 2);
            pnlAudioLevel.Width = barWidth;

            // Renk değiştir
            if (audioLevel > 50)
                pnlAudioLevel.BackColor = Color.Green;
            else if (audioLevel > 25)
                pnlAudioLevel.BackColor = Color.Orange;
            else
                pnlAudioLevel.BackColor = Color.Red;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (isListening)
            {
                StopListening();
            }

            if (speechEngine != null)
            {
                speechEngine.Dispose();
            }

            statusTimer?.Dispose();
            base.OnFormClosing(e);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
