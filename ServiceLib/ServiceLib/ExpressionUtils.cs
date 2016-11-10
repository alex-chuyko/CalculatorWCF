using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLib
{
    class ExpressionUtils
    {
        public static string[] ParseExpression(string expression)
        {
            string[] result = new string[1];
            int j = -1;
            for (int i = 0; i < expression.Length; i++)
            {
                if (!Char.IsNumber(expression[i]))
                {
                    j++;
                    Array.Resize<string>(ref result, j + 1);
                    result[j] = expression[i].ToString();
                }
                else
                {
                    if (i == 0 || !Char.IsNumber(expression[i - 1]))
                    {
                        j++;
                        Array.Resize<string>(ref result, j + 1);
                        result[j] += expression[i];
                    }
                    else
                    {
                        result[j] += expression[i];
                    }
                }
            }
            return result;
        }

        public static List<string> CreateRPN(string[] tokens)
        {
            List<string> result = new List<string>();
            List<string> stack = new List<string>();
            List<int> priority = new List<int>();
            for (int i = 0; i < tokens.Count(); i++)
            {
                double tempIntVar;
                if (Double.TryParse(tokens[i], out tempIntVar))
                {
                    result.Add(tokens[i]);
                }
                else
                {
                    switch (tokens[i])
                    {
                        case "*":
                        case "/":
                            {
                                while ((priority.Count != 0) && (priority[priority.Count - 1] >= 2))
                                {
                                    result.Add(stack[stack.Count - 1]);
                                    stack.RemoveAt(stack.Count - 1);
                                    priority.RemoveAt(priority.Count - 1);
                                }
                                stack.Add(tokens[i]);
                                priority.Add(2);
                                break;
                            }
                        case "+":
                        case "-":
                            {
                                while ((priority.Count != 0) && (priority[priority.Count - 1] >= 1))
                                {
                                    result.Add(stack[stack.Count - 1]);
                                    stack.RemoveAt(stack.Count - 1);
                                    priority.RemoveAt(priority.Count - 1);
                                }
                                stack.Add(tokens[i]);
                                priority.Add(1);
                                break;
                            }
                        case "(":
                            {
                                stack.Add(tokens[i]);
                                priority.Add(0);
                                break;
                            }
                        case ")":
                            {
                                while (stack[stack.Count - 1] != "(")
                                {
                                    result.Add(stack[stack.Count - 1]);
                                    stack.RemoveAt(stack.Count - 1);
                                    priority.RemoveAt(priority.Count - 1);
                                }
                                stack.RemoveAt(stack.Count - 1);
                                priority.RemoveAt(priority.Count - 1);
                                break;
                            }
                    }
                }
            }
            while (stack.Count != 0)
            {
                result.Add(stack[stack.Count - 1]);
                stack.RemoveAt(stack.Count - 1);
                priority.RemoveAt(priority.Count - 1);
            }
            return result;
        }
    }
}
