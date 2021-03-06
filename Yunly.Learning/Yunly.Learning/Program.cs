﻿#define DEBUG


using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;


using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System;
using Yunly.Learning.LeetCode;
using System.Collections.Generic;

using Yunly.Learning.DesignPattern.Strategy;
using System.Collections;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace Yunly.Learning
{


    class Sort
    {
        private readonly int[] array;

        private int runTimes = 0;
        private int swapTime = 0;
        public Sort(int[] array)
        {
            this.array = array;
        }



        public int[] SortedArray { get; private set; }
        public int RunTimes => runTimes;
        public int SwapTime => swapTime;
        public void FastSort()
        {
            runTimes = 0;
            swapTime = 0;
            var need = new int[array.Length];

            array.CopyTo(need, 0);

            fastSort(need, 0, array.Length - 1);
            SortedArray = need;
        }


        

        private void fastSort(int[] array, int left, int right)
        {
            
            if (left < right)
            {
                int middle = array[(left + right) / 2];
                int i = left-1;
                int j = right+1;

                while (true)
                {

                    while (array[++i] < middle) { runTimes++; }
                    while (array[--j] > middle) { runTimes++; }

                    runTimes++;
                    if (i >= j) break;

                    swapTime++;
                    (array[i], array[j]) = (array[j], array[i]);
                    
                }

                fastSort(array, left, i - 1);
                fastSort(array, j + 1, right);

                //  Parallel.Invoke(()=> fastSort(array, left, i - 1), ()=> fastSort(array, j + 1, right));


            }
        }

        public void BubbleSort()
        {
            runTimes = 0;
            swapTime = 0;
            var need = new int[array.Length];

            array.CopyTo(need, 0);

            for (var i = 1; i < need.Length; i++)
                for (var j = 0; j < need.Length -1 -i; j++) {
                    runTimes++;
                    if (need[i] < need[j])
                    {
                        swapTime++;
                        (need[i], need[j]) = (need[j], need[i]);
                    }
                }

            SortedArray = need;
        }

        public void MySort()
        {
            runTimes = 0;
            swapTime = 0;
            var need = new int[array.Length];

            array.CopyTo(need, 0);


            int left = 0;
            int right = need.Length - 1;

            int minPos = left;
            int maxPos = right;

            int min = need[left];
            int max = need[right];


            while (left < right)
            {
                for (var i = left; i <= right; i++)
                {
                    runTimes++;
                    if (min > need[i]) { minPos = i; min = need[minPos]; }
                    if (max < need[i]) { maxPos = i; max = need[maxPos]; }
                }

                swapTime++;
                (need[left], need[minPos]) = (need[minPos], need[left]);
                (need[right], need[maxPos]) = (need[maxPos], need[right]);

                left++;right--;
            }



            SortedArray = need;
        }

        public static int plus(int a, int b)
        {
            Contract.Requires(a > 0 && b > 0);

            return a + b;
        }
    }

    class Program
    {



        static void printArray(char[][] array)
        {
            foreach (var line in array)
                Console.WriteLine(string.Join(' ', line));

            Console.WriteLine();
        }
                   
        static void Main(string[] args)
        {

            var i = '9';
            var j = '8';

            Console.WriteLine(i -0x30+ j-0x30);

            Console.WriteLine(DateTime.Now);
            Console.ReadKey();
        }


      
        static void Greeting(string name, Action<string> localGreet) => localGreet(name);

             
        static void EnglishGreating(string name) => Console.WriteLine($"Morning, {name}");
        static void FrenchGreating(string name) => Console.WriteLine($"Bonjour, {name}");

    }

  
}




