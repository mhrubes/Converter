using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using Spire.Pdf;
using System.Windows.Media;

namespace PDFtoWordConverter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Convert_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";

            if (openFileDialog.ShowDialog() == true)
            {
                PdfDocument pdf = new PdfDocument();

                string pdfFilePath = openFileDialog.FileName;

                string defaultFileName = Path.GetFileNameWithoutExtension(pdfFilePath);
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Word files (*.docx)|*.docx";
                saveFileDialog.FileName = defaultFileName;
                if (saveFileDialog.ShowDialog() == true)
                {
                    string outputFilePath = saveFileDialog.FileName;

                    try
                    {
                        pdf.LoadFromFile(pdfFilePath);

                        pdf.SaveToFile(outputFilePath, FileFormat.DOCX);
                        pdf.Close();

                        MessageBox.Show("Proces byl dokončen. Soubor uložen jako " + outputFilePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chyba při zpracování: " + ex.Message);
                    }
                }
            }
        }

        private void Convert_btn_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //this.MaxHeight = 120;
            //this.MaxWidth = 220;

            //this.Height = 120;
            //this.Width = 220;

            //Convert_btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF104D5D"));
            Convert_btn.Background = (Brush)FindResource("onMouseEnterBackgroundColor");
            Convert_btn.FontWeight = FontWeights.Bold;
        }

        private void Convert_btn_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //this.MaxHeight = 110;
            //this.MaxWidth = 200;

            //this.Height = 110;
            //this.Width = 200;

            Convert_btn.Background = (Brush)FindResource("onMouseLeaveBackgroundColor");
            Convert_btn.FontWeight = FontWeights.Normal;
        }
    }
}
