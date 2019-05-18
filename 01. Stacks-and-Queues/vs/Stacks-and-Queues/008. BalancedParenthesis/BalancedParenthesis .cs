namespace _008._BalancedParenthesis
{
    using System;
    using System.Collections.Generic;

    class BalancedParenthesis
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            bool isSimetric = true;
            Stack<char> stackParenthes = new Stack<char>();
            if (inputLine.Length % 2 == 1)
            {
                isSimetric = false;
            }
            else
            {


                for (int index = 0; index < inputLine.Length; index++)
                {
                    char current = inputLine[index];
                    switch (current)
                    {//{[(
                        case '{':
                        case '[':
                        case '(':
                            stackParenthes.Push(current);
                            break;
                        case '}':
                        case ']':
                        case ')':
                            char lastParenthes = stackParenthes.Peek();
                            if ((current == '}' && lastParenthes == '{') ||
                                (current == ']' && lastParenthes == '[') ||
                                (current == ')' && lastParenthes == '('))
                            {
                                stackParenthes.Pop();
                            }
                            else
                            {
                                isSimetric = false;
                            }
                            break;
                        default:
                            break;
                    }
                    if (!isSimetric)
                    {
                        break;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            if (isSimetric)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
