using System;
using System.Collections;

using Machine.Container.Services;

using MassTransit.ServiceBus;

namespace Machine.MassTransitExtensions
{
  public class MachineObjectBuilder : IObjectBuilder
  {
    private readonly IMachineContainer _container;

    public MachineObjectBuilder(IMachineContainer container)
    {
      _container = container;
    }

    #region IObjectBuilder Members
    public T Build<T>(IDictionary arguments)
    {
      return _container.Resolve.Object<T>();
    }

    public T Build<T>(Type component) where T : class
    {
      return _container.Resolve.Object<T>();
    }

    public T Build<T>() where T : class
    {
      return _container.Resolve.Object<T>();
    }

    public object Build(Type objectType)
    {
      return _container.Resolve.Object(objectType);
    }

    public void Register<T>() where T : class
    {
      _container.Register.Type<T>().AsTransient();
    }

    public void Release<T>(T obj)
    {
      _container.Deactivate(obj);
    }
    #endregion
  }
}