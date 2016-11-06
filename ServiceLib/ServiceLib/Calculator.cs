using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceLib
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Calculator" в коде и файле конфигурации.
    public class Calculator : ICalculator
    {
        [DllImport(@"C:\Users\Александр\Documents\Visual Studio 2015\Projects\SPP\Lab5\MathFuncDll\Debug\MathFuncDll.dll", CallingConvention = CallingConvention.StdCall)]
        static extern double Add(double a, double b);
        [DllImport(@"C:\Users\Александр\Documents\Visual Studio 2015\Projects\SPP\Lab5\MathFuncDll\Debug\MathFuncDll.dll", CallingConvention = CallingConvention.StdCall)]
        static extern double Substract(double a, double b);
        [DllImport(@"C:\Users\Александр\Documents\Visual Studio 2015\Projects\SPP\Lab5\MathFuncDll\Debug\MathFuncDll.dll", CallingConvention = CallingConvention.StdCall)]
        static extern double Multiply(double a, double b);
        [DllImport(@"C:\Users\Александр\Documents\Visual Studio 2015\Projects\SPP\Lab5\MathFuncDll\Debug\MathFuncDll.dll", CallingConvention = CallingConvention.StdCall)]
        static extern double Divide(double a, double b);

        public int CalculateExpression(string expression)
        {
            string[] tokens = ExpressionUtils.ParseExpression(expression);
            List<string> rpn = ExpressionUtils.CreateRPN(tokens);
            Expression<Func<int>> lambda = Expression.Lambda<Func<int>>(GetExpressionTree(rpn));
            Func<int> myDelegate = lambda.Compile();
            return myDelegate();
        }

        public void Set(double a)
        {
            result = a;
        }

        public void Add(double a)
        {
            result = Add(result, a);
        }

        public void Substract(double a)
        {
            result = Substract(result, a);
        }

        public void Multiply(double a)
        {
            result = Multiply(result, a);
        }

        public void Divide(double a)
        {
            result = Divide(result, a);
        }

        public double Result()
        {
            return result;
        }

        private double result = 0;

        private Expression GetExpressionTree(List<string> rpn)
        {
            ExpressionHandler expressionHandler = new ExpressionHandler();
            List<Expression> expressionStack = new List<Expression>();
            foreach(string token in rpn)
            {
                int tempIntVar;
                if (Int32.TryParse(token, out tempIntVar))
                {
                    expressionStack.Add(Expression.Constant(tempIntVar));
                }
                else
                {
                    expressionHandler.Handle(expressionStack, token);
                }
            }
            return expressionStack[0];
        }
    }
}
