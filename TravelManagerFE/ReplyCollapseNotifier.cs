using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelManagerFE
{
    public class ReplyCollapseNotifier
    {
        // Can be called from anywhere
        public async Task Update()
        {
            if (Notify != null)
            {
                await Notify.Invoke("",1);
            }
        }

        public event Func<string, int, Task> Notify;
    }
}
