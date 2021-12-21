using System;
using System.IO;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;

namespace Module18_task2_youtubeVideo
{
    class Program
    {
        static void Main(string[] args)
        {
            var sender = new Sender();
            var receiver = new Receiver();

            var commandOne = new CommandOne(receiver);

            sender.SetCommand(commandOne);

            Console.Write("Веедите ссылку на видео: ");
            string pathToVideo = Console.ReadLine();


            sender.Run(pathToVideo);

            Console.ReadKey();
        }
    }
}

