using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsAppMetricAnalyzerService.DataAccess.Abstract;

namespace WhatsAppMetricAnalyzer
{
    public class Application
    {
        private readonly IChatFileHelper _chatFileHelper;

        public Application(IChatFileHelper chatFileHelper)
        {
            _chatFileHelper = chatFileHelper;
        }
        public void Run()
        {
            string path = GetFilePath();

            List<WhatsAppMetricAnalyzerService.Entities.Message> messages = _chatFileHelper.ParseChatFile(path);
        }

        [STAThread]
        private string GetFilePath()
        {
            foreach (int countback in Enumerable.Range(1, 3).Reverse())
            {
                Console.Clear();
                Console.WriteLine(@"
                             /\_/\  
                            ( o.o )  Whatsapp Metrik Analiz Programına Hoşgeldiniz!
                             > ^ <");
                Console.WriteLine(countback + " saniye sonra dosya seçme ekranı açılacak.");
                System.Threading.Thread.Sleep(1000);
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.Title = "Bir dosya seçin";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                Console.WriteLine("Seçilen dosya yolu: " + filePath);
                return filePath;
            }
            else
            {
                Console.WriteLine("Dosya seçilmedi.");
                return null;
            }
        }
    }
}
