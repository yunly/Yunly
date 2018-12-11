using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Singleton
{
    public class MyLove
    {

        public static MyLove love;
        public string lover;
        private MyLove()
        {
        
        }   

        public static MyLove marry(string name)
        {
              
            if (love == null) love = new MyLove();

            love.lover = name;
            return love;
        }
    }
}
