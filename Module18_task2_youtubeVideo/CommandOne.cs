using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module18_task2_youtubeVideo
{
    class CommandOne : ICommand
    {
        Receiver receiver;
        
        public CommandOne(Receiver receiver)
        {
            this.receiver = receiver;
        }
        public void Execute(string videoUrl)
        {
            receiver.GetVideoInfo(videoUrl);
            receiver.DownloadVideo(videoUrl);
        }


    }
}
