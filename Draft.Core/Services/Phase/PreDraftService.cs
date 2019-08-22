using System;
using Draft.Core.Interfaces;

namespace Draft.Core.Services
{
    public class PreDraftService : IPhaseService
    {
        private readonly ITimerService _timer;

        public PreDraftService(ITimerService timer)
        {
            _timer = timer;
        }
        public void Handle()
        {
            _timer.StartTimer(100);
        }
        public void EndTimer()
        {
            _timer.EndTimer();
        }
    }
}