using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsAppMetricAnalyzerService.Entities.DTO;

namespace WhatsAppMetricAnalyzerService.Presentation.Abstract
{
    public interface IPDFService
    {
        void GeneratePDF(MetricsDTO metricsDTO);
    }
}
