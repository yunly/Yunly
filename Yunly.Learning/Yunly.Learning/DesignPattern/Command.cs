using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Command
{
    public interface iCommand
    {
        void execute();
    }

    public class Switch
    {
        private readonly iCommand closeCommand;
        private readonly iCommand changeCommand;
        private readonly iCommand openCommand;

        public Switch(iCommand open, iCommand close, iCommand change)
        {
            this.closeCommand = close;
            this.changeCommand = change;
            this.openCommand = open;
        }

        public void Close()
        {
            closeCommand.execute();
        }

        public void Open()
        {
            openCommand.execute();
        }

        public void Change()
        {
            changeCommand.execute();
        }
    }


    public interface ISwitchable
    {
        void PowerOn();
        void PowerOff();
    }

    public class Light : ISwitchable
    {
        

        public void PowerOff()
        {
            Console.WriteLine("Power Off.");
        }

        public void PowerOn()
        {
            Console.WriteLine("Power On.");
        }
    }

    public class CloseSwitchCommaond : iCommand
    {
        private ISwitchable switchable;

        public CloseSwitchCommaond(ISwitchable s) => switchable = s;
        

        public void execute()
        {
            switchable.PowerOff();
        }
    }

    public class OpenSwitchCommand : iCommand
    {
        private ISwitchable switchable;

        public OpenSwitchCommand(ISwitchable s) => switchable = s;
        public void execute()
        {
            switchable.PowerOn();
        }
    }


}
