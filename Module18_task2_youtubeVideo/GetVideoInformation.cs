using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;

namespace Module18_task2_youtubeVideo
{
    class GetVideoInformation : ICommand
    {
        public async Task ExecuteAsync(string videoUrl)
        {
            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(videoUrl);

            Console.WriteLine($"\nИнформация о видео: ");
            Console.WriteLine($"\nНазвание: '{video.Title}' || Автор: {video.Author.Title} || Продолжительность: {video.Duration}");
            Console.WriteLine($"\nОписание: {video.Description}");
        }
    }
}
