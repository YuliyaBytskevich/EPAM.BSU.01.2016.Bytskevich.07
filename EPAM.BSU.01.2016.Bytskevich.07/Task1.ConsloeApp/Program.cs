using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Task1.MailSenderOnTimer;

namespace Task1.ConsloeApp
{
    class Program
    {
        static void Main(string[] args)
        {           
            MailSender sender = new MailSender();
            TimerImitation timer = new TimerImitation(sender);
            string command;
            string currentArg = "";
            while (true)
            {
                if (currentArg == "")
                    Console.Write(Environment.UserName + "> ");
                else
                    Console.Write(Environment.UserName + "> " + currentArg + "> ");
                command = Console.ReadLine();
                switch (command)
                {
                    case ("subs"): case ("subs -all"): case ("show subs"): case ("subsribers"):
                        Console.WriteLine("mary\njohn");
                        break;
                    case ("enter as mary"): case ("as mary"): case ("subs -mary"):
                        currentArg = "mary";
                        break;
                    case ("enter as john"): case ("as john"): case ("subs -john"):
                        currentArg = "john";
                        break;
                    case ("subscribe"): case ("enable"):
                        {
                            if (currentArg == "mary")
                            {
                                SubscriberMary.Subscribe(sender);
                                Console.WriteLine("mary subscribed to mail sender");
                            }
                            else if (currentArg == "john")
                            {
                                SubscriberJohn.Subscribe(sender);
                                Console.WriteLine("john subscribed to mail sender");
                            }
                            else
                                Console.WriteLine("unknown command");
                        }
                        break;
                    case ("unsubscribe"): case ("disable"):
                        {
                            if (currentArg == "mary")
                            {
                                SubscriberMary.Unsubscribe(sender);
                                Console.WriteLine("mary unsubscribed mail sender");
                            }
                            else if (currentArg == "john")
                            {
                                SubscriberJohn.Unsubscribe(sender);
                                Console.WriteLine("john unsubscribed mail sender");
                            }
                            else
                                Console.WriteLine("unknown command");
                        }
                        break;
                    case ("show mail"): case ("mail"):
                        {
                            if (currentArg == "mary")
                                Console.Write(SubscriberMary.PrivateMail ?? "Mailbox is empty\n");
                            else if (currentArg == "john")
                                Console.Write(SubscriberJohn.PrivateMail ?? "Mailbox is empty\n");
                            else
                                Console.WriteLine("unknown command");
                        }
                        break;
                    case ("timer"):
                        currentArg = "timer";
                        break;
                    case ("delay"): case ("config delay"): case ("set delay"): case ("set"):
                        {
                            if (currentArg == "timer")
                            {
                                Console.WriteLine("setting delay (in seconds): ");
                                int delay;
                                if (Int32.TryParse(Console.ReadLine(), out delay))
                                    timer.SetDelay(delay);
                                else
                                    Console.WriteLine("invalid value for delay");
                            }
                            else
                                Console.WriteLine("unknown command");
                        }
                        break;
                    case ("run"):
                        {
                            if (currentArg == "timer")
                            {
                                timer.Run();
                                Console.WriteLine("timer rang at " + DateTime.Now.ToLongTimeString());
                            }
                            else
                                Console.WriteLine("unknown command");
                        }
                        break;
                    case ("exit"):
                        {
                            if (currentArg == "")
                                Environment.Exit(0);
                            currentArg = "";
                        }
                        break;
                    default:
                        Console.WriteLine("unknown command");
                        break;
                }
            }
        }
    }
}
