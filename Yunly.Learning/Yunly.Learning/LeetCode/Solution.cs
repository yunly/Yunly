using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Yunly.Learning.LeetCode
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {

            //for (int i = 0; i < nums.Length; i++)
            //{                
            //    for (int j = i + 1; j < nums.Length; j++)
            //        if (nums[i] + nums[j] == target)
            //        {                        
            //            return new int[] { i, j };
            //        }
            //}

            //throw new InvalidCastException("No indices found");

            var temp = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                int current = target - nums[i];
                if (temp.ContainsKey(current))
                    return new int[] { temp[current], i };
                if (!temp.ContainsKey(nums[i])) temp.Add(nums[i], i);
            }

            throw new InvalidCastException("No indices found");
        }


        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var carryFlag = false;
            ListNode result = new ListNode(l1.val + l2.val);
            if (carryFlag)
            {
                result.val += 1;
                carryFlag = false;
            }

            if (result.val >= 10)
            {
                result.val -= 10;
                carryFlag = true;
            }

            ListNode now = result;


            l1 = l1.next;
            l2 = l2.next;

            while (l1 != null || l2 != null)
            {
                var v1 = l1 == null ? 0 : l1.val;
                var v2 = l2 == null ? 0 : l2.val;

                var current = new ListNode(v1 + v2);

                if (carryFlag)
                {
                    current.val += 1;
                    carryFlag = false;
                }

                if (current.val >= 10)
                {
                    current.val -= 10;
                    carryFlag = true;
                }

                now.next = current;
                now = now.next;

                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }


            if (carryFlag) now.next = new ListNode(1);

            return result;

        }


        public int LengthOfLongestSubstring(string s)
        {
            int result = 1;

            foreach (var ch in s.Distinct())
            {
                var max = s.Split(ch).Max(d => d.Length == d.Distinct().Count() ? d.Length : 0);

                result = result > max ? result : max;
            }

            return result + 1;






            //if (string.IsNullOrEmpty(s)) return 0;
            //if (s.Length == 1) return 1;
            //int max = 1;

            //var temp = new List<char>();
            //for (var i = 0; i < s.Length; i++)
            //{
            //    for (var j = i; j < s.Length; j++)
            //    {
            //        if (temp.Contains(s[j]))
            //        {
            //            max = max > temp.Count ? max : temp.Count;
            //            temp = new List<char>();
            //            break;
            //        }
            //        temp.Add(s[j]);
            //    }
            //}

            //max = max > temp.Count ? max : temp.Count;

            //return max;



        }


        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var result = nums1.Concat(nums2).OrderBy(p => p).ToList();

            if (result.Count() % 2 == 1) return (double)result[result.Count() / 2];
            else
                return ((double)(result[result.Count() / 2] + result[result.Count() / 2 - 1])) / 2.0d;
        }


        public string LongestPalindrome(string s)
        {
            string max = "";

            if (s.Length <= 1)
                return s;

            if (s.Length == 2)
            {
                if (s[0] == s[1]) return s;
                else return s.Substring(0, 1);
            }


            for (var i = 1; i < s.Length; i++)
            {
                int j = i, k = i;
                string substr = char.ToString(s[i]);
                while (--j >= 0 && ++k < s.Length)
                {
                    if (s[j] == s[k]) substr = char.ToString(s[j]) + substr + char.ToString(s[k]);
                    else
                    {
                        
                        break;
                    }
                }
                max = max.Length > substr.Length ? max : substr;

                j = i; k = i - 1; substr = "";
                while (--j >= 0 && ++k < s.Length)
                {
                    if (s[j] == s[k]) substr = char.ToString(s[j]) + substr + char.ToString(s[k]);
                    else
                    {
                        break;                        
                    }
                }
                max = max.Length > substr.Length ? max : substr;
            }
            return max;
        }

        /// <summary>
        /// https://leetcode.com/problems/zigzag-conversion/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public string Convert(string s, int numRows)
        {
            if (numRows == 1) return s;

            var array = new StringBuilder[numRows];
            for (var i = 0; i < array.Length; i++)
                array[i] = new StringBuilder();

            var downFlag = true;
            int currentRow = 0;
            foreach (char ch in s)
            {
                array[currentRow].Append(ch);

                if (currentRow == 0 || currentRow == array.Length - 1)
                    downFlag = !downFlag;

                currentRow += downFlag ? -1 : 1;
            }


            var result = "";

            foreach (var sb in array)
            {
                result += sb.ToString();
            }

            return result;












            /*

            if (string.IsNullOrEmpty(s) || s.Length == 1) return s;

            char[][] array = new char[numRows][];
            int columns = calculateSize(s.Length, numRows);


            for (var i = 0; i < numRows; i++)
            {
                array[i] = new char[columns];
            }

            var index = -1; ;
            int j = 0, k = 0;
            bool downFlag = true;
            while (index++ < s.Length-1)
            {
                array[j][k] = s[index];

                if (downFlag)
                {
                    if (j < array.Length - 1)
                        j++;
                    else
                    {
                        j--;
                        k++;
                        downFlag = false;
                    }
                }
                else
                {
                    if (j > 0)
                    {
                        j--; k++;
                    }
                    else
                    {
                        j++;
                        downFlag = true;
                    }
                }
            }

            var result = "";
            foreach (var row in array)
            {
                result += array2StringWithoutBlank(row);
            }

            return result;
            */
        }

        public int calculateSize(int total, int rows)
        {
            int columns = total / (rows * 2 - 2);

            int remain = total % (rows * 2 - 2);

            if (remain == 0) return columns * (rows - 1);

            if (remain <= rows) 
                return columns * (rows - 1) + 1;
            else
            {
                return columns * (rows - 1) + 1 + remain - rows;         
            }
        }

        public string array2StringWithoutBlank(char[] array)
        {
            return new string(array.Where(c=>c!='\0').ToArray());
        }




        public int Reverse(int x)
        {
            int result = 0;
            
            while (x != 0)
            {
                int pop = x % 10;
                x /= 10;

                if (result > int.MaxValue / 10) return 0;
                if (result < int.MinValue / 10) return 0;

                result = result * 10 + pop;
            }

            return result;
        }



        public int MyAtoi(string str)
        {
            string pattern = @"^\s*[-\+]?\d+";

            if (!Regex.IsMatch(str, pattern)) return 0;


            var match = Regex.Match(str, @"^\s*([-\+]?\d+)");

            var matched = match.Groups[1].Value;

            try
            {
                return int.Parse(matched);
            }
            catch(OverflowException)
            {
                return matched.StartsWith('-') ? int.MinValue : int.MaxValue;
                    
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/palindrome-number/
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;

            var reverse = 0;
            
            while (x > reverse)
            {
                reverse = reverse * 10 + x % 10;
                x /= 10;
            }

            return x == reverse || x == reverse / 10;
        }

        /// <summary>
        /// https://leetcode.com/problems/regular-expression-matching/
        /// </summary>
        /// <param name="s">could be empty and contains only lowercase letters a-z</param>
        /// <param name="p">could be empty and contains only lowercase letters a-z, and characters like . or *.</param>
        /// <returns></returns>
        public bool IsMatch(string s, string p)
        {

            if (Regex.IsMatch(p, @"^[a-z]$")) return s == p;
            return Regex.IsMatch(s, p);


            if (string.IsNullOrEmpty(p))
                return string.IsNullOrEmpty(p);

            bool first_match = (!string.IsNullOrEmpty(s) &&
                (p[0] == s[0] || p[0] == '.'));

            if (p.Length >= 2 && p[1] == '*')
            {
                return (IsMatch(s, p.Substring(2)) ||
                    (first_match && IsMatch(s.Substring(1), p)));
            }
            else
                return first_match && IsMatch(s.Substring(1), p.Substring(1));

        }

        /// <summary>
        /// 11. Container With Most Water
        /// https://leetcode.com/problems/container-with-most-water/
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea(int[] height)
        {
            //var dict = new Dictionary<int, int>();

            //for (var i = 0; i < height.Length; i++)
            //    dict.Add(i, height[i]);

            //var result = from f1 in dict from f2 in dict select Math.Abs(f1.Key - f2.Key) * Math.Min(f1.Value, f2.Value);

            //return result.Max();



            //var max = 0;
            //for (var i = 0; i < height.Length; i++)
            //    for (var j = i; j < height.Length; j++)
            //    {
            //        max = Math.Max(max, (j - i) * Math.Min(height[i], height[j]));
            //    }

            //return max;




            var max = 0;
            var i = 0;
            var j = height.Length - 1;

            while (i < j)
            {
                max = Math.Max(max, (j - i) * Math.Min(height[i], height[j]));

                if (height[i] < height[j])
                    i++;
                else
                    j--;
            }

            return max;
        }

        /// <summary>
        /// 12. Integer to Roman
        /// https://leetcode.com/problems/integer-to-roman/
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string IntToRoman(int num)
        {
            var dict = new Dictionary<int, char>();
            dict.Add(1, 'I');            
            dict.Add(5, 'V');
            dict.Add(10,'X');
            dict.Add(50,'L');
            dict.Add(100,'C');
            dict.Add(500,'D');
            dict.Add(1000, 'M');

            int digit = 0;
            while (num > 0)
            {
                digit = num % 5;
                num /= 5;
            }

            return "";
            
        }

    }
}
