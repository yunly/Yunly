using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yunly.Learning.CodeWars
{
    public class Kata
    {

        /// <summary>
        /// Write a function lcs that accepts two strings and returns their longest common subsequence as a string. Performance matters.
        //
        //        Examples
        //        lcs( "abcdef", "abc" ) => "abc"
        //lcs( "abcdef", "acf" ) => "acf"
        //lcs( "132535365", "123456789" ) => "12356"
        //lcs( "abcdefghijklmnopq", "apcdefghijklmnobq" ) => "acdefghijklmnoq"
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string Lcs(string a, string b)
        {
            var subA = allSubString(a);
            var subB = allSubString(b);

            var result = subA.Where(s => subB.Contains(s));

            

            return result.Last();
        }

        public static List<string> allSubString(string s)
        {
            var subStrings = new List<string>();

            for (int len = 1; len <= s.Length;
                               len++)
            {
                // Pick ending point 
                for (int i = 0; i <= s.Length - len; i++)
                {
                    // Print characters 
                    // from current 
                    // starting point to 
                    // current ending 
                    // point.  
                    int j = i + len - 1;

                    var chs = new List<char>();
                    for (int k = i; k <= j; k++)
                        chs.Add(s[k]);

                    subStrings.Add(new string(chs.ToArray()));
                }
            }

            return subStrings;
        }
      


        /// <summary>
        /// "56 65 74 100 99 68 86 180 90" ordered by numbers weights becomes: "100 180 90 56 65 74 68 86 99"
        /// </summary>
        /// <param name="strng"></param>
        /// <returns></returns>
        public static string orderWeight(string strng)
        {
            //user iComparer
            return string.Join(' ', (strng.Split(' ').OrderBy(s => s, new StringComparier()).ToArray()));


            return string.Join(' ', strng.Split(' ').OrderBy(n => n.ToCharArray().Select(c => (int)char.GetNumericValue(c)).Sum()).ThenBy(n => n));                                  

            return string.Join(' ', strng.Split(' ').OrderBy(s => s.ToCharArray().Sum(c => char.GetNumericValue(c))).ThenBy(s => s));
        }
        class StringComparier : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                if (x.Equals(y)) return 0;

                var intX = x.Sum(c => char.GetNumericValue(c));
                var intY = y.Sum(c => char.GetNumericValue(c));

                if (intX == intY)
                    for (int i = 0; i < (x.Length > y.Length ? y.Length : x.Length); i++)
                    {
                        if (x[i] > y[i])
                            return 1;
                        if (x[i] < y[i])
                            return -1;
                    }

                return intX > intY ? 1 :- 1;
            }
        }

        
    }
}

