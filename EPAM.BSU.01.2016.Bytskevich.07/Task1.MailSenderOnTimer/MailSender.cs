using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.MailSenderOnTimer
{
    public class MailSender
    {
        public event EventHandler<TimerEventArgs> TimerRing = delegate {};

        protected virtual void OnTimerTick(object sender, TimerEventArgs e)
        {
            TimerRing(sender, e);
        }

        public void ActAsTimerRings(string message)
        {
            OnTimerTick(this, new TimerEventArgs(message));
        }

    }
}
