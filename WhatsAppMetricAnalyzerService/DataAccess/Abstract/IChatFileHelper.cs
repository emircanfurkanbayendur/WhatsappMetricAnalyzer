using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsAppMetricAnalyzerService.Entities;

namespace WhatsAppMetricAnalyzerService.DataAccess.Abstract
{
    public interface IChatFileHelper
    {
        List<Message> ParseChatFile(string filePath);
    }
}
