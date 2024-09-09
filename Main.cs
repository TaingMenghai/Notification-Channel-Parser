using System;
using System.Collections.Generic;
using System.Linq;

namespace NotificationChannelParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Notification Channel Parser");
            Console.WriteLine("---------------------------");

            while (true)
            {
                Console.Write("Enter notification title (or 'exit' to quit): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                var channels = ParseNotificationChannels(input);
                DisplayResult(channels, input);
            }
        }

        private static HashSet<string> ParseNotificationChannels(string input)
        {
            var channels = new HashSet<string>();
            var channelTags = Enum.GetNames(typeof(NotificationChannel));

            foreach (var tag in channelTags)
            {
                if (input.Contains($"[{tag}]"))
                {
                    channels.Add(tag);
                }
            }

            return channels;
        }

        private static void DisplayResult(HashSet<string> channels, string input)
        {
            if (channels.Count > 0)
            {
                Console.WriteLine($"Receive channels: {string.Join(", ", channels)}");
            }
            else
            {
                Console.WriteLine("No valid notification channels found.");
            }
        }
    }

    public enum NotificationChannel
    {
        BE,
        FE,
        QA,
        Urgent
    }
}
