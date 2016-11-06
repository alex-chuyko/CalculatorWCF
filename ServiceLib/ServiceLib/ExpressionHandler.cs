using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLib
{
    class ExpressionHandler
    {
        private Dictionary<string, IExpressionFactory> dictionary = new Dictionary<string, IExpressionFactory>()
        {
            { "+", new AddExpressionFactory() },
            { "-", new SubtractExpressionFactory() },
            { "*", new MultiplyExpressionFactory() },
            { "/", new DivideExpressionFactory() },
        };

        public void Handle(List<Expression> stack, string token)
        {
            IExpressionFactory factory = dictionary[token];
            if (factory != null)
            {
                factory.Create(stack);
            }
        }

        interface IExpressionFactory
        {
            void Create(List<Expression> stack);
        }

        private class AddExpressionFactory: IExpressionFactory
        {
            public void Create(List<Expression> stack)
            {
                Expression right = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);
                Expression left = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);
                stack.Add(Expression.Add(left, right));
            }
        }

        private class MultiplyExpressionFactory : IExpressionFactory
        {
            public void Create(List<Expression> stack)
            {
                Expression right = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);
                Expression left = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);
                stack.Add(Expression.Multiply(left, right));
            }
        }

        private class SubtractExpressionFactory : IExpressionFactory
        {
            public void Create(List<Expression> stack)
            {
                Expression right = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);
                Expression left = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);
                stack.Add(Expression.Subtract(left, right));
            }
        }

        private class DivideExpressionFactory : IExpressionFactory
        {
            public void Create(List<Expression> stack)
            {
                Expression right = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);
                Expression left = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);
                stack.Add(Expression.Divide(left, right));
            }
        }
    }
}
