using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Singleton
{
    public sealed class TestClass4
    {
        public static TestClass4 instance = new TestClass4();

        static TestClass4() { }
        private TestClass4() { }

        public static TestClass4 GetInstance()
        {
            return instance;
        }
    }
}
