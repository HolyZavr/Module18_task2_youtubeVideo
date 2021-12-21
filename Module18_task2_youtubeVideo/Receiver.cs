using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;
using System.IO;

namespace Module18_task2_youtubeVideo
{
    class Receiver
    {

        public async Task GetVideoInfo(string videoUrl)
        {
            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(videoUrl);

            Console.WriteLine($"\nИнформация о видео: ");
            Console.WriteLine($"\nНазвание: '{video.Title}' || Автор: {video.Author.Title} || Продолжительность: {video.Duration}");
            Console.WriteLine($"\nОписание: {video.Description}");
        }

        public async Task DownloadVideo(string videoUrl)
        {
            string pathToFolder = @"C:\Users\stolb\Desktop\videos"; // место куда сохранять
            if (!Directory.Exists(pathToFolder)) Directory.CreateDirectory(pathToFolder);

            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(videoUrl);

            var baseVideoName = video.Author.Title + "-" + video.Title;
            var unwantedChars = new string[] { ":", "|" };

            foreach (var ch in unwantedChars)
            {
                baseVideoName = baseVideoName.Replace(ch, string.Empty);
            }

            await youtube.Videos.DownloadAsync(videoUrl, $"{pathToFolder}/{baseVideoName.Substring(0, 25)}.mp4", o => o
            .SetPreset(ConversionPreset.UltraFast));

            Console.WriteLine("\n\nВидео загружено!\n\n\n");
        }
    }
}
