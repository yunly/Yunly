using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern
{
    public class Home
    {
        
    }

    public abstract class Outlet
    {
        public string name { get; set; }
        public bool hasPower { get; protected set; }

        public const int capacity = 1;

        protected void switchOff()
        {
            Console.WriteLine($"{name} has been turned off.");
            hasPower = false;
        }

        protected void switchOn()
        {
            Console.WriteLine($"{name} has been turned on.");
            hasPower = true;
        }

        public abstract void PowerSwitch(Home home, bool switche);
    }

    public sealed class TwoHoleOutlet : Outlet
    {
        public override void PowerSwitch(Home home, bool switcher)
        {
            if (switcher) switchOn();
            else switchOff();
        }

        public void accept(ITwoHoleable connection)
        {

        }
    }

    public sealed class ThreeHoleOutlet : Outlet
    {
        public override void PowerSwitch(Home home, bool switcher)
        {
            if (switcher) switchOn();
            else switchOff();
        }
    }


    public abstract class Appliance
    {
        public string name { get; set; }
        public abstract void play();
        protected bool hasPower {
            get
            {
                if (connectedOutlet == null || !connectedOutlet.hasPower) return false;
                return true;
            }
        }

        protected Outlet connectedOutlet = null;

    }


    public interface ITwoHoleable
    {
        void connect(TwoHoleOutlet outle);
    }


    public class SonyTV : Appliance, ITwoHoleable
    {
 
        public void connect(TwoHoleOutlet outlet)
        {
            Console.WriteLine($"{name} connected to {outlet.name}");
            connectedOutlet = outlet;
        }

        public override void play()
        {
            if (hasPower)
                Console.WriteLine($"{name} start to play TV.");
            else
                Console.WriteLine($"{ name} has no power.");
        }
    }



    /////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////
    ///new appliance with three hole standant interface
    ///


    public interface IThreeHoleable
    {
        void connectThree(ThreeHoleOutlet outlet);
    }

    public class LGTV : Appliance, IThreeHoleable
    {
         public void connectThree(ThreeHoleOutlet outlet)
        {
            Console.WriteLine($"{name} connected to {outlet.name}");
            connectedOutlet = outlet;
        }

        public override void play()
        {
            if (hasPower)
                Console.WriteLine($"{name} start to play TV.");
            else
                Console.WriteLine($"{ name} has no power.");
        }
    }


}
