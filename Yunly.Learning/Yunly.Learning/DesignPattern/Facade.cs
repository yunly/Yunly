using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern
{
    public class Facade
    {
        public static void runTest()
        {
            var tv = new SonyTV { name = "Sony TV" };
            var outlet = new TwoHoleOutlet { name = "Two hole outlet #1" };

            var plugWire = new PlugWire(tv, outlet);

            plugWire.playTV();

        }

    }

    public class PlugWire
    {
        SonyTV tv;
        TwoHoleOutlet outlet;

        public PlugWire(SonyTV app, TwoHoleOutlet outlet)
        {
            tv = app;
            this.outlet = outlet;
        }

        public void playTV()
        {
            var home = new Home();

            outlet.PowerSwitch(home, true);

            tv.connect(outlet);

            tv.play();            
        }

    }
}
