using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.MailSenderOnTimer
{
    public static class SubscriberMary
    {
        public static string PrivateMail { get; private set; }

        public static void Subscribe(MailSender mailSender)
        {
            mailSender.TimerRing += ActWhenTimerRings;
        }

        public static void Unsubscribe(MailSender mailSender)
        {
            mailSender.TimerRing -= ActWhenTimerRings;
        }

        private static void ActWhenTimerRings(Object sender, TimerEventArgs eventArgs)
        {
            PrivateMail += "FOR MARY: " +eventArgs.Message;
        }
    }
}
