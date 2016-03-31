using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.MailSenderOnTimer
{
    public class TimerEventArgs: EventArgs
    {
        public string Message { get; private set; }

        public TimerEventArgs(string message)
        {
            Message = message;
        }

    }
}
