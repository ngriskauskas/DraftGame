using System;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Core.Specifications;

namespace Draft.Core.Services
{
    public class PreDraftPhaseService : IHandle<PreDraftPhaseEvent>,
                                IHandle<DraftPhaseEvent>,
                                IHandle<TrainStartPhaseEvent>,
                                IHandle<FirstCutPhaseEvent>,
                                IHandle<SecondCutPhaseEvent>,
                                IHandle<FinalCutPhaseEvent>,
                                IHandle<DivChampPhaseEvent>,
                                IHandle<ChampPhaseEvent>,
                                IHandle<EndSeasonPhaseEvent>,
                                IHandle<RetirementPhaseEvent>

    {


        private readonly ITimerService _timerService;
        private readonly IRepository _repository;

        public PreDraftPhaseService(ITimerService timerService, IRepository repository)
        {
            _timerService = timerService;
            _repository = repository;
        }

        public void Handle(PreDraftPhaseEvent domainEvent)
        {
            _timerService.StartTimer(100, new PhaseTimerEndedEvent());
        }

        public void Handle(DraftPhaseEvent domainEvent)
        {
            _timerService.StartTimer(10, new PhaseTimerEndedEvent());
        }

        public void Handle(TrainStartPhaseEvent domainEvent)
        {
            _timerService.StartTimer(100, new PhaseTimerEndedEvent());
        }

        public void Handle(FirstCutPhaseEvent domainEvent)
        {
            _timerService.StartTimer(100, new PhaseTimerEndedEvent());
        }

        public void Handle(SecondCutPhaseEvent domainEvent)
        {
            _timerService.StartTimer(100, new PhaseTimerEndedEvent());
        }

        public void Handle(FinalCutPhaseEvent domainEvent)
        {
            _timerService.StartTimer(100, new PhaseTimerEndedEvent());
        }

        public void Handle(DivChampPhaseEvent domainEvent)
        {
            _timerService.StartTimer(100, new PhaseTimerEndedEvent());
        }

        public void Handle(ChampPhaseEvent domainEvent)
        {
            _timerService.StartTimer(100, new PhaseTimerEndedEvent());
        }

        public void Handle(EndSeasonPhaseEvent domainEvent)
        {
            _timerService.StartTimer(100, new PhaseTimerEndedEvent());
        }

        public void Handle(RetirementPhaseEvent domainEvent)
        {
            _timerService.StartTimer(100, new PhaseTimerEndedEvent());
        }
    }
}