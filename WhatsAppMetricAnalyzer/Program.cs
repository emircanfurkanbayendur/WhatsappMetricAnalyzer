using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatsAppMetricAnalyzer
{
    internal class Program
    {
        private readonly IServiceProvider _serviceProvider;

        public Program(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;


        }

        [STAThread]
        static void Main(string[] args)
        {
            var serviceProvider = DependencyInjectionConfig.ConfigureServices();

            Program program = new Program(serviceProvider);
            program.Run();
        }

        private void Run()
        {
            string path = GetFilePath();
        }

        [STAThread]
        private string GetFilePath()
        {
            foreach (int countback in Enumerable.Range(1, 10).Reverse())
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
