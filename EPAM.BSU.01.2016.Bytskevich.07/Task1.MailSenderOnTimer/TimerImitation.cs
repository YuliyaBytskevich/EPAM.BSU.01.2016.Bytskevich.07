using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Task1.MailSenderOnTimer
{
    public class TimerImitation
    {
        private int delay = 1;
        private readonly MailSender mailSender;    

        public TimerImitation(MailSender sender)
        {
            mailSender = sender;
        }

        public void Run()
        {
            Thread.Sleep(delay * 1000);
            mailSender.ActAsTimerRings("New message on " + DateTime.Now.ToLongTimeString() + " >>> " + delay + " seconds passed, no more info\n");
        }

        public void SetDelay(int timerDelayInSeconds)
        {
            delay = timerDelayInSeconds;
        }
    }
}
