using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(ServiceLib.Calculator)))
            {
                host.Open(); 
                Console.WriteLine("Host started...");
                Console.ReadLine();
            }
        }
    }
}
