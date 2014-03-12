using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WcfInterception.Server.Contracts
{
    [ServiceContract(Name = "CalculatorService", Namespace = "http://schemas.WcfInterception/2014/03/calculator")]
    public interface ICalculatorService
    {
        [OperationContract]
        int Add(int a, int b);
    }
}
