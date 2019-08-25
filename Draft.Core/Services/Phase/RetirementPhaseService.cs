using Draft.Core.Events;
using Draft.Core.Interfaces;

namespace Draft.Core.Services
{

    public class RetirementPhaseService : IHandle<RetirementPhaseEvent>
    {
        private readonly ITimerService _timerService;

        public RetirementPhaseService(ITimerService timerService)
        {
            _timerService = timerService;
        }
        public void Handle(RetirementPhaseEvent domainEvent)
        {

        }
    }
}