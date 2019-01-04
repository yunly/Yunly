using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Singleton
{
    /// <summary>
    /// simple thread-safety
    /// </summary>
    public sealed class TestClass2
    {
        private static TestClass2 Instance = null;
        private static readonly object locker = new object();

        private TestClass2() { }


        public static TestClass2 GetInstance()
        {
            lock (locker)
            {
                if (Instance == null)
                    Instance = new TestClass2();

                return Instance;
            }
        }
    }
}
