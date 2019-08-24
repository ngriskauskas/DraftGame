using Draft.Core.SharedKernel;

namespace Draft.Core.Interfaces
{
    public interface ITimerService
    {
        void StartTimer(int time, DomainEvent endEvent);
        void EndTimer();
    }
}