using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern
{
    public class Factory
    {
        public static void runTest()
        {
            var logs = new List<LogFactory> { new FileLogFactory(), new DatabaseLogFactory() };

            foreach (var log in logs)
            {
                log.createLog().writeLog();
            }
                
        }
    }

    public abstract class Log
    {
        public abstract void writeLog();
    }

    public class FileLog : Log
    {
        public override void writeLog()
        {
            Console.WriteLine("Write log to file.");
        }
    }

    public class DatabaseLog : Log
    {
        public override void writeLog()
        {
            Console.WriteLine("Write log to database.");
        }
    }

    public abstract class LogFactory
    {
        public abstract Log createLog();       
    }

    public class FileLogFactory : LogFactory
    {
        public override Log createLog()
        {
            return new FileLog();
        }
    }

    public class DatabaseLogFactory : LogFactory
    {
        public override Log createLog()
        {
            return new DatabaseLog();
        }
    }


}
