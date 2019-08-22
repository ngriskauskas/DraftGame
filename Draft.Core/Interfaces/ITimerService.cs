namespace Draft.Core.Interfaces
{
    public interface ITimerService
    {
        void StartTimer(int time);
        void EndTimer();
    }
}