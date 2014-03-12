using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace WcfInterceptoion.Server.Console
{
    public static class Bootstrapper
    {
       public static IUnityContainer GetConfiguredContainer()
       {
           var container = new UnityContainer();

           container.LoadConfiguration();

           return container;
       }
    }
}
