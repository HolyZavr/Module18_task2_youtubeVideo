using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module18_task2_youtubeVideo
{
    interface ICommand
    {
        public abstract void Execute(string videoUrl);
    }
}
