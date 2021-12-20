using System;
using System.IO;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;

namespace Module18_task2_youtubeVideo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Write("Веедите ссылку на видео: ");
                    string pathToVideo = Console.ReadLine();

                    string pathToFolder = @"C:\Users\stolb\Desktop\videos";
                    if (!Directory.Exists(pathToFolder)) Directory.CreateDirectory(pathToFolder);

                    var youtube = new YoutubeClient();
                    var video = await youtube.Videos.GetAsync(pathToVideo);

                    var title = video.Title;
                    var author = video.Author.Title;

                    Console.WriteLine($"\nИнформация о видео: ");
                    Console.WriteLine($"\nНазвание: '{title}' || Автор: {author} || Продолжительность: {video.Duration}");
                    Console.WriteLine($"\nОписание: {video.Description}");

                    var baseVideoName = author +"-"+ title; 
                    var unwantedChars = new string[] {":", "|"};

                    foreach (var ch in unwantedChars)
                    {
                        baseVideoName = baseVideoName.Replace(ch, string.Empty);
                    }

                    if (baseVideoName.Length > 30) baseVideoName.Substring(0, 25);

                    await youtube.Videos.DownloadAsync(pathToVideo, $"{pathToFolder}/{baseVideoName.Substring(0, 25)}.mp4", o => o
                    .SetPreset(ConversionPreset.UltraFast));

                    Console.WriteLine("\n\nВидео загружено!\n\n\n");
                }
                catch (System.ArgumentException)
                {
                    Console.WriteLine("\nНе корректный URL видео\n");
                }
            }
        }
    }
}
