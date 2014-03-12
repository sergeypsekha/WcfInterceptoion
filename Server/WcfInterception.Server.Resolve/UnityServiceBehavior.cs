using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

using Microsoft.Practices.Unity;

namespace WcfInterception.Server.Resolve
{
    public class UnityServiceBehavior : IServiceBehavior
    {
        private readonly IUnityContainer container;

        public UnityServiceBehavior(IUnityContainer container)
        {
            this.container = container;
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(
            ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase,
            Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var channelDispatcherBase in serviceHostBase.ChannelDispatchers)
            {
                var channelDispatcher = channelDispatcherBase as ChannelDispatcher;
                if (channelDispatcher == null) continue;

                foreach (var endpointDispatcher in channelDispatcher.Endpoints)
                {
                    var contractName = endpointDispatcher.ContractName;
                    if (contractName.Equals("IMetadataExchange", StringComparison.InvariantCultureIgnoreCase)) continue;

                    var serviceEndpoint =
                        serviceDescription.Endpoints.FirstOrDefault(
                            e => contractName.Equals(e.Contract.Name, StringComparison.InvariantCultureIgnoreCase));
                    if(serviceEndpoint == null) continue;
                    
                    endpointDispatcher.DispatchRuntime.InstanceProvider = new UnityInstanceProvider(this.container, serviceEndpoint.Contract.ContractType);
                }
            }
        }
    }
}
