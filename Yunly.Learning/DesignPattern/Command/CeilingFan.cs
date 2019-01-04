using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Command
{
    public class CeilingFan
    {

        public FanSpeed speed { get; private set; } = FanSpeed.OFF;
        public string Name { get; set; }

        public void High() => speed = FanSpeed.HIGH;
        public void Medium() => speed = FanSpeed.MEDIUM;
        public void Low() => speed = FanSpeed.LOW;
        public void Off() => speed = FanSpeed.OFF;

        public override string ToString()
        {
            return $"{Name} run at {speed}";
        }

    }

    public enum FanSpeed
    {
        OFF = 0,
        LOW,
        MEDIUM,
        HIGH
    }
}
