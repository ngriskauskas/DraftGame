using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Core.Specifications;

namespace Draft.Core.Handlers
{
    public class GameWeekHandler : IHandle<GameWeekStartedEvent>
    {
        private readonly IRepository _repository;
        private readonly ITimerService _timer;
        public GameWeekHandler(IRepository repository, ITimerService timer)
        {
            _repository = repository;
            _timer = timer;
        }
        public void Handle(GameWeekStartedEvent domainEvent)
        {
            _timer.StartTimer(30, new GameWeekTimerEndedEvent());
            var season = _repository.Get(new CurrentSeason());

            var games = _repository.List(new GamesOnDate(season.CurDate));

            foreach (Game game in games)
                game.Play();

            _repository.UpdateRange<Game>(games);



        }
    }
}