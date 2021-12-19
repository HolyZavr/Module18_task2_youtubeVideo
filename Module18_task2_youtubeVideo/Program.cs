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
                    var discription = video.Description;
                    var duration = video.Duration;

                    Console.WriteLine($"Информация о видео: ");
                    Console.WriteLine($"Название: '{title}' | Автор: {author} | Продолжительность {duration}");
                    Console.WriteLine($"Описание: {discription}");

                    await youtube.Videos.DownloadAsync(pathToVideo, $"{pathToFolder}/{author}-{title}.mp4", o => o
                    .SetPreset(ConversionPreset.UltraFast));

                    Console.WriteLine("\nВидео загружено!\n");
                }
                catch (System.ArgumentException ex)
                {
                    Console.WriteLine("\nНе корректный URL видео\n");
                }
            }
        }
    }
}
