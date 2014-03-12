using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WcfInterception.Server.Contracts;

namespace WcfInterception.Server.Services
{
    public class CalculatorService : ICalculatorService
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
