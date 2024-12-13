using Microsoft.Extensions.DependencyInjection;
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
            
            var application = serviceProvider.GetRequiredService<Application>();
            application.Run();

        }

    }
}
