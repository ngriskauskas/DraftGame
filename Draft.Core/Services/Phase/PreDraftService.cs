using System;
using Draft.Core.Events;
using Draft.Core.Interfaces;

namespace Draft.Core.Services
{
    public class PreDraftService : IHandle<PreDraftPhaseEvent>
    {
        private readonly ITimerService _timerService;

        public PreDraftService(ITimerService timerService)
        {
            _timerService = timerService;
        }

        public void Handle(PreDraftPhaseEvent domainEvent)
        {
            _timerService.StartTimer(100);
        }
    }
}