using System;
using Autofac;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Core.Services;

namespace Draft.Core.Handlers
{
    public class PhaseDispatcher : IHandle<PhaseStartedEvent>
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public PhaseDispatcher(IDomainEventDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        public void Handle(PhaseStartedEvent domainEvent)
        {
            Dispatch(domainEvent.Phase);
        }
        private void Dispatch(Phase phase)
        {
            switch (phase.PhaseType)
            {
                case PhaseType.PreDraft:
                    _dispatcher.Dispatch(new PreDraftPhaseEvent(phase));
                    break;
                case PhaseType.Draft:
                    _dispatcher.Dispatch(new DraftPhaseEvent(phase));
                    break;
                case PhaseType.TrainStart:
                    _dispatcher.Dispatch(new TrainStartPhaseEvent(phase));
                    break;
                case PhaseType.FirstCut:
                    _dispatcher.Dispatch(new FirstCutPhaseEvent(phase));
                    break;
                case PhaseType.SecondCut:
                    _dispatcher.Dispatch(new SecondCutPhaseEvent(phase));
                    break;
                case PhaseType.FinalCut:
                    _dispatcher.Dispatch(new FinalCutPhaseEvent(phase));
                    break;
                case PhaseType.FirstRegGame:
                    _dispatcher.Dispatch(new FirstRegGamePhaseEvent(phase));
                    break;
                case PhaseType.SecondRegGame:
                    _dispatcher.Dispatch(new SecondRegGamePhaseEvent(phase));
                    break;
                case PhaseType.DivChamp:
                    _dispatcher.Dispatch(new DivChampPhaseEvent(phase));
                    break;
                case PhaseType.Champ:
                    _dispatcher.Dispatch(new ChampPhaseEvent(phase));
                    break;
                case PhaseType.EndSeason:
                    _dispatcher.Dispatch(new EndSeasonPhaseEvent(phase));
                    break;
                case PhaseType.Retirement:
                    _dispatcher.Dispatch(new RetirementPhaseEvent(phase));
                    break;
                default:
                    break;
            }

        }


    }
}