using Draft.Core.SharedKernel;

namespace Draft.Core.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(DomainEvent domainEvent);
    }
}