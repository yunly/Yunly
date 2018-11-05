using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern
{
    public class SimpleFactory
    {
        public static void runTest()
        {

            string input = Console.ReadLine();

            while (input != "")
            {

                if (!int.TryParse(input, out int hour))
                    break;

                OneDay day = OneDayFactory.getDayTime(hour);

                if (day == null) Console.WriteLine("Invalid hour");
                else
                    day.message();



                input = Console.ReadLine();
            }
        }
    }

    public abstract class OneDay
    {
        public abstract void message();        
    }

    public class DayTime : OneDay
    {
        public override void message()
        {
            Console.WriteLine("It's time to work");
        }
    }

    public class NightTime : OneDay
    {
        public override void message()
        {
            Console.WriteLine("It's time to sleep");
        }
    }

    public class OneDayFactory
    {
        public static OneDay getDayTime(int hour)
        {
            if (hour < 0 || hour > 24) return null;

            if (hour > 7 && hour < 19) return new DayTime();

            return new NightTime();
        }
    }
}
