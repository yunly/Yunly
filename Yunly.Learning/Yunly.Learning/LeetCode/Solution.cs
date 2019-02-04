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
            return new string(array.Where(c => c != '\0').ToArray());
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
            catch (OverflowException)
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

            //if (Regex.IsMatch(p, @"^[a-z]$")) return s == p;
            //return Regex.IsMatch(s, p);


            if (p == "") return s == "";

            bool firstMatch = (s != "" &&
                (s[0] == p[0] || p[0] == '?'));

            if (p.Length >= 2 && p[1] == '*')
                return IsMatch(s, p.Substring(2)) || firstMatch && IsMatch(s.Substring(1), p);
            else
                return firstMatch && IsMatch(s.Substring(1), p.Substring(1));
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
            dict.Add(10, "X");
            dict.Add(20, "XX");
            dict.Add(30, "XXX");
            dict.Add(40, "XL");
            dict.Add(50, "L");
            dict.Add(60, "LX");
            dict.Add(70, "LXX");
            dict.Add(80, "LXXX");
            dict.Add(90, "XC");
            dict.Add(100, "C");
            dict.Add(200, "CC");
            dict.Add(300, "CCC");
            dict.Add(400, "CD");
            dict.Add(500, "D");
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
               .Where(p => p.Count > 1 && positives.Contains(p.Num * -2)).Select(p => new List<int> { p.Num, p.Num, p.Num * -2 });

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
        /// <example>        
        /// {-5,-2,1,1,3,5,5,5] 4 =>        {-5,1,3,5}
        ///         
        /// {-5,-3,-2,0,0,4,4,5} 4 =>{{-5,0,4,5},{-3,-2,4,5}}   
        /// </example>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            var result = new List<IList<int>>();

            if (nums == null || nums.Length < 4) return result;

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 1; i++)
                for (int j = nums.Length - 1; j > i; j--)
                {

                    if (j < nums.Length - 1 && nums[j] == nums[j + 1] ||
                        i > 0 && nums[i] == nums[i - 1]
                        ) continue;

                    var left = i + 1;
                    var right = j - 1;

                    while (left < right)
                    {
                        if (nums[i] + nums[left] + nums[right] + nums[j] == target)
                        {
                            result.Add(new List<int> { nums[i], nums[left], nums[right], nums[j] });
                            while (left < nums.Length - 1 && nums[left - 1] == nums[left]) left++;
                            while (right > 0 && nums[right + 1] == nums[right]) right--;

                            left++; right--;
                        }
                        else if (nums[i] + nums[left] + nums[right] + nums[j] > target) right--;
                        else
                            left++;
                    }
                }

            return result;
        }

        /// <summary>
        /// 19. Remove Nth Node From End of List
        /// https://leetcode.com/problems/remove-nth-node-from-end-of-list/
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {

            if (head == null) return null;

            int length = 1;
            ListNode current = head;
            ListNode last = head;
            while (current.next != null)
            {
                length++;
                last = current;
                current = current.next;
            }

            if (n > length) return null;
            if (n == length) return head.next;
            if (n == 1)
            {
                last.next = null;
                return head;
            }

            int position = 1;
            ListNode beforeDelete = null;
            ListNode afterDelete = null;
            current = head;
            while (current != null)
            {
                if (position == length - n)
                    beforeDelete = current;
                current = current.next;
                position++;
            }

            beforeDelete.next = beforeDelete.next.next;

            return head;

        }

        /// <summary>
        /// 20. Valid Parentheses
        /// https://leetcode.com/problems/valid-parentheses/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid(string s)
        {
            //if (s == null || s.Length == 1) return false;

            //var dict = new Dictionary<char, char>();
            //dict.Add(')', '(');
            //dict.Add(']', '[');
            //dict.Add('}', '{');

            //var stack = new Stack<char>();

            //foreach (var ch in s)
            //{
            //    if (stack.Count == 0)
            //    {
            //        stack.Push(ch);
            //        continue;
            //    }

            //    if (dict.ContainsKey(ch) && dict[ch] == stack.Peek())
            //        stack.Pop();
            //    else
            //        stack.Push(ch);
            //}

            //return stack.Count == 0;

            var stack = new Stack<char>();

            foreach (var ch in s)
            {
                switch (ch)
                {
                    case '(': stack.Push(')'); break;
                    case '[': stack.Push(']'); break;
                    case '{': stack.Push('}'); break;
                    default:
                        if (stack.Count() == 0 || stack.Pop() != ch)
                            return false;
                        break;
                }
            }

            return stack.Count() == 0;
        }


        /// <summary>
        /// 21. Merge Two Sorted Lists
        ///https://leetcode.com/problems/merge-two-sorted-lists/
        /// </summary>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;


            if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists(l1, l2.next);
                return l2;
            }











            var list = new List<int>();

            while (l1 != null)
            {
                list.Add(l1.val);
                l1 = l1.next;
            }

            while (l2 != null)
            {
                list.Add(l2.val);
                l2 = l2.next;
            }

            list.Sort();

            //while (l1 != null || l2 != null)
            //{
            //    if (l1 != null && l2 != null)
            //    {
            //        list.Add(Math.Min(l1.val, l2.val));
            //        list.Add(Math.Max(l1.val, l2.val));
            //    }
            //    else
            //        list.Add(l1 == null ? l2.val : l1.val);

            //    l1 = l1 == null ? null : l1.next;
            //    l2 = l2 == null ? null : l2.next;

            //}

            var result = new ListNode(list[0]);
            var current = result;
            for (var i = 1; i < list.Count; i++)
            {
                current.next = new ListNode(list[i]);
                current = current.next;
            }

            return result;
        }


        /// <summary>
        /// 22. Generate Parentheses
        /// https://leetcode.com/problems/generate-parentheses/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis(int n)
        {
            var Parenthesis = new List<string>();
            if (n < 1) return Parenthesis;
            Parenthesis.Add("()");

            while (--n > 0)
                Parenthesis = GenerateParenthesis(Parenthesis);

            return Parenthesis.Distinct().ToList();
        }

        private List<string> GenerateParenthesis(IList<string> parenthesis)
        {
            var result = new List<string>();
            foreach (var parenthese in parenthesis)
            {
                result.Add("(" + parenthese + ")");
                result.Add("()" + parenthese);
                result.Add(parenthese + "()");

                var temp = parenthese;
                int position = temp.IndexOf("()");
                while (position > 0)
                {
                    position = temp.Substring(position).IndexOf("()");
                    result.Add(temp.Insert(position + 1, "()"));

                    position = temp.Substring(position + 2).IndexOf("()");
                }
            }

            return result;
        }

        /// <summary>
        /// 23. Merge k Sorted Lists
        /// https://leetcode.com/problems/merge-k-sorted-lists/
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode MergeKLists(ListNode[] lists)
        {
            //if (lists == null || lists.Length == 0) return null;

            //var result = new List<int>();

            //foreach (var list in lists)
            //{
            //    var current = list;
            //    while (current != null)
            //    {
            //        result.Add(current.val);
            //        current = current.next;
            //    }
            //}

            //if (result.Count == 0) return null;

            //result.Sort();

            //var node = new ListNode(result[0]);
            //var head = node;
            //for (var i = 1; i < result.Count; i++)
            //{
            //    node.next = new ListNode(result[i]);
            //    node = node.next;
            //}

            //return head;


            var min = 0;
            while (min < lists.Length && lists[min] == null)
            {
                min++;
            }

            if (min >= lists.Length) return null;
            if (min == lists.Length - 1) return lists[min];

            for (var i = min + 1; i < lists.Length; i++)
            {
                if (lists[i] == null) continue;

                min = lists[min].val > lists[i].val ? i : min;
            }

            var result = lists[min];
            lists[min] = lists[min].next;

            result.next = MergeKLists(lists);
            return result;
        }

        /// <summary>
        /// 24. Swap Nodes in Pairs
        /// https://leetcode.com/problems/swap-nodes-in-pairs/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null) return null;

            if (head.next == null) return head;


            var temp = head.next;

            head.next = SwapPairs(temp.next);
            temp.next = head;

            return temp;
        }

        /// <summary>
        /// 25. Reverse Nodes in k-Group
        /// https://leetcode.com/problems/reverse-nodes-in-k-group/
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || head.next == null) return head;

            var stack = new Stack<ListNode>();

            var current = head;
            int position = k;
            while (position-- > 0)
            {
                if (current == null)
                    return head;

                stack.Push(current);

                current = current.next;
            }

            var temp = fromStack(stack);

            head.next = ReverseKGroup(current, k);
            //           temp.next = head;

            return temp;
        }

        private ListNode fromStack(Stack<ListNode> stack)
        {
            if (stack == null || stack.Count == 0) return null;

            var head = stack.Pop();
            var current = head;
            while (stack.Count > 0)
            {
                current.next = stack.Pop();
                current = current.next;
            }

            current.next = null;

            return head;
        }


        /// <summary>
        /// 26. Remove Duplicates from Sorted Array
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            if (nums.Length == 1) return 1;

            //nums = nums.Distinct().ToArray();
            //return nums.Length;


            var j = 1;
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[j - 1])
                {
                    nums[j++] = nums[i];
                }
            }


            return j;

        }


        /// <summary>
        /// 27. Remove Element
        /// https://leetcode.com/problems/remove-element/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public int RemoveElement(int[] nums, int val)
        {
            if (nums == null || nums.Length == 0) return 0;


            var j = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val) continue;

                nums[j++] = nums[i];
            }

            return j;

        }


        /// <summary>
        /// 28. Implement strStr()
        /// https://leetcode.com/problems/implement-strstr/
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr(string haystack, string needle)
        {
            //return haystack.IndexOf(needle);

            if (haystack == null || needle == null) return -1;
            if (haystack == "" && needle == "") return 0;

            if (haystack == "") return -1;

            if (needle == "") return 0;

            if (haystack == needle) return 0;

            for (var i = 0; i <= haystack.Length - needle.Length; i++)
            {
                if (haystack.Substring(i, needle.Length).Equals(needle))
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// 29. Divide Two Integers
        /// https://leetcode.com/problems/divide-two-integers/
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public int Divide(int dividend, int divisor)
        {
            if (dividend == 0) return 0;
            if (divisor == 0) throw new InvalidOperationException();

            if (dividend == int.MinValue && divisor == -1) return int.MaxValue;

            if (divisor == 2) return dividend >> 1;


            int quotient = 0;
            if (dividend > 0)
            {
                if (divisor > 0)
                {
                    dividend -= divisor;
                    while (dividend >= 0)
                    {
                        quotient++;
                        dividend -= divisor;
                    }
                    return quotient;
                }
                else
                {
                    quotient = 0;
                    dividend += divisor;
                    while (dividend >= 0)
                    {
                        quotient--;
                        dividend += divisor;
                    }
                    return quotient;
                }
            }
            else
            {
                if (divisor < 0)
                {
                    quotient = 0;
                    dividend -= divisor;
                    while (dividend <= 0)
                    {
                        quotient++;
                        dividend -= divisor;
                    }
                    return quotient;
                }
                else
                {
                    quotient = 0;
                    dividend += divisor;
                    while (dividend <= 0)
                    {
                        quotient--;
                        dividend += divisor;
                    }

                    return quotient;
                }
            }
        }


        /// <summary>
        /// 30. Substring with Concatenation of All Words
        /// https://leetcode.com/problems/substring-with-concatenation-of-all-words/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<int> FindSubstring(string s, string[] words)
        {
            var result = new List<int>();

            if (s == null || words == null || words.Length == 0 ||
                s.Length < words[0].Length * words.Length
                ) return result;


            var dict = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (dict.ContainsKey(word)) dict[word]++;
                else dict[word] = 1;
            }

            var wordLength = words[0].Length;
            var totalLength = words[0].Length * words.Length;


            for (var i = 0; i <= s.Length - totalLength; i++)
            {
                var target = new Dictionary<string, int>();
                for (var j = 0; j < words.Length; j++)
                {
                    var temp = s.Substring(i + j * wordLength, wordLength);
                    if (target.ContainsKey(temp)) target[temp]++;
                    else target[temp] = 1;
                }

                if (target.Count == dict.Count)
                {
                    Boolean isSame = true;
                    foreach (var item in target)
                    {
                        if (!dict.ContainsKey(item.Key) || (dict[item.Key] != item.Value))
                            isSame = false;
                    }

                    if (isSame) result.Add(i);
                }
            }



            return result;

            //var result = new List<int>();

            //if (s == null || words == null || words.Length == 0 ||
            //    s.Length < words[0].Length * words.Length
            //    ) return result;

            //var totalLength = words[0].Length * words.Length;

            //for (var i = 0; i <= s.Length - totalLength; i++)
            //{
            //    var temp = s.Substring(i, totalLength);

            //    foreach (var word in words)
            //    {
            //        for (var j = 0; j <= temp.Length - words[0].Length; j += words[0].Length)
            //        {
            //            if (temp.IndexOf(word, j) == j)
            //            {
            //                temp = temp.Remove(j, words[0].Length);
            //                break;
            //            }
            //        }
            //    }

            //    if (temp == "") result.Add(i);
            //}


            //return result;


        }


        /// <summary>
        /// 31. Next Permutation
        /// https://leetcode.com/problems/next-permutation/
        /// </summary>
        /// <param name="nums"></param>
        public void NextPermutation(int[] nums)
        {
            if (nums == null || nums.Length <= 1) return;

            var i = nums.Length - 2;
            while (i >= 0 && nums[i + 1] <= nums[i])
                i--;

            if (i >= 0)
            {
                var j = nums.Length - 1;

                while (j >= 0 && nums[j] <= nums[i]) j--;

                (nums[i], nums[j]) = (nums[j], nums[i]);
            }

            var m = i + 1;
            var n = nums.Length - 1;
            while (m < n)
            {
                (nums[m], nums[n]) = (nums[n], nums[m]);
                m++; n--;
            }
        }


        /// <summary>
        /// 32. Longest Valid Parentheses
        /// https://leetcode.com/problems/longest-valid-parentheses/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestValidParentheses(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            int max = 0;

            var stack = new Stack<int>();
            stack.Push(-1);

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    stack.Push(i);
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                        stack.Push(i);
                    else
                        max = Math.Max(max, i - stack.Peek());
                }
            }

            return max;
        }

        /// <summary>
        /// 33. Search in Rotated Sorted Array
        /// https://leetcode.com/problems/search-in-rotated-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return -1;

            //var left = 0;
            //var right = nums.Length - 1;
            //var index = 0;
            //while (left < right)
            //{
            //    var middle = (left + right) / 2;

            //    if (nums[middle] > nums[middle + 1])
            //    {
            //        index = middle + 1;
            //        break;
            //    }

            //    if (nums[middle] < nums[left])
            //        right = middle - 1;
            //    else
            //        left = middle + 1;                        
            //}





            if (target >= nums[0])
            {
                for (var i = 0; i < nums.Length; i++)
                    if (nums[i] == target) return i;
            }
            else
            {
                if (target <= nums[nums.Length - 1])
                {
                    for (var i = nums.Length - 1; i >= 0; i--)
                        if (nums[i] == target) return i;
                }
            }

            return -1;
        }


        /// <summary>
        /// 34. Find First and Last Position of Element in Sorted Array
        /// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange(int[] nums, int target)
        {
            //var result = new int[] { -1, -1 };
            //if (nums == null || nums.Length == 0) return result;


            //for (var i = 0; i < nums.Length; i++)
            //{
            //    if (nums[i] == target)
            //    {
            //        result[0] = i;
            //        break;
            //    }
            //}

            //if (result[0] == -1) return result;

            //for (var j = nums.Length - 1; j >= 0; j--)
            //{
            //    if (nums[j] == target)
            //    {
            //        result[1] = j;
            //        break;
            //    }
            //}

            //return result;


            var result = new int[] { -1, -1 };
            if (nums == null || nums.Length == 0) return result;


            var left = 0;
            var right = nums.Length - 1;

            while (left < right)
            {
                var middle = (left + right) / 2;

                if (nums[middle] > target || (nums[middle] == target)) right = middle;
                else left = middle + 1;
            }

            if (left <= right) { result[0] = left; result[1] = left; }
            else return result;


            for (var i = left; i < nums.Length - 1; i++)
            {
                if (nums[i] != nums[i + 1]) result[1] = i;
            }

            return result;

        }


        public string StrWithout3a3b(int A, int B)
        {
            if (A == 0 && B == 0) return "";

            if (A == 0) return new string('b', B);

            if (B == 0) return new string('a', A);

            var s = "";

            if (A >= B)
            {
                var diff = A - B;
                var count = B;
                while (count > 0)
                {
                    if (count >= 2) { s += "aabb"; count -= 2; continue; }

                    if (count == 1) { s += "ab"; count--; continue; }

                }

                s += new string('a', diff);
            }
            else
            {
                var diff = B - A;
                var count = A;

                while (count > 0)
                {
                    if (count >= 2) { s += "bbaa"; count -= 2; continue; }

                    if (count == 1) { s += "ba"; count--; continue; }
                }

                s += new string('b', diff);
            }


            return s;

        }


        /// <summary>
        /// 37. Sudoku Solver
        /// https://leetcode.com/problems/sudoku-solver/
        /// </summary>
        /// <param name="board"></param>
        public void SolveSudoku(char[][] board)
        {

            solve(board);
        }

        private bool solve(char[][] board)
        {
            for (var i = 0; i < 9; i++)
                for (var j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.')
                    {
                        for (var k = '1'; k <= '9'; k++)
                        {
                            if (isValid(board, i, j, k))
                            {
                                board[i][j] = k;

                                if (solve(board))
                                    return true;

                                board[i][j] = '.';
                            }
                        }
                        return false;
                    }
                }

            return true;
        }

        private bool isValid(char[][] board, int row, int column, char num)
        {
            for (var i = 0; i < board.Length; i++)
            {
                if (board[row][i] == num) return false;
                if (board[i][column] == num) return false;
            }

            for (var i = row / 3 * 3; i < row / 3 * 3 + 3; i++)
                for (var j = column / 3 * 3; j < column / 3 * 3 + 3; j++)
                    if (board[i][j] == num) return false;

            return true;
        }

        /// <summary>
        /// 41. First Missing Positive
        /// https://leetcode.com/problems/first-missing-positive/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FirstMissingPositive(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 1;

            for (var i = 0; i < nums.Length; i++)
            {
                while (nums[i] > 0 && nums[i] < nums.Length && nums[i] != nums[nums[i] - 1])
                    swap(nums, i, nums[i] - 1);
            }


            for (var i = 0; i < nums.Length; i++)
                if (nums[i] != i + 1)
                    return i + 1;

            return nums.Length + 1;
        }

        private void swap(int[] nums, int i, int j)
        {
            (nums[i], nums[j]) = (nums[j], nums[i]);
        }

        /// <summary>
        /// 42. Trapping Rain Water
        /// https://leetcode.com/problems/trapping-rain-water/
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            //var total = 0;
            //var temp = height.AsEnumerable();
            //while (true)
            //{

            //    temp = temp.SkipWhile(d => d == 0).Reverse().SkipWhile(d => d == 0);
            //    if (temp.Count(d => d == 0) == 0) break;
            //    total += temp.Count(d => d == 0);

            //    temp = temp.Select(d => d > 0 ? d-1 : 0);

            //}

            //return total;


            if (height == null || height.Length <= 1) return 0;


            var total = 0;
            while (true)
            {
                int count = 0;
                bool startFlag = false;
                for (var i = 0; i <= height.Length; i++)
                {

                    if (height[i] == 0) total++;
                    else
                    {
                        height[i]--;
                        count++;
                    }
                }
                if (count <= 1) break;
            }

            return total;
        }

        public int Trap1(int[] height)
        {
            if (height == null || height.Length <= 1) return 0;

            int total = 0;
            var stack = new Stack<int>();

            for (var i = 0; i < height.Length; i++)
            {
                while (stack.Count > 0 && height[i] > height[stack.Peek()])
                {
                    var top = stack.Pop();
                    if (stack.Count == 0)
                        break;

                    var distance = i - stack.Peek() - 1;
                    var temp = Math.Min(height[i], height[stack.Peek()]) - height[top];
                    total += distance * temp;
                }

                stack.Push(i);
            }

            return total;


        }

        public int Trap2(int[] height)
        {
            if (height == null || height.Length <= 1) return 0;

            var left = 0;
            var right = height.Length - 1;

            var left_max = 0;
            var right_max = 0;

            var total = 0;
            while (left < right)
            {
                if (height[left] < height[right])
                {
                    if (height[left] >= left_max)
                        left_max = height[left];
                    else
                        total += left_max - height[left];
                    left++;
                }
                else
                {
                    if (height[right] >= right_max)
                        right_max = height[right];
                    else
                        total += right_max - height[right];
                    right--;
                }
            }

            return total;
        }



        /// <summary>
        /// 43. Multiply Strings
        /// https://leetcode.com/problems/multiply-strings/
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0") return "0";

            var result = new int[num1.Length + num2.Length];

            for(var j=num1.Length-1;j>=0;j--)
                for (var i = num2.Length-1; i >= 0; i--)
                {
                    var mul = (num1[j] - '0') * (num2[i] - '0');

                    mul += result[i + j + 1] + result[i + j] * 10;

                    result[i + j + 1] = mul % 10;
                    result[i + j] = mul / 10;
                }


         
            var product = "";
            for (var i = result.Length - 1; i >= 0; i--)
            {


                product = result[i] + product;
            }
            return product.TrimStart('0');

            
        }











    }





















    static class ListNodeEx
    {
        public static bool HasNext(this ListNode node) => node.next != null;

    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}


