using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsAppMetricAnalyzerService.DataAccess.Abstract;
using WhatsAppMetricAnalyzerService.DataAccess.Concrete;

namespace WhatsAppMetricAnalyzer
{
    public class DependencyInjectionConfig
    {
        public static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();


            serviceCollection.AddSingleton<IChatFileHelper, ChatFileHelper>();


            return serviceCollection.BuildServiceProvider();
        }
    }
}
