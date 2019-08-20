using Draft.Core.SharedKernel;

namespace Draft.Core.Interfaces
{
    public interface IHandle<T> where T : DomainEvent
    {
        void Handle(T domainEvent);
    }
}