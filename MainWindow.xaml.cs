using System.IO;
using System.Windows;
using System.Text;

namespace Patientenakten
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void erstellen_Click(object sender, RoutedEventArgs e)
        {
            string content = inhalt.Text;
            string textdateie = dateiname.Text;
            string dirPath = @"C:\Users\CC-Student\Desktop\";
            

            using (FileStream fs = File.Create(dirPath + textdateie + ".txt"))
            {
                byte[] contentToByte = Encoding.ASCII.GetBytes(content);
                fs.Write(contentToByte, 0, contentToByte.Length);
            }
            
            MessageBox.Show("Datei wurde angelegt.");
        }

        private void offnen_Click(object sender, RoutedEventArgs e)
        {
            string textdateie = dateiname.Text;
            string dirPath = @"C:\Users\CC-Student\Desktop\";
            using (FileStream fs = File.OpenRead(dirPath + textdateie + ".txt"))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string content = sr.ReadToEnd();
                    inhalt.Text = content;
                }
            }
            MessageBox.Show("Datei wurde gelesen.");

        }
    }
}
