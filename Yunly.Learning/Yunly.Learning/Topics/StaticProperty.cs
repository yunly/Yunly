using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.Topics
{
    public class StaticProperty
    {
        public static string baseProperty = "Hello, I'm base Property.";

        public static string testProperty = "Hello, I'm test Property in base Class.";
    }

    public class InheritClass : StaticProperty
    {
        public static string InheritProperty = "Hello, I'm Inherity Property.";
        public static string testProperty = "Hello, I'm test Property in Inherity Class.";

        public static string testPropertyNew = StaticProperty.testProperty;
    }
}
