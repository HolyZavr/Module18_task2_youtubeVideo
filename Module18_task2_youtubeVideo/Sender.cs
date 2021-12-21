using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module18_task2_youtubeVideo
{
    class Sender
    {
        ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void Run(string videoUrl)
        {
            command.Execute(videoUrl);
        }

    }
}
