using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Yunly.Learning.LeetCode;
using System.Linq;

namespace Yunly.Learning.Test
{
    public class LeetCodeTests
    {

        Solution solution = new Solution();

        [Theory]
        [InlineData(new int[] { 0, 1 }, new int[] { 230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789 }, 542)]
        public void TwoSumTest(int[] expected, int[] input, int target)
        {
            //arrange

            //act
            var result = solution.TwoSum(input, target);

            //assert
            Assert.Equal<int[]>(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 1 }, new int[] { 9, 9 }, new int[] { 0, 0, 1 })]
        public void AddTwoNumbersTest(int[] input1, int[] input2, int[] expected)
        {
            //arrange
            var item1 = new ListNode(input1[0]);
            var item = item1;
            for (var i = 1; i < input1.Length; i++)
            {
                item.next = new ListNode(input1[i]);
                item = item.next;
            }

            var item2 = new ListNode(input2[0]);
            item = item2;
            for (var i = 1; i < input2.Length; i++)
            {
                item.next = new ListNode(input2[i]);
                item = item.next;
            }

            //act
            var result = solution.AddTwoNumbers(item1, item2);

            //assert
            var num = 0;
            while (result.next != null)
            {
                Assert.Equal(expected[num++], result.val);
                result = result.next;
            }
        }

        [Theory]
        [InlineData("asjrgapa", 6)]
        public void LengthOfLongestSubstringTest(string input, int expected)
        {
            //arrange

            //act
            var result = solution.LengthOfLongestSubstring(input);

            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 3 }, new int[] { 2 }, 2.0),]
        [InlineData(new int[] { 1, 2 }, new int[] { 3, 4 }, 2.5),]
        public void FindMedianSortedArrays(int[] input1, int[] input2, double expected)
        {
            //arrange

            //act
            var result = solution.FindMedianSortedArrays(input1, input2);

            //assert
            Assert.Equal(expected, result);

        }


        [Theory]
        [InlineData("ccc", new string[] { "ccc" })]

        public void LongestPalindromeTest(string input, string[] expected)
        {
            //arrange

            //act
            var result = solution.LongestPalindrome(input);

            //assert
            Assert.Contains<string>(result, expected);
        }

        [Theory]
        [InlineData(20, 3, 10)]
        [InlineData(23, 4, 11)]
        public void calculateSizeTest(int input1, int input2, int expected)
        {
            //arrange

            //act
            var result = solution.calculateSize(input1, input2);

            //assert;
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
        public void ConvertTest(string input1, int input2, string expected)
        {
            //arrange

            //act
            var result = solution.Convert(input1, input2);

            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new char[] { 'a', ' ', 'b', ' ', ' ', 'c' }, "abc")]
        public void array2StringWithoutBlankTest(char[] input, string expected)
        {
            //arrange
            char[] array = new char[10];

            array[1] = 'a';
            array[3] = 'b';
            array[5] = 'c';


            //act
            var result = solution.array2StringWithoutBlank(array);

            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(123, 321)]
        [InlineData(1534236469, 0)]
        public void ReverseTest(int input, int expected)
        {
            //arrange

            //act
            var result = solution.Reverse(input);

            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        //[InlineData("42",42)]
        //[InlineData("   -42", -42)]
        //[InlineData("4193 with words", 4193)]
        //[InlineData("words and 987",0)]
        [InlineData("      -11919730356x", -2147483648)]
        public void MyAtoiTest(string input, int expected)
        {
            //arrange

            //act
            var result = solution.MyAtoi(input);

            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(121, true)]
        [InlineData(12321, true)]
        [InlineData(1221, true)]
        public void IsPalindrome(int input, bool expected)
        {
            //arrange

            //act
            var result = solution.IsPalindrome(input);

            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("aa", "a*", true)]
        [InlineData("mississippi", "mis*is*p*.", false)]
        public void IsMatchTest(string input, string pattern, bool expected)
        {
            //arrange

            //act
            var result = solution.IsMatch(input, pattern);
            //assert
            Assert.Equal(expected, result);

        }

        [Theory]
        [InlineData(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
        public void MaxAreaTest(int[] input, int expected)
        {
            //arrange

            //act
            var result = solution.MaxArea(input);

            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, "III")]
        [InlineData(10, "X")]
        [InlineData(58, "LVIII")]
        [InlineData(1994, "MCMXCIV")]
        public void IntToRomanTest(int input, string expected)
        {
            //arrange

            //act
            var result = solution.IntToRoman(input);

            //assert
            Assert.Equal(expected, result);

        }

        [Theory]
        [InlineData("III", 3)]
        [InlineData("LVIII", 58)]
        public void RomanToIntTest(string input, int expected)
        {
            //arrange

            //act
            var result = solution.RomanToInt(input);

            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("flow", "flight", "fl")]
        [InlineData("aa", "a", "a")]
        public void LongestCommonPrefixTest1(string input1, string input2, string expected)
        {
            //arrange

            //act
            var result = solution.LongestCommonPrefix(input1, input2);

            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new string[] { "flower", "flow", "flight" }, "fl")]
        public void LongestCommonPrefixTest(string[] input, string expected)
        {
            //arrange

            //act
            var result = solution.LongestCommonPrefix(input);

            //assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ThreeSumTest()
        {
            //arrange
            var input = new int[] { 3, 0, -2, -1, 1, 2, 1 };
            //-2 -1 0 1 2 3
            var expected = new List<IList<int>>
            {

                new List<int> {-2,-1,3 },
                new List<int>{ -2,0,2 },
                new List<int>{ -2,1,1},
                new List<int>{ -1,0,1}

            };

            //act
            var result = solution.ThreeSum1(input);

            //assert
            Assert.Equal<IList<IList<int>>>(expected, result);
        }

        [Fact]
        public void ThreeSumClosestTest()
        {
            //arrange
            var input = new int[] { -1, 2, 1, -4 };
            var target = 1;
            var expected = 2;

            //act
            var result = solution.ThreeSumClosest(input, target);

            //assert
            Assert.Equal(expected, result);

        }

        [Fact]
        public void LetterCombinationsTest()
        {
            var input = "23";
            var expected = new List<string> { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" };


            var result = solution.LetterCombinations(input);

            Assert.Equal<IList<string>>(expected, result);

        }

        [Fact]
        public void FourSumTest()
        {
            //arrange
            var input = new int[] { 1, 0, -1, 0, -2, 2 };
            var target = 0;

            var expected = new List<IList<int>> {
                new List<int> { -1, 0, 0, 1 },
                new List<int> {-2, -1, 1, 2 },
                new List<int> {-2, 0, 0, 2 }
            };

            //act
            var result = solution.FourSum(input, target);

            //assert
            Assert.Equal<IList<IList<int>>>(expected, result);
        }

        [Fact]
        public void RemoveNthFromEndTest()
        {
            //arrange
            var head = new ListNode(1);
            var current = head;
            var i = 1;
            while (i++ < 5)
            {
                current.next = new ListNode(i);
                current = current.next;
            }
            int position = 2;
            int expected = 0;

            //act
            var result = solution.RemoveNthFromEnd(head, position);

            //assert

            while (result.next != null)
            {
                Assert.Equal(expected++, result.val);
                result = result.next;
            }

        }

        [Theory]
        [InlineData("()", true)]
        public void IsValid(string input, bool expected)
        {
            //arrange

            //act
            var result = solution.IsValid(input);

            //assert
            Assert.Equal(expected, result);

        }

        [Fact]
        public void MergeTwoListsTest()
        {
            ListNode l1 = new ListNode(2);

            ListNode l2 = new ListNode(1);

            var expected = new ListNode(2);
            l1.next = l2;

            var result = solution.MergeTwoLists(l1, l2);

            Assert.Equal<ListNode>(expected, result);
        }

        [Fact]
        public void GenerateParenthesisTest()
        {
            //arrange
            var input = 2;
            var expected = new List<string> { "()()", "(())" };
            //arrange
            var result = solution.GenerateParenthesis(input);

            //assert
            Assert.Equal<IList<string>>(expected, result);
        }


        [Fact]
        public void MergeKListsTest()
        {
            //arrange
            var node1 = new ListNode(1);
            node1.next = new ListNode(3);
            node1.next.next = new ListNode(5);

            var node2 = new ListNode(2);
            node2.next = new ListNode(4);
            node2.next.next = new ListNode(6);

            var node3 = new ListNode(7);
            node3.next = new ListNode(8);


            var input = new ListNode[] {
                node1,node2,node3
            };

            var expected = new ListNode(1);

            //act
            var result = solution.MergeKLists(input);

            //assert
            Assert.Equal<ListNode>(result, expected);

        }


        [Fact]
        public void SwapPairs()
        {
            //arrange            
            var node1 = new ListNode(1);
            node1.next = new ListNode(3);
            node1.next.next = new ListNode(5);
            node1.next.next.next = new ListNode(7);

            var expected = node1;

            //act
            var result = solution.SwapPairs(node1);

            //assert
            Assert.Equal<ListNode>(expected, result);
        }

        [Fact]
        public void ReverseKGroupTest()
        {
            //arrange
            var node1 = new ListNode(1);
            node1.next = new ListNode(2);
            node1.next.next = new ListNode(3);
            node1.next.next.next = new ListNode(4);
            node1.next.next.next.next = new ListNode(5);

            var expected = node1;
            var k = 3;

            //act
            var result = solution.ReverseKGroup(node1, k);

            //assert
            Assert.Equal<ListNode>(expected, result);
        }


        [Theory]
        [InlineData(new int[] { 1, 1, 2 }, 2, new int[] { 1, 2 })]
        public void RemoveDuplicatesTest(int[] input, int expected, int[] expected1)
        {
            //arrange

            //act
            var result = solution.RemoveDuplicates(input);

            //assert
            Assert.Equal(expected, result);
            Assert.Equal<int[]>(expected1, input.Take(expected1.Length).ToArray());
        }


        [Theory]
        [InlineData(new int[] { 3, 2, 2, 3 }, 3, 2, new int[] { 2, 2 })]
        [InlineData(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, 5, new int[] { 0, 1, 3, 0, 4 })]
        [InlineData(new int[] { 3, 3 }, 5, 2, new int[] { 3, 3 })]
        public void RemoveElementTest(int[] input, int val, int expected1, int[] expected2)
        {
            //arrange

            //act
            var result = solution.RemoveElement(input, val);

            //assert
            Assert.Equal(expected1, result);
            Assert.Equal<int[]>(expected2, input.Take(expected2.Length).ToArray());

        }

        [Theory]
        [InlineData(-2147483648, 2, -2147483648 / 2)]
        public void DivideTest(int dividend, int divisor, int expected)
        {
            //arrange

            //act
            var result = solution.Divide(dividend, divisor);

            //assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("askrnjtapxodiovimfcvfnouluznhhyjzjcmuvojudpdtknfprawfqrqksgszgbypemkbbvwgkbzxogmiglnwcfgunatuctjihvjktfqdgrcxzpffaudebmapmtjqouaxskilraqautztkebkaeqbqqqflbvbwwyqigbzjrbdkawugzgieykwocbzgxactzubhvcqogvbguxptexxchutmvssuvwpwqsflvwzbtajnyyhewgifadrywluthkpxcukzsmcmombomiuipforihrgtmzcwqcanmahactrqxhdfclwhborlhygvxirqkudzumbyispfaskefhnjxeugcacckvuvpzwllxktsbyuvjyasllrrhxuhbyuxsrmrnacmkyenwyihykzjwsddqxnrxhqrydindmzpkgchemqfwqqsktyaqnupwkgupqjudilpqpyvbpayhqsrksucfqubcaxurgqwrcnhtoevdgvmzpdlizpnpjrskomdxcbogqxaecxjisxhhburakfstykfmykjcnzjexjkzgwjatthunzxxgrredysbjcdwdmcaxnbfjlfegpbtoarwrkauisxrwaqapscoheusrzxxoyqeyjartcnexkvvknxbiaqpgkkxlhuchmghwjarnnvkxrijgflofdenpqkaxgcgtlppupgjccubvekdjxsrayepopsnvwvqjkffbopfslgppssyqkpskwkyncliagbksiptwgyqrgfgzahrmyjxutxhxlsartmmbdfakgsboakpargorsnmnlvlwnnpizbmcjoopgqdgctivbxmtkyhvwutlhjuimikvwzkcrqlvltqoqeidfrablumuficrqonopztiredexvtqadthuvihrwdwffqvvdmnefvwjbaiyvyaythsrpbimeftlvqjacwehtcsufbtabvzxdtouxwibdbpasycwujennwksxftbauyfpoammkqqofsgdvezgiothamefhhidfpsvrhicxaqcsyhpcivnwruzdaemioppejlvqtzntprnpydugahfrbewbkkjbzb",
            new string[] { "xactzubhvcqogvbguxptexxchutmv", "hborlhygvxirqkudzumbyispfaske", "uisxrwaqapscoheusrzxxoyqeyjar", "ppupgjccubvekdjxsrayepopsnvwv", "jarnnvkxrijgflofdenpqkaxgcgtl", "cbogqxaecxjisxhhburakfstykfmy", "agbksiptwgyqrgfgzahrmyjxutxhx", "fhnjxeugcacckvuvpzwllxktsbyuv", "rcnhtoevdgvmzpdlizpnpjrskomdx", "kjcnzjexjkzgwjatthunzxxgrredy", "tcnexkvvknxbiaqpgkkxlhuchmghw", "sbjcdwdmcaxnbfjlfegpbtoarwrka", "qjkffbopfslgppssyqkpskwkyncli", "pqpyvbpayhqsrksucfqubcaxurgqw", "yihykzjwsddqxnrxhqrydindmzpkg", "jyasllrrhxuhbyuxsrmrnacmkyenw", "chemqfwqqsktyaqnupwkgupqjudil", "vlwnnpizbmcjoopgqdgctivbxmtky", "rihrgtmzcwqcanmahactrqxhdfclw", "ssuvwpwqsflvwzbtajnyyhewgifad", "lsartmmbdfakgsboakpargorsnmnl", "rywluthkpxcukzsmcmombomiuipfo", "hvwutlhjuimikvwzkcrqlvltqoqei" },
            new int[] { 186 })]
        public void FindSubstringTest(string s, string[] words, int[] expected)
        {
            //act
            var result = solution.FindSubstring(s, words);

            //assert
            Assert.Equal<int[]>(expected, result.ToArray());
        }

        [Theory]
        [InlineData(new int[] { 1, 3, 2 }, new int[] { 2, 1, 3 })]
        public void NextPermutationTest(int[] input, int[] expected)
        {
            //arrange

            //act
            solution.NextPermutation(input);

            //assert
            Assert.Equal<int[]>(expected, input);
        }

        [Theory]
        //[InlineData("(()", 2)]
        [InlineData(")()())", 4)]
        //[InlineData("())()",2)]
        public void LongestValidParenthesesTest(string input, int expected)
        {
            //arrange

            //act
            var result = solution.LongestValidParentheses(input);

            //
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 5, 7, 7, 8, 8, 10 }, 8, new int[] { 3, 4 })]
        public void SearchRangeTest(int[] nums, int target, int[] expected)
        {
            //arrange

            //act
            var result = solution.SearchRange(nums, target);

            //assert
            Assert.Equal<int[]>(expected, result);

        }


    }
}


