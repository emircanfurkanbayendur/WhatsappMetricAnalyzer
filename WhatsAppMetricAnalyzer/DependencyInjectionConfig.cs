using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsAppMetricAnalyzerService.Business.Abstract;
using WhatsAppMetricAnalyzerService.Business.Concrete;
using WhatsAppMetricAnalyzerService.DataAccess.Abstract;
using WhatsAppMetricAnalyzerService.DataAccess.Concrete;
using WhatsAppMetricAnalyzerService.Presentation.Abstract;
using WhatsAppMetricAnalyzerService.Presentation.Concrete;

namespace WhatsAppMetricAnalyzer
{
    public class DependencyInjectionConfig
    {
        public static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();


            serviceCollection.AddSingleton<IChatFileHelper, ChatFileHelper>();
            serviceCollection.AddSingleton<IMetricService, MetricService>();
            serviceCollection.AddSingleton<IPDFService, PDFService>();
            serviceCollection.AddSingleton<Application>();


            return serviceCollection.BuildServiceProvider();
        }
    }
}
