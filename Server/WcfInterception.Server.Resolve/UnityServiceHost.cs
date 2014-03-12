using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

using Microsoft.Practices.Unity;

namespace WcfInterception.Server.Resolve
{
    public class UnityServiceHost : ServiceHost
    {
        private readonly IUnityContainer unityContainer;

        public UnityServiceHost(IUnityContainer unityContainer, Type serviceType) : base(serviceType)
        {
            this.unityContainer = unityContainer;
        }

        protected override void OnOpening()
        {
            this.AddUnityServiceBehavior();
            base.OnOpening();
        }

        private void AddUnityServiceBehavior()
        {
            if (this.Description.Behaviors.Find<UnityServiceBehavior>() != null)
            {
                return;
            }

            this.Description.Behaviors.Add(new UnityServiceBehavior(this.unityContainer));
        }
    }
}
