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
            var client = new Calculator.CalculatorClient("NetTcpBinding_ICalculator");
            string exspression = "";
            string result = "";
            double res = 0;
            while (true)
            {
                client = new Calculator.CalculatorClient("NetTcpBinding_ICalculator");
                try
                {
                    Console.Write("Input your exspression(Exit input \"exit\"): ");
                    exspression = Console.ReadLine();

                    if (exspression == "exit")
                        break;

                    exspression = exspression.Replace(" ", "");
                    result = client.CalculateExpression(exspression);
                    if (Double.TryParse(result, out res))
                        Console.WriteLine("Result = " + res);
                    else
                        Console.WriteLine("Error: " + result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Введены некорректные данные");
                }
            }
            client.Close();
        }
    }
}
