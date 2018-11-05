using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yunly.Learning.DesignPattern
{
    public class Singleton
    {
        private static readonly object objLock = new object();
        

        public static void runTest()
        {
            List<string> women = new List<string> { "w1", "w2", "w3", "w4" };
            Dictionary<string, int> mywifes = new Dictionary<string, int>();

            int looptime = 100;

            while (looptime-- > 0)
                foreach (var woman in women)
                {
                    Console.WriteLine("Marry with {0} at {1}", woman, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                    Task.Factory.StartNew(() => 
                    {
                        var wife = Wife.marry(woman);
                        lock (objLock)
                        {
                            if (mywifes.ContainsKey(wife.name))
                                mywifes[wife.name]++;
                            else
                                mywifes.Add(wife.name, 1);

                        }
                    }
                    );
                }


            Task.Delay(1000);

            if (mywifes.Count == 0)
                Console.WriteLine("No wife.");
            else
                foreach (var wife in mywifes)
                    Console.WriteLine($"{wife.Key}, marry times:{wife.Value}");
        }


    }



    public class Wife
    {
        public string name { get; private set; }

        private static Wife instance = null;

        private static object locker = new object();

        private Wife(string name)
        {
            this.name = name;
        }

        public static Wife marry(string name)
        {
            //    Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            if (instance == null)
                lock (locker)
                {
                    Console.WriteLine("Marry with {0}", name);
                    instance = instance ?? new Wife(name);
                }

            //lock (locker)
            //{
            //    instance = instance ?? new Wife(name);
            //}

            return instance;
        }
        
    }
}
