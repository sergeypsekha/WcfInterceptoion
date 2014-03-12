using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

using WcfInterception.Server.Contracts;
using WcfInterception.Server.Services;

namespace WcfInterceptoion.Server.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(CalculatorService)))
            {
                host.Open();
                System.Console.ReadLine();
                host.Close();
            }
        }
    }
}
