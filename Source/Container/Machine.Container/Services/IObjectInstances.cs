using Machine.Container.Model;

namespace Machine.Container.Services
{
  public interface IObjectInstances
  {
    void Remember(ResolvedServiceEntry entry, object instance);
    void Release(ICreationServices services, object instance);
  }
}