using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern
{
    public class AbstractFactory
    {
        public static void runTest()
        {
            TelecomCompany zhejiang = new ZhejiangCompany();
            TelecomCompany beijing = new BeijingCompany();

            Console.WriteLine(zhejiang.internet());
            Console.WriteLine(zhejiang.wireless());

            Console.WriteLine(beijing.internet());
            Console.WriteLine(beijing.wireless());

        }
    }


    public abstract class TelecomCompany
    {
        public abstract Internet internet();
        public abstract Wireless wireless();

    }

    public abstract class Product
    {

    }

    public abstract class Internet
    {

    }

    public abstract class Wireless
    {

    }

    public class BeijingInternet: Internet
    {
        public override string ToString()
        {
            return "Beijing Internet";
        }
    }

    public class BeijingWireless:Wireless
    {
        public override string ToString()
        {
            return "Beijing Wireless";
        }
    }


    public class ZhejiangInternet:Internet
    {
        public override string ToString()
        {
            return "Zhejiang Internet";
        }
    }

    public class ZhejiangWireless:Wireless
    {
        public override string ToString()
        {
            return "Zhejiang Wireless";
        }
    }


    public class ZhejiangCompany : TelecomCompany
    {
        public override Internet internet()
        {
            return new ZhejiangInternet();
        }

        public override Wireless wireless()
        {
            return new ZhejiangWireless();
        }
    }

    public class BeijingCompany : TelecomCompany
    {
        public override Internet internet()
        {
            return new BeijingInternet();
        }

        public override Wireless wireless()
        {
            return new BeijingWireless();
        }
    }










}
