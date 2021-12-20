using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;

namespace Module18_task2_youtubeVideo
{
    class DownloadVideo : ICommand
    {

        public async Task ExecuteAsync(string videoUrl)
        {
            string pathToFolder = @"C:\Users\stolb\Desktop\videos";
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
