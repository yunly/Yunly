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
            if (num < 1 || num >= 4000) return "";

            var dict = new Dictionary<int, string>();
            dict.Add(0, "");
            dict.Add(1, "I");
            dict.Add(2, "II");
            dict.Add(3, "III");
            dict.Add(4, "IV");
            dict.Add(5, "V");
            dict.Add(6, "VI");
            dict.Add(7, "VII");
            dict.Add(8, "VIII");
            dict.Add(9, "IX");
            dict.Add(10,"X");
            dict.Add(20, "XX");
            dict.Add(30, "XXX");
            dict.Add(40, "XL");
            dict.Add(50,"L");
            dict.Add(60, "LX");
            dict.Add(70, "LXX");
            dict.Add(80, "LXXX");
            dict.Add(90, "XC");
            dict.Add(100,"C");
            dict.Add(200, "CC");
            dict.Add(300, "CCC");
            dict.Add(400, "CD");
            dict.Add(500,"D");
            dict.Add(600, "DC");
            dict.Add(700, "DCC");
            dict.Add(800, "DCCC");
            dict.Add(900, "CM");
            dict.Add(1000, "M");
            dict.Add(2000, "MM");
            dict.Add(3000, "MMM");

           
            return dict[num / 1000 * 1000] + dict[num % 1000 / 100 * 100] + dict[num % 100 / 10 * 10] + dict[num % 10];

            /*
            int digit = 0;

            string Roman = "";

            int carry = 1;
            while (num > 0)
            {
                carry *= 10;
                digit = num % 10;
                num /= 10;
                //if (digit == 0) continue;
                Roman = dict[digit * carry / 10] + Roman;
            }

            return Roman;
            */
        }

        /// <summary>
        /// 13. Roman to Integer
        /// https://leetcode.com/problems/roman-to-integer/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int RomanToInt(string s)
        {
            int sum = 0;
            var dict = new Dictionary<char, int>();
            dict.Add('I', 1);
            dict.Add('V', 5);
            dict.Add('X', 10);
            dict.Add('L', 50);
            dict.Add('C', 100);
            dict.Add('D', 500);
            dict.Add('M', 1000);

            char p = 'I';
            for (var i = s.Length - 1; i >= 0; i--)
            {
                sum += dict[s[i]] < dict[p] ? -dict[s[i]] : dict[s[i]];

                p = s[i];
            }
            return sum;


            /*
            int sum = 0;
            var dict = new Dictionary<char, int>();
            dict.Add('I', 1);
            dict.Add('V', 5);
            dict.Add('X', 10);
            dict.Add('L', 50);
            dict.Add('C', 100);
            dict.Add('D', 500);
            dict.Add('M', 1000);


            var dict2 = new Dictionary<string, int>();
            dict2.Add("IV", -2);
            dict2.Add("IX", -2);
            dict2.Add("XL", -20);
            dict2.Add("XC", -20);
            dict2.Add("CD", -200);
            dict2.Add("CM", -200);

            foreach (var item in dict2)
            {
                if (s.Contains(item.Key))
                    sum -= item.Value;
            }


            foreach(var digit in s)
            {
                sum += dict[digit];
            }
            

            return sum;
            */

            /*
            var dict = new Dictionary<char, int>();
            dict.Add('I', 1);
            dict.Add('V', 5);
            dict.Add('X', 10);
            dict.Add('L', 50);
            dict.Add('C', 100);
            dict.Add('D', 500);
            dict.Add('M', 1000);

            var sum = dict[s.Last()];
            for (var i = s.Length - 2; i >= 0; i--)
            {
                if (dict[s[i]] < dict[s[i + 1]])
                    sum -= dict[s[i]];
                else
                    sum += dict[s[i]];
            }

            return sum;
            */
            /*

            var dict = new Dictionary<string, int>();
            dict.Add("I", 1);
            dict.Add("II", 2);
            dict.Add("III", 3);
            dict.Add("IV", 4);
            dict.Add("V", 5);
            dict.Add("VI", 6);
            dict.Add("VII", 7);
            dict.Add("VIII", 8);
            dict.Add("IX", 9);
            dict.Add("X", 10);
            dict.Add("XX", 20);
            dict.Add("XXX", 30);
            dict.Add("XL", 40);
            dict.Add("L", 50);
            dict.Add("LX", 60);
            dict.Add("LXX", 70);
            dict.Add("LXXX", 80);
            dict.Add("XC", 90);
            dict.Add("C", 100);
            dict.Add("CC", 200);
            dict.Add("CCC", 300);
            dict.Add("CD", 400);
            dict.Add("D", 500);
            dict.Add("DC", 600);
            dict.Add("DCC", 700);
            dict.Add("DCCC", 800);
            dict.Add("CM", 900);
            dict.Add("M", 1000);
            dict.Add("MM", 2000);
            dict.Add("MMM", 3000);

            if (dict.ContainsKey(s)) return dict[s];

            int sum = 0;

            while (s.Length > 0)
            {
                int len = Math.Min(4, s.Length);

                while (len> 0)
                {
                    if (dict.ContainsKey(s.Substring(0, len)))
                    {
                        sum += dict[s.Substring(0, len)];
                        s = s.Substring(len);
                        break;
                    }

                    len--;
                }                
            }

            return sum;
            */
        }

        /// <summary>
        /// 14. Longest Common Prefix
        /// https://leetcode.com/problems/longest-common-prefix/
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0) return "";
            return strs.Aggregate((current, next) => current = LongestCommonPrefix(current, next));
        }

        public string LongestCommonPrefix(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
                return "";

            if (str1 == str2) return str1;

            
            

            var len = 0;
            while (len < str1.Length && len < str2.Length)
            {
                if (str2.StartsWith(str1.Substring(0, ++len)))
                    continue;
                len--;
                break;
            }

            return str2.Substring(0, len);
        }

        /// <summary>
        /// 15. 3Sum
        /// https://leetcode.com/problems/3sum/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums == null || nums.Length < 3)
                return new List<IList<int>> { };

            
            var zeros = nums.Where(n => n == 0);
            ///all zero array
            if (zeros.Count() == nums.Length) return new List<IList<int>> { new List<int> { 0, 0, 0 } };

            var positives = nums.Where(n => n > 0).OrderBy(n => n);
            var minus = nums.Where(n => n < 0).OrderByDescending(n => n);
            IEnumerable<IList<int>> result = null;

            // -N,0,N
            if (zeros.Count() > 0)
            {
                result = positives.Distinct().Where(p => minus.Contains(-p))
                    .Select(n => new List<int> { -n, 0, n });

                if (zeros.Count() >= 3)
                    result = result.Union(new List<IList<int>> { new List<int> { 0, 0, 0 } });
            }

            //-2N,N,N
            var result1 = positives.GroupBy(key => key, n => n, (d, items) => new { Num = d, Count = items.Count() })
               .Where(p => p.Count > 1 && minus.Contains(p.Num * -2)).Select(p => new List<int> { p.Num * -2, p.Num, p.Num });

            result = result == null ? result1 : result.Union(result1);

            //-N,-N,2N
            result1 = minus.GroupBy(key => key, n => n, (d, items) => new { Num = d, Count = items.Count() })
               .Where(p => p.Count > 1 && positives.Contains(p.Num * -2)).Select(p => new List<int> {p.Num, p.Num, p.Num * -2});

            result = result == null ? result1 : result.Union(result1);


            //-X,-Y,Z
            result1 = from p1 in minus
                      from p2 in minus
                      from sum in positives
                      where p1 != p2 && sum == -p1 - p2
                      select new List<int> { Math.Min(p1, p2), Math.Max(p1, p2), sum };
            result = result == null ? result1 : result.Union(result1);

            //-X,Y,Z
            result1 = from p1 in positives
                      from p2 in positives
                      from sum in minus
                      where p1 != p2 && sum == -p1 - p2
                      select new List<int> { sum, Math.Min(p1, p2), Math.Max(p1, p2), };
            result = result == null ? result1 : result.Union(result1);


            return result.OrderBy(a => a, new ListComparer())
                .Distinct(new ListEqualityComparer())
                .ToList();
        }


        class ListComparer : IComparer<IList<int>>
        {
            public int Compare(IList<int> x, IList<int> y)
            {
                for (var i = 0; i < x.Count; i++)
                {
                    if (x[i] == y[i]) continue;

                    if (x[i] > y[i]) return 1;
                    else return -1;
                    

                }
                return 0;
            }
        }

        class ListEqualityComparer : IEqualityComparer<IList<int>>
        {
            public bool Equals(IList<int> x, IList<int> y)
            {
                for (var i = 0; i < x.Count; i++)
                    if (x[i] != y[i]) return false;
                return true;
            }

            public int GetHashCode(IList<int> obj)
            {
                int hCode = 0;
                foreach (var n in obj)
                    hCode += n;
                return hCode;
            }
        }

        //0   1 2 3 4 5
        //-2 -1 0 1 2 3
        public IList<IList<int>> ThreeSum1(int[] nums)
        {
            var result = new List<IList<int>>();

            if (nums == null || nums.Length < 3) return result;

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                var left = i + 1;
                var right = nums.Length - 1;
                var sum = 0 - nums[i];
                while (left < right)
                {
                    if (nums[left] + nums[right] == sum)
                    {
                        result.Add(new int[] { nums[i], nums[left], nums[right] });
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;
                        left++; right--;
                    }
                    else if (nums[left] + nums[right] < sum)
                        left++;
                    else
                        right--;


                }
                
            }

            return result;
        }

        /// <summary>
        /// 16. 3Sum Closest
        /// https://leetcode.com/problems/3sum-closest/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ThreeSumClosest(int[] nums, int target)
        {
            if (nums == null || nums.Length < 3) return target;

            Array.Sort(nums);
            int result = nums[0] + nums[1] + nums[2];
            for (var i = 0; i < nums.Length - 2; i++)
            {
                int left = i + 1;
                int right = nums.Length - 1;
                int sum = target - nums[i];
                while (left < right)
                {
                    if (nums[left] + nums[right] == sum)
                        return target;
                    else
                    {
                        if (Math.Abs(result - target) > Math.Abs(nums[left] + nums[right] - sum))
                        {
                            result = nums[left] + nums[right] + nums[i];
                        }

                        if (nums[left] + nums[right] > sum) right--;
                        else left++;

                        
                    }                                    
                }
            }

            return result;
        }

        /// <summary>
        /// 17. Letter Combinations of a Phone Number
        /// https://leetcode.com/problems/letter-combinations-of-a-phone-number/
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public IList<string> LetterCombinations(string digits)
        {            
            var result = new List<string>();
            if (string.IsNullOrEmpty(digits)) return result;

            var mapping = new Dictionary<char, IList<string>>();

            mapping.Add('2', new List<string> { "a", "b", "c" });
            mapping.Add('3', new List<string> { "d", "e", "f" });
            mapping.Add('4', new List<string> { "g", "h", "i" });
            mapping.Add('5', new List<string> { "j", "k", "l" });
            mapping.Add('6', new List<string> { "m", "n", "o" });
            mapping.Add('7', new List<string> { "p", "q", "r", "s" });
            mapping.Add('8', new List<string> { "t", "u", "v" });
            mapping.Add('9', new List<string> { "w", "x", "y", "z" });


            result = digits.Select(ch => mapping[ch]).Aggregate(
                (finial, next) =>
                    (from s1 in finial
                    from s2 in next
                    select s1 + s2).ToList()

                    //var temp = new List<string>();
                    //foreach (var s1 in finial)
                    //    foreach (var s2 in next)
                    //        temp.Add(s1 + s2);
                    //return temp;
                
                ).ToList();


            return result;
        }

        /// <summary>
        /// 18. 4Sum
        /// https://leetcode.com/problems/4sum/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            var result = new List<IList<int>>();

            if (nums == null || nums.Length < 4) return result;

            Array.Sort(nums);

            for (int i = 0, j = nums.Length - 1; i < nums.Length - 1 && j >= 0; i++, j--)
            {
                var left = i + 1;
                var right = j - 1;

                while (left < right)
                {
                    if (nums[i] + nums[left] + nums[right] + nums[j] == target)
                    {
                        result.Add(new List<int> { nums[i], nums[left], nums[right], nums[j] });
                        while (nums[left + 1] == nums[left]) left++;
                        while (nums[right - 1] == nums[right]) right--;
                        left++; right--;
                    }
                    else if (nums[i] + nums[left] + nums[right] + nums[j] > target) right--;
                    else
                        left++;
                }
            }

            return result;
        }


    }
}


