using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

using Microsoft.Practices.Unity;

using WcfInterception.Server.Contracts;
using WcfInterception.Server.Services;

namespace WcfInterceptoion.Server.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            var service = Bootstrapper.GetConfiguredContainer().Resolve<ICalculatorService>();
            using (var host = new ServiceHost(service))
            {
                host.Open();
                System.Console.ReadLine();
                host.Close();
            }
        }
    }
}
