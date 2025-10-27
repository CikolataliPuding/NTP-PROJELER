namespace SpeechToTextApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            
            // Azure Speech Service ile başlat (daha iyi doğruluk için)
            Application.Run(new AzureSpeechForm());
            
            // Alternatif olarak yerel Windows Speech ile:
            // Application.Run(new MainForm());
        }
    }
}