using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WhatsAppMetricAnalyzerService.Entities;
using System.IO;
using WhatsAppMetricAnalyzerService.DataAccess.Abstract;


namespace WhatsAppMetricAnalyzerService.DataAccess.Concrete
{
    public class ChatFileHelper : IChatFileHelper
    {
        public ChatFileHelper() { }

        public List<Message> ParseChatFile(string filePath)
        {
            List<Message> messages = new List<Message>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                //regex... (╯°□°)╯︵ ┻━┻
                var messageMatch = Regex.Match(line, @"^\[(\d{2}\.\d{2}\.\d{4}, \d{2}:\d{2}:\d{2})\] ~?(\w+(?: \w+)*):\s*(.*)$");



                if (messageMatch.Success)
                {

                    string timestamp = messageMatch.Groups[1].Value;
                    string user = messageMatch.Groups[2].Value;
                    string content = messageMatch.Groups[3].Value;

                    messages.Add(new Message
                    {
                        Timestamp = timestamp,
                        User = user,
                        Content = content
                    });
                }
            }

            return messages;
        }


    }
}
