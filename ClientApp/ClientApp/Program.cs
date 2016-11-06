using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Input your exspression: ");
                string exspression;
                exspression = Console.ReadLine();
                exspression = exspression.Replace(" ", "");
                var client = new Calculator.CalculatorClient("NetTcpBinding_ICalculator");
                int result = client.CalculateExpression(exspression);
                client.Set(5);
                client.Add(6);
                client.Substract(1);
                client.Divide(2);
                client.Multiply(4);
                Console.WriteLine("Dll Result = " + client.Result());
                client.Close();
                //int res = CalculateExpression(exspression);
                Console.WriteLine("Result = " + result);
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        /*private static Expression CreateLambda(List<string> rpn)
        {
            List<Expression> expressionStack = new List<Expression>();
            foreach(string token in rpn)
            {
                int test;
                if(Int32.TryParse(token, out test))
                {
                    expressionStack.Add(Expression.Constant(test));
                }
                else
                {
                    switch(token)
                    {
                        case "+":
                            {
                                Expression right = expressionStack[expressionStack.Count - 1];
                                expressionStack.RemoveAt(expressionStack.Count - 1);
                                Expression left = expressionStack[expressionStack.Count - 1];
                                expressionStack.RemoveAt(expressionStack.Count - 1);
                                expressionStack.Add(Expression.Add(left, right));
                                break;
                            }
                        case "-":
                            {
                                Expression right = expressionStack[expressionStack.Count - 1];
                                expressionStack.RemoveAt(expressionStack.Count - 1);
                                Expression left = expressionStack[expressionStack.Count - 1];
                                expressionStack.RemoveAt(expressionStack.Count - 1);
                                expressionStack.Add(Expression.Subtract(left, right));
                                break;
                            }
                        case "*":
                            {
                                Expression right = expressionStack[expressionStack.Count - 1];
                                expressionStack.RemoveAt(expressionStack.Count - 1);
                                Expression left = expressionStack[expressionStack.Count - 1];
                                expressionStack.RemoveAt(expressionStack.Count - 1);
                                expressionStack.Add(Expression.Multiply(left, right));
                                break;
                            }
                        case "/":
                            {
                                Expression right = expressionStack[expressionStack.Count - 1];
                                expressionStack.RemoveAt(expressionStack.Count - 1);
                                Expression left = expressionStack[expressionStack.Count - 1];
                                expressionStack.RemoveAt(expressionStack.Count - 1);
                                expressionStack.Add(Expression.Divide(left, right));
                                break;
                            }
                    }
                }
            }
            return expressionStack[0];
        }

        public static int CalculateExpression(string expression)
        {
            string[] tokens = ParseExpression(expression);
            List<string> rpn = CreateRPN(tokens);
            Expression calculate = CreateLambda(rpn);
            Expression<Func<int>> method = Expression.Lambda<Func<int>>(calculate);
            Func<int> myMethod = method.Compile(); 
            int result = myMethod();
            Console.Write("RPN = ");
            for(int i = 0; i < rpn.Count; i++)
            {
                Console.Write(rpn[i] + "|");
            }
            Console.WriteLine();
            return result;
        }

        private static string[] ParseExpression(string expression)
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

        private static List<string> CreateRPN(string[] tokens)
        {
            List<string> result = new List<string>();
            List<string> stack = new List<string>();
            List<int> priority = new List<int>();
            for (int i = 0; i < tokens.Count(); i++)
            {
                int tempIntVar;
                if (Int32.TryParse(tokens[i], out tempIntVar))
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
        }*/
    }
}
