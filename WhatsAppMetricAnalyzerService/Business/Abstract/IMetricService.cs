using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsAppMetricAnalyzerService.Entities;

namespace WhatsAppMetricAnalyzerService.Business.Abstract
{
    public interface IMetricService
    {
        void CreateAndProcessMetrics(List<Message> messages);

    }
}
