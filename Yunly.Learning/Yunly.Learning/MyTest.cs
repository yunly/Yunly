using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning
{
    public static class MyTest
    {
        public static testValue testTryReturn(testValue value)
        {

            value.name = "Initial";
            try
            {
                value.name = "Try";
                return value;
            }
            catch (Exception ex)
            {
                value.name = "Catch";
                return value;
            }
            finally
            {
                value.name = "Finally";
            }
        }
    }

    public class testValue
    {
        public string name { get; set; }
    }
}
