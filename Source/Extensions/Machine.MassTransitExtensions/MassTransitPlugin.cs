using System;
using System.Collections.Generic;

using Machine.Container.Plugins;
using Machine.Container.Services;

using MassTransit.ServiceBus.Internal;
using MassTransit.ServiceBus.Subscriptions;

namespace Machine.MassTransitExtensions
{
  public class MassTransitPlugin : IServiceContainerPlugin
  {
    #region IServiceContainerPlugin Members
    public virtual void Initialize(PluginServices services)
    {
    }

    public virtual void ReadyForServices(PluginServices services)
    {
      RegisterServices(services.Container);
    }
    #endregion

    #region IDisposable Members
    public void Dispose()
    {
    }
    #endregion

    public virtual void RegisterServices(IMachineContainer container)
    {
      container.Register.Type<MassTransitController>();
      container.Register.Type<MassTransitUriFactory>();
      container.Register.Type<FollowerRepository>();
      container.Register.Type<EndpointResolver>();
      container.Register.Type<LocalSubscriptionCache>();
      container.Register.Type<HostedServicesController>();
      container.Register.Type<MachineObjectBuilder>();
      container.Register.Type<ServiceBusFactory>();
      container.Register.Type<ServiceBusHubFactory>();
    }
  }
}