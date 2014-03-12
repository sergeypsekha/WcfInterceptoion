using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;

using Microsoft.Practices.Unity;

namespace WcfInterception.Server.Resolve
{
    public class UnityInstanceProvider : IInstanceProvider
    {
        private readonly IUnityContainer container;

        private readonly Type contractType;

        public UnityInstanceProvider(IUnityContainer container, Type contractType)
        {
            this.container = container;
            this.contractType = contractType;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return this.GetInstance(instanceContext, message: null);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return this.container.Resolve(this.contractType);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            this.container.Teardown(instance);
        }
    }
}
