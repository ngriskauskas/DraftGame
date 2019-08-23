using System;
using Draft.Core.Events;
using Draft.Core.Interfaces;

namespace Draft.Core.Services
{
    public class PreDraftService : IHandle<PreDraftPhaseEvent>,
                                IHandle<DraftPhaseEvent>,
                                IHandle<TrainStartPhaseEvent>,
                                IHandle<FirstCutPhaseEvent>,
                                IHandle<SecondCutPhaseEvent>,
                                IHandle<FinalCutPhaseEvent>,
                                IHandle<FirstRegGamePhaseEvent>,
                                IHandle<SecondRegGamePhaseEvent>,
                                IHandle<DivChampPhaseEvent>,
                                IHandle<ChampPhaseEvent>,
                                IHandle<EndSeasonPhaseEvent>,
                                IHandle<RetirementPhaseEvent>

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

        public void Handle(DraftPhaseEvent domainEvent)
        {
            _timerService.StartTimer(100);
        }

        public void Handle(TrainStartPhaseEvent domainEvent)
        {
            _timerService.StartTimer(100);
        }

        public void Handle(FirstCutPhaseEvent domainEvent)
        {
            _timerService.StartTimer(100);
        }

        public void Handle(SecondCutPhaseEvent domainEvent)
        {
            _timerService.StartTimer(100);
        }

        public void Handle(FinalCutPhaseEvent domainEvent)
        {
            _timerService.StartTimer(100);
        }

        public void Handle(FirstRegGamePhaseEvent domainEvent)
        {
            _timerService.StartTimer(100);
        }

        public void Handle(SecondRegGamePhaseEvent domainEvent)
        {
            _timerService.StartTimer(100);
        }

        public void Handle(DivChampPhaseEvent domainEvent)
        {
            _timerService.StartTimer(100);
        }

        public void Handle(ChampPhaseEvent domainEvent)
        {
            _timerService.StartTimer(100);
        }

        public void Handle(EndSeasonPhaseEvent domainEvent)
        {
            _timerService.StartTimer(100);
        }

        public void Handle(RetirementPhaseEvent domainEvent)
        {
            _timerService.StartTimer(100);
        }
    }
}