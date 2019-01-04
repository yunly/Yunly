using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Singleton
{
    /// <summary>
    /// not thread-safe
    /// </summary>
    public sealed class TestClass1
    {
        private static TestClass1 Instance = null;

    
        private TestClass1() {}

        public static TestClass1 GetInstance()
        {
            if (Instance == null)
                Instance = new TestClass1();

            return Instance;
        }
    }
}
