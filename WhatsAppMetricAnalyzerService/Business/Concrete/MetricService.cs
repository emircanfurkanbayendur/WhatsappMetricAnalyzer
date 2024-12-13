using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsAppMetricAnalyzerService.Business.Abstract;
using WhatsAppMetricAnalyzerService.Entities;
using WhatsAppMetricAnalyzerService.Entities.DTO;

namespace WhatsAppMetricAnalyzerService.Business.Concrete
{
    public class MetricService : IMetricService
    {
        public MetricService() { }

        public void CreateAndProcessMetrics(List<Message> messages)
        {
            var metrics = new MetricsDTO
            {
                TotalMessages = GetTotalMessages(messages),
                TotalWords = GetTotalWords(messages),
                AverageWordsPerUser = GetAverageWordsPerUser(messages),
                MostUsedWords = GetMostUsedWords(messages),
                MessagesPerUser = GetMessagesPerUser(messages),
                MessagesPerHour = GetMessagesPerHour(messages),
                MessagesPerMonth = GetMessagesPerMonth(messages),
                MessagesPerYear = GetMessagesPerYear(messages),
                MessagesPerUserPerMonth = GetMessagesPerUserPerMonth(messages),
                MessagesPerUserPerYear = GetMessagesPerUserPerYear(messages),
                MessagesPerUserPerHour = GetMessagesPerUserPerHour(messages),
                LongestMessagePerUser = GetLongestMessagePerUser(messages)
            };





        }

        private int GetTotalMessages(List<Message> messages)
        {
            return messages.Count;

        }

        private int GetTotalWords(List<Message> messages)
        {
            int totalWords = 0;
            foreach (var message in messages)
            {
                totalWords += message.Content.Split(' ').Length;
            }
            return totalWords;
        }

        private Dictionary<string, int> GetAverageWordsPerUser(List<Message> messages)
        {
            Dictionary<string, int> userWordCount = new Dictionary<string, int>();
            Dictionary<string, int> userMessageCount = new Dictionary<string, int>();
            foreach (var message in messages)
            {
                if (userWordCount.ContainsKey(message.User))
                {
                    userWordCount[message.User] += message.Content.Split(' ').Length;
                    userMessageCount[message.User]++;
                }
                else
                {
                    userWordCount.Add(message.User, message.Content.Split(' ').Length);
                    userMessageCount.Add(message.User, 1);
                }
            }
            Dictionary<string, int> userAverageWordCount = new Dictionary<string, int>();
            foreach (var user in userWordCount)
            {
                userAverageWordCount.Add(user.Key, user.Value / userMessageCount[user.Key]);
            }
            return userAverageWordCount;
        }

        private Dictionary<string, int> GetMostUsedWords(List<Message> messages)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach (var message in messages)
            {
                string[] words = message.Content.Split(' ');
                foreach (var word in words)
                {
                    if (wordCount.ContainsKey(word))
                    {
                        wordCount[word]++;
                    }
                    else
                    {
                        wordCount.Add(word, 1);
                    }
                }
            }
            return wordCount;
        }

        private Dictionary<string, int> GetMessagesPerUser(List<Message> messages)
        {
            Dictionary<string, int> userCount = new Dictionary<string, int>();
            foreach (var message in messages)
            {
                if (userCount.ContainsKey(message.User))
                {
                    userCount[message.User]++;
                }
                else
                {
                    userCount.Add(message.User, 1);
                }
            }
            return userCount;
        }

        private Dictionary<string, int> GetMessagesPerHour(List<Message> messages)
        {
            Dictionary<string, int> hourCount = new Dictionary<string, int>();
            foreach (var message in messages)
            {
                string hour = message.Timestamp.Split(',')[1].Trim().Split(':')[0];
                if (hourCount.ContainsKey(hour))
                {
                    hourCount[hour]++;
                }
                else
                {
                    hourCount.Add(hour, 1);
                }
            }
            return hourCount;
        }

        private Dictionary<string, int> GetMessagesPerMonth(List<Message> messages)
        {
            Dictionary<string, int> monthCount = new Dictionary<string, int>();
            foreach (var message in messages)
            {
                string month = message.Timestamp.Split(',')[0].Split('.')[1].Trim();
                if (monthCount.ContainsKey(month))
                {
                    monthCount[month]++;
                }
                else
                {
                    monthCount.Add(month, 1);
                }
            }
            return monthCount;

        }


        private Dictionary<string, int> GetMessagesPerYear(List<Message> messages)
        {
            Dictionary<string, int> yearCount = new Dictionary<string, int>();
            foreach (var message in messages)
            {
                string year = message.Timestamp.Split(',')[0].Split('.')[2].Trim();
                if (yearCount.ContainsKey(year))
                {
                    yearCount[year]++;
                }
                else
                {
                    yearCount.Add(year, 1);
                }
            }
            return yearCount;
        }

        private Dictionary<string, int> GetMessagesPerUserPerMonth(List<Message> messages)
        {
            Dictionary<string, int> userMonthCount = new Dictionary<string, int>();
            foreach (var message in messages)
            {
                string userMonth = message.User + " " + message.Timestamp.Split(',')[0].Split('.')[1].Trim();
                if (userMonthCount.ContainsKey(userMonth))
                {
                    userMonthCount[userMonth]++;
                }
                else
                {
                    userMonthCount.Add(userMonth, 1);
                }
            }
            return userMonthCount;
        }

        private Dictionary<string, int> GetMessagesPerUserPerYear(List<Message> messages)
        {
            Dictionary<string, int> userYearCount = new Dictionary<string, int>();
            foreach (var message in messages)
            {
                string userYear = message.User + " " + message.Timestamp.Split(',')[0].Split('.')[2].Trim();
                if (userYearCount.ContainsKey(userYear))
                {
                    userYearCount[userYear]++;
                }
                else
                {
                    userYearCount.Add(userYear, 1);
                }
            }
            return userYearCount;
        }

        private Dictionary<string, int> GetMessagesPerUserPerHour(List<Message> messages)
        {
            Dictionary<string, int> userHourCount = new Dictionary<string, int>();
            foreach (var message in messages)
            {
                string userHour = message.User + " " + message.Timestamp.Split(',')[1].Trim().Split(':')[0];
                if (userHourCount.ContainsKey(userHour))
                {
                    userHourCount[userHour]++;
                }
                else
                {
                    userHourCount.Add(userHour, 1);
                }
            }
            return userHourCount;
        }

        private Dictionary<string, int> GetLongestMessagePerUser(List<Message> messages)
        {
            Dictionary<string, int> userLongestMessage = new Dictionary<string, int>();
            foreach (var message in messages)
            {
                if (userLongestMessage.ContainsKey(message.User))
                {
                    if (message.Content.Length > userLongestMessage[message.User])
                    {
                        userLongestMessage[message.User] = message.Content.Length;
                    }
                }
                else
                {
                    userLongestMessage.Add(message.User, message.Content.Length);
                }
            }
            return userLongestMessage;


        }

    }
}
