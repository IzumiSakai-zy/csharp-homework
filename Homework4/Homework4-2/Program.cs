using System;

namespace Homework4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = 3;
            int minute = 0;
            int second = 0;
            Form form = new Form();
            while (true)
            {
                System.Threading.Thread.Sleep(2000);
                form.clockEvent.TickOrAlarm(hour, minute, second);
                hour++;
            }
        }
    }
    public delegate void ClockHandler(Object seder,EventArgs args);
    public class EventArgs
    {
        public int hour { get; set; }
        public int minute { get; set; }
        public int second { get; set; }
    }
    public class ClockEvent
    {
        public event ClockHandler handler;
        public void TickOrAlarm(int hour,int minute,int second)
        {
            EventArgs args = new EventArgs { hour = hour, minute = minute, second = second };
            handler(this, args);
        }
    }
    public class Form
    {
        public ClockEvent clockEvent = new ClockEvent() ;
        public Form()
        {
            clockEvent.handler += tick;
            clockEvent.handler += alarm;
        }
        public void tick(Object sender,EventArgs args)
        {
            Console.WriteLine("滴答滴答");
        }
        public void alarm(Object sender,EventArgs args)
        {
            if (args.hour == 8 && args.minute == 0)
            {
                Console.Write("上早八啦，上早八啦       ");
                Console.WriteLine("闹铃响啦闹铃响啦");
            }
        }
    }
}
