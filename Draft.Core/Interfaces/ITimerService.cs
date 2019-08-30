using Draft.Core.SharedKernel;

namespace Draft.Core.Interfaces
{
    public interface ITimerService
    {
        void StartTimer(int time, DomainEvent endEvent);
        void AddTeamManager(int id);
        void RemoveTeamManager(int id);
        void SetManagerReady(int id, bool ready);
    }
}