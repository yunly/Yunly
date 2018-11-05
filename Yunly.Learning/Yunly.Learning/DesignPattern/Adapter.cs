using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern
{
    public class Adapter
    {
        public static void runTest()
        {
            var home = new Home();

            var outlet1 = new TwoHoleOutlet { name = "Two hole outlet #1" };

            var sonyTV = new SonyTV { name = "Sony TV" };

            sonyTV.connect(outlet1);

            sonyTV.play();

            outlet1.PowerSwitch(home, true);

            sonyTV.play();

            outlet1.PowerSwitch(home, false);

            sonyTV.play();



            var lgTV = new LGTV { name = "LG TV" };

            


        }




        
    }
}
