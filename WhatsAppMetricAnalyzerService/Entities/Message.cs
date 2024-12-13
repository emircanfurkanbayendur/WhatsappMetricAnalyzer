using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsAppMetricAnalyzerService.Entities
{
    public class Message
    {
        public string Timestamp { get; set; }
        public string User { get; set; }
        public string Content { get; set; }
    }
}
