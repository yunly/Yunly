using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Singleton
{
    /// <summary>
    /// attempted thread-safety using double-check locking
    /// </summary>
    public sealed class TestClass3
    {
        private static TestClass3 Instance = null;
        private static readonly object locker = new object();

        private TestClass3() { }

        public static TestClass3 GetInstance()
        {
            if (Instance == null)
            {
                lock (locker)
                {
                    if (Instance == null)
                        Instance = new TestClass3();
                }
            }
            return Instance;
        }
    }
}
