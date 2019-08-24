using System.Linq;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Core.Specifications;

namespace Draft.Core.Services
{
    public class GamePhaseService : IHandle<FirstRegGamePhaseEvent>,
                                    IHandle<SecondRegGamePhaseEvent>,
                                    IHandle<GameWeekTimerEndedEvent>
    {
        private readonly IDomainEventDispatcher _dispatcher;
        private readonly IRepository _repository;

        public GamePhaseService(IDomainEventDispatcher dispatcher, IRepository repository)
        {
            _dispatcher = dispatcher;
            _repository = repository;
        }
        public void Handle(SecondRegGamePhaseEvent domainEvent)
        {
            StartGameWeek();
        }

        public void Handle(FirstRegGamePhaseEvent domainEvent)
        {
            StartGameWeek();
        }

        public void Handle(GameWeekTimerEndedEvent domainEvent)
        {
            StartGameWeek();
        }

        private void StartGameWeek()
        {
            var season = _repository.Get(new CurrentSeason());
            var firstGameNotCompleted = _repository.List<Game>()
                    .OrderBy(g => g.Date)
                    .FirstOrDefault(g => !g.IsCompleted);

            if (firstGameNotCompleted == null)
            {
                season.CompletePhase();
                _repository.Update(season);
                return;
            }

            season.SetDate(firstGameNotCompleted.Date);

            if (season.CurDate == season.NextPhase.Date)
            {
                season.CompletePhase();
                _repository.Update(season);
                return;
            }
            _repository.Update(season);

            _dispatcher.Dispatch(new GameWeekStartedEvent());
        }
    }
}