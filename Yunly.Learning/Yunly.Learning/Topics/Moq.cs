﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.Topics.MoqLearning
{
    public interface IFoo
    {
        Bar Bar { get; set; }
        string Name { get; set; }
        int Value { get; set; }
        bool DoSomething(string value);
        bool DoSomething(int number, string value);
        string DoSomethingStringy(string value);
        bool TryParse(string value, out string outputValue);
        bool Submit(ref Bar bar);
        int GetCount();
        bool Add(int value);
    }

    public class Bar
    {
        public virtual Baz Baz { get; set; }
        public virtual bool Submit() { return false; }
    }

    public class Baz
    {
        public virtual string Name { get; set; }
    }

    public class App
    {
        IFoo foo;

        public App(IFoo f) => foo = f;

        public bool ping(string ip) => foo.DoSomething(ip);

        public string getString(string ip) => foo.DoSomethingStringy(ip);
    }
}
