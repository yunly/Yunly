using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.Syntex
{
    public class MyException
    {
        public void runTest1()
        {
            try
            {
                throw new Exception("try 1");
            }
            catch(Exception ex)
            {
                throw ex;
            }

            try
            {
                throw new Exception("try 2");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Catch block 2");
                Console.WriteLine(ex.Message);
            }
        }


        public void runTest2()
        {
            try
            {
                try
                {
                    throw new Exception("try nested 1");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("catch 1");
                Console.WriteLine(ex.Message);

            }


            try
            {
                throw new Exception("try 2");
            }
            catch (Exception ex)
            {
                Console.WriteLine("catch 2");
                Console.WriteLine(ex.Message);
            }
        }



    }
}
