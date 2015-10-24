using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestQuery
{
    class Program2
    {
        const char LeftParenthesis = '(';
        const char RightParenthesis = ')';

        public static void Main()
        {
            string s;
            TestMethod();
            string input = ":-)";
            bool test = Balanced(input);
        }

        public static void TestMethod()
        {

        }

        static bool isBalancedWithStack(string str)
        {
      
            if (str.Length <= 1 || str.Equals(null))
                return false;

            var items = new Stack<int>(str.Length);
            int errorAt = -1;
            for (int i = 0; i < str.Length; i++)
            {

                if (str[i].Equals(LeftParenthesis))
                    items.Push(i);
                else if (str[i].Equals(RightParenthesis))
                {
                    if (items.Count == 0)
                    {
                        errorAt = i + 1;
                        return false;
                    }
                    items.Pop();
                }
            }
            if (items.Count > 0)
            {
                errorAt = items.Peek() + 1;
                return false;
            }
            return true;
        }

        public static bool Balanced(string input)
        {
            const char LeftParentheses = '(';
            const char RightParentheses = ')';

            if (input.Length <= 1 || input.Equals(null))
            {
                return false;
            }
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Equals(LeftParentheses))
                {
                    count++;
                }
                else if (input[i].Equals(RightParentheses))
                {
                    count--;
                    if (count < 0)
                    {
                        return false;
                    }
                }
            }
            return (count == 0);

        }
    }
}
