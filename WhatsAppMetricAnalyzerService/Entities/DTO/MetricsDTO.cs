using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsAppMetricAnalyzerService.Entities.DTO
{
    public class MetricsDTO
    {
        public int TotalMessages { get; set; }
        public int TotalWords { get; set; }
        public Dictionary<string, int> AverageWordsPerUser { get; set; }
        public Dictionary<string, int> MostUsedWords { get; set; }
        public Dictionary<string, int> MessagesPerUser { get; set; }
        public Dictionary<string, int> MessagesPerHour { get; set; }
        public Dictionary<string, int> MessagesPerMonth { get; set; }
        public Dictionary<string, int> MessagesPerYear { get; set; }
        public Dictionary<string, int> MessagesPerUserPerMonth { get; set; }
        public Dictionary<string, int> MessagesPerUserPerYear { get; set; }
        public Dictionary<string, int> MessagesPerUserPerHour { get; set; }
        public Dictionary<string, int> LongestMessagePerUser { get; set; }
    }

}
