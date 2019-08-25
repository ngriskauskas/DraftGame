using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class TimerChangedEvent : DomainEvent
    {
        public int Time { get; private set; }

        public TimerChangedEvent(int time)
        {
            Time = time;
        }
    }
}