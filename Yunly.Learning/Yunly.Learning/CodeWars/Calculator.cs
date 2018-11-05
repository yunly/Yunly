using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using System.Linq;

namespace Yunly.Learning.CodeWars
{
    public class Calculator
    {
        /*
         For a given list [x1, x2, x3, ..., xn] compute the last (decimal) digit of x1 ^ (x2 ^ (x3 ^ (... ^ xn))).

E. g.,

int[] array = new int[] {3,4,2};
LastDigit(array) == 1
because 3 ^ (4 ^ 2) = 3 ^ 16 = 43046721.

Beware: powers grow incredibly fast. For example, 9 ^ (9 ^ 9) has more than 369 millions of digits. lastDigit has to deal with such numbers efficiently.

Corner cases: we assume that 0 ^ 0 = 1 and that lastDigit of an empty list equals to 1.
             */
        public static int LastDigit(int[] array)
        {
            if (array.Length == 0)
                return 1;

            if (array.Length == 1)
                return array[0];

            Stack<int> stack = new Stack<int>(array);



            double power = stack.Pop();

            while (stack.Count > 0)
            {
                power = Math.Pow(stack.Pop(), power % 4);
            }


            return (int)(power % 10);
        }

    }



    /*
     Given a string of characters and symbols, calculate the expected result. The string consists of numbers, and the operators:

/  division
+  addition
-  subtraction
\* multiplication
^  power of
As well as the brackets ()

Numbers can be integers or doubles.

Assume the string is of the correct format (no missing brackets, unmatched operators). 

The format of the string can also have optional whitespace between numbers and symbols, so the following are equivalent:
"3+4*2"
"3 +                             4*   2"
         */


    public class ExpressionCalculator
    {
        public static double calculate(string s)
        {
            return 0;
        }


        static Dictionary<string, int> operators = new Dictionary<string, int>();
        static ExpressionCalculator()
        {
            operators.Add("/", 10);
            operators.Add("*", 10);
            operators.Add("\\", 10);

            operators.Add("+", 5);
            operators.Add("-", 5);

            operators.Add("^", 15);

            //operators.Add("(", 20);
            //operators.Add(")", 20);
        }

        private double calValue(string op, double v2, double v1)
        {


            switch (op)
            {
                case "/":
                    return v1 / v2;
                case "*":
                    return v1 * v2;
                case "+":
                    return v1 + v2;
                case "-":
                    return v1 - v2;
                case "^":
                    return Math.Pow(v1, v2);
            }

            return -1;
        }

        private bool isOperator(string op)
        {
            return operators.ContainsKey(op);
        }

        private int getPriority(string op)
        {
            if (op == "(") return 0;

            return operators[op];
        }

        List<string> expression = new List<string>();

        public ExpressionCalculator(string inputString)
        {
            expression = convert(inputString);

        }



        public double calExpression()
        {
            Stack<double> numbers = new Stack<double>();

            foreach (var item in expression)
            {
                if (isOperator(item))
                {

                    var result = calValue(item, numbers.Pop(), numbers.Pop());
                    numbers.Push(result);
                }
                else
                    numbers.Push(double.Parse(item));
            }




            return numbers.Pop();
        }


        private List<string> convert(string inputString)
        {
            string result = Regex.Replace(inputString, @"(/|\*|\\|\+|-|\^|\(|\))", " $1 ");

            string[] splitedExpression = result.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Stack<string> operators = new Stack<string>();

            List<string> expressions = new List<string>();

            for (int i = 0; i < splitedExpression.Length; i++)
            {
                if (splitedExpression[i] == "(")
                {
                    operators.Push(splitedExpression[i]);
                    continue;
                }

                if (splitedExpression[i] == ")")
                {

                    while (operators.Count > 0 && operators.Peek() != "(")
                    {
                        expressions.Add(operators.Pop());
                    }

                    if (operators.Peek() == "(")
                        operators.Pop();
                    else
                        throw new FormatException("unpair ()");

                    continue;
                }


                if (isOperator(splitedExpression[i]))
                {            
                    if (operators.Count == 0)
                    {
                        operators.Push(splitedExpression[i]);
                        continue;
                    }

                    if (getPriority(splitedExpression[i]) <= getPriority(operators.Peek()))
                    {
                        while (operators.Count > 0 && getPriority(operators.Peek()) >= getPriority(splitedExpression[i]))
                            expressions.Add(operators.Pop());                        
                    }

                    operators.Push(splitedExpression[i]);

                }
                else
                    expressions.Add(splitedExpression[i]);
            }

            while (operators.Count > 0)
                expressions.Add(operators.Pop());
            return expressions;

        }
    }
}



